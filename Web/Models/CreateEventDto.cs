using Application.Event.Commands.CreateEvent;
using Application.Mappings;
using AutoMapper;
using System.Diagnostics.Tracing;

namespace Web.Models
{
    public class CreateEventDto : IMapWith<CreateEventDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }
        public string Location {  get; set; }
        public int MaxParticipant {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventDto, DeleteEventCommand>()
                .ForMember(eventCommand => eventCommand.Name,
                    opt => opt.MapFrom(EventDto => EventDto.Name))
                .ForMember(eventCommand => eventCommand.Description,
                    opt => opt.MapFrom(EventDto => EventDto.Description))
                .ForMember(eventCommand => eventCommand.Date,
                    opt => opt.MapFrom(EventDto => EventDto.Date))
                .ForMember(eventCommand => eventCommand.Location,
                    opt => opt.MapFrom(EventDto => EventDto.Location))
                .ForMember(eventCommand => eventCommand.MaxParticipants,
                    opt => opt.MapFrom(EventDto => EventDto.MaxParticipant));
        }  
    }
}
