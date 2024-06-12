using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Participant.Commands.CancelRegisterForEvent
{
    public class CancelRegisterForEventCommandHandler : IRequestHandler<CancelRegisterForEventCommand>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IAuthService _authService;

        public CancelRegisterForEventCommandHandler(IParticipantRepository participantRepository, IEventRepository eventRepository, IAuthService authService)
        {
            _participantRepository = participantRepository;
            _eventRepository = eventRepository;
            _authService = authService;
        }

        public async Task Handle(CancelRegisterForEventCommand request, CancellationToken cancellationToken)
        {
            var participantId = _authService.GetParticipantId();
            var _event = await _eventRepository.GetEventByIdAsync(request.EventId, cancellationToken);
            var participant = await _participantRepository.GetParticipantByIdAsync(participantId, cancellationToken);
            _event.Participants.Remove(participant);
            _eventRepository.UpdateEventAsync(_event.Id, _event, cancellationToken);
        }
    }
}
