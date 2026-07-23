import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { HighlightDirective } from '../../directives/highlight.directive';
import { CreditLabelPipe } from '../../pipes/credit-label.pipe';
import { Course } from '../../models/course.model';

// HANDS-ON 2/3/6/9: The course card is the most reused component in the portal.
// It renders a single course (@Input), emits an enroll request (@Output), toggles
// its own expanded state, and shows a grade badge via *ngSwitch.
@Component({
  selector: 'app-course-card',
  standalone: true,
  imports: [CommonModule, HighlightDirective, CreditLabelPipe],
  templateUrl: './course-card.component.html',
  styleUrl: './course-card.component.css',
})
export class CourseCardComponent implements OnChanges {
  // HANDS-ON 2 (Step 20): data flows DOWN via @Input.
  @Input() course!: Course;

  // Enrolled ids passed down from the parent (which reads them from the store),
  // so this card never needs to inject the Store itself.
  @Input() enrolledIds: number[] = [];

  // HANDS-ON 2 (Step 21): events bubble UP via @Output. Strongly typed payload.
  @Output() enrollRequested = new EventEmitter<number>();

  // HANDS-ON 3 (Step 31): local UI state toggled by the "Show Details" button.
  isExpanded = false;

  get isEnrolled(): boolean {
    return this.course ? this.enrolledIds.includes(this.course.id) : false;
  }

  // HANDS-ON 3 (Step 32): a getter keeps the template clean — the class-logic
  // lives in TypeScript instead of a long inline object expression.
  get cardClasses(): Record<string, boolean> {
    return {
      'card--enrolled': this.isEnrolled,
      'card--full': (this.course?.credits ?? 0) >= 4,
      expanded: this.isExpanded,
    };
  }

  // HANDS-ON 3 (Step 30): left border colour driven by grade status.
  get borderColor(): string {
    switch (this.course?.gradeStatus) {
      case 'passed':
        return 'green';
      case 'failed':
        return 'red';
      default:
        return 'grey';
    }
  }

  // HANDS-ON 2 (Step 18): ngOnChanges fires whenever an @Input reference changes.
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['course']) {
      console.log(
        'CourseCard ngOnChanges — previous:',
        changes['course'].previousValue,
        'current:',
        changes['course'].currentValue
      );
    }
  }

  toggleExpand(): void {
    this.isExpanded = !this.isExpanded;
  }

  // Button click both emits up to the parent (@Output) and is the single place
  // the enroll intent originates from.
  onEnroll(): void {
    this.enrollRequested.emit(this.course.id);
  }
}
