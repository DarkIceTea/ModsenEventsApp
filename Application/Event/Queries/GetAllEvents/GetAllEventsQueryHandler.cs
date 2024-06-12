using Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Application.Event.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Core.Entities.Event>>
    {
        IUnitOfWork _unitOfWork;
        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Core.Entities.Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetAllEventsAsync(cancellationToken);
        }
    }
}
