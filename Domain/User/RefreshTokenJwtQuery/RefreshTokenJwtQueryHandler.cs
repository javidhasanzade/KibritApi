using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using KibritAPI.Services;
using MediatR;

namespace KibritAPI.Domain.User.RefreshTokenJwtQuery
{
    public class RefreshTokenJwtQueryHandler : IRequestHandler<RefreshTokenJwtQuery, UserTokens>
    {
        private readonly MyDbContext _context;
        private readonly ITokenGenerator _tokenGenerator;

        public RefreshTokenJwtQueryHandler(MyDbContext context, ITokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }


        public async Task<UserTokens> Handle(RefreshTokenJwtQuery request, CancellationToken cancellationToken)
        {
            var oldToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == request.RefreshToken);
            var user = _context.Users.FirstOrDefault(x => x.Id == oldToken.AppUserId);

            if (oldToken == null)
            {
                throw new Exception("Unauthorized");
            }

            else if(oldToken!=null && oldToken.ExpiresAt < DateTime.Now)
            {
                _context.RefreshTokens.Remove(oldToken);
                await _context.SaveChangesAsync(cancellationToken);

                throw new Exception("Unauthorized");
            }
            else
            {
                var newToken = new RefreshToken
                {
                    Token = _tokenGenerator.CreateRefreshToken(),
                    AppUserId = oldToken.AppUserId,
                    ExpiresAt = DateTime.Now + TimeSpan.FromDays(30)
                };

                await _context.RefreshTokens.AddAsync(newToken, cancellationToken);
                _context.RefreshTokens.Remove(oldToken);
                await _context.SaveChangesAsync(cancellationToken);

                var userTokens = new UserTokens 
                { 
                    AccessToken = _tokenGenerator.CreateJwtToken(user.Email, user.Id),
                    RefreshToken = newToken.Token,
                    UserId = user.Id,
                    UserName = user.UserName
                };

                return userTokens;
            }
        }
    }
}