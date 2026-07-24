import { createFeatureSelector, createSelector } from '@ngrx/store';
import { EnrollmentState } from './enrollment.reducer';
import { selectAllCourses } from '../course/course.selectors';

// HANDS-ON 9 (Step 99): Enrollment selectors, including a CROSS-SLICE selector
// that joins the course slice and the enrollment slice to derive the full list
// of enrolled Course objects — without duplicating course data in this slice.
export const selectEnrollmentState = createFeatureSelector<EnrollmentState>('enrollment');

export const selectEnrolledIds = createSelector(
  selectEnrollmentState,
  (state) => state.enrolledCourseIds
);

export const selectEnrolledCourses = createSelector(
  selectAllCourses,
  selectEnrolledIds,
  (courses, ids) => courses.filter((c) => ids.includes(c.id))
);
