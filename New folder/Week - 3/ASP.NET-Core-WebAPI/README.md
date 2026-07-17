# Module 6 – ASP.NET Core 8.0 Web API

6 self-contained Web API projects built to demonstrate the concepts covered in Module 6 (RESTful services, Web API, Swagger, JWT auth, filters/middleware, exception handling, and API security).

| # | Project | Module 6 Topic Covered |
|---|---------|-------------------------|
| 1 | `01-CRUD-RestApi` | Building RESTful APIs — controllers, routes, GET/POST/PUT/DELETE verbs |
| 2 | `02-Swagger-WebApi` | API Documentation — Swagger/OpenAPI integration with XML comments |
| 3 | `03-JWT-Auth-WebApi` | Advanced API Features — JWT-based authentication & role-based authorization |
| 4 | `04-Middleware-Filters` | Advanced API Features — custom middleware, action filters, exception filters |
| 5 | `05-ExceptionHandling-Serilog` | API Security and Exception Handling — global exception handling + Serilog logging |
| 6 | `06-ApiKey-CORS-Security` | API Security — securing APIs with API keys + CORS policy |

## How to run any project

```bash
cd 0X-ProjectName
dotnet restore
dotnet run
```

Then open `https://localhost:<port>/swagger` (project 1, 3, 4, 5, 6) or `https://localhost:<port>` (project 2, since Swagger is set as the root page) to explore and test the endpoints.

## Notes
- Project 1 uses an in-memory list (no database needed) to keep the CRUD demo self-contained.
- Project 3's JWT secret in `appsettings.json` is a placeholder for demo purposes — never commit real secrets in production.
- Project 6's API key (`DEMO-API-KEY-12345`) must be sent in the `X-Api-Key` header for any request other than `/swagger`.

## Author
Kakumanu Venkata Sadwik — B.Tech CSE, VFSTR
