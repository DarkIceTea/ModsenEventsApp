using Core.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityTypeConfigurations;

namespace Infrastructure.Data
{
    public class EventAppDbContext : DbContext
    {
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public EventAppDbContext(DbContextOptions<EventAppDbContext> options)
            : base(options) 
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new ParticipantConfiguration());
            
            SeedData.Seed(builder);

            base.OnModelCreating(builder);
        }
    }
}
