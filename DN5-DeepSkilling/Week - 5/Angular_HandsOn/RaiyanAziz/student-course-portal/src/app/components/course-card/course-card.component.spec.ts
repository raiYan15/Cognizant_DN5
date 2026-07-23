import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { SimpleChange, SimpleChanges } from '@angular/core';
import { CourseCardComponent } from './course-card.component';
import { Course } from '../../models/course.model';

// HANDS-ON 10 (Task 1): unit tests for CourseCardComponent.
describe('CourseCardComponent', () => {
  let fixture: ComponentFixture<CourseCardComponent>;
  let component: CourseCardComponent;

  const mockCourse: Course = {
    id: 1,
    name: 'Data Structures',
    code: 'CS101',
    credits: 4,
    gradeStatus: 'passed',
  };

  beforeEach(async () => {
    // Standalone components are imported, not declared.
    await TestBed.configureTestingModule({
      imports: [CourseCardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CourseCardComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render the course name (@Input)', () => {
    component.course = mockCourse;
    fixture.detectChanges();
    const h3 = fixture.debugElement.query(By.css('h3')).nativeElement as HTMLElement;
    expect(h3.textContent).toContain('Data Structures');
  });

  it('should emit enrollRequested with the course id when Enroll is clicked (@Output)', () => {
    component.course = mockCourse;
    fixture.detectChanges();
    spyOn(component.enrollRequested, 'emit');

    const enrollBtn = fixture.debugElement.query(By.css('button.enroll')).nativeElement as HTMLButtonElement;
    enrollBtn.click();
    fixture.detectChanges();

    expect(component.enrollRequested.emit).toHaveBeenCalledWith(1);
  });

  it('should log previous and current values in ngOnChanges', () => {
    const logSpy = spyOn(console, 'log');
    component.course = mockCourse;
    const changes: SimpleChanges = {
      course: new SimpleChange(undefined, mockCourse, true),
    };
    component.ngOnChanges(changes);
    expect(logSpy).toHaveBeenCalled();
  });

  it('should show Unenroll when the course id is in enrolledIds', () => {
    component.course = mockCourse;
    component.enrolledIds = [1];
    fixture.detectChanges();
    const enrollBtn = fixture.debugElement.query(By.css('button.enroll')).nativeElement as HTMLButtonElement;
    expect(enrollBtn.textContent).toContain('Unenroll');
  });
});
