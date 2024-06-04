
using Application.Event.Commands.CreateEvent;
using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            //connection = "Server=(localdb)\\v11.0;Database=EventApp;Trusted_Connection=True;MultipleActiveResultSets=true";
            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EventAppDbContext>(options => options.UseSqlite("Data Source=EventApp.db"));
            //SQLitePCL.raw.SetProvider(new SQLitePCL.);


            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                                /*.RegisterServicesFromAssemblyContaining<CreateEventCommandHandler>()*/);
            //builder.Services.AddDbContext<EventAppDbContext>(options => options.UseSqlServer(connection));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
