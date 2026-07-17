# Module 5 – Entity Framework Core 8.0

3 self-contained console projects demonstrating EF Core 8 concepts covered in Module 5 (ORM fundamentals, code-first modeling, CRUD, LINQ, relationships, loading strategies, and performance).

| # | Project | Module 5 Topic Covered |
|---|---------|-------------------------|
| 1 | `01-CodeFirst-Relationships` | Code-First model, primary/foreign keys, navigation properties, One-to-One / One-to-Many / Many-to-Many relationships |
| 2 | `02-CRUD-LINQ` | CRUD operations (AddAsync, Find, FirstOrDefault, ToListAsync, Update, Remove/RemoveRange), LINQ (Where, Select, OrderBy, DTO projection, aggregation) |
| 3 | `03-Loading-Performance` | Eager/Lazy/Explicit loading, AsNoTracking, RowVersion concurrency, compiled queries, batch updates |

## How to run any project

```bash
cd 0X-ProjectName
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

Requires SQL Server LocalDB (or update the connection string in `Program.cs` to point at your own SQL Server instance).

## Notes
- Project 1 (`StudentManagement.CodeFirst`) models a Student–Address (1:1), Department–Student (1:many), and Student–Course (many:many via `Enrollment`) schema — the classic code-first relationship demo.
- Project 2 (`EFCore.CrudLinq`) wraps all data access in a `ProductService` so CRUD and LINQ patterns are easy to find and reuse.
- Project 3 (`EFCore.LoadingAndPerformance`) enables `UseLazyLoadingProxies()` and uses `virtual` navigation properties so all three loading strategies can be compared side by side, plus demonstrates `RowVersion` optimistic concurrency and `ExecuteUpdateAsync` batch updates (EF Core 8 feature).

## Author
Kakumanu Venkata Sadwik — B.Tech CSE, VFSTR
