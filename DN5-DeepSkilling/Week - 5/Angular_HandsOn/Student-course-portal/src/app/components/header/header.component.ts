import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

// HANDS-ON 1 (Step 7): Header with the portal name and navigation links.
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  portalName = 'Student Course Portal';
}
