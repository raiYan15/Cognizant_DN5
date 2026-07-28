import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Course } from '../../models/course.model';
import { selectEnrolledCourses } from '../../store/enrollment/enrollment.selectors';

// HANDS-ON 6 (Step 66) + HANDS-ON 9: the profile page lists the student's enrolled
// courses. It derives them from a CROSS-SLICE selector joining course + enrollment.
@Component({
  selector: 'app-student-profile',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.css',
})
export class StudentProfileComponent {
  private store = inject(Store);
  enrolledCourses$: Observable<Course[]> = this.store.select(selectEnrolledCourses);

  student = { name: 'Raiyan Aziz', email: 'raiyan@example.com', gpa: 8.0 };
}
