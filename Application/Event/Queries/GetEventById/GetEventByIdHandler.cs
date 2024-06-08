using Application.Event.Queries.GetEventById;
using Domain.Interfaces;
using MediatR;

namespace Application.Event.Queries.GetEventbyId
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Core.Entities.Event>
    {
        IEventRepository _eventRepository;
        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Core.Entities.Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await _eventRepository.GetEventByIdAsync(request.Id, cancellationToken);
        }
    }
}
