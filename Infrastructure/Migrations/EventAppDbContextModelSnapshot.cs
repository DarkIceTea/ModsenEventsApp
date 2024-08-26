﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EventAppDbContext))]
    partial class EventAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7547c50-3500-4a98-9590-91bf6c1d87bb"),
                            Category = "Развлечения",
                            Date = new DateTime(2024, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Музыка, концерт, движ! всё как мы любим",
                            Location = "Минск",
                            MaxParticipants = 150,
                            Name = "Рок за бобров"
                        });
                });

            modelBuilder.Entity("Core.Entities.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d47cb24-6914-4d38-877e-d002bc6c91ad"),
                            DateOfBirth = new DateOnly(2000, 1, 15),
                            Email = "admin@mail.com",
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            RegistrationDate = new DateTime(2024, 8, 26, 3, 5, 4, 130, DateTimeKind.Local).AddTicks(9286),
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("EventParticipant", b =>
                {
                    b.Property<Guid>("EventsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParticipantsId")
                        .HasColumnType("TEXT");

                    b.HasKey("EventsId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("EventParticipant");
                });

            modelBuilder.Entity("EventParticipant", b =>
                {
                    b.HasOne("Core.Entities.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
