using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KibritAPI.Domain.User.CreateProfileCommand
{
    public class CreateProfileCommand : IdentityUser, IRequest
    {
        public string Password { get; set; }
    }
}