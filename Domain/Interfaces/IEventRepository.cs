using Core.Entities;
namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        public Task<Guid> CreateEventAsync(Event _event, CancellationToken cancellationToken);
        public Task<Guid> UpdateEventAsync(Guid id, Event _event, CancellationToken cancellationToken);
        public Task<Guid> DeleteEventAsync(Guid id, CancellationToken cancellationToken);
        public Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken cancellationToken);
        public Task<IEnumerable<Event>> GetEventByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken);
    }
}
