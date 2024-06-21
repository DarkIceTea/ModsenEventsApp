using MediatR;
using Domain.Interfaces;
using Mapster;
using Application.Interfaces;
using Application.Dto;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventDto> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {

            Core.Entities.Event _event = command.Adapt<Core.Entities.Event>();

            var res = await _unitOfWork.EventRepository.CreateEventAsync(_event, cancellationToken);
            _unitOfWork.Save();
            return res.Adapt<EventDto>();
        }
    }
}
