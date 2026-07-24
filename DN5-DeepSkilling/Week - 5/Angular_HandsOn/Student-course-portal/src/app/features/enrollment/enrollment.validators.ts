import { AbstractControl, ValidationErrors } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { delay, map } from 'rxjs/operators';

// HANDS-ON 5 (Step 53): custom SYNC validator — reject course codes starting 'XX'.
export function noCourseCode(control: AbstractControl): ValidationErrors | null {
  const value = control.value;
  if (typeof value === 'string' && value.startsWith('XX')) {
    return { noCourseCode: true };
  }
  return null;
}

// HANDS-ON 5 (Step 55): custom ASYNC validator — simulates an API check.
// Async validators run only after sync validators pass, and return a Promise or
// Observable of ValidationErrors | null.
export function simulateEmailCheck(
  control: AbstractControl
): Observable<ValidationErrors | null> {
  return of(control.value).pipe(
    delay(800),
    map((email: string) => (email && email.includes('test@') ? { emailTaken: true } : null))
  );
}
