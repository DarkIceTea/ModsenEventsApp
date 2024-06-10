using Domain.Interfaces;
using MediatR;

namespace Application.Participant.Queries.GetParticipantById
{
    public class GetParticipantByIdQueryHandler : IRequestHandler<GetParticipantByIdQuery, Core.Entities.Participant>
    {
        private readonly IParticipantRepository _participantRepository;
        public GetParticipantByIdQueryHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<Core.Entities.Participant> Handle(GetParticipantByIdQuery query,CancellationToken cancellationToken)
        {
            return await _participantRepository.GetParticipantByIdAsync(query.Id, cancellationToken);
        }
    }

}
