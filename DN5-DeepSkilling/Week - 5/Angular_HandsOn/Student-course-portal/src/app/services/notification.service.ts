import { Injectable, signal } from '@angular/core';

// HANDS-ON 6 (Step 67): NotificationService is provided at COMPONENT level inside
// NotificationComponent (not providedIn: 'root'). That creates a brand-new instance
// scoped to that component and its children, isolated from the rest of the app —
// unlike a root singleton which is shared everywhere.
@Injectable()
export class NotificationService {
  readonly messages = signal<string[]>([]);

  notify(message: string): void {
    this.messages.update((list) => [...list, message]);
  }

  clear(): void {
    this.messages.set([]);
  }
}
