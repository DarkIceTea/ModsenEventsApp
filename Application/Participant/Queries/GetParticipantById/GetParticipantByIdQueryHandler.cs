using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Participant.Queries.GetParticipantById
{
    public class GetParticipantByIdQueryHandler : IRequestHandler<GetParticipantByIdQuery, ParticipantDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetParticipantByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ParticipantDto> Handle(GetParticipantByIdQuery query,CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.ParticipantRepository.GetByIdAsync(query.Id, cancellationToken);
            return res.Adapt<ParticipantDto>();
        }
    }

}
