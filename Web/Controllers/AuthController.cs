
using Application.Auth.Login;
using Application.Participant.Commands.RegisterParticipant;
using MediatR;
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
        public async Task<IActionResult> Register([FromBody]RegisterParticipantCommand registerParticipantCommand)
        {
            await _sender.Send(registerParticipantCommand);
            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand loginCommand)
        {
            return Ok(_sender.Send(loginCommand));
        }
    }
}
