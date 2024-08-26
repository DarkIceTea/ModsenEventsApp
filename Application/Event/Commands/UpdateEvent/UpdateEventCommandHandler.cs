using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, EventResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EventResponseDto> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            Core.Entities.Event _event = command.EventRequestDto.Adapt<Core.Entities.Event>();
            _event.Id = command.Id;
            var existingEvent = await _unitOfWork.EventRepository.GetByIdAsync(_event.Id, cancellationToken);
            var res = await _unitOfWork.EventRepository.UpdateAsync(existingEvent, _event, cancellationToken);
            _unitOfWork.Save();
            return res.Adapt<EventResponseDto>();
        }
    }
}
