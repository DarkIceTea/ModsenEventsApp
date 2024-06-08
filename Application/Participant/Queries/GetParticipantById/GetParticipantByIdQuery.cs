using MediatR;

namespace Application.Participant.Queries.GetParticipantById
{
    public class GetParticipantByIdQuery : IRequest<Core.Entities.Participant>
    {
        public Guid Id { get; set; }
    }
}
