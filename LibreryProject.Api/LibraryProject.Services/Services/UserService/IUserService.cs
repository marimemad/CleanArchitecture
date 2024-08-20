using LibraryProject.Data.Entities;

namespace LibraryProject.Services.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<string> AddUserAsync(User user);
        public Task<bool> IsEmailExsistAsync(string email);
        public Task<bool> IsEmailExsistExcludeSelfAsync(string email, int id);
        public Task<string> EditeUserAsync(User user);
        public Task<string> DeleteUserAsync(User user);
        public IQueryable<User> GetUsersQueryable();
        public IQueryable<User> FilterUsersQueryable(string filter);
    }
}
