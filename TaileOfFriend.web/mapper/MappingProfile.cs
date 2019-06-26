using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.web.ViewModel;



namespace TaileOfFriend.web.mapper
{
    public class MappingProfile : Profile

    {
         public MappingProfile()
        {
            CreateMap<ProfileDTO, ProfileViewModel>()
               .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
               .ForMember(dest => dest.Age, opts => opts.MapFrom(src => (DateTime.Today.Year - src.Birthday.Year)));

            CreateMap<EditProfileViewModel, ProfileDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Location, opts => opts.MapFrom(src => src.Location));


            CreateMap<TaileOfFriend.DAL.Enteties.Profile, ProfileDTO>()
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email));
                
        }

        
    }
}
