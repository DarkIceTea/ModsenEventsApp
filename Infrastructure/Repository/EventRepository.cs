using Core.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        readonly EventAppDbContext eventAppDbContext;
        public EventRepository(EventAppDbContext context) : base(context)
        {
            eventAppDbContext = context;
        }

        async Task<Event> IEventRepository.AddAsync(Event _event, CancellationToken cancellationToken)
        {
            return await base.AddAsync(_event, cancellationToken);
        }

        async Task<Event> IEventRepository.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        async Task<IEnumerable<Event>> IEventRepository.GetAllAsync(CancellationToken cancellationToken)
        {
            return await eventAppDbContext.Events.Include(e => e.Participants).ToListAsync(cancellationToken);
        }

        async Task<IEnumerable<Event>> IEventRepository.GetByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken)
        {
            IQueryable<Event> query = eventAppDbContext.Events.Include(e => e.Participants);

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

        async Task<Event> IEventRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        async Task<Event> IEventRepository.UpdateAsync(Guid id, Event _event, CancellationToken cancellationToken)
        {
            _event.Id = id;
            return await base.UpdateAsync(_event, cancellationToken);
        }   


        //public async Task<Event> CreateEventAsync(Event _event, CancellationToken cancellationToken)
        //{
        //    await _dbContext.Events.AddAsync(_event, cancellationToken);
        //    return _event;
        //}

        //public async Task<Event> DeleteEventAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var eventForRemove = await _context.Events.FindAsync(id, cancellationToken);
        //    _context.Events.Remove(eventForRemove);
        //    return eventForRemove;
        //}

        //public async Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken cancellationToken)
        //{
        //    return await _context.Events.Include(e => e.Participants).ToListAsync(cancellationToken);
        //}

        //public async Task<IEnumerable<Event>> GetEventByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken)
        //{

        //    IQueryable<Event> query = _context.Events.Include(e => e.Participants);

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(e => e.Name.Contains(name));
        //    }

        //    if (date.HasValue)
        //    {
        //        query = query.Where(e => e.Date.Date == date.Value.Date);
        //    }

        //    if (!string.IsNullOrEmpty(location))
        //    {
        //        query = query.Where(e => e.Location.Contains(location));
        //    }

        //    if (!string.IsNullOrEmpty(category))
        //    {
        //        query = query.Where(e => e.Category.Contains(category));
        //    }
        //    return await query.ToListAsync(cancellationToken);
        //}

        //public async Task<Event> GetEventByIdAsync(Guid id, CancellationToken cancellationToken)
        //{
        //    var _event = await _context.Events.FindAsync(id, cancellationToken);
        //    _context.Entry(_event).Collection(e => e.Participants).Load();
        //    return _event;
        //}

        //public async Task<Event> UpdateEventAsync(Guid id, Event _event, CancellationToken cancellationToken)
        //{
        //    var existingEvent = await _context.Events.FindAsync(id, cancellationToken);

        //    if (existingEvent == null)
        //    {
        //        throw new KeyNotFoundException($"Event with ID {id} not found.");
        //    }

        //    existingEvent.Name = _event.Name;
        //    existingEvent.Date = _event.Date;
        //    existingEvent.Location = _event.Location;
        //    existingEvent.Category = _event.Category;

        //    return existingEvent;
        //}
    }
}
