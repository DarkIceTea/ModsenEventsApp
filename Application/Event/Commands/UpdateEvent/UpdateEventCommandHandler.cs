using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<UpdateEventCommand> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();
            await _eventRepository.UpdateEventAsync(command.UpdatableId, _event, cancellationToken);

            return command;
        }
    }
}
