using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IEventRepository EventRepository { get; }
        public IParticipantRepository ParticipantRepository { get; }
        public void Save();
    }
}
