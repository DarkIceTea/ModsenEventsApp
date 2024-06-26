﻿using Core.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityTypeConfigurations;

namespace Infrastructure.Data
{
    public class EventAppDbContext : DbContext, IEventAppDbContext
    {
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public EventAppDbContext(DbContextOptions<EventAppDbContext> options)
            : base(options) 
        {
            if (!Database.CanConnect())
            {
                Database.EnsureCreated();
                new EventAppDbSeed(this);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new ParticipantConfiguration());

            base.OnModelCreating(builder);
            
        }
    }
}
