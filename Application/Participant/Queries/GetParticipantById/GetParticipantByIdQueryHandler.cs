using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Participant.Queries.GetParticipantById
{
    public class GetParticipantByIdQueryHandler : IRequestHandler<GetParticipantByIdQuery, Core.Entities.Participant>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetParticipantByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Core.Entities.Participant> Handle(GetParticipantByIdQuery query,CancellationToken cancellationToken)
        {
            return await _unitOfWork.ParticipantRepository.GetParticipantByIdAsync(query.Id, cancellationToken);
        }
    }

}
