using KibritAPI.Models;
using MediatR;

namespace KibritAPI.Domain.User.RefreshTokenJwtQuery
{
    public class RefreshTokenJwtQuery : IRequest<UserTokens>
    {
        public string RefreshToken { get; set; }
    }
}