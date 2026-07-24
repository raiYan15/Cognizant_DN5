import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

// HANDS-ON 7 (Step 68): wildcard ('**') 404 page.
@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterLink],
  template: `
    <section class="not-found">
      <h2>404 — Page Not Found</h2>
      <p>The page you are looking for does not exist.</p>
      <a routerLink="/">Go back home</a>
    </section>
  `,
  styles: [`.not-found { padding: 2rem; text-align: center; } a { color: #2563eb; }`],
})
export class NotFoundComponent {}
