using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.BookFeature.Queries.Responses;
using MediatR;

namespace LibraryProject.Core.Features.BookFeature.Queries.Requests
{
    public class GetBookByIdRequest : IRequest<Response<GetBookByIdResponce>>
    {
        public int Id { get; set; }
        public int Pagenumber { get; set; }
        public int PageSize { get; set; }
    }
}
