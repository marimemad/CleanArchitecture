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
            CreateMap<User, GetUsersResponse>();
            CreateMap<User, GetUserResponse>();
            //commands
            CreateMap<AddUserCommand, User>();
            CreateMap<EditeUserCommand, User>();
        }
    }
}
