using System.Threading.Tasks;
using KibritAPI.Domain.User.AuthorizationQuery;
using KibritAPI.Domain.User.CreateProfileCommand;
using KibritAPI.Domain.User.LogoutCommand;
using KibritAPI.Domain.User.RefreshTokenJwtQuery;
using KibritAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KibritAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(CreateProfileCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthorizationQuery query)
        {
            UserTokens userToken = new UserTokens();
            userToken = await _mediator.Send(query);
            return Ok(userToken);
        }
        
        [HttpPost("Refresh")]
        public async Task<ActionResult<UserTokens>> Refresh(RefreshTokenJwtQuery query)
        {
            UserTokens tokens = new UserTokens();
            tokens = await _mediator.Send(query);
            return Ok(tokens);
        }
        
        [HttpGet("logout/{RefreshToken}")]
        public IActionResult Logout([FromRoute] LogoutCommand command)
        {
            _mediator.Send(command);
            return Ok();
        }
    }
}