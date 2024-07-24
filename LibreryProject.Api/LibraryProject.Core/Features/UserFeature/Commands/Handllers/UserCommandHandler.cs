﻿using AutoMapper;
using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Data.Entities;
using LibraryProject.Services.Services.UserService;
using MediatR;

namespace LibraryProject.Core.Features.UserFeature.Commands.Handllers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
                                    , IRequestHandler<EditeUserCommand, Response<string>>
                                    , IRequestHandler<DeleteUserCommand, Response<string>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User usermapping = _mapper.Map<User>(request);

            string result = await _userService.AddUserAsync(usermapping);
            if (result == "Exist") return UnprocessableEntity<string>("Email Is Exsist");
            else if (result == "Success") return Created<string>("Added Successfuly");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditeUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.UserID);
            if (user == null) return NotFound<string>("User Not Found");
            var mappedUser = _mapper.Map<User>(request);

            string result = await _userService.EditeUserAsync(mappedUser);
            if (result == "Success") return Success<string>("Edite Successfuly");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.UserID);
            if (user == null) return NotFound<string>("User Not Found");
            string result = await _userService.EditeUserAsync(user);
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();

        }
    }
}
