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
            var ev = await base.AddAsync(_event, cancellationToken);
            await eventAppDbContext.Entry(ev)
                    .Collection(e => e.Participants)
                    .LoadAsync(cancellationToken);
            return ev;
        }

        async Task<Event> IEventRepository.DeleteAsync(Event _event, CancellationToken cancellationToken)
        {
            var ev = await base.DeleteAsync(_event, cancellationToken);
            await eventAppDbContext.Entry(ev)
                    .Collection(e => e.Participants)
                    .LoadAsync(cancellationToken);
            return ev;
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
            var ev = await base.GetByIdAsync(id, cancellationToken);
            if (ev != null)
            {
                await eventAppDbContext.Entry(ev)
                    .Collection(e => e.Participants)
                    .LoadAsync(cancellationToken);
            }
            return ev;
        }

        async Task<Event> IEventRepository.UpdateAsync(Event existingEvent, Event _event, CancellationToken cancellationToken)
        {
            var ev = await base.UpdateAsync(existingEvent, _event, cancellationToken);
            await eventAppDbContext.Entry(ev)
                    .Collection(e => e.Participants)
                    .LoadAsync(cancellationToken);
            return ev;
        }   
    }
}
