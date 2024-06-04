using Domain.Interfaces;
using MediatR;

namespace Application.Event.Queries.GetEventByCriteria
{
    public class GetEventByCriteriaHandler : IRequestHandler<GetEventByCriteriaQuery, IEnumerable<Core.Entities.Event>>
    {
        IEventRepository _repository;

        public GetEventByCriteriaHandler(IEventRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Core.Entities.Event>> Handle(GetEventByCriteriaQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetEventByCriteriaAsync(query.Name, query.Date, query.Location, query.Category, cancellationToken);
        }
    }
}
