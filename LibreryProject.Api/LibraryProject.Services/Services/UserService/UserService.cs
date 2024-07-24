using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.RepositoriesUserRepo;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> AddUserAsync(User user)
        {
            var FindUser = await _userRepo.GetTableNoTracking().Where(u => u.Email == user.Email).FirstOrDefaultAsync();
            if (FindUser != null) return "Exist";

            _ = await _userRepo.AddAsync(user);
            return "Success";
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            var tranc = _userRepo.BeginTransaction();
            try
            {
                await _userRepo.DeleteAsync(user);
                await tranc.CommitAsync();
                return "Success";
            }
            catch
            {
                await tranc.RollbackAsync();
                return "Faild";
            }
            throw new NotImplementedException();
        }

        public async Task<string> EditeUserAsync(User user)
        {
            await _userRepo.UpdateAsync(user);
            return "Success";
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetTableNoTracking().Where(u => u.UserID.Equals(id)).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepo.GetUsersAsync();
        }

        public async Task<bool> IsEmailExsistAsync(string email)
        {
            var FindUser = await _userRepo.GetTableNoTracking().Where(u => u.Email == email).FirstOrDefaultAsync();
            if (FindUser != null) return true;
            return false;
        }

        public async Task<bool> IsEmailExsistExcludeSelfAsync(string email, int id)
        {
            var FindUser = await _userRepo.GetTableNoTracking().Where(u => u.Email.Equals(email) & !u.UserID.Equals(id)).FirstOrDefaultAsync();
            if (FindUser != null) return true;
            return false;
        }
    }
}
