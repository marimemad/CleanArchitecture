using LibraryProject.Core.Bases;
using MediatR;

namespace LibraryProject.Core.Features.UserFeature.Commands.Requests
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int UserID { get; set; }
        public DeleteUserCommand(int id)
        {
            UserID = id;
        }
    }
}
