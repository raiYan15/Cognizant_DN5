import { Pipe, PipeTransform } from '@angular/core';

// HANDS-ON 3 (Step 35): Custom pipe. Turns a credits number into a readable label.
// Edge cases (null / 0) return 'No Credits'. Pure by default — only re-runs when
// the input reference changes.
@Pipe({
  name: 'creditLabel',
})
export class CreditLabelPipe implements PipeTransform {
  transform(credits: number | null | undefined): string {
    if (credits === null || credits === undefined || credits === 0) {
      return 'No Credits';
    }
    return credits === 1 ? '1 Credit' : `${credits} Credits`;
  }
}
