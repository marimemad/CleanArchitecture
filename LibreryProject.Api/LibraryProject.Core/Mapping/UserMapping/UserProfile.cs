using AutoMapper;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Core.Features.UserFeature.Queries.Responses;
using LibraryProject.Data.Entities;

namespace LibraryProject.Core.Mapping.UserMapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //queries
            CreateMap<User, GetUsersResponse>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocalizeName(src.NameAr, src.NameEn)));
            CreateMap<User, GetUserResponse>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocalizeName(src.NameAr, src.NameEn)));
            //commands
            CreateMap<AddUserCommand, User>();
            CreateMap<EditeUserCommand, User>();
        }
    }
}
