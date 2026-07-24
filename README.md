# Cognizant Digital Nurture 5.0 (DN5)

This repository contains learning materials for Cognizant Digital Nurture 5.0.
It is organized into two tracks:

- `DN5-DeepSkilling/`: the populated advanced learning track with weekly
  hands-on exercises, notes, and sample projects.
- `DN5-Upskilling/`: the foundation-track folder. In the current workspace it
  contains only a placeholder `README.md` and can be expanded with foundation
  modules later.

## Repository Structure

```text
Cognizant-DN5/
|-- README.md
|-- DN5-DeepSkilling/
|   |-- README.md
|   |-- Week - 1/
|   |   |-- README.md
|   |   |-- Advanced SQL/
|   |   |-- Engineering concepts/
|   |   `-- NUnit-Moq/
|   |-- Week - 2/
|   |   |-- README.md
|   |   |-- ASP.NET-Core-WebAPI/
|   |   `-- Entity-Framework-Core/
|   |-- Week - 3/
|   |   |-- README.md
|   |   `-- ASP.NET-Core-WebAPI/
|   |-- Week - 4/
|   |   |-- README.md
|   |   `-- Microservices/
|   |-- Week - 5/
|   |   |-- README.md
|   |   `-- Angular_HandsOn/
|   |-- Week - 6/
|   |   |-- README.md
|   |   |-- Angular/
|   |   |-- CI CD/
|   |   `-- GIT/
|   `-- Week - 7/
|       |-- README.md
|       |-- DevOps/
|       |-- Docker_/
|       `-- GenAI-Fundamentals/
`-- DN5-Upskilling/
    `-- README.md
```

## Track Overview

| Track | Current content |
| --- | --- |
| `DN5-DeepSkilling` | Complete week-wise learning material from Week 1 to Week 7. |
| `DN5-Upskilling` | Placeholder folder for future foundation-track content. |

## DeepSkilling Weekly Guide

| Week | Topics | Main folders |
| --- | --- | --- |
| Week 1 | Advanced SQL, engineering concepts, algorithms, design patterns, NUnit, and Moq. | `Advanced SQL/`, `Engineering concepts/`, `NUnit-Moq/` |
| Week 2 | ASP.NET Core Web API and Entity Framework Core. | `ASP.NET-Core-WebAPI/`, `Entity-Framework-Core/` |
| Week 3 | Advanced ASP.NET Core Web API topics: middleware, filters, Serilog, CORS, and API key security. | `ASP.NET-Core-WebAPI/` |
| Week 4 | Microservices concepts and JWT authentication exercises. | `Microservices/` |
| Week 5 | Angular Hands-On 1 to 5 and the Student Course Portal sample app. | `Angular_HandsOn/` |
| Week 6 | Angular Hands-On 6 to 10, CI/CD fundamentals, and Git practicals. | `Angular/`, `CI CD/`, `GIT/` |
| Week 7 | DevOps, Docker, Kubernetes, Terraform, monitoring, DevSecOps, and GenAI fundamentals. | `DevOps/`, `Docker_/`, `GenAI-Fundamentals/` |

## Technologies Covered

- SQL and advanced database programming.
- C#, .NET, NUnit, and Moq.
- Java design-pattern examples.
- ASP.NET Core Web API and JWT authentication.
- Entity Framework Core 8.
- Angular 20, RxJS, forms, routing, guards, interceptors, NgRx, and unit tests.
- Git, CI/CD, Docker, Kubernetes, Terraform, Prometheus, and Grafana.
- Generative AI fundamentals, prompt engineering, RAG, agents, and responsible
  AI practices.

## How to Use This Repository

1. Start with `DN5-DeepSkilling/README.md` for the full course overview.
2. Open the README inside each `Week - X/` folder for week-specific guidance.
3. Follow nested module READMEs for project-specific or task-specific
   instructions.
4. For runnable .NET projects, enter the project folder and use:

   ```bash
   dotnet restore
   dotnet run
   ```

5. For the Week 5 Angular Student Course Portal, use:

   ```bash
   cd "DN5-DeepSkilling/Week - 5/Angular_HandsOn/Student-course-portal"
   npm install
   npm run api
   npm start
   ```

   Run `npm run api` and `npm start` in separate terminals.

## Notes

- The DeepSkilling track is the active, populated part of the repository.
- The Upskilling track is present but has not yet been filled with module
  folders in this workspace.
- Several notes are available in both Markdown and PDF formats for convenient
  reading.
- Demo credentials, API keys, and JWT secrets in sample projects are for
  learning only.

## Last Updated

2026-07-24
