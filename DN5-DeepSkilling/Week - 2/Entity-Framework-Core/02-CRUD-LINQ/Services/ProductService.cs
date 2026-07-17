using EFCore.CrudLinq.Data;
using EFCore.CrudLinq.DTOs;
using EFCore.CrudLinq.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.CrudLinq.Services
{
    public class ProductService
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context)
        {
            _context = context;
        }

        // ---------------- CREATE ----------------
        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // ---------------- READ ----------------

        // Find() checks the change tracker first, then hits the DB by primary key - fastest lookup by PK.
        public Product? FindById(int id) => _context.Products.Find(id);

        // FirstOrDefaultAsync with a predicate - use when querying by a non-PK column.
        public Task<Product?> GetByNameAsync(string name) =>
            _context.Products.FirstOrDefaultAsync(p => p.Name == name);

        public Task<List<Product>> GetAllAsync() => _context.Products.ToListAsync();

        // ---------------- UPDATE ----------------
        public async Task<bool> UpdatePriceAsync(int id, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null) return false;

            product.Price = newPrice; // change tracker automatically detects this mutation
            await _context.SaveChangesAsync();
            return true;
        }

        // ---------------- DELETE ----------------
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null) return false;

            _context.Products.Remove(product); // single-entity delete
            await _context.SaveChangesAsync();
            return true;
        }

        // Bulk delete: removes every product below a stock threshold in one SaveChanges call.
        public async Task<int> DeleteOutOfStockAsync(int stockThreshold)
        {
            var outOfStock = await _context.Products
                .Where(p => p.Stock < stockThreshold)
                .ToListAsync();

            _context.Products.RemoveRange(outOfStock);
            return await _context.SaveChangesAsync();
        }

        // ---------------- LINQ QUERIES ----------------

        // Where + OrderBy + Select projection into a DTO (only pulls the columns it needs).
        public Task<List<ProductSummaryDto>> GetExpensiveProductsAsync(decimal minPrice) =>
            _context.Products
                .Where(p => p.Price >= minPrice)
                .OrderByDescending(p => p.Price)
                .Select(p => new ProductSummaryDto
                {
                    ProductName = p.Name,
                    CategoryName = p.Category.Name,
                    Price = p.Price
                })
                .ToListAsync();

        // Aggregation: count, average, sum per category.
        public Task<List<CategoryStatsDto>> GetCategoryStatsAsync() =>
            _context.Products
                .GroupBy(p => p.Category.Name)
                .Select(g => new CategoryStatsDto
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count(),
                    AveragePrice = g.Average(p => p.Price),
                    TotalStockValue = g.Sum(p => p.Price * p.Stock)
                })
                .ToListAsync();
    }

    public class CategoryStatsDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal TotalStockValue { get; set; }
    }
}
