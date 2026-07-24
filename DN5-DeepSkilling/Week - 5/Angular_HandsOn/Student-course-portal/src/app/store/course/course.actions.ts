import { createAction, props } from '@ngrx/store';
import { Course } from '../../models/course.model';

// HANDS-ON 9 (Step 93): Course actions. The '[Course]' prefix groups actions by
// feature so the Redux DevTools timeline stays readable.
export const loadCourses = createAction('[Course] Load Courses');

export const loadCoursesSuccess = createAction(
  '[Course] Load Courses Success',
  props<{ courses: Course[] }>()
);

export const loadCoursesFailure = createAction(
  '[Course] Load Courses Failure',
  props<{ error: string }>()
);
