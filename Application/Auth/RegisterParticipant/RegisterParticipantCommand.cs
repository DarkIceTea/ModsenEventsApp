using MediatR;

namespace Application.Auth.RegisterParticipant
{
    public class RegisterParticipantCommand : IRequest<Tokens>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
