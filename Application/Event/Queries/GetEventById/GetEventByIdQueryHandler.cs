using Application.Event.Queries.GetEventById;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Event.Queries.GetEventbyId
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Core.Entities.Event>
    {
        IUnitOfWork _unitOfWork;
        public GetEventByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Core.Entities.Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetEventByIdAsync(request.Id, cancellationToken);
        }
    }
}
