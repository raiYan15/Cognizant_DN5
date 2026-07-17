using EFCore.LoadingAndPerformance.Data;
using EFCore.LoadingAndPerformance.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.LoadingAndPerformance.Services
{
    public class LoadingDemoService
    {
        private readonly LibraryContext _context;

        // A compiled query is parsed/translated to SQL once and cached, skipping that
        // overhead on every subsequent call - useful for hot-path queries.
        private static readonly Func<LibraryContext, string, IAsyncEnumerable<Author>> GetAuthorsByNameCompiled =
            EF.CompileAsyncQuery((LibraryContext ctx, string name) =>
                ctx.Authors.Where(a => a.Name.Contains(name)));

        public LoadingDemoService(LibraryContext context)
        {
            _context = context;
        }

        // ---------------- EAGER LOADING ----------------
        // Loads Author and all related Books in a single SQL query using JOIN via Include().
        public Task<List<Author>> GetAuthorsEagerAsync() =>
            _context.Authors.Include(a => a.Books).ToListAsync();

        // ---------------- LAZY LOADING ----------------
        // Requires the proxies package + "virtual" navigation properties.
        // Books are NOT fetched until author.Books is actually accessed - each access issues its own query.
        public Author? GetAuthorLazy(int id) => _context.Authors.Find(id);

        // ---------------- EXPLICIT LOADING ----------------
        // Load the Author first, then explicitly trigger a separate query for its Books when needed.
        public async Task<Author?> GetAuthorExplicitAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author is not null)
            {
                await _context.Entry(author)
                    .Collection(a => a.Books)
                    .LoadAsync();
            }
            return author;
        }

        // ---------------- PERFORMANCE: AsNoTracking ----------------
        // Read-only query - skips change tracking overhead, faster for reports/listings
        // where you will never call SaveChanges() on the results.
        public Task<List<Book>> GetAllBooksReadOnlyAsync() =>
            _context.Books.AsNoTracking().ToListAsync();

        // ---------------- PERFORMANCE: Compiled query ----------------
        public async Task<List<Author>> SearchAuthorsCompiledAsync(string name)
        {
            var results = new List<Author>();
            await foreach (var author in GetAuthorsByNameCompiled(_context, name))
            {
                results.Add(author);
            }
            return results;
        }

        // ---------------- CONCURRENCY: RowVersion ----------------
        public async Task<bool> TryUpdatePriceAsync(int bookId, decimal newPrice, byte[] originalRowVersion)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book is null) return false;

            // Tell EF what version we originally read, so it can detect a conflicting concurrent update.
            _context.Entry(book).Property(b => b.RowVersion).OriginalValue = originalRowVersion;
            book.Price = newPrice;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Someone else updated this row since we read it - caller should reload and retry.
                return false;
            }
        }

        // ---------------- PERFORMANCE: Batch/bulk operation ----------------
        // A single round trip that updates every matching row without loading entities into memory.
        public Task<int> ApplyDiscountToAllBooksAsync(decimal discountPercent) =>
            _context.Books.ExecuteUpdateAsync(setters =>
                setters.SetProperty(b => b.Price, b => b.Price - (b.Price * discountPercent / 100)));
    }
}
