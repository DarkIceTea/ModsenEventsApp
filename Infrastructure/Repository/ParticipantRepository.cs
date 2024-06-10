using Core.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        EventAppDbContext _dbContext;
        public ParticipantRepository(EventAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddParicipantAsync(Participant paricipant, CancellationToken cancellationToken)
        {
            await _dbContext.Participants.AddAsync(paricipant, cancellationToken);
            _dbContext.SaveChanges();
            return paricipant.Id;
        }

        public async Task<Participant> GetParticipantByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Participants.FirstOrDefaultAsync(p => p.Email == email, cancellationToken);
        }

        public async Task<Participant> GetParticipantByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Participants.FindAsync(id, cancellationToken);
        }

        public async Task SetRefreshTokenAsync(Guid id, string refreshToken, CancellationToken cancellationToken)
        {
            var participant = await _dbContext.Participants.FindAsync(id, cancellationToken);
            participant.RefreshToken = refreshToken;
            _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
