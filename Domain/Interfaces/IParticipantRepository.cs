﻿using Core.Entities;

namespace Domain.Interfaces
{
    public interface IParticipantRepository
    {
        public Task<Guid> AddParicipantAsync(Participant paricipant, CancellationToken cancellationToken);
        public Task<Participant> GetParticipantByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<Participant> GetParticipantByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
