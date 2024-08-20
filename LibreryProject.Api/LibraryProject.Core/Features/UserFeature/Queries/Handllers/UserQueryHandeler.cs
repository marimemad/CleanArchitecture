using AutoMapper;
using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.UserFeature.Queries.Requests;
using LibraryProject.Core.Features.UserFeature.Queries.Responses;
using LibraryProject.Core.Shared;
using LibraryProject.Core.Wrappers;
using LibraryProject.Data.Entities;
using LibraryProject.Services.Services.UserService;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace LibraryProject.Core.Features.UserFeature.Queries.Handllers
{
    public class UserQueryHandeler : ResponseHandler, IRequestHandler<GetUsersQuery, Response<List<GetUsersResponse>>>
                                                    , IRequestHandler<GetUserByIdQuery, Response<GetUserResponse>>
                                                    , IRequestHandler<GetUsersPaginationQuery, PaginatedResult<GetUsersPaginationResponse>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UserQueryHandeler(IUserService userService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _userService = userService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
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
            if (user == null) return NotFound<GetUserResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var UsersMappimg = _mapper.Map<GetUserResponse>(user);
            return Success(UsersMappimg);
        }

        public Task<PaginatedResult<GetUsersPaginationResponse>> Handle(GetUsersPaginationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<User, GetUsersPaginationResponse>> expression = e => new GetUsersPaginationResponse(e.UserID, e.NameAr, e.NameEn, e.Email, e.Gender, e.Age);
            var queryable = _userService.GetUsersQueryable();
            if (request.Search != null)
            {
                queryable = _userService.FilterUsersQueryable(request.Search);
            }
            var pagenation = queryable.Select(expression).ToPaginatedListAsync(request.Pagenumber, request.PageSize);
            return pagenation;
        }
    }
}
