import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationService } from '../../services/notification.service';

// HANDS-ON 6 (Step 67): NotificationService is provided HERE, at the component
// level, via the providers array. This creates a NEW instance scoped only to this
// component and its children — separate from any other injector in the app. Use
// this when you want isolated per-component state instead of a shared singleton.
@Component({
  selector: 'app-notification',
  standalone: true,
  providers: [NotificationService],
  template: `
    <div class="notification-panel">
      <h4>Notifications</h4>
      <button (click)="add()">Add notification</button>
      <ul>
        <li *ngFor="let msg of notifications.messages()">{{ msg }}</li>
      </ul>
    </div>
  `,
  imports: [CommonModule],
})
export class NotificationComponent {
  protected notifications = inject(NotificationService);
  private counter = 0;

  add(): void {
    this.notifications.notify(`Notification #${++this.counter}`);
  }
}
