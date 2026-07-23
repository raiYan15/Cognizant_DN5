# Student Course Portal — Digital Nurture 5.0 (Angular v20)

A single Angular 20 standalone SPA built incrementally across the 10 hands-on
exercises of the DN 5.0 Angular exercise book. Each hands-on adds a layer to the
same **Student Course Portal**.

## Run it

```bash
npm install                # install dependencies
npm run api                # terminal 1 — mock REST API (json-server on :3000)
npm start                  # terminal 2 — ng serve on http://localhost:4200
```

- `npm run build` — production build (outputs to `dist/`).
- `npm run test:ci` — run all unit tests once in headless Chrome.
- `npm test` — run tests in Karma watch mode.

> The course/enrollment data comes from `db.json` via json-server. Start the API
> before browsing `/courses` so the NgRx effect can load data.
> (Install json-server once with `npm install -g json-server` if `npm run api` fails.)

## Hands-on → where it lives

| Hands-On | Topic | Key files |
|----------|-------|-----------|
| 1 | Setup, structure, first components | `notes.txt`, `app.ts/html`, `components/header`, `pages/home` |
| 2 | Binding, lifecycle, @Input/@Output | `pages/home`, `components/course-card` |
| 3 | Directives & pipes | `directives/highlight.directive.ts`, `pipes/credit-label.pipe.ts`, `components/course-card` |
| 4 | Template-driven form | `features/enrollment/enrollment-form.component.*` |
| 5 | Reactive form + validators + FormArray | `features/enrollment/reactive-enrollment-form.component.*`, `enrollment.validators.ts` |
| 6 | Services & DI | `services/*.ts`, `models/*.ts`, `components/notification` (component-level provider) |
| 7 | Routing, guards, lazy loading | `app.routes.ts`, `pages/courses-layout`, `pages/course-detail`, `guards/*.ts`, `features/enrollment/enrollment.routes.ts` |
| 8 | HttpClient, RxJS, interceptors | `services/course.service.ts`, `interceptors/*.ts`, `services/loading.service.ts`, `db.json` |
| 9 | NgRx state management | `store/course/*`, `store/enrollment/*`, `app.config.ts` |
| 10 | Unit testing | `*.spec.ts` (course-card, course-list w/ MockStore, course.service w/ HTTP testing) |

## Notes

- Uses the modern **standalone** API (no NgModules) — `app.config.ts` replaces the
  classic `app.module.ts`.
- The end-state code reflects the *latest* layer for each feature: `CourseService`
  is HTTP-based (HO8), course/enrollment state lives in **NgRx** (HO9), and forms,
  guards and interceptors are all wired into the running app.
