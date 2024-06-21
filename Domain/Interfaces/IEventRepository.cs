using Core.Entities;
namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        public Task<Event> CreateEventAsync(Event _event, CancellationToken cancellationToken);
        public Task<Event> UpdateEventAsync(Guid id, Event _event, CancellationToken cancellationToken);
        public Task<Event> DeleteEventAsync(Guid id, CancellationToken cancellationToken);
        public Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken cancellationToken);
        public Task<Event> GetEventByIdAsync(Guid id, CancellationToken cancellationToken); 
        public Task<IEnumerable<Event>> GetEventByCriteriaAsync(string name, DateTime? date, string location, string category, CancellationToken cancellationToken);
    }
}
