import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';

// HANDS-ON 4: Template-driven enrollment form. The form model lives in the template
// via ngModel + name attributes; the component just handles submit/reset.
@Component({
  selector: 'app-enrollment-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './enrollment-form.component.html',
  styleUrl: './enrollment-form.component.css',
})
export class EnrollmentFormComponent {
  submitted = false;

  model = {
    studentName: '',
    studentEmail: '',
    courseId: null as number | null,
    preferredSemester: 'Odd',
    agreeToTerms: false,
  };

  // HANDS-ON 4 (Step 40): log the whole value object and validity on submit.
  onSubmit(form: NgForm): void {
    console.log('form.value:', form.value);
    console.log('form.valid:', form.valid);
    if (form.valid) {
      this.submitted = true;
    }
  }
}
