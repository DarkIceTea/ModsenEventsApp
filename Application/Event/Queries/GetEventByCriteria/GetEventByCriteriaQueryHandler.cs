using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Event.Queries.GetEventByCriteria
{
    public class GetEventByCriteriaQueryHandler : IRequestHandler<GetEventByCriteriaQuery, IEnumerable<Core.Entities.Event>>
    {
        IUnitOfWork _unitOfWork;

        public GetEventByCriteriaQueryHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Core.Entities.Event>> Handle(GetEventByCriteriaQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetEventByCriteriaAsync(query.Name, query.Date, query.Location, query.Category, cancellationToken);
        }
    }
}
