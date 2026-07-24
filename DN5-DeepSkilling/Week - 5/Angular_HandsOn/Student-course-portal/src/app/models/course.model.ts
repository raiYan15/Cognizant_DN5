// HANDS-ON 6 (Step 59): Strongly-typed Course model shared across the whole app.
// Preferring an interface over `any` gives compile-time type checking everywhere.
export interface Course {
  id: number;
  name: string;
  code: string;
  credits: number;
  gradeStatus: 'passed' | 'failed' | 'pending';
}
