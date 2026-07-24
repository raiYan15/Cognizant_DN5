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
      <strong>Total courses:</strong> {{ (courses$ | async)?.length ?? 0 }}
    </div>
  `,
  styles: [
    `.summary { padding: 0.5rem 0.75rem; background: #eef2ff; border-radius: 6px; }`,
  ],
})
export class CourseSummaryWidgetComponent implements OnInit {
  private store = inject(Store);
  courses$: Observable<Course[]> = this.store.select(selectAllCourses);

  ngOnInit(): void {
    this.store.dispatch(loadCourses());
  }
}
