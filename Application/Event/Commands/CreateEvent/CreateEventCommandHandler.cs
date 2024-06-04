﻿using MediatR;
using Domain.Interfaces;
using Mapster;

namespace Application.Event.Commands.CreateEvent
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

            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();

            await _eventRepository.CreateEventAsync(_event, cancellationToken);
            return command;
        }
    }
}
