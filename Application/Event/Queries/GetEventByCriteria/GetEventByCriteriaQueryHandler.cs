using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Queries.GetEventByCriteria
{
    public class GetEventByCriteriaQueryHandler : IRequestHandler<GetEventByCriteriaQuery, IEnumerable<EventDto>>
    {
        IUnitOfWork _unitOfWork;

        public GetEventByCriteriaQueryHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetEventByCriteriaQuery query, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.EventRepository.GetByCriteriaAsync(query.Name, query.Date, query.Location, query.Category, cancellationToken);
            return res.Adapt<IEnumerable<EventDto>>();
        }
    }
}
