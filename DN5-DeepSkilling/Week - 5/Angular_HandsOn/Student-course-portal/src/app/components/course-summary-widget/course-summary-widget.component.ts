import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Course } from '../../models/course.model';
import { loadCourses } from '../../store/course/course.actions';
import { selectAllCourses } from '../../store/course/course.selectors';

// HANDS-ON 6 (Step 62): A second consumer of the course data. It reads from the
// SAME store as the course list, proving state is shared — add a course anywhere
// and this count updates too.
@Component({
  selector: 'app-course-summary-widget',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="summary">
      <span class="summary-icon" aria-hidden="true">
        <svg viewBox="0 0 24 24">
          <path d="M4 6.5h7a3 3 0 0 1 3 3v8a3 3 0 0 0-3-3H4z" />
          <path d="M20 6.5h-7a3 3 0 0 0-3 3v8a3 3 0 0 1 3-3h7z" />
        </svg>
      </span>
      <div>
        <span class="summary-label">Catalog snapshot</span>
        <strong>{{ (courses$ | async)?.length ?? 0 }} total courses</strong>
      </div>
    </div>
  `,
  styles: [
    `
      .summary {
        display: flex;
        align-items: center;
        gap: 0.85rem;
        padding: 1rem;
        background: var(--color-surface);
        border: 1px solid var(--color-border);
        border-radius: var(--radius-card);
        box-shadow: var(--shadow-card);
      }

      .summary-icon {
        display: inline-grid;
        width: 2.65rem;
        height: 2.65rem;
        place-items: center;
        color: var(--color-primary);
        background: var(--color-primary-soft);
        border-radius: 8px;
      }

      .summary-icon svg {
        width: 1.35rem;
        height: 1.35rem;
        fill: none;
        stroke: currentColor;
        stroke-linecap: round;
        stroke-linejoin: round;
        stroke-width: 1.9;
      }

      .summary-label {
        display: block;
        color: var(--color-muted);
        font-size: 0.82rem;
        font-weight: 700;
      }

      strong {
        display: block;
        color: var(--color-text);
        font-size: 1.05rem;
      }
    `,
  ],
})
export class CourseSummaryWidgetComponent implements OnInit {
  private store = inject(Store);
  courses$: Observable<Course[]> = this.store.select(selectAllCourses);

  ngOnInit(): void {
    this.store.dispatch(loadCourses());
  }
}
