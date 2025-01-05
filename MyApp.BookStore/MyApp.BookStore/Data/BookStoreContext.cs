using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyApp.BookStore.Data
{
    public class BookStoreContext : IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options) { 
        
        }

        public DbSet<Books> Books { get; set; }

        public DbSet<BookGallery> BookGallery { get; set; }


    }
}
