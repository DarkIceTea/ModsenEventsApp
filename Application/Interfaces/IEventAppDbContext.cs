using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Application.Interfaces
{
    public interface IEventAppDbContext
    {
        DbSet<Core.Entities.Event> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
