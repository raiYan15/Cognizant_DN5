using EFCore.LoadingAndPerformance.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.LoadingAndPerformance.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.RowVersion)
                .IsRowVersion(); // maps to SQL Server rowversion column, auto-updated on every write
        }
    }
}
