using Core.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        EventAppDbContext _dbContext;
        public ParticipantRepository(EventAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Participant> AddAsync(Participant paricipant, CancellationToken cancellationToken)
        { 
            return await base.AddAsync(paricipant, cancellationToken);
        }

        public async Task<Participant> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Participants.FirstOrDefaultAsync(p => p.Email == email, cancellationToken);
        }

        public async Task<Participant> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        public async Task SetRefreshTokenAsync(Guid id, string refreshToken, CancellationToken cancellationToken)
        {
            var participant = await _dbContext.Participants.FindAsync(id, cancellationToken);
            participant.RefreshToken = refreshToken;
        }
    }
}
