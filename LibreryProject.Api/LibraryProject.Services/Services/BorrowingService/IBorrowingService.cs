using LibraryProject.Data.Entities;

namespace LibraryProject.Services.Services.BorrowingService
{
    public interface IBorrowingService
    {
        public IQueryable<Borrowing> GetBorrowingsByBookId(int bookId);
    }
}
