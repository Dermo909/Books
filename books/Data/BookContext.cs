using books.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace books.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ReadingList> ReadingLists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(entity => {
                entity.HasIndex(e => e.ISBN).IsUnique();
            });
        }
    }
}
