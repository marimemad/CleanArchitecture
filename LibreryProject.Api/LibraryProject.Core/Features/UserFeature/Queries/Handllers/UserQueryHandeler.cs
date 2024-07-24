using AutoMapper;
using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.UserFeature.Queries.Requests;
using LibraryProject.Core.Features.UserFeature.Queries.Responses;
using LibraryProject.Data.Entities;
using LibraryProject.Services.Services.UserService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Core.Features.UserFeature.Queries.Handllers
{
    public class UserQueryHandeler :ResponseHandler ,IRequestHandler<GetUsersQuery,Response<List<GetUsersResponse>>>
                                                    ,IRequestHandler<GetUserByIdQuery,Response<GetUserResponse>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserQueryHandeler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetUsersResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var Users = await _userService.GetUsersAsync();
            var UsersMappimg = _mapper.Map<List<GetUsersResponse>>(Users);
            return Success(UsersMappimg);
        }

        public async Task<Response<GetUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.Id);
            if (user == null) return NotFound<GetUserResponse>("object not found");
            
            var UsersMappimg = _mapper.Map<GetUserResponse>(user);
            return Success(UsersMappimg);
        }
    }
}
