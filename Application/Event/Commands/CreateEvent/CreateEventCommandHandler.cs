using MediatR;
using Domain.Interfaces;
using Mapster;
using Application.Interfaces;
using Application.Dto;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventResponseDto> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            Core.Entities.Event _event = command.EventRequest.Adapt<Core.Entities.Event>();

            var res = await _unitOfWork.EventRepository.AddAsync(_event, cancellationToken);
            _unitOfWork.Save();
            return res.Adapt<EventResponseDto>();
        }
    }
}
