using MediatR;
using Domain.Interfaces;


namespace Application.Event.Commands.DeleteEvent
{
    public class CreateEventCommandHandler : IRequestHandler<DeleteEventCommand, DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<DeleteEventCommand> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            _eventRepository.DeleteEventAsync(command.Id, cancellationToken);
            return command;
        }
    }
}
