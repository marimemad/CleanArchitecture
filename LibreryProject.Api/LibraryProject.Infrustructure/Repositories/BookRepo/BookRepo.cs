using LibraryProject.Data.Entities;
using LibraryProject.Infrustructure.AppDbContext;
using LibraryProject.Infrustructure.InfrustructureBases;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infrustructure.Repositories.BookRepo
{
    internal class BookRepo : GenericRepo<Book>, IBookRepo
    {
        private readonly DbSet<Book> _book;

        public BookRepo(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _book = applicationDBContext.Set<Book>();
        }
    }
}
