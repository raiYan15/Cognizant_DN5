import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CourseState } from './course.reducer';

// HANDS-ON 9 (Step 95): Selectors are memoised — they only recompute when their
// input state slice actually changes. This is NgRx's key performance win.
export const selectCourseState = createFeatureSelector<CourseState>('course');

export const selectAllCourses = createSelector(selectCourseState, (state) => state.courses);

export const selectCoursesLoading = createSelector(selectCourseState, (state) => state.loading);

export const selectCoursesError = createSelector(selectCourseState, (state) => state.error);
