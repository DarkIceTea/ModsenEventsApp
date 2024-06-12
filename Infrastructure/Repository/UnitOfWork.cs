using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private DbContext _dbContext;
        private EventRepository _eventRepository;
        private ParticipantRepository _participantRepository;

        public UnitOfWork(EventAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _eventRepository = new EventRepository(dbContext);
            _participantRepository = new ParticipantRepository(dbContext);
        }

        public IEventRepository EventRepository { get { return _eventRepository; } }
        public IParticipantRepository ParticipantRepository { get { return _participantRepository; } }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
