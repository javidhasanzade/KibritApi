using KibritAPI.Models;
using MediatR;

namespace KibritAPI.Domain.User.AuthorizationQuery
{
    public class AuthorizationQuery : IRequest<UserTokens>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}