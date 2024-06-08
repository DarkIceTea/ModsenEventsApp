using Application.Event.Commands.CreateEvent;
using Application.Event.Commands.UpdateEvent;
using Application.Event.Commands.DeleteEvent;
using Application.Event.Queries.GetAllEvents;
using Application.Event.Queries.GetEventByCriteria;
using Application.Event.Queries.GetEventById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/events")]
    //[Authorize(Policy = "AuthUsers")]
    [Authorize(Policy = "AuthUsers")]
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

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult> GetEventByCriteria(CancellationToken cancellationToken, string name = null, DateTime? dateTime = null, string location = null, string category = null)
        {
            return Ok(await _sender.Send(new GetEventByCriteriaQuery()
            {
                Name = name,
                Date = dateTime,
                Location = location,
                Category = category
            }));
        }

        [HttpPost("create")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> CreateEvent([FromBody] CreateEventCommand command, CancellationToken cancellationToken)
        {
            _sender.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] UpdateEventCommand updateEventCommand, CancellationToken cancellationToken)
        {
            updateEventCommand.UpdatableId = id;
            return Ok(await _sender.Send(updateEventCommand, cancellationToken));
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> DeleteEvent([FromRoute]Guid id)
        {
            return Ok(_sender.Send(new DeleteEventCommand() { Id = id }));
        }
    }
}
