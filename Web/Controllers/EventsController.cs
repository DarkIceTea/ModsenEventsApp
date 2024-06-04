using Application.Event.Commands.CreateEvent;
using Application.Event.Queries.GetAllEvents;
using Application.Event.Queries.GetEventById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : Controller
    {
        ISender _sender;
        IMapper _mapper;

        public EventsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEvents(CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(new GetAllEventsQuery(), cancellationToken));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetEventsById([FromRoute] Guid id ,CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(new GetEventByIdQuery() { Id = id }, cancellationToken));
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateEvent([FromBody] DeleteEventCommand command, CancellationToken cancellationToken)
        {
            _sender.Send(command, cancellationToken);
            return Ok();
        }

        

    }
}
