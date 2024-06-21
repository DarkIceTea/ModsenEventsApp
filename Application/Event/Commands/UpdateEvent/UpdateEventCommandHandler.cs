using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, EventDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EventDto> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();
            var res = await _unitOfWork.EventRepository.UpdateEventAsync(command.UpdatableId, _event, cancellationToken);
            _unitOfWork.Save();
            return res.Adapt<EventDto>();
        }
    }
}
