import { Injectable } from '@angular/core';

// HANDS-ON 7 (Step 75): Minimal AuthService backing the auth guard.
// isLoggedIn is hardcoded for the exercise; flip it to false to see the guard
// redirect /profile and /enroll back to home.
@Injectable({ providedIn: 'root' })
export class AuthService {
  isLoggedIn = true;

  login(): void {
    this.isLoggedIn = true;
  }

  logout(): void {
    this.isLoggedIn = false;
  }
}
