# JavaScript - Comprehensive Notes

## 📌 Overview

JavaScript is a versatile, high-level programming language that powers interactive web applications. ES6+ (ECMAScript 2015 and beyond) introduced significant improvements including arrow functions, classes, modules, and async/await, making JavaScript a powerful language for both client-side and server-side development.

**Key Point:** JavaScript brings interactivity and logic to web applications, enabling dynamic user experiences.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Master JavaScript fundamentals and ES6+ features
- [ ] Understand DOM manipulation and events
- [ ] Work with asynchronous programming (Promises, async/await)
- [ ] Use modern debugging techniques
- [ ] Build interactive web applications
- [ ] Understand event-driven programming

---

## 📚 Core Concepts Learned

### 1. **JavaScript Fundamentals**

**Variables & Data Types:**
```javascript
// Variables (var, let, const)
let name = "John";           // Block-scoped, mutable
const age = 30;              // Block-scoped, immutable
var city = "NYC";            // Function-scoped (legacy)

// Data types
let string = "Hello";
let number = 42;
let boolean = true;
let undef = undefined;
let nullValue = null;
let symbol = Symbol('unique');
let obj = {};
let arr = [];
```

**Operators:**
```javascript
// Arithmetic
let sum = 10 + 5;            // 15
let product = 10 * 5;        // 50

// Comparison
10 == "10"                   // true (loose equality)
10 === "10"                  // false (strict equality)

// Logical
true && false                // false
true || false                // true
!true                        // false

// Ternary
let status = age > 18 ? "adult" : "minor";

// Nullish coalescing
let value = null ?? "default";  // "default"

// Optional chaining
let email = user?.email;
```

### 2. **Functions & Arrow Functions**

```javascript
// Function declaration
function greet(name) {
    return `Hello, ${name}`;
}

// Function expression
const add = function(a, b) {
    return a + b;
};

// Arrow function
const multiply = (a, b) => a * b;

// Arrow function with multiple statements
const divide = (a, b) => {
    if (b === 0) return 0;
    return a / b;
};

// Default parameters
const greet2 = (name = "Guest") => `Hello, ${name}`;

// Rest parameters
const sum = (...numbers) => numbers.reduce((a, b) => a + b, 0);
```

### 3. **Objects & Arrays**

**Objects:**
```javascript
// Object literal
const person = {
    name: "John",
    age: 30,
    greet() {
        return `Hi, I'm ${this.name}`;
    }
};

// Destructuring
const { name, age } = person;

// Spread operator
const updated = { ...person, age: 31 };

// Object methods
Object.keys(person);              // ['name', 'age', 'greet']
Object.values(person);            // ['John', 30, function]
Object.entries(person);           // [['name', 'John'], ...]
```

**Arrays:**
```javascript
const arr = [1, 2, 3, 4, 5];

// Array methods
arr.map(x => x * 2);              // [2, 4, 6, 8, 10]
arr.filter(x => x > 2);           // [3, 4, 5]
arr.reduce((sum, x) => sum + x, 0); // 15
arr.find(x => x > 3);             // 4
arr.includes(3);                  // true

// Destructuring
const [first, second, ...rest] = arr;
```

### 4. **Asynchronous Programming**

**Promises:**
```javascript
const promise = new Promise((resolve, reject) => {
    setTimeout(() => {
        resolve("Success!");
    }, 1000);
});

promise
    .then(result => console.log(result))
    .catch(error => console.error(error))
    .finally(() => console.log("Done"));
```

**Async/Await:**
```javascript
async function fetchData() {
    try {
        const response = await fetch('https://api.example.com/data');
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error:', error);
    }
}
```

### 5. **DOM Manipulation**

**Selecting Elements:**
```javascript
// Single element
const element = document.getElementById('my-id');
const element2 = document.querySelector('.my-class');

// Multiple elements
const elements = document.querySelectorAll('.item');
const elements2 = document.getElementsByClassName('item');
```

**Modifying Elements:**
```javascript
// Text & HTML
element.textContent = "New text";
element.innerHTML = "<p>New content</p>";

// Attributes
element.setAttribute('data-id', '123');
element.getAttribute('data-id');
element.removeAttribute('data-id');

// Classes
element.classList.add('active');
element.classList.remove('active');
element.classList.toggle('active');

// Styles
element.style.color = 'red';
element.style.backgroundColor = 'blue';
```

### 6. **Event Handling**

```javascript
// Add event listener
button.addEventListener('click', (event) => {
    console.log('Button clicked');
});

// Common events
document.addEventListener('DOMContentLoaded', () => {
    console.log('Page loaded');
});

input.addEventListener('change', (e) => {
    console.log('Value:', e.target.value);
});

window.addEventListener('scroll', () => {
    console.log('Page scrolled');
});
```

### 7. **Classes & OOP**

```javascript
class Animal {
    constructor(name) {
        this.name = name;
    }

    speak() {
        console.log(`${this.name} makes a sound`);
    }
}

class Dog extends Animal {
    speak() {
        console.log(`${this.name} barks`);
    }
}

const dog = new Dog('Rex');
dog.speak();  // Rex barks
```

### 8. **Modules**

```javascript
// Export
export const greet = (name) => `Hello, ${name}`;
export default class User { }

// Import
import User, { greet } from './user.js';
```

---

## 💻 Hands-On Exercises

### Exercise 1: Calculator App
**Task:** Build a calculator that performs basic operations

### Exercise 2: Todo List
**Task:** Create a functional todo list with add, delete, mark complete

### Exercise 3: API Fetch
**Task:** Fetch data from an API and display it

### Exercise 4: Form Validation
**Task:** Build form validation with custom rules

### Exercise 5: Interactive Game
**Task:** Create a simple game (Rock-Paper-Scissors or similar)

---

## 📝 Assignments

1. **Weather App**
   - Fetch weather data from an API
   - Display current weather and forecast
   - Search by city name
   - Save favorites to local storage

2. **E-Commerce Product Browser**
   - Display products from an API
   - Filter by category
   - Add to cart functionality
   - Persist cart in local storage

3. **Real-Time Chat Interface**
   - Build a chat UI (without backend initially)
   - Message timestamps
   - User typing indicator
   - Message history

---

## 🔗 References

### Official Documentation:
- [MDN: JavaScript Reference](https://developer.mozilla.org/en-US/docs/Web/JavaScript)
- [JavaScript.info](https://javascript.info/)
- [ECMAScript Specification](https://tc39.es/ecma262/)

### Tutorials:
- [freeCodeCamp JavaScript Course](https://www.freecodecamp.org/)
- [Codecademy JavaScript](https://www.codecademy.com/learn/learn-javascript)
- [Eloquent JavaScript Book](https://eloquentjavascript.net/)

### Tools:
- [JSFiddle](https://jsfiddle.net/) - Online code editor
- [CodePen](https://codepen.io/) - Community platform

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Fundamentals
- [ ] Functions
- [ ] Objects & Arrays
- [ ] Asynchronous Programming
- [ ] DOM Manipulation
- [ ] Events
- [ ] Classes

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

**Projects Completed:**
1. ___________
2. ___________
3. ___________

**Next Steps:**
- Move to SQL or continue with frameworks
- Learn JavaScript frameworks (React, Vue, Angular)

---

**Last Updated:** June 2026
**Completion Status:** Not Started
