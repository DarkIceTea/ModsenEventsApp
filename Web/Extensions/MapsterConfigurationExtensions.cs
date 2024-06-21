using Application.Dto;
using Core.Entities;
using Mapster;
using System.Reflection;

namespace Web.Extensions
{
    public static class MapsterConfigurationExtensions
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Core.Entities.Event, Guid>
                .NewConfig()
                .Map(dest => dest, src => src.Id);

            TypeAdapterConfig<Core.Entities.Participant, Guid>
                .NewConfig()
                .Map(dest => dest, src => src.Id);

            TypeAdapterConfig<Event, EventDto>.NewConfig()
            .Map(dest => dest.Participants, src => src.Participants.Select(p => p.Id).ToList());

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
