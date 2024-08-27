using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventAppMigrationSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "Date", "Description", "Image", "Location", "MaxParticipants", "Name" },
                values: new object[] { new Guid("e7547c50-3500-4a98-9590-91bf6c1d87bb"), "Развлечения", new DateTime(2024, 8, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Музыка, концерт, движ! всё как мы любим", null, "Минск", 150, "Рок за бобров" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "RefreshToken", "RegistrationDate", "Role" },
                values: new object[] { new Guid("9d47cb24-6914-4d38-877e-d002bc6c91ad"), new DateOnly(2000, 1, 15), "admin@mail.com", "Ivan", "Ivanov", null, new DateTime(2024, 8, 26, 3, 5, 4, 130, DateTimeKind.Local).AddTicks(9286), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e7547c50-3500-4a98-9590-91bf6c1d87bb"));

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: new Guid("9d47cb24-6914-4d38-877e-d002bc6c91ad"));
        }
    }
}
