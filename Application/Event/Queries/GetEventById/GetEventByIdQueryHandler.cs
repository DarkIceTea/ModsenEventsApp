using Application.Dto;
using Application.Event.Queries.GetEventById;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Queries.GetEventbyId
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventResponseDto>
    {
        IUnitOfWork _unitOfWork;
        public GetEventByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventResponseDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.EventRepository.GetByIdAsync(request.Id, cancellationToken);
            return res.Adapt<EventResponseDto>();
        }
    }
}
