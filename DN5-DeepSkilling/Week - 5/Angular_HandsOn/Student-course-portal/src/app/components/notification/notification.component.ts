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
      <div class="panel-header">
        <div>
          <span class="panel-kicker">Updates</span>
          <h4>Notifications</h4>
        </div>
        <button type="button" (click)="add()">
          <svg aria-hidden="true" viewBox="0 0 24 24">
            <path d="M12 5v14M5 12h14" />
          </svg>
          Add
        </button>
      </div>

      <ul *ngIf="notifications.messages().length; else emptyNotifications">
        <li *ngFor="let msg of notifications.messages()">{{ msg }}</li>
      </ul>

      <ng-template #emptyNotifications>
        <div class="empty-notifications">
          <span aria-hidden="true">
            <svg viewBox="0 0 24 24">
              <path d="M6 8a6 6 0 0 1 12 0c0 7 3 7 3 9H3c0-2 3-2 3-9" />
              <path d="M10 21h4" />
            </svg>
          </span>
          <p>No notifications yet.</p>
        </div>
      </ng-template>
    </div>
  `,
  imports: [CommonModule],
  styles: [
    `
      .notification-panel {
        padding: 1rem;
        background: var(--color-surface);
        border: 1px solid var(--color-border);
        border-radius: var(--radius-card);
        box-shadow: var(--shadow-card);
      }

      .panel-header {
        display: flex;
        align-items: center;
        justify-content: space-between;
        gap: 1rem;
      }

      .panel-kicker {
        display: block;
        color: var(--color-accent);
        font-size: 0.75rem;
        font-weight: 800;
        letter-spacing: 0;
        text-transform: uppercase;
      }

      h4 {
        margin: 0.15rem 0 0;
        color: var(--color-text);
        font-size: 1.1rem;
      }

      button {
        display: inline-flex;
        align-items: center;
        gap: 0.45rem;
        min-height: 2.35rem;
        padding: 0.5rem 0.8rem;
        color: #fff;
        background: var(--color-primary);
        border: 1px solid var(--color-primary);
        border-radius: 8px;
        font-weight: 800;
        cursor: pointer;
        box-shadow: 0 9px 16px rgba(29, 78, 216, 0.18);
      }

      button:hover {
        background: var(--color-primary-dark);
        border-color: var(--color-primary-dark);
        transform: translateY(-1px);
      }

      button svg,
      .empty-notifications svg {
        width: 1rem;
        height: 1rem;
        fill: none;
        stroke: currentColor;
        stroke-linecap: round;
        stroke-linejoin: round;
        stroke-width: 2;
      }

      ul {
        display: grid;
        gap: 0.55rem;
        margin: 1rem 0 0;
        padding: 0;
        list-style: none;
      }

      li {
        padding: 0.7rem 0.8rem;
        color: var(--color-text);
        background: var(--color-surface-soft);
        border: 1px solid var(--color-border);
        border-radius: 8px;
      }

      .empty-notifications {
        display: flex;
        align-items: center;
        gap: 0.8rem;
        margin-top: 1rem;
        padding: 0.9rem;
        color: var(--color-muted);
        background: var(--color-surface-soft);
        border-radius: 8px;
      }

      .empty-notifications span {
        display: inline-grid;
        width: 2.25rem;
        height: 2.25rem;
        place-items: center;
        color: var(--color-primary);
        background: var(--color-primary-soft);
        border-radius: 8px;
      }

      .empty-notifications p {
        margin: 0;
        font-weight: 700;
      }
    `,
  ],
})
export class NotificationComponent {
  protected notifications = inject(NotificationService);
  private counter = 0;

  add(): void {
    this.notifications.notify(`Notification #${++this.counter}`);
  }
}
