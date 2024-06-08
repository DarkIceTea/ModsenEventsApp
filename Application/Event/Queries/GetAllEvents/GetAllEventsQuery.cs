using MediatR;

namespace Application.Event.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<IEnumerable<Core.Entities.Event>>
    {
    }
}
