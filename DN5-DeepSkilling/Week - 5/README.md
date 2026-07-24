# Week - 5: Angular Hands-On 1 to 5

Week 5 begins the Angular track. It includes task-level hands-on notes and a
complete Student Course Portal sample app that demonstrates the first five
Angular exercise areas.

## Folder Contents

| Folder | What it contains |
| --- | --- |
| `Angular_HandsOn/` | Week 5 Angular overview, hands-on task notes, and the runnable Student Course Portal application. |
| `Angular_HandsOn/Hand-On (1 - 5)/` | Exercise folders for Hands-On 1 through Hands-On 5. |
| `Angular_HandsOn/Student-course-portal/` | Angular 20 standalone SPA with app source, routes, components, services, forms, guards, interceptors, NgRx store files, tests, and mock API data. |

## Hands-On Topics

| Hands-On | Tasks |
| --- | --- |
| Hands-On 1 | Project setup and first components. |
| Hands-On 2 | Data binding, lifecycle hooks, and `@Input`/`@Output`. |
| Hands-On 3 | Structural directives, attribute directives, custom pipes, and custom directives. |
| Hands-On 4 | Template-driven forms and validation. |
| Hands-On 5 | Reactive forms and custom validators. |

## Student Course Portal Highlights

- `angular.json` stores Angular workspace configuration.
- `package.json` includes scripts for `start`, `build`, `test`, `test:ci`, and
  `api`.
- `db.json` provides mock data for `json-server`.
- `src/app/components/` contains reusable UI components such as header,
  course-card, course-summary-widget, and notification.
- `src/app/features/enrollment/` contains template-driven and reactive
  enrollment forms.
- `src/app/directives/`, `src/app/pipes/`, `src/app/services/`,
  `src/app/guards/`, `src/app/interceptors/`, and `src/app/store/` contain the
  supporting Angular features used by the app.

## How to Run the Sample App

```bash
cd "Angular_HandsOn/Student-course-portal"
npm install
npm run api
npm start
```

Run `npm run api` and `npm start` in separate terminals. The mock API uses
`http://localhost:3000`, and Angular serves the app at `http://localhost:4200`.

## Notes

- Start with `Angular_HandsOn/README.md` for the Week 5 overview.
- Each task folder contains a `README.md` and a
  `student-course-portal-task.md` file that maps the task to the sample app.
- The Student Course Portal app is the runnable reference implementation for
  this week.
