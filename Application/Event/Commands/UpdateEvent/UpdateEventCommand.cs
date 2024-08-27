using Application.Dto;
using MediatR;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest <EventResponseDto>
    {
        public Guid Id { get; set; }

        public EventRequestDto EventRequestDto { get; set; }
    }
}
