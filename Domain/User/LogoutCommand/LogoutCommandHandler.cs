using System;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;

namespace KibritAPI.Domain.User.LogoutCommand
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly MyDbContext _context;

        public LogoutCommandHandler(MyDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var token = await _context.RefreshTokens.FindAsync(request.RefreshToken);
            if (token == null)
            {
                
                throw new Exception("Bad request");
            }


            try
            {
                _context.RefreshTokens.Remove(token);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw new Exception("Bad request");
            }

            return Unit.Value;
        }
    }
}