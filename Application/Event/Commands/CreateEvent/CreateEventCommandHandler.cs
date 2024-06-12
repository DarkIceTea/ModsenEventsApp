using MediatR;
using Domain.Interfaces;
using Mapster;
using Application.Interfaces;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateEventCommand> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {

            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();

            await _unitOfWork.EventRepository.CreateEventAsync(_event, cancellationToken);
            _unitOfWork.Save();
            return command;
        }
    }
}
