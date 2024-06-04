using Core.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        EventAppDbContext _context;

        public EventRepository(EventAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateEventAsync(Event _event, CancellationToken cancellationToken)
        {
            await _context.Events.AddAsync(_event, cancellationToken);
            _context.SaveChanges();
            return _event.Id;
        }

        public Task<Guid> DeleteEventAsync(Event _event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetEventByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateEventAsync(Event _event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
