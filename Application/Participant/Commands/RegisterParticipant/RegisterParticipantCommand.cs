using MediatR;

namespace Application.Participant.Commands.RegisterParticipant
{
    public class RegisterParticipantCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
