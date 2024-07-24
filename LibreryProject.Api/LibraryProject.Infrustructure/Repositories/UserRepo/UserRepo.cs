using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.AppDbContext;
using LibraryProject.Infrustructure.InfrustructureBases;
using LibraryProject.Infrustructure.RepositoriesUserRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Infrustructure.Repositories.UserRepo
{
    internal class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly DbSet<User> _user;

        public UserRepo(ApplicationDBContext applicationDBContext):base(applicationDBContext) 
        {
            _user = applicationDBContext.Set<User>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _user.ToListAsync();
        }
    }
}
