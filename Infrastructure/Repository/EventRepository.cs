using Core.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        DbContext _context;

        EventRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateEventAsync(Event _event, CancellationToken cancellationToken)
        {
            _context.AddAsync(_event, cancellationToken);
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
