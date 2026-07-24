import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

// HANDS-ON 8 (Step 90): Global error-handling interceptor. Catches HTTP errors,
// reacts to specific status codes, then re-throws so callers can still handle them.
export const errorHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);

  return next(req).pipe(
    catchError((error) => {
      if (error.status === 401) {
        // Unauthorised — send the user back to the (login/home) page.
        router.navigate(['/']);
      } else if (error.status === 500) {
        // Server error — surface a global notification.
        console.error('Global error: a server error occurred. Please try again later.');
      }
      // Re-throw so component-level catchError/error callbacks still run.
      return throwError(() => error);
    })
  );
};
