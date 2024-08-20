using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.AppDbContext;
using LibraryProject.Infrustructure.InfrustructureBases;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infrustructure.Repositories.BorrowingRepo
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly DbSet<Borrowing> _borrowing;

        public BorrowingRepo(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _borrowing = applicationDBContext.Set<Borrowing>();
        }
    }
}
