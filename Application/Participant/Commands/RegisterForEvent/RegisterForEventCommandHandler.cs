using Application.Exceptions;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Participant.Commands.RegisterForEvent
{
    public class RegisterForEventCommandHandler : IRequestHandler<RegisterForEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public RegisterForEventCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task Handle(RegisterForEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _unitOfWork.EventRepository.GetByIdAsync(request.EventId, cancellationToken);

            if (_event.Participants.Count >= _event.MaxParticipants)
                throw new BadHttpRequestException($"Maximum Participant already registered on Event {_event.Id}");

            var participant = await _unitOfWork.ParticipantRepository.GetByIdAsync(request.ParticipantId, cancellationToken);
            _event.Participants.Add(participant);
            _unitOfWork.Save();
        }

    }
}
