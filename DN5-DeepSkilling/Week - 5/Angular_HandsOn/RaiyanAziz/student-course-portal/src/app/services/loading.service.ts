import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

// HANDS-ON 8 (Step 91): LoadingService exposes a global loading flag as a stream.
// The loading interceptor flips it on before each request and off in finalize;
// the root component binds a spinner to isLoading$ with the async pipe.
@Injectable({ providedIn: 'root' })
export class LoadingService {
  private readonly _isLoading = new BehaviorSubject<boolean>(false);
  readonly isLoading$ = this._isLoading.asObservable();

  // Track concurrent requests so the spinner only hides when ALL are done.
  private activeRequests = 0;

  show(): void {
    this.activeRequests++;
    this._isLoading.next(true);
  }

  hide(): void {
    this.activeRequests = Math.max(0, this.activeRequests - 1);
    if (this.activeRequests === 0) {
      this._isLoading.next(false);
    }
  }
}
