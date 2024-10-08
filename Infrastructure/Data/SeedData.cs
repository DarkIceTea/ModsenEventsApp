﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Core.Entities.Event() { Id = Guid.NewGuid(), Name = "Рок за бобров", Description = "Музыка, концерт, движ! всё как мы любим", Category = "Развлечения", Date = new DateTime(2024, 8, 20, 18, 0, 0), Location = "Минск", MaxParticipants = 150 }
            );

            modelBuilder.Entity<Participant>().HasData(
                new Core.Entities.Participant() { Id = Guid.NewGuid(), DateOfBirth = new DateOnly(2000, 1, 15), Email = "admin@mail.com", FirstName = "Ivan", LastName = "Ivanov", RegistrationDate = DateTime.Now, Role = "admin" }
            );
        }
    }
}
