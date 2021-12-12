using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using KibritAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KibritAPI.Domain.User.AuthorizationQuery
{
    public class AuthorizationQueryHandler : IRequestHandler<AuthorizationQuery, UserTokens>
    {
        private readonly MyDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthorizationQueryHandler(MyDbContext context, UserManager<IdentityUser> userManager,
            ITokenGenerator tokenGenerator)

        {
            _context = context;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserTokens> Handle(AuthorizationQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Login);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                throw new Exception("Wrong Password!");

            var token = _tokenGenerator.CreateJwtToken(user.UserName, user.Id);
            
            var refreshToken = new RefreshToken
            {
                Token = _tokenGenerator.CreateRefreshToken(),
                AppUser = user,
                ExpiresAt = DateTime.Now + TimeSpan.FromDays(30),
                AppUserId = user.Id
            };

            var list = _context.RefreshTokens.Where(x => x.AppUserId == user.Id).ToList();
            _context.RefreshTokens.RemoveRange(list);

            await _context.RefreshTokens.AddAsync(refreshToken, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);


            var userTokens = new UserTokens
            {
                AccessToken = token,
                RefreshToken = refreshToken.Token,
                UserId = user.Id,
                UserName = request.Login
            };


            return userTokens;
        }
    }
}