import { Routes } from '@angular/router';
import { EnrollmentFormComponent } from './enrollment-form.component';
import { ReactiveEnrollmentFormComponent } from './reactive-enrollment-form.component';
import { unsavedChangesGuard } from '../../guards/unsaved-changes.guard';

// HANDS-ON 7 (Step 73): lazy-loaded feature routes. The main app references these
// via loadChildren, so this chunk is only downloaded when /enroll is first visited.
export const ENROLLMENT_ROUTES: Routes = [
  { path: '', component: EnrollmentFormComponent },
  {
    path: 'reactive',
    component: ReactiveEnrollmentFormComponent,
    // HANDS-ON 7 (Step 77): protect against leaving with unsaved changes.
    canDeactivate: [unsavedChangesGuard],
  },
];
