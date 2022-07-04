using Microsoft.EntityFrameworkCore;
namespace Micheal.Bookstore.Data
{
    public class BookstoreContext:DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options) 
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<BookGallery> BookGallery { get; set; }
    }
}
