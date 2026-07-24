import { HttpInterceptorFn } from '@angular/common/http';

// HANDS-ON 8 (Step 88): Functional auth interceptor. Clones every outgoing request
// and attaches a (mock) Authorization header. Requests are immutable, so we must
// clone rather than mutate.
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const cloned = req.clone({
    setHeaders: { Authorization: 'Bearer mock-token-12345' },
  });
  return next(cloned);
};
