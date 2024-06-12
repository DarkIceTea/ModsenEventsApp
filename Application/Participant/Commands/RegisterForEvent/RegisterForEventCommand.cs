using MediatR;

namespace Application.Participant.Commands.RegisterForEvent
{
    public class RegisterForEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}