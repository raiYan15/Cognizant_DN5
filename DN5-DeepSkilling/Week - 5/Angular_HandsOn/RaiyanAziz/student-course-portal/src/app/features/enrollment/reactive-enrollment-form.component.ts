import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormArray,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CanComponentDeactivate } from '../../guards/unsaved-changes.guard';
import { noCourseCode, simulateEmailCheck } from './enrollment.validators';

// HANDS-ON 5: Reactive enrollment form — the whole form model lives in TypeScript,
// making it fully unit-testable without a DOM. Also implements CanComponentDeactivate
// (HANDS-ON 7, Step 77) so the unsaved-changes guard can protect it.
@Component({
  selector: 'app-reactive-enrollment-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-enrollment-form.component.html',
  styleUrl: './enrollment-form.component.css',
})
export class ReactiveEnrollmentFormComponent implements OnInit, CanComponentDeactivate {
  private fb = inject(FormBuilder);
  enrollForm!: FormGroup;

  ngOnInit(): void {
    this.enrollForm = this.fb.group({
      studentName: ['', [Validators.required, Validators.minLength(3)]],
      // async validator passed as the 3rd argument.
      studentEmail: this.fb.control(
        '',
        [Validators.required, Validators.email],
        [simulateEmailCheck]
      ),
      courseId: ['', [Validators.required, noCourseCode]],
      preferredSemester: ['Odd', Validators.required],
      agreeToTerms: [false, Validators.requiredTrue],
      additionalCourses: this.fb.array([]),
    });
  }

  // HANDS-ON 5 (Step 57): a typed getter is cleaner and safer than casting to
  // FormArray inline in the template on every change-detection cycle.
  get additionalCourses(): FormArray {
    return this.enrollForm.get('additionalCourses') as FormArray;
  }

  addCourse(): void {
    this.additionalCourses.push(new FormControl('', Validators.required));
  }

  removeCourse(index: number): void {
    this.additionalCourses.removeAt(index);
  }

  onSubmit(): void {
    // HANDS-ON 5 (Step 52): value excludes disabled controls; getRawValue includes them.
    console.log('enrollForm.value:', this.enrollForm.value);
    console.log('enrollForm.getRawValue():', this.enrollForm.getRawValue());
  }

  // HANDS-ON 7 (Step 77): the guard calls this — safe to leave only if not dirty.
  canDeactivate(): boolean {
    return !this.enrollForm.dirty;
  }
}
