using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.Repositories.BookRepo;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Services.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _bookRepo;
        public BookService(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepo.GetTableNoTracking()
                            .Where(b => b.BookID.Equals(id))
                            .Include(b => b.Categories)
                            .Include(b => b.Borrowings).
                            ThenInclude(b => b.User).FirstOrDefaultAsync();
        }
    }
}
