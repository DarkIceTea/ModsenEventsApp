using Core.Entities;

namespace Domain.Interfaces
{
    public interface IParticipantRepository
    {
        public Task<Participant> AddAsync(Participant paricipant, CancellationToken cancellationToken);
        public Task<Participant> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<Participant> GetByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<Participant> UpdateAsync(Participant paricipant, CancellationToken cancellationToken);
        public Task<Participant> DeleteAsync(Participant participant, CancellationToken cancellationToken);
        public Task SetRefreshTokenAsync (Guid id, string refreshToken, CancellationToken cancellationToken);
    }
}
