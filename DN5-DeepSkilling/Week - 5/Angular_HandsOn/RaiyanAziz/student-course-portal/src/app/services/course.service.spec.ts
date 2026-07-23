import { TestBed } from '@angular/core/testing';
import {
  HttpTestingController,
  provideHttpClientTesting,
} from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';
import { CourseService } from './course.service';
import { Course } from '../models/course.model';

// HANDS-ON 10 (Task 2, Steps 106-108): service testing with the HTTP testing backend.
describe('CourseService', () => {
  let service: CourseService;
  let httpMock: HttpTestingController;
  const url = 'http://localhost:3000/courses';

  const mockCourses: Course[] = [
    { id: 1, name: 'Data Structures', code: 'CS101', credits: 4, gradeStatus: 'passed' },
    { id: 2, name: 'Databases', code: 'CS102', credits: 3, gradeStatus: 'pending' },
  ];

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CourseService, provideHttpClient(), provideHttpClientTesting()],
    });
    service = TestBed.inject(CourseService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    // Assert no unexpected outstanding requests.
    httpMock.verify();
  });

  it('should GET courses from the correct URL', () => {
    service.getCourses().subscribe((courses) => {
      expect(courses.length).toBe(2);
    });

    const req = httpMock.expectOne(url);
    expect(req.request.method).toBe('GET');
    req.flush(mockCourses);
  });

  it('should surface a friendly error message on failure', () => {
    let capturedError: Error | undefined;
    service.getCourses().subscribe({
      next: () => fail('expected an error'),
      error: (err: Error) => (capturedError = err),
    });

    // getCourses() uses retry(2) → 3 total attempts before catchError kicks in.
    for (let i = 0; i < 3; i++) {
      httpMock.expectOne(url).flush('boom', { status: 500, statusText: 'Server Error' });
    }

    expect(capturedError?.message).toContain('Failed to load courses');
  });
});
