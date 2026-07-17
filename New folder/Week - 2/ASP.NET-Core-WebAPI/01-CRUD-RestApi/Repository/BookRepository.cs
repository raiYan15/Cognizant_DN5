using CrudRestApi.Models;

namespace CrudRestApi.Repository
{
    // In-memory store so the sample runs with zero external dependencies (no DB required).
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 499.00m, PublishedYear = 2008 },
            new Book { Id = 2, Title = "C# in Depth", Author = "Jon Skeet", Price = 799.00m, PublishedYear = 2019 }
        };

        private int _nextId = 3;

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public bool Update(int id, Book book)
        {
            var existing = GetById(id);
            if (existing is null) return false;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Price = book.Price;
            existing.PublishedYear = book.PublishedYear;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing is null) return false;

            _books.Remove(existing);
            return true;
        }
    }
}
