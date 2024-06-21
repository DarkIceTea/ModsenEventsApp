using Application.Dto;
using MediatR;

namespace Application.Event.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<EventDto>
    {
        public Guid Id { get; set; }
    }
}
