using MediatR;
using Application.Interfaces;
using Core.Entities;
using Domain.Interfaces;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;

        CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Guid> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            var _event = new Core.Entities.Event
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Location = command.Location,
                Category = command.Category,
                MaxParticipants = command.MaxParticipants,
                ImagePath = command.ImagePath
            };

            await _eventRepository.CreateEventAsync(_event, cancellationToken);

            return _event.Id;
        }
    }
}
