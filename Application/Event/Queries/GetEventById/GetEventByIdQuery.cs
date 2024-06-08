using MediatR;

namespace Application.Event.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<Core.Entities.Event>
    {
        public Guid Id { get; set; }
    }
}
