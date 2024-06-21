using MediatR;
using Application.Interfaces;
using Application.Dto;
using Mapster;


namespace Application.Event.Commands.DeleteEvent
{
    public class CreateEventCommandHandler : IRequestHandler<DeleteEventCommand, EventDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventDto> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            var res = await _unitOfWork.EventRepository.DeleteEventAsync(command.Id, cancellationToken);
            _unitOfWork.Save();
            return res.Adapt<EventDto>();
        }
    }
}
