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

        async Task<Event> IEventRepository.DeleteAsync(Event _event, CancellationToken cancellationToken)
        {
            return await base.DeleteAsync(_event, cancellationToken);
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

        async Task<Event> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await eventAppDbContext.Events.Include(e => e.Participants).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        async Task<Event> UpdateAsync(Event _event, CancellationToken cancellationToken)
        {
            return await base.UpdateAsync(_event, cancellationToken);
        }   
    }
}
