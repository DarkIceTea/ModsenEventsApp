using Application.Dto;
using MediatR;

namespace Application.Auth.RegisterParticipant
{
    public class RegisterParticipantCommand : IRequest<Tokens>
    {
        public ParticipantRequestDto ParticipantRequestDto { get; set; }
    }
}
