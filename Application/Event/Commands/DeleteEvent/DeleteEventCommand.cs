using Application.Dto;
using Core.Entities;
using MediatR;
namespace Application.Event.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<EventDto>
    {
        public Guid Id { get; set; }
    }
}
