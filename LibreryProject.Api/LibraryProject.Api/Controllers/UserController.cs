using LibraryProject.Api.Bases;
using LibraryProject.Core.Features.UserFeature.Commands.Requests;
using LibraryProject.Core.Features.UserFeature.Queries.Requests;
using LibraryProject.Core.Features.UserFeature.Queries.Responses;
using LibraryProject.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Api.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpGet(Router.UserRouting.List)]
        public async Task<IActionResult> GetUsers()
        {
            Core.Bases.Response<List<GetUsersResponse>> response = await Mediator.Send(new GetUsersQuery());
            return Ok(response);
        }

        [HttpGet(Router.UserRouting.Pagenated)]
        public async Task<IActionResult> Pagenated([FromQuery] GetUsersPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.UserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            Core.Bases.Response<GetUserResponse> response = await Mediator.Send(new GetUserByIdQuery() { Id = id });
            return NewResult(response);
        }

        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand user)
        {
            Core.Bases.Response<string> response = await Mediator.Send(user);
            return NewResult(response);
        }

        [HttpPut(Router.UserRouting.Edite)]
        public async Task<IActionResult> EditeUser([FromBody] EditeUserCommand user)
        {
            Core.Bases.Response<string> response = await Mediator.Send(user);
            return NewResult(response);
        }

        [HttpDelete(Router.UserRouting.Delete)]
        public async Task<IActionResult> EditeUser([FromRoute] int id)
        {
            Core.Bases.Response<string> response = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }

    }
}
