using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Application.Event.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventResponseDto>>
    {
        IUnitOfWork _unitOfWork;
        public GetAllEventsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventResponseDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.EventRepository.GetAllAsync(cancellationToken);
            return res.Adapt<IEnumerable<EventResponseDto>>();
        }
    }
}
