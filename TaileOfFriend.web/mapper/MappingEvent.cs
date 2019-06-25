using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.web.ViewModel;

namespace TaileOfFriend.web.mapper
{
    public class MappingEvent : AutoMapper.Profile
    {
        public MappingEvent()
        {
            CreateMap<Event, EventViewModel>()
             .ForMember(dest => dest.EventName, opts => opts.MapFrom(src => src.EventName))
             .ForMember(dest => dest.EventDates, opts => opts.MapFrom(src => src.EventDates))
             .ForMember(dest => dest.OwnerId, opts => opts.MapFrom(src => src.OwnerId))
             .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));

            CreateMap<EventViewModel, Event>()
                .ForMember(dest => dest.EventName, opts => opts.MapFrom(src => src.EventName))
             .ForMember(dest => dest.EventDates, opts => opts.MapFrom(src => src.EventDates))
             .ForMember(dest => dest.OwnerId, opts => opts.MapFrom(src => src.OwnerId))
             .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));
        }
    }
}
