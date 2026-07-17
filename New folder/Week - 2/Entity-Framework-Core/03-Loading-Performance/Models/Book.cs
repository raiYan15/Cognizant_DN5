using System.ComponentModel.DataAnnotations;

namespace EFCore.LoadingAndPerformance.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation used to demonstrate eager/lazy/explicit loading
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; } = null!;

        // Concurrency token: EF Core checks this on UPDATE/DELETE and throws
        // DbUpdateConcurrencyException if another process changed the row first.
        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
