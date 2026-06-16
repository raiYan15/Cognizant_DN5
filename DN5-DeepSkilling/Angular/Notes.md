# Angular - Comprehensive Notes

## 📌 Overview

Angular is a comprehensive TypeScript-based framework for building robust, scalable, and maintainable single-page applications (SPAs). It provides a complete solution with components, services, routing, forms, and HTTP client for modern web development.

**Key Point:** Angular enables building enterprise-grade, feature-rich web applications with strong tooling and best practices.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand Angular architecture and components
- [ ] Master data binding and directives
- [ ] Implement services and dependency injection
- [ ] Build reactive forms with validation
- [ ] Implement routing and navigation
- [ ] Handle HTTP requests
- [ ] Understand state management basics
- [ ] Deploy Angular applications

---

## 📚 Core Concepts Learned

### 1. **Components & Templates**

```typescript
// Component definition
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {
  @Input() user: { name: string; email: string };
  @Output() userSelected = new EventEmitter<string>();
  
  isExpanded = false;
  
  constructor() {}
  
  ngOnInit(): void {
    // Component initialization
  }
  
  onSelectUser(): void {
    this.userSelected.emit(this.user.email);
  }
}
```

**Template:**
```html
<div class="user-card">
  <h3>{{ user.name }}</h3>
  <p>{{ user.email }}</p>
  
  <!-- Event binding -->
  <button (click)="onSelectUser()">Select</button>
  
  <!-- Property binding -->
  <div [class.expanded]="isExpanded">
    Expanded content
  </div>
</div>
```

### 2. **Data Binding**

```html
<!-- String interpolation -->
<h1>{{ title }}</h1>

<!-- Property binding -->
<img [src]="imageUrl">
<button [disabled]="!isValid">Submit</button>

<!-- Event binding -->
<button (click)="onClick()">Click me</button>
<input (change)="onInputChange($event)">

<!-- Two-way binding -->
<input [(ngModel)]="username">

<!-- Attribute binding -->
<button [attr.aria-label]="buttonLabel">Button</button>

<!-- Class binding -->
<div [ngClass]="{'active': isActive, 'disabled': !isEnabled}"></div>

<!-- Style binding -->
<div [ngStyle]="{'color': selectedColor, 'font-size': fontSize}"></div>
```

### 3. **Directives & Control Flow**

```html
<!-- *ngIf -->
<div *ngIf="isLoggedIn">
  Welcome back!
</div>

<!-- *ngFor -->
<ul>
  <li *ngFor="let item of items; let i = index">
    {{ i + 1 }}: {{ item.name }}
  </li>
</ul>

<!-- *ngSwitch -->
<div [ngSwitch]="status">
  <div *ngSwitchCase="'active'">Active</div>
  <div *ngSwitchCase="'inactive'">Inactive</div>
  <div *ngSwitchDefault>Unknown</div>
</div>

<!-- String filters (pipes) -->
<p>{{ date | date: 'dd/MM/yyyy' }}</p>
<p>{{ price | currency: 'USD' }}</p>
<p>{{ text | uppercase }}</p>

<!-- Custom pipe -->
<p>{{ text | customFilter }}</p>
```

### 4. **Services & Dependency Injection**

```typescript
// Service
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'  // Available application-wide
})
export class UserService {
  private apiUrl = 'https://api.example.com/users';
  
  constructor(private http: HttpClient) {}
  
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }
  
  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }
  
  createUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiUrl, user);
  }
  
  updateUser(id: number, user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/${id}`, user);
  }
  
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

// Component using service
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  
  constructor(private userService: UserService) {}
  
  ngOnInit(): void {
    this.loadUsers();
  }
  
  loadUsers(): void {
    this.userService.getUsers().subscribe(
      (data) => {
        this.users = data;
      },
      (error) => {
        console.error('Error loading users', error);
      }
    );
  }
}
```

### 5. **Reactive Forms**

```typescript
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html'
})
export class UserFormComponent implements OnInit {
  userForm: FormGroup;
  
  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      age: [null, [Validators.required, Validators.min(18)]],
      address: this.fb.group({
        street: ['', Validators.required],
        city: ['', Validators.required]
      })
    });
  }
  
  ngOnInit(): void {
    // Watch for changes
    this.userForm.valueChanges.subscribe(value => {
      console.log('Form value changed:', value);
    });
  }
  
  onSubmit(): void {
    if (this.userForm.valid) {
      console.log('Submitted:', this.userForm.value);
    }
  }
  
  get name() {
    return this.userForm.get('name');
  }
}
```

**Template:**
```html
<form [formGroup]="userForm" (ngSubmit)="onSubmit()">
  <input formControlName="name" placeholder="Name">
  <span *ngIf="name?.invalid && name?.touched">
    Name is required
  </span>
  
  <input formControlName="email" placeholder="Email">
  
  <div formGroupName="address">
    <input formControlName="street" placeholder="Street">
    <input formControlName="city" placeholder="City">
  </div>
  
  <button [disabled]="!userForm.valid">Submit</button>
