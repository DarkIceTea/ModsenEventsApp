using Application.Dto;
using Application.Event.Queries.GetEventById;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Queries.GetEventbyId
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto>
    {
        IUnitOfWork _unitOfWork;
        public GetEventByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.EventRepository.GetEventByIdAsync(request.Id, cancellationToken);
            return res.Adapt<EventDto>();
        }
    }
}
