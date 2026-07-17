using EFCore.LoadingAndPerformance.Data;
using EFCore.LoadingAndPerformance.Models;
using EFCore.LoadingAndPerformance.Services;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<LibraryContext>()
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;")
    .UseLazyLoadingProxies() // enables lazy loading for "virtual" navigation properties
    .Options;

using var context = new LibraryContext(options);
context.Database.Migrate();

// Seed sample data if empty
if (!context.Authors.Any())
{
    var author = new Author { Name = "R.K. Narayan" };
    author.Books.Add(new Book { Title = "Swami and Friends", Price = 250 });
    author.Books.Add(new Book { Title = "The Guide", Price = 300 });
    context.Authors.Add(author);
    context.SaveChanges();
}

var service = new LoadingDemoService(context);

Console.WriteLine("---- Eager Loading ----");
var eagerAuthors = await service.GetAuthorsEagerAsync();
foreach (var a in eagerAuthors)
    Console.WriteLine($"{a.Name}: {a.Books.Count} books (loaded in one query)");

Console.WriteLine("\n---- Lazy Loading ----");
var lazyAuthor = service.GetAuthorLazy(eagerAuthors.First().Id);
Console.WriteLine($"{lazyAuthor!.Name}: {lazyAuthor.Books.Count} books (Books queried only when accessed)");

Console.WriteLine("\n---- Explicit Loading ----");
var explicitAuthor = await service.GetAuthorExplicitAsync(eagerAuthors.First().Id);
Console.WriteLine($"{explicitAuthor!.Name}: {explicitAuthor.Books.Count} books (loaded via .Collection().LoadAsync())");

Console.WriteLine("\n---- AsNoTracking (read-only) ----");
var readOnlyBooks = await service.GetAllBooksReadOnlyAsync();
Console.WriteLine($"Fetched {readOnlyBooks.Count} books without change tracking overhead");

Console.WriteLine("\n---- Compiled Query ----");
var searchResults = await service.SearchAuthorsCompiledAsync("Narayan");
Console.WriteLine($"Compiled query found {searchResults.Count} matching author(s)");

Console.WriteLine("\n---- Batch update (ExecuteUpdateAsync) ----");
var updatedRows = await service.ApplyDiscountToAllBooksAsync(10);
Console.WriteLine($"Applied 10% discount to {updatedRows} book(s) in a single round trip");
