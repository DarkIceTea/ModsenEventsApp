using Application.Interfaces;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateEventCommand> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();
            await _unitOfWork.EventRepository.UpdateEventAsync(command.UpdatableId, _event, cancellationToken);

            return command;
        }
    }
}
