using Application.Dto;
using MediatR;

namespace Application.Event.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<EventResponseDto>
    {
        public Guid Id { get; set; }
    }
}
