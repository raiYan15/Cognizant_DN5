# Week - 4: Microservices and JWT Authentication

Week 4 introduces microservices-oriented authentication concepts through
ASP.NET Core source examples. The current folder focuses on JWT-based login and
secured controller access.

## Folder Contents

| Folder | What it contains |
| --- | --- |
| `Microservices/` | JWT authentication notes and two exercise folders with ASP.NET Core controllers, models, launch settings, and `Program.cs` configuration. |

## Exercises

| Exercise | Focus |
| --- | --- |
| `Exercise_01_JWTAuthentication` | Login endpoint, JWT generation, bearer authentication setup, and a secured controller. |
| `Exercise_02` | A second JWT-protected API exercise with the same controller/model structure for additional practice. |

## Learning Focus

- Compare monolithic and microservices-style service boundaries.
- Understand why APIs often rely on token-based authentication.
- Configure JWT bearer authentication in ASP.NET Core.
- Build an `AuthController` that issues a token for valid credentials.
- Protect endpoints with bearer tokens through a secure controller.

## Important Files

- `Program.cs` configures controllers, Swagger, JWT bearer authentication, and
  authorization.
- `Controllers/AuthController.cs` validates demo credentials and creates JWTs.
- `Controllers/SecureController.cs` represents protected API endpoints.
- `Models/LoginModel.cs` and `Models/User.cs` provide simple request and user
  models.
- `Properties/launchSettings.json` contains local launch profiles.

## How to Use

The exercise folders currently contain source files but no `.csproj` files. To
run them, create or use an ASP.NET Core Web API project, copy the exercise files
into it, add the required JWT authentication packages, and run the project with
the .NET CLI or Visual Studio.

## Notes

- The demo credentials and signing key are hard-coded for learning purposes.
- Do not use the sample JWT secret or credential logic in production code.
