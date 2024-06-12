using Application.Exceptions;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Participant.Commands.RegisterForEvent
{
    public class RegisterForEventCommandHandler : IRequestHandler<RegisterForEventCommand>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IAuthService _authService;

        public RegisterForEventCommandHandler(IParticipantRepository participantRepository, IEventRepository eventRepository, IAuthService authService)
        {
            _participantRepository = participantRepository;
            _eventRepository = eventRepository;
            _authService = authService;
        }

        public async Task Handle(RegisterForEventCommand request, CancellationToken cancellationToken)
        {
            var participantId = _authService.GetParticipantId();
            var _event = await _eventRepository.GetEventByIdAsync(request.EventId, cancellationToken);

            if (_event.Participants.Count >= _event.MaxParticipants)
                throw new MaximumParticipantsException($"Maximum Participant already registered on Event {_event.Id}");

            var participant = await _participantRepository.GetParticipantByIdAsync(_authService.GetParticipantId(), cancellationToken);
            _event.Participants.Add(participant);
            _eventRepository.UpdateEventAsync(_event.Id, _event, cancellationToken);
        }

    }
}
