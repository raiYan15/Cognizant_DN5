# Entity Framework Core - Comprehensive Notes

## 📌 Overview

Entity Framework Core (EF Core) is a lightweight, extensible, open-source ORM (Object-Relational Mapper) for .NET. It enables developers to work with databases using .NET objects, abstracting away most of the database code required for data access.

**Key Point:** EF Core enables database operations using LINQ and C# objects instead of raw SQL.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand ORM concepts and EF Core architecture
- [ ] Configure DbContext and models
- [ ] Use LINQ for queries
- [ ] Manage relationships (one-to-many, many-to-many)
- [ ] Implement migrations for schema management
- [ ] Optimize query performance
- [ ] Handle concurrency and transactions

---

## 📚 Core Concepts Learned

### 1. **DbContext & Models**

```csharp
// Model definition
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    // Relationships
    public ICollection<Order> Orders { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }  // Navigation property
}

// DbContext configuration
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Connection String");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure relationships
        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);
        
        // Data annotations
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}
```

### 2. **Fluent API Configuration**

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Entity configuration
    modelBuilder.Entity<User>(entity =>
    {
        entity.HasKey(u => u.Id);
        
        entity.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        entity.Property(u => u.Email)
            .IsRequired()
            .HasColumnName("email_address");
        
        entity.HasIndex(u => u.Email).IsUnique();
        
        // Relationships
        entity.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    });
    
    // Default values
    modelBuilder.Entity<Order>()
        .Property(o => o.OrderDate)
        .HasDefaultValue(DateTime.Now);
}
```

### 3. **CRUD Operations**

```csharp
public class UserRepository
{
    private readonly ApplicationDbContext context;
    
    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    // Create
    public async Task<User> CreateAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }
    
    // Read
    public async Task<User> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }
    
    // Update
    public async Task<User> UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }
    
    // Delete
    public async Task DeleteAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
```

### 4. **LINQ Queries**

```csharp
// Simple query
var users = context.Users.ToList();

// Filter
var activeUsers = context.Users
    .Where(u => u.CreatedDate > DateTime.Now.AddMonths(-1))
    .ToList();

// Project
var userEmails = context.Users
    .Select(u => u.Email)
    .ToList();

// Sort
var sortedUsers = context.Users
    .OrderByDescending(u => u.CreatedDate)
    .ThenBy(u => u.Name)
    .ToList();

// Pagination
var page1 = context.Users
    .Skip(0)
    .Take(10)
    .ToList();

// Complex query with joins
var userOrders = context.Users
    .Where(u => u.Email.Contains("@example.com"))
    .SelectMany(u => u.Orders)
    .Where(o => o.Total > 100)
    .OrderByDescending(o => o.OrderDate)
    .ToList();

// Aggregation
var totalOrders = context.Orders.Count();
var averageOrderValue = context.Orders.Average(o => o.Total);
var maxOrderValue = context.Orders.Max(o => o.Total);

// Group by
var ordersPerUser = context.Orders
    .GroupBy(o => o.UserId)
    .Select(g => new {
        UserId = g.Key,
        OrderCount = g.Count(),
        TotalValue = g.Sum(o => o.Total)
    })
    .ToList();
```

### 5. **Relationships**

```csharp
// One-to-Many
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}

// Many-to-Many
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Student> Students { get; set; }
}

// Configuration
modelBuilder.Entity<Student>()
    .HasMany(s => s.Courses)
    .WithMany(c => c.Students)
    .UsingEntity(j => j
        .ToTable("StudentCourses")
        .HasKey(x => new { x.StudentId, x.CourseId })
    );
```

### 6. **Migrations**

```bash
# Add initial migration
dotnet ef migrations add InitialCreate

# Run migrations
dotnet ef database update

# Create new migration
dotnet ef migrations add AddUserEmailColumn

# Revert migration
dotnet ef database update PreviousMigrationName

# Remove migration
dotnet ef migrations remove
```

**Migration File:**
```csharp
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                Email = table.Column<string>(maxLength: 100, nullable: false),
                CreatedDate = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });
    }
    
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Users");
    }
}
```

### 7. **Eager & Lazy Loading**

```csharp
// Eager loading
var users = context.Users
    .Include(u => u.Orders)
    .ToList();

// Multiple includes
var users2 = context.Users
    .Include(u => u.Orders)
    .ThenInclude(o => o.OrderDetails)
    .ToList();

// Lazy loading (requires navigation property to be virtual)
public class User
{
    public int Id { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}

var user = context.Users.Find(1);
var orders = user.Orders; // Loads automatically

// Explicit loading
context.Entry(user)
    .Collection(u => u.Orders)
    .Load();
```

### 8. **Performance & Best Practices**

```csharp
// Use AsNoTracking for read-only queries
var users = context.Users
    .AsNoTracking()
    .ToList();

// Avoid N+1 queries
var badWay = context.Users.ToList();
foreach (var user in badWay)
{
    var orders = context.Orders.Where(o => o.UserId == user.Id).ToList();
}

// Good way - eager load
var goodWay = context.Users
    .Include(u => u.Orders)
    .ToList();

// Batch updates
context.Users
    .Where(u => u.CreatedDate < DateTime.Now.AddYears(-5))
    .ExecuteDeleteAsync(); // Only available in EF Core 7+
```

---

## 💻 Hands-On Exercises

### Exercise 1: Model Design
**Task:** Design entities with proper relationships

### Exercise 2: Repository Pattern
**Task:** Implement generic repository with CRUD

### Exercise 3: LINQ Queries
**Task:** Write complex LINQ queries

### Exercise 4: Migrations
**Task:** Create and manage database migrations

### Exercise 5: Performance Optimization
**Task:** Identify and fix N+1 queries

---

## 📝 Assignments

1. **Blog Platform**
   - Create entities for posts, comments, users
   - Implement repositories
   - Query complex data

2. **E-Commerce Database**
   - Design product, category, order relationships
   - Write queries for inventory management
   - Implement transactional operations

3. **Reporting System**
   - Complex analytical queries
   - Aggregations and grouping
   - Performance optimization

---

## 🔗 References

### Official:
- [EF Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [EF Core GitHub](https://github.com/dotnet/efcore)

### Tutorials:
- [Microsoft Learn - EF Core](https://docs.microsoft.com/learn/paths/build-data-applications/)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] DbContext
- [ ] Models & Configuration
- [ ] LINQ Queries
- [ ] Relationships
- [ ] Migrations
- [ ] Performance

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

---

**Last Updated:** June 2026
**Completion Status:** Not Started
