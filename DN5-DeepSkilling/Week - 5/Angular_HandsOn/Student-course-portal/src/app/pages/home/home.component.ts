import { Component, OnInit, OnDestroy, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Course } from '../../models/course.model';
import { loadCourses } from '../../store/course/course.actions';
import { selectAllCourses } from '../../store/course/course.selectors';
import { selectEnrolledIds } from '../../store/enrollment/enrollment.selectors';
import { NotificationComponent } from '../../components/notification/notification.component';
import { CourseSummaryWidgetComponent } from '../../components/course-summary-widget/course-summary-widget.component';

// HANDS-ON 1 (Step 8) + HANDS-ON 2 (Tasks 1 & 2): dashboard with all four binding
// types and lifecycle hooks.
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, NotificationComponent, CourseSummaryWidgetComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit, OnDestroy {
  private store = inject(Store);

  // Interpolation source.
  portalName = 'Student Course Portal';
  // Property-binding source (controls the button's disabled state).
  isPortalActive = true;
  // Set by event binding.
  message = '';
  // Two-way binding target.
  searchTerm = '';

  courses$: Observable<Course[]> = this.store.select(selectAllCourses);
  enrolledIds$: Observable<number[]> = this.store.select(selectEnrolledIds);

  // Static stat used in the stats row.
  gpa = 3.8;

  // HANDS-ON 2 (Step 13): event-binding handler.
  onEnrollClick(): void {
    this.message = 'Enrollment opened!';
  }

  /*
   * HANDS-ON 2 (Step 15): [property]="expr" is ONE-WAY — data flows from the
   * component to the DOM only. [(ngModel)]="prop" is TWO-WAY — it is sugar for
   * [ngModel]="prop" (ngModelChange)="prop = $event", so the DOM can also push
   * changes back into the component.
   */

  // HANDS-ON 2 (Step 16): ngOnInit is the right place to fetch data (inputs are
  // set by now) — unlike the constructor which runs before inputs exist.
  ngOnInit(): void {
    this.store.dispatch(loadCourses());
    console.log('HomeComponent initialised — courses loaded');
  }

  // HANDS-ON 2 (Step 17): clean-up hook — unsubscribe / clear timers here.
  ngOnDestroy(): void {
    console.log('HomeComponent destroyed');
  }
}
