import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

// HANDS-ON 7 (Step 72): Layout component for the nested /courses routes. Its own
// <router-outlet> renders either the list ('') or a course detail (':id').
@Component({
  selector: 'app-courses-layout',
  standalone: true,
  imports: [RouterOutlet],
  template: `
    <div class="courses-layout">
      <router-outlet></router-outlet>
    </div>
  `,
})
export class CoursesLayoutComponent {}
