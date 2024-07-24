using LibraryProject.Core.Bases;
using MediatR;

namespace LibraryProject.Core.Features.UserFeature.Commands.Requests
{
    public class EditeUserCommand : IRequest<Response<string>>
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}
