using LibraryProject.Data.Entities;

namespace LibraryProject.Services.Services.BookService
{
    public interface IBookService
    {
        public Task<Book?> GetBookByIdAsync(int id);

    }
}
