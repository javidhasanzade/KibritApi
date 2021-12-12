using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Domain.User.LogoutCommand
{
    public class LogoutCommand : IRequest
    {
        [FromRoute]
        public string RefreshToken { get; set; }
    }
}