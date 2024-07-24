using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.InfrustructureBases;

namespace LibraryProject.Infrustructure.RepositoriesUserRepo
{
    public interface IUserRepo :IGenericRepo<User>
    {
        public Task<List<User>> GetUsersAsync();
    }
}
