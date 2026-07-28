import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Course } from '../models/course.model';
import { Student } from '../models/student.model';
import { CourseService } from './course.service';

// HANDS-ON 6 (Step 63/64): EnrollmentService keeps track of which course ids the
// student is enrolled in. It injects CourseService (service-to-service injection)
// to resolve ids into full Course objects — a layered architecture like a backend
// service layer.
@Injectable({ providedIn: 'root' })
export class EnrollmentService {
  // Service-to-service injection demonstrates the DI hierarchy.
  private courseService = inject(CourseService);
  private http = inject(HttpClient);

  private enrolledCourseIds: string[] = [];

  enroll(courseId: string): void {
    if (!this.isEnrolled(courseId)) {
      this.enrolledCourseIds.push(courseId);
    }
  }

  unenroll(courseId: string): void {
    this.enrolledCourseIds = this.enrolledCourseIds.filter((id) => id !== courseId);
  }

  isEnrolled(courseId: string): boolean {
    return this.enrolledCourseIds.includes(courseId);
  }

  getEnrolledIds(): string[] {
    return [...this.enrolledCourseIds];
  }

  // Uses CourseService internally to turn ids into full Course objects.
  getEnrolledCourses(): Observable<Course[]> {
    return this.courseService.getCourses().pipe(
      switchMap((courses) => of(courses.filter((c) => this.enrolledCourseIds.includes(c.id))))
    );
  }

  getStudentsByCourse(courseId: string): Observable<Student[]> {
    return this.http.get<Student[]>(`http://localhost:3000/enrollments?courseId=${courseId}`);
  }
}
