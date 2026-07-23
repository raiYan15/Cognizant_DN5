import { CanDeactivateFn } from '@angular/router';

// HANDS-ON 7 (Step 77): CanDeactivate guard. Any component that can block
// navigation implements this interface (e.g. a form that is dirty).
export interface CanComponentDeactivate {
  canDeactivate: () => boolean;
}

export const unsavedChangesGuard: CanDeactivateFn<CanComponentDeactivate> = (component) => {
  // If the component says it is safe to leave, allow it.
  if (!component.canDeactivate || component.canDeactivate()) {
    return true;
  }
  // Otherwise ask the user to confirm leaving with unsaved changes.
  return window.confirm('You have unsaved changes. Leave?');
};
