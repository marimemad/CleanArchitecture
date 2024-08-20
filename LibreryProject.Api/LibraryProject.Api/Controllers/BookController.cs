using LibraryProject.Api.Bases;
using LibraryProject.Core.Features.BookFeature.Queries.Requests;
using LibraryProject.Core.Features.BookFeature.Queries.Responses;
using LibraryProject.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Api.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class BookController : AppControllerBase
    {
        [HttpGet(Router.BookRouting.GetById)]
        public async Task<IActionResult> GetBookById([FromQuery] GetBookByIdRequest request)
        {
            Core.Bases.Response<GetBookByIdResponce> response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
