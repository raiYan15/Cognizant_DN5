using EFCore.CrudLinq.Data;
using EFCore.CrudLinq.Models;
using EFCore.CrudLinq.Services;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<StoreContext>()
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreDb;Trusted_Connection=True;")
    .Options;

using var context = new StoreContext(options);
context.Database.Migrate();

var service = new ProductService(context);

// CREATE
await service.AddProductAsync(new Product { Name = "Laptop", Price = 55000, Stock = 10, CategoryId = 1 });
await service.AddProductAsync(new Product { Name = "Notebook", Price = 40, Stock = 200, CategoryId = 2 });
await service.AddProductAsync(new Product { Name = "Headphones", Price = 1500, Stock = 3, CategoryId = 1 });

// READ (all + by name)
var all = await service.GetAllAsync();
Console.WriteLine($"Total products: {all.Count}");

var headphones = await service.GetByNameAsync("Headphones");
Console.WriteLine($"Found: {headphones?.Name} @ Rs.{headphones?.Price}");

// UPDATE
if (headphones is not null)
{
    await service.UpdatePriceAsync(headphones.Id, 1299);
}

// LINQ: filtered + projected + ordered
var expensive = await service.GetExpensiveProductsAsync(1000);
foreach (var p in expensive)
{
    Console.WriteLine($"{p.ProductName} ({p.CategoryName}) - Rs.{p.Price}");
}

// LINQ: aggregation per category
var stats = await service.GetCategoryStatsAsync();
foreach (var s in stats)
{
    Console.WriteLine($"{s.CategoryName}: {s.ProductCount} products, avg Rs.{s.AveragePrice:F2}, stock value Rs.{s.TotalStockValue:F2}");
}

// DELETE
var deletedCount = await service.DeleteOutOfStockAsync(5);
Console.WriteLine($"Removed {deletedCount} low-stock products.");
