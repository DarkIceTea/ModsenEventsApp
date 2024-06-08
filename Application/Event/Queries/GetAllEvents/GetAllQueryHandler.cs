using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Application.Event.Queries.GetAllEvents
{
    public class GetAllQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Core.Entities.Event>>
    {
        IEventRepository _eventRepository;
        public GetAllQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Core.Entities.Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetAllEventsAsync(cancellationToken);
        }
    }
}
