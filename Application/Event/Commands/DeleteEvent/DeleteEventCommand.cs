using Application.Dto;
using Core.Entities;
using MediatR;
namespace Application.Event.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<EventResponseDto>
    {
        public Guid Id { get; set; }
    }
}
