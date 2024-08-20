using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.Repositories.BorrowingRepo;

namespace LibraryProject.Services.Services.BorrowingService
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepo _borrowingRepo;
        public BorrowingService(IBorrowingRepo borrowingRepo)
        {
            _borrowingRepo = borrowingRepo;
        }

        public IQueryable<Borrowing> GetBorrowingsByBookId(int bookId)
        {
            return _borrowingRepo.GetTableNoTracking().Where(b => b.BookID.Equals(bookId)).AsQueryable();
        }
    }
}
