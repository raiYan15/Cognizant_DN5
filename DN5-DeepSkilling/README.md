# DN5 - DeepSkilling (Course Materials)

This repository contains the DeepSkilling curriculum (DN5) organized by week. Each week contains hands-on exercises, sample apps, and notes used for instructor-led or self-paced learning.

Overview of weeks
-----------------
- Week - 1: Advanced SQL, Cursors, Exception Handling, Functions, Indexing, Stored Procedures, Triggers, Views
- Week - 2: ASP.NET Core WebAPI exercises and Entity Framework Core (code-first, CRUD with LINQ, loading/performance)
- Week - 3: Additional ASP.NET Core WebAPI topics (middleware, Serilog, CORS, API key security)
- Week - 4: Microservices exercises (JWT authentication, microservices examples)
- Week - 5: Angular hands-on exercises and a sample Student Course Portal app
- Week - 6: Additional Angular hands-on (services, routing, HTTP, NgRx) and CI/CD/Git exercises
- Week - 7: DevOps, Docker, GenAI fundamentals and supporting notes

How this folder is organized
----------------------------
Each week folder contains topic folders and one or more hands-on exercise folders. The Angular weeks (5 and 6) include both task outlines (Hand-On directories) and a complete sample app used across multiple hands-on layers.

Week - 5: Angular (summary)
---------------------------
Path: `Week - 5/Angular_HandsOn`

Structure provided in this workspace:
- `Hand-On (1 - 5)/` — Task-level notes and starter READMEs for Hands-On 1 through 5.
  - Hands-On 1: Project Setup, Components
  - Hands-On 2: Data Binding, Lifecycle Hooks, @Input/@Output
  - Hands-On 3: Structural and Attribute Directives, Custom Pipe & Directive
  - Hands-On 4: Template-driven Forms and Validation
  - Hands-On 5: Reactive Forms and Custom Validators

- `Student-course-portal/` — Full Angular sample application that the hands-on exercises are built on incrementally.
  Key files and folders inside `Student-course-portal/`:
  - `angular.json` — workspace and build/serve configuration
  - `package.json` — npm scripts (install, start, test), dependencies
  - `db.json` — mock API dataset (json-server)
  - `src/` — application source code, highlights:
    - `app/` — application code (app.config.ts, root component, components/, directives/, features/, guards/, interceptors/, models/, pages/, pipes/, services/, store/)
    - `main.ts`, `index.html`, `styles.css` — bootstrap and global styles
  - `notes.txt` — developer or instructor notes for Hands-On 1 (project setup)

How to run the Student Course Portal (example)

1. Install dependencies

```bash
cd Week - 5/Angular_HandsOn/Student-course-portal
npm install
```

2. Start the mock API and app (two terminals)

```bash
npm run api    # runs json-server on :3000 using db.json
npm start      # runs angular dev server on http://localhost:4200
```

# DN5 - DeepSkilling (Course Materials)

This repository contains the DeepSkilling curriculum (DN5) organized by week. Each week includes hands-on exercises, sample projects, and notes for instructor-led or self-paced learning.

## Overview of weeks

- Week - 1: Advanced SQL (AdvancedConcepts.sql, Cursors, ExceptionHandling, Functions, Indexing, StoredProcedures, Triggers, Views)
- Week - 2: ASP.NET Core WebAPI exercises and Entity Framework Core (code-first, CRUD with LINQ, loading/performance)
- Week - 3: ASP.NET Core topics (middleware, Serilog, API security, CORS)
- Week - 4: Microservices exercises (JWT authentication and related samples)
- Week - 5: Angular hands-on exercises and a sample Student Course Portal app (task notes + sample app)
- Week - 6: Angular continuation (services, routing, HTTP, NgRx) plus CI/CD and Git exercises
- Week - 7: DevOps, Docker, GenAI fundamentals and supporting notes

---

## How this repository is organized

Each week folder is self-contained and typically includes:

- hands-on folders or exercises (task notes and starter code)
- sample applications (when applicable)
- configuration and run/test scripts (package.json, tsconfig, angular.json, etc.)

Refer to the weekly README files for exercise-level guidance.

