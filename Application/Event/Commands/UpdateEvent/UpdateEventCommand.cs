using Application.Dto;
using MediatR;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest <EventDto>
    {
        public Guid UpdatableId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public int MaxParticipants { get; set; }
        public byte[]? Image { get; set; }
    }
}
