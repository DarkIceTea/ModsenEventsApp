using Application.Event.Commands.CreateEvent;
using Application.Event.Commands.UpdateEvent;
using Application.Event.Commands.DeleteEvent;
using Application.Event.Queries.GetAllEvents;
using Application.Event.Queries.GetEventByCriteria;
using Application.Event.Queries.GetEventById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Dto;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Filters;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize(Policy = "AuthUsers")]
    [ValidateModel]
    public class EventsController : Controller
    {
        private readonly ISender _sender;

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
        public async Task<ActionResult> CreateEvent([FromBody] EventRequestDto eventRequestDto, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(new CreateEventCommand() {EventRequest = eventRequestDto}, cancellationToken));
        }

        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult> UpdateEvent([FromRoute] Guid id, [FromBody] EventRequestDto eventRequestDto, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(new UpdateEventCommand() {Id = id, EventRequestDto = eventRequestDto}, cancellationToken));
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> DeleteEvent([FromRoute]Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(new DeleteEventCommand() { Id = id }, cancellationToken));
        }
    }
}
