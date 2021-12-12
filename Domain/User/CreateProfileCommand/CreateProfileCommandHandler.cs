using System;
using System.Threading;
using System.Threading.Tasks;
using KibritAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KibritAPI.Domain.User.CreateProfileCommand
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly MyDbContext _context;

        public CreateProfileCommandHandler(UserManager<IdentityUser> userManager, MyDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        
        public async Task<Unit> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.UserName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if(!result.Succeeded)
                throw new Exception("Invalid Registration!");

            _context.Users.Add(user);

            return Unit.Value;
        }
    }
}