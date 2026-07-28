import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

// HANDS-ON 7 (Step 68): wildcard ('**') 404 page.
@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterLink],
  template: `
    <section class="not-found">
      <h2>404 - Page Not Found</h2>
      <p>The page you are looking for does not exist.</p>
      <a routerLink="/">Go back home</a>
    </section>
  `,
  styles: [
    `
      .not-found {
        display: grid;
        gap: 0.75rem;
        max-width: 560px;
        margin: 0 auto;
        padding: clamp(1.5rem, 6vw, 4rem);
        text-align: center;
      }

      h2 {
        margin: 0;
        font-size: clamp(1.8rem, 5vw, 2.75rem);
      }

      p {
        margin: 0;
        color: var(--color-muted);
      }

      a {
        justify-self: center;
        margin-top: 0.5rem;
        color: var(--color-primary);
        font-weight: 800;
        text-decoration: none;
      }
    `,
  ],
})
export class NotFoundComponent {}
