# Week 5 Angular Hands-On Overview

This folder contains the Week 5 Angular exercises for DN5.0.

## Folder layout

- `Hand-On (1 - 5)/`
  - `Hands-On 1/`
    - `Task 1 - Project Setup/`
    - `Task 2 - Components/`
  - `Hands-On 2/`
    - `Task 1 - Data Binding/`
    - `Task 2 - Lifecycle Hooks/`
    - `Task 3 - @Input@Output/`
  - `Hands-On 3/`
    - `Task 1 - Structural Directives/`
    - `Task 2 - Attribute Directives/`
    - `Task 3 - Custom Pipe & Directive/`
  - `Hands-On 4/`
    - `Task 1 - Template Forms/`
    - `Task 2 - Validation/`
  - `Hands-On 5/`
    - `Task 1 - Reactive Forms/`
    - `Task 2 - Custom Validators/`

- `Student-course-portal/`
  - Complete Angular application folder for the sample student course portal.

## What each folder contains

### `Hand-On (1 - 5)`

This folder contains task-level notes and starter guidance for the first five hands-on exercises.
Each task subfolder currently includes a `README.md` that describes the task goal and what to build.

Use this folder when working through the core Week-5 exercise flow:

- Hands-On 1: setup and first components
- Hands-On 2: binding, lifecycle hooks, and component input/output
- Hands-On 3: directives, pipes, and UI behavior
- Hands-On 4: template-driven forms and validation
- Hands-On 5: reactive forms and custom validators

### `Student-course-portal`

This folder contains the actual Angular sample app and supporting files for Week 5.
The key files and folders include:

- `angular.json` — Angular workspace and build configuration
- `package.json` — project scripts, dependencies, and metadata
- `tsconfig.json`, `tsconfig.app.json`, `tsconfig.spec.json` — TypeScript compiler configuration
- `db.json` — mock API data for the sample portal
- `src/` — Angular source files for the app
- `.angular/` — build cache and Angular compiler artifacts
- `.vscode/` — VS Code task and launch settings
- `README.md` — app-specific instructions

The `src/` structure contains:

- `app/` — app config, routes, components, directives, pages, services, pipes, models, guards, interceptors, and store
- `public/` — static assets for the app shell
- `main.ts` / `index.html` / `styles.css` — application bootstrap and global styling

## How to use this folder

- Start with the task folders inside `Hand-On (1 - 5)` for guided exercise outlines.
- Use `Student-course-portal/` when you need the full working example app and source files.
- Do not move or rename the `Student-course-portal` app files unless you are intentionally copying the sample app into a new project.
