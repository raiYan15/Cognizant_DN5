import { Directive, ElementRef, HostListener, Input, inject } from '@angular/core';

// HANDS-ON 3 (Steps 33/37): Custom attribute directive. Highlights the host
// element on hover. @HostListener wires up DOM events with automatic cleanup.
// The colour is configurable via the directive's own input (@Input appHighlight).
@Directive({
  selector: '[appHighlight]',
})
export class HighlightDirective {
  private el = inject(ElementRef<HTMLElement>);

  // Bound as the directive's main input: <div appHighlight="lightblue">
  @Input() appHighlight = 'yellow';

  @HostListener('mouseenter')
  onMouseEnter(): void {
    this.el.nativeElement.style.backgroundColor = this.appHighlight || 'yellow';
  }

  @HostListener('mouseleave')
  onMouseLeave(): void {
    this.el.nativeElement.style.backgroundColor = '';
  }
}
