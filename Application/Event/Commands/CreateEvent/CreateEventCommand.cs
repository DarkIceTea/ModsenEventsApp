using MediatR;
namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public int MaxParticipants { get; set; }
        public string ImagePath { get; set; }
    }
}
