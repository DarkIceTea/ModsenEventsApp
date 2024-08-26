using Core.Entities;
namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        public Task<Event> AddAsync(Event _event, CancellationToken cancellationToken);
        public Task<Event> UpdateAsync(Event existingEvent, Event _event, CancellationToken cancellationToken);
        public Task<Event> DeleteAsync(Event _event, CancellationToken cancellationToken);
        public Task<IEnumerable<Event>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Event> GetByIdAsync(Guid id, CancellationToken cancellationToken); 
        public Task<IEnumerable<Event>> GetByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken);
    }
}
