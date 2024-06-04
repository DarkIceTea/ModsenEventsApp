using Application.Event.Commands.CreateEvent;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

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
        // GET: EventController
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateEvent([FromBody] CreateEventCommand command, CancellationToken cancellationToken)
        {
            //var command = _mapper.Map<CreateEventCommand>(createEventDto);
            _sender.Send(command);
            return Ok();
        }

    }
}
