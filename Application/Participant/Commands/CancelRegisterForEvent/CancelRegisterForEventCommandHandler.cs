﻿using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Participant.Commands.CancelRegisterForEvent
{
    public class CancelRegisterForEventCommandHandler : IRequestHandler<CancelRegisterForEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public CancelRegisterForEventCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task Handle(CancelRegisterForEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _unitOfWork.EventRepository.GetByIdAsync(request.EventId, cancellationToken);
            var participant = await _unitOfWork.ParticipantRepository.GetByIdAsync(request.ParticipantId, cancellationToken);
            _event.Participants.Remove(participant);
            _unitOfWork.Save();
        }
    }
}