</form>
```

### 6. **Routing**

```typescript
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'users', component: UserListComponent },
  { path: 'users/:id', component: UserDetailComponent, canActivate: [AuthGuard] },
  { path: 'not-found', component: NotFoundComponent },
  { path: '**', redirectTo: '/not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// Route Guard
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}
  
  canActivate(): boolean {
    if (this.authService.isLoggedIn()) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}
```

**Navigation:**
```html
<nav>
  <a routerLink="/home">Home</a>
  <a routerLink="/users">Users</a>
  <a [routerLink]="['/users', userId]">User Detail</a>
  <a routerLinkActive="active">Link</a>
</nav>

<router-outlet></router-outlet>
```

### 7. **RxJS & Observables**

```typescript
import { Observable, Subject, BehaviorSubject } from 'rxjs';
import { map, filter, switchMap, debounceTime } from 'rxjs/operators';

// Subject - multicast
const subject = new Subject<string>();

subject.subscribe(value => console.log('Subscriber 1:', value));
subject.subscribe(value => console.log('Subscriber 2:', value));

subject.next('Hello'); // Both receive

// BehaviorSubject - initial value
const behaviorSubject = new BehaviorSubject<string>('initial');
behaviorSubject.subscribe(value => console.log(value)); // Immediate

// Observable operators
this.userService.getUsers().pipe(
  map(users => users.filter(u => u.age > 18)),
  filter(user => user.active),
  switchMap(user => this.userService.getUserDetails(user.id))
).subscribe(
  details => console.log(details),
  error => console.error(error)
);

// Search with debounce
const searchTerm$ = new Subject<string>();
searchTerm$.pipe(
  debounceTime(300),
  switchMap(term => this.searchService.search(term))
).subscribe(results => this.results = results);
```

### 8. **Modules & Lazy Loading**

```typescript
// Feature module
@NgModule({
  declarations: [UserListComponent, UserDetailComponent],
  imports: [CommonModule, UserRoutingModule]
})
export class UserModule { }

// Lazy loading in routing
const routes: Routes = [
  {
    path: 'users',
    loadChildren: () => import('./modules/users/users.module')
      .then(m => m.UserModule)
  }
];
```

---

## 💻 Hands-On Exercises

### Exercise 1: Create Components
**Task:** Build a component with input and output properties

### Exercise 2: Services
**Task:** Create a service and inject it into components

### Exercise 3: Reactive Forms
**Task:** Build a complex form with validation

### Exercise 4: Routing
**Task:** Implement routing with guards

### Exercise 5: HTTP Calls
**Task:** Fetch and display data from an API

---

## 📝 Assignments

1. **Blog Application**
   - List posts, view details
   - Create/edit posts
   - Comment functionality
   - Authentication

2. **User Management Dashboard**
   - User list with pagination
   - Add/edit/delete users
   - Search and filter
   - Role-based access

3. **E-Commerce Frontend**
   - Product catalog
   - Shopping cart
   - Checkout process
   - Order tracking

---

## 🔗 References

### Official:
- [Angular Official Documentation](https://angular.io/docs)
- [Angular CLI](https://angular.io/cli)

### Tutorials:
- [Angular Tutorial](https://angular.io/guide/architecture)
- [Angular University](https://angular-university.io/)

### Tools:
- VS Code with Angular extensions
- Angular DevTools browser extension

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Components
- [ ] Data Binding
- [ ] Services
- [ ] Reactive Forms
- [ ] Routing
- [ ] HTTP Client
- [ ] RxJS Observables

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

---

**Last Updated:** June 2026
**Completion Status:** Not Started
