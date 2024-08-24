using Application.Participant.Commands.CancelRegisterForEvent;
using Application.Participant.Commands.RegisterForEvent;
using Application.Participant.Queries.GetParticipantById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/participants")]
    [Authorize(Policy = "AuthUsers")]
    public class ParticipantController : Controller
    {
        ISender _sender;

        public ParticipantController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetParticipantById([FromRoute] Guid id)
        {
            var participant = await _sender.Send(new GetParticipantByIdQuery { Id = id });
            return Ok(participant);
        }

        [HttpPost("register-for-event/{eventGuid:guid}/{participantGuid:guid}")]
        public async Task<ActionResult> RegisterForEvent([FromRoute] Guid eventGuid, [FromRoute] Guid participantGuid, CancellationToken cancellationToken)
        {
            await _sender.Send(new RegisterForEventCommand() { EventId = eventGuid, ParticipantId = participantGuid}, cancellationToken);
            return Ok();
        }

        [HttpPost("cancel-register-for-event/{eventGuid:guid}/{participantGuid:guid}")]
        public async Task<ActionResult> CancelRegisterForEvent([FromRoute] Guid eventGuid, [FromRoute] Guid participantGuid, CancellationToken cancellationToken)
        {
            await _sender.Send(new CancelRegisterForEventCommand() { EventId = eventGuid, ParticipantId = participantGuid }, cancellationToken);
            return Ok();
        }
    }
}
