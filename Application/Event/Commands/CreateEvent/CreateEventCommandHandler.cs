using MediatR;
using Domain.Interfaces;
using Mapster;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<CreateEventCommand> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {

            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();

            await _eventRepository.CreateEventAsync(_event, cancellationToken);
            return command;
        }
    }
}
