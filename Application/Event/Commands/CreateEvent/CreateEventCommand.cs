using Application.Dto;
using MediatR;
namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<EventResponseDto>
    {
        public EventRequestDto EventRequest { get; set; }
    }
}
