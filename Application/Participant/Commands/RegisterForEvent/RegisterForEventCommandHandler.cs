﻿using Application.Exceptions;
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
            var participantId = _authService.GetParticipantId();
            var _event = await _unitOfWork.EventRepository.GetEventByIdAsync(request.EventId, cancellationToken);

            if (_event.Participants.Count >= _event.MaxParticipants)
                throw new MaximumParticipantsException($"Maximum Participant already registered on Event {_event.Id}");

            var participant = await _unitOfWork.ParticipantRepository.GetParticipantByIdAsync(_authService.GetParticipantId(), cancellationToken);
            _event.Participants.Add(participant);
            _unitOfWork.EventRepository.UpdateEventAsync(_event.Id, _event, cancellationToken);
            _unitOfWork.Save();
        }

    }
}
