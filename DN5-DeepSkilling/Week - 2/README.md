# Week - 2: ASP.NET Core Web API and Entity Framework Core

Week 2 focuses on server-side .NET development. It includes ASP.NET Core Web API
projects for REST, Swagger, and JWT authentication, plus Entity Framework Core
console projects for code-first modeling, CRUD, LINQ, loading strategies, and
performance.

## Folder Contents

| Folder | What it contains |
| --- | --- |
| `ASP.NET-Core-WebAPI/` | Web API exercises with controllers, models, repositories, Swagger setup, and JWT authentication helpers. |
| `Entity-Framework-Core/` | EF Core console applications demonstrating relationships, CRUD with LINQ, and loading/performance techniques. |

## ASP.NET Core Web API Projects

| Project | Focus |
| --- | --- |
| `01-CRUD-RestApi` | REST endpoints for book CRUD operations using controllers and an in-memory repository. |
| `02-Swagger-WebApi` | Swagger/OpenAPI documentation using an employee API sample. |
| `03-JWT-Auth-WebApi` | JWT token generation, authentication, authorization, and secured controller routes. |

## Entity Framework Core Projects

| Project | Focus |
| --- | --- |
| `01-CodeFirst-Relationships` | Code-first student management model with students, addresses, departments, courses, and enrollments. |
| `02-CRUD-LINQ` | Product CRUD operations, LINQ filtering/projection/ordering, and DTO usage. |
| `03-Loading-Performance` | Eager, lazy, and explicit loading with performance features such as `AsNoTracking`, compiled queries, and batch updates. |

## Learning Focus

- Build REST APIs with ASP.NET Core controllers and routing.
- Add Swagger/OpenAPI documentation to a Web API project.
- Protect APIs with JWT authentication.
- Model relational data with EF Core code-first entities.
- Perform CRUD operations and LINQ queries through service classes.
- Compare EF Core loading strategies and performance patterns.

## How to Run

For a Web API project:

```bash
cd "ASP.NET-Core-WebAPI/01-CRUD-RestApi"
dotnet restore
dotnet run
```

Then open the Swagger URL shown in the terminal, usually
`https://localhost:<port>/swagger`.

For an EF Core project:

```bash
cd "Entity-Framework-Core/01-CodeFirst-Relationships"
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

The EF Core projects expect SQL Server LocalDB unless the connection string is
changed in the project source.

## Notes

- See `ASP.NET-Core-WebAPI/README.md` and
  `Entity-Framework-Core/README.md` for module-specific details.
- Demo secrets and JWT keys are for learning only and should not be reused in
  production code.
