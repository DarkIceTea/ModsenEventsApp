
using Application.Auth.Login;
using Application.Auth.RefreshTokens;
using Application.Auth.RegisterParticipant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        ISender _sender;
        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterParticipantCommand registerParticipantCommand, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(registerParticipantCommand, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(loginCommand, cancellationToken));
        }

        //[Authorize(Policy = "AuthUsers")]
        [HttpPost("tokens-refresh")]
        public async Task<IActionResult> TokenRefresh([FromBody] RefreshTokensCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(command, cancellationToken));
        }
    }
}
