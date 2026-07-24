import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Observable, of } from 'rxjs';
import { switchMap, catchError } from 'rxjs/operators';
import { Course } from '../../models/course.model';
import { Student } from '../../models/student.model';
import { CourseService } from '../../services/course.service';
import { EnrollmentService } from '../../services/enrollment.service';

// HANDS-ON 7 (Step 69) + HANDS-ON 8 (Step 87): course detail read from the :id
// route param, then a dependent HTTP call (switchMap) for its enrolled students.
@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './course-detail.component.html',
  styleUrl: './course-detail.component.css',
})
export class CourseDetailComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private courseService = inject(CourseService);
  private enrollmentService = inject(EnrollmentService);

  course$!: Observable<Course>;
  students$!: Observable<Student[]>;
  errorMessage = '';

  ngOnInit(): void {
    // snapshot is fine here because we navigate to a fresh component each time.
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.course$ = this.courseService.getCourseById(id).pipe(
      catchError((err) => {
        this.errorMessage = err.message ?? 'Could not load course.';
        return of({} as Course);
      })
    );

    // HANDS-ON 8 (Step 87): switchMap cancels the previous inner request if the id
    // changes before the first completes — preventing out-of-order responses.
    this.students$ = of(id).pipe(
      switchMap((courseId) => this.enrollmentService.getStudentsByCourse(courseId)),
      catchError(() => of([] as Student[]))
    );
  }
}
