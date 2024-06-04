using Core.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data
{
    public class EventAppDbContext : DbContext, IEventAppDbContext
    {
        
        public DbSet<Event> Events { get; set; }
        public EventAppDbContext(DbContextOptions<EventAppDbContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new ParticipantConfiguration());

            base.OnModelCreating(builder);
            
        }
    }
}
