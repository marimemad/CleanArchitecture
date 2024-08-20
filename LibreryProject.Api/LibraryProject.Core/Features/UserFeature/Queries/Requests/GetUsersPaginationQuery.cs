using LibraryProject.Core.Features.UserFeature.Queries.Responses;
using LibraryProject.Core.Wrappers;
using MediatR;

namespace LibraryProject.Core.Features.UserFeature.Queries.Requests
{
    public class GetUsersPaginationQuery : IRequest<PaginatedResult<GetUsersPaginationResponse>>
    {
        public int Pagenumber { set; get; }
        public int PageSize { set; get; }
        public string[]? Order { set; get; }
        public string? Search { set; get; }
    }
}
