﻿using MediatR;

namespace Application.Participant.Commands.CancelRegisterForEvent
{
    public class CancelRegisterForEventCommand : IRequest
    {
        public Guid ParticipantId { get; set; }
        public Guid EventId { get; set; }
    }
}
