import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { finalize } from 'rxjs';
import { LoadingService } from '../services/loading.service';

// HANDS-ON 8 (Step 91): Loading interceptor. Turns the global spinner on before the
// request goes out and off in finalize — which runs whether the request succeeds or
// fails, exactly like a try/catch/finally block.
export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loading = inject(LoadingService);
  loading.show();
  return next(req).pipe(finalize(() => loading.hide()));
};
