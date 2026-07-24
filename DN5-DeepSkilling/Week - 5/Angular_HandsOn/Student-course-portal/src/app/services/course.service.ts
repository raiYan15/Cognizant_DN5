import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap, retry } from 'rxjs/operators';
import { Course } from '../models/course.model';

// HANDS-ON 6 (Step 58) + HANDS-ON 8 (Task 1 & 2):
// CourseService started as an in-memory store and was refactored to call a
// real REST API (json-server) using HttpClient. providedIn: 'root' makes it a
// singleton shared across the whole app.
@Injectable({ providedIn: 'root' })
export class CourseService {
  private http = inject(HttpClient);
  private readonly baseUrl = 'http://localhost:3000/courses';

  // GET all courses. HttpClient returns a cold Observable — nothing happens
  // until something subscribes (or the async pipe does it for us).
  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.baseUrl).pipe(
      // map: transform the response — drop any course with no credits.
      map((courses) => courses.filter((c) => c.credits > 0)),
      // retry: re-attempt a failed request up to 2 times before giving up.
      retry(2),
      // tap: side-effect only (logging). Preferred over logging inside map
      // because tap never mutates the stream — map is only for transforms.
      tap((courses) => console.log('Courses loaded:', courses.length)),
      // catchError: convert a low-level HTTP error into a friendly message.
      catchError((err) => {
        console.error(err);
        return throwError(() => new Error('Failed to load courses. Please try again.'));
      })
    );
  }

  getCourseById(id: number): Observable<Course> {
    return this.http.get<Course>(`${this.baseUrl}/${id}`);
  }

  // POST — create a new course. Omit<Course,'id'> because the server assigns the id.
  createCourse(course: Omit<Course, 'id'>): Observable<Course> {
    return this.http.post<Course>(this.baseUrl, course);
  }

  updateCourse(course: Course): Observable<Course> {
    return this.http.put<Course>(`${this.baseUrl}/${course.id}`, course);
  }

  deleteCourse(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
