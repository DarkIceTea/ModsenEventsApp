
using Application.Auth.Login;
using Application.Auth.RefreshTokens;
using Application.Participant.Commands.RegisterParticipant;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom.Compiler;
using System.Security.Claims;

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
            await _sender.Send(registerParticipantCommand, cancellationToken);
            return Created();
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
