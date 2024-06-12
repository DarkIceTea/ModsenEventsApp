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

        public async Task<Guid> DeleteEventAsync(Guid id, CancellationToken cancellationToken)
        {
            var eventForRemove = await _context.Events.FindAsync(id, cancellationToken);
            _context.Events.Remove(eventForRemove);
            _context.SaveChanges();
            return eventForRemove.Id;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            return await _context.Events.Include(e => e.Participants).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Event>> GetEventByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken)
        {
           
            IQueryable<Event> query = _context.Events.Include(e => e.Participants);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
  
            if (date.HasValue)
            {
                query = query.Where(e => e.Date.Date == date.Value.Date);
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(e => e.Location.Contains(location));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(e => e.Category.Contains(category));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Event> GetEventByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var _event = await _context.Events.FindAsync(id, cancellationToken);
            _context.Entry(_event).Collection(e => e.Participants).Load();
            return _event;
        }

        public async Task<Guid> UpdateEventAsync(Guid id, Event _event, CancellationToken cancellationToken)
        {
            var existingEvent = await _context.Events.FindAsync(id, cancellationToken);

            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"Event with ID {id} not found.");
            }

            existingEvent.Name = _event.Name;
            existingEvent.Date = _event.Date;
            existingEvent.Location = _event.Location;
            existingEvent.Category = _event.Category;

            await _context.SaveChangesAsync(cancellationToken);

            return existingEvent.Id;
        }
    }
}