---

## Week - 5: Angular (detailed)

Path: `Week - 5/Angular_HandsOn`

This week has two primary areas:

- `Hand-On (1 - 5)/` — Task-level notes and starter READMEs for Hands-On 1 through 5. Each task folder contains a `README.md` describing the learning goal and step list, plus a `student-course-portal-task.md` that maps the task to the sample app files.
- `Student-course-portal/` — The full Angular sample application used across the hands-on exercises. The sample app is an Angular v20 standalone SPA that demonstrates the progressive features covered in Hands-On 1–5.

Key files and folders inside `Student-course-portal/`:

- `angular.json` — workspace build and serve configuration
- `package.json` — npm scripts (install, start, api, test) and dependency lists
- `db.json` — mock API data used by `json-server`
- `src/` — application source code; important subfolders:
  - `app/` — application code, including:
    - `app.config.ts` — standalone application providers and routing config
    - `app.ts` / `app.html` — root component
    - `components/` — `header`, `course-card`, `course-summary-widget`, `notification`
    - `directives/` — example attribute directive (`highlight.directive.ts`)
    - `features/enrollment/` — template and reactive enrollment forms, validators
    - `guards/` — `auth.guard.ts`, `unsaved-changes.guard.ts`
    - `interceptors/` — `auth.interceptor.ts`, `error-handler.interceptor.ts`, `loading.interceptor.ts`
    - `models/`, `pages/`, `pipes/`, `services/`, `store/`
- `.vscode/` — recommended launch and task configurations for VS Code

How to run the Student Course Portal (example):

```bash
cd "Week - 5/Angular_HandsOn/Student-course-portal"
npm install
# In terminal 1:
npm run api    # Starts json-server on http://localhost:3000 using db.json
# In terminal 2:
npm start      # Starts ng serve on http://localhost:4200
```

Tests:

```bash
npm test        # run tests in watch mode (Karma + Jasmine)
npm run test:ci # run tests once in headless CI mode
```

Notes for Week-5 task files:

- The `Hand-On (1 - 5)` subfolders contain `README.md` and `student-course-portal-task.md` duplicates which reference the real sample app paths. These are *notes for learners* and do not modify the sample app code.
- If you want to create isolated exercises, copy the `Student-course-portal` app to a new folder before changing source files.

---

## Week - 6: Angular (detailed)

Path: `Week - 6/Angular`

This week continues the Angular curriculum and includes:

- `Hand-On (6 - 10)/` — Task-level notes and starter READMEs for Hands-On 6 through 10.
  - Hands-On 6: Course Service, Enrollment Service
  - Hands-On 7: Routing, Guards & Lazy Loading
  - Hands-On 8: HTTP CRUD, RxJS, Interceptors
  - Hands-On 9: NgRx Store and Effects
  - Hands-On 10: Testing (components, services, NgRx)

Notes for Week-6 files:

- Each `Hands-On X/Task Y` folder contains a `README.md` describing the goal and what to implement. Currently these are task outlines — implement source files (services, effects, tests) inside these folders or point them at a sample app.
- If you plan to add a runnable Week-6 sample app, create it as a new sibling folder (for example `Week - 6/Angular/student-course-portal-ho6`) rather than modifying the task-note structure.

---

## Other weeks and resources

- `Week - 1/` through `Week - 4/` contain SQL and .NET server-side exercises.
- `Week - 6/CI CD/` and `Week - 6/GIT/` contain CI/CD and Git practicals with their own README files.
- `Week - 7/` contains DevOps and Docker notes; consult `DevOps/DevOps_Complete_Notes.md` for consolidated material.

---

## Maintainers' notes

- The `Student-course-portal` app is the canonical working example for Week 5. The task-note duplicates in `Hand-On (1 - 5)` map exercises to that app and are intentionally left as read-only references.
- When adding new code or sample apps, prefer isolated folders to keep the instructor materials reproducible for other learners.

If you want, I can:

- Create runnable starter code for each hand-on task (components, services, forms, tests) inside the corresponding folders.
- Add example solutions and npm scripts to scaffold and run each exercise quickly.

---

Last updated: 2026-07-24
