# Week - 3: Advanced ASP.NET Core Web API

Week 3 continues the ASP.NET Core Web API track with middleware, filters,
centralized exception handling, structured logging, CORS, and API key security.

## Folder Contents

| Folder | What it contains |
| --- | --- |
| `ASP.NET-Core-WebAPI/` | Three focused Web API projects covering advanced request pipeline and API security topics. |

## Projects

| Project | Focus |
| --- | --- |
| `04-Middleware-Filters` | Custom request logging middleware, custom action filters, exception filters, and a demo controller. |
| `05-ExceptionHandling-Serilog` | Global exception-handling middleware and Serilog-based logging around an orders API. |
| `06-ApiKey-CORS-Security` | API key validation middleware, CORS setup, and a secured data controller. |

## Learning Focus

- Understand how ASP.NET Core middleware participates in the request pipeline.
- Use action filters and exception filters for cross-cutting behavior.
- Centralize exception handling.
- Add structured logging with Serilog.
- Configure CORS policies.
- Require an API key header for protected endpoints.

## How to Run

From any project folder:

```bash
dotnet restore
dotnet run
```

Open the Swagger endpoint shown by the running application when Swagger is
enabled. For `06-ApiKey-CORS-Security`, send the configured API key in the
`X-Api-Key` header when testing secured endpoints.

## Notes

- The detailed project list is also documented in
  `ASP.NET-Core-WebAPI/README.md`.
- Security settings in these samples are intentionally simple for hands-on
  learning and should be replaced with production-grade configuration in real
  applications.
