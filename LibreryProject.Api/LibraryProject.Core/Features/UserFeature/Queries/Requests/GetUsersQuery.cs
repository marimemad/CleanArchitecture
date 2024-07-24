using LibraryProject.Core.Bases;
using LibraryProject.Core.Features.UserFeature.Queries.Responses;
using LibraryProject.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Core.Features.UserFeature.Queries.Requests
{
    public class GetUsersQuery : IRequest<Response<List<GetUsersResponse>>>
    {
    }
}
