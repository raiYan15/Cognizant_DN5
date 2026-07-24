import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Course } from '../../models/course.model';
import { CourseCardComponent } from '../../components/course-card/course-card.component';
import { HighlightDirective } from '../../directives/highlight.directive';
import { loadCourses } from '../../store/course/course.actions';
import {
  selectAllCourses,
  selectCoursesLoading,
  selectCoursesError,
} from '../../store/course/course.selectors';
import { enrollInCourse, unenrollFromCourse } from '../../store/enrollment/enrollment.actions';
import { selectEnrolledIds } from '../../store/enrollment/enrollment.selectors';

// HANDS-ON 3/7/8/9: The course listing page. It reads courses from the NgRx store
// (async pipe), supports a search query param, and navigates to a course detail.
@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, FormsModule, CourseCardComponent, HighlightDirective],
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.css',
})
export class CourseListComponent implements OnInit {
  private store = inject(Store);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  courses$: Observable<Course[]> = this.store.select(selectAllCourses);
  loading$: Observable<boolean> = this.store.select(selectCoursesLoading);
  error$: Observable<string | null> = this.store.select(selectCoursesError);
  enrolledIds$: Observable<number[]> = this.store.select(selectEnrolledIds);

  searchTerm = '';

  ngOnInit(): void {
    // HANDS-ON 9 (Step 96): dispatch the load action; the effect does the HTTP call.
    this.store.dispatch(loadCourses());

    // HANDS-ON 7 (Step 71): read the search query param back out of the URL.
    const search = this.route.snapshot.queryParamMap.get('search');
    if (search) {
      this.searchTerm = search;
    }
  }

  // HANDS-ON 3 (Step 26): trackBy lets Angular update only the changed rows
  // instead of re-rendering the whole list on every array change.
  trackByCourseId(_index: number, course: Course): number {
    return course.id;
  }

  // HANDS-ON 7 (Step 70): navigate to the detail route for a course.
  openCourse(course: Course): void {
    this.router.navigate(['courses', course.id]);
  }

  // HANDS-ON 7 (Step 71): push the search term into the URL as a query param.
  onSearch(): void {
    this.router.navigate(['courses'], { queryParams: { search: this.searchTerm } });
  }

  // HANDS-ON 9 (Step 100): enroll/unenroll toggles the enrollment slice.
  onEnroll(courseId: number, enrolledIds: number[]): void {
    if (enrolledIds.includes(courseId)) {
      this.store.dispatch(unenrollFromCourse({ courseId }));
    } else {
      this.store.dispatch(enrollInCourse({ courseId }));
    }
    console.log('Enrolling in course: ' + courseId);
  }
}
