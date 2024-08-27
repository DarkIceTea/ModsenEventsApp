using Application.Dto;
using MediatR;

namespace Application.Participant.Queries.GetParticipantById
{
    public class GetParticipantByIdQuery : IRequest<ParticipantResponseDto>
    {
        public Guid Id { get; set; }
    }
}
