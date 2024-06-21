using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Application.Event.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventDto>>
    {
        IUnitOfWork _unitOfWork;
        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.EventRepository.GetAllEventsAsync(cancellationToken);
            return res.Adapt<IEnumerable<EventDto>>();
        }
    }
}
