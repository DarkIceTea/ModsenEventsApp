using MediatR;
using Application.Interfaces;
using Application.Dto;
using Mapster;


namespace Application.Event.Commands.DeleteEvent
{
    public class CreateEventCommandHandler : IRequestHandler<DeleteEventCommand, EventResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventResponseDto> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            var eventForDelete = await _unitOfWork.EventRepository.GetByIdAsync(command.Id, cancellationToken);
            var res = await _unitOfWork.EventRepository.DeleteAsync(eventForDelete, cancellationToken);
            _unitOfWork.Save();
            return res.Adapt<EventResponseDto>();
        }
    }
}
