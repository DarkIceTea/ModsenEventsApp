using MediatR;
using Application.Interfaces;


namespace Application.Event.Commands.DeleteEvent
{
    public class CreateEventCommandHandler : IRequestHandler<DeleteEventCommand, DeleteEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteEventCommand> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            _unitOfWork.EventRepository.DeleteEventAsync(command.Id, cancellationToken);
            _unitOfWork.Save();
            return command;
        }
    }
}
