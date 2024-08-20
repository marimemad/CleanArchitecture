using AutoMapper;
using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Core.Shared;
using LibraryProject.Data.Entities;
using LibraryProject.Services.Services.UserService;
using MediatR;
using Microsoft.Extensions.Localization;

namespace LibraryProject.Core.Features.UserFeature.Commands.Handllers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
                                    , IRequestHandler<EditeUserCommand, Response<string>>
                                    , IRequestHandler<DeleteUserCommand, Response<string>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UserCommandHandler(IUserService userService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _userService = userService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User usermapping = _mapper.Map<User>(request);

            string result = await _userService.AddUserAsync(usermapping);
            if (result == "Exist") return UnprocessableEntity<string>("Email Is Exsist");
            else if (result == "Success") return Created<string>(_stringLocalizer[SharedResourcesKeys.Added]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditeUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.UserID);
            if (user == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var mappedUser = _mapper.Map(request, user);

            string result = await _userService.EditeUserAsync(mappedUser);
            if (result == "Success") return Success<string>(_stringLocalizer[SharedResourcesKeys.Edite]);
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.UserID);
            if (user == null) return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            string result = await _userService.EditeUserAsync(user);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }
    }
}
