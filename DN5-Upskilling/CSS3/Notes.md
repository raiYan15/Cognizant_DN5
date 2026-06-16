# CSS3 - Comprehensive Notes

## 📌 Overview

CSS3 (Cascading Style Sheets Level 3) is used for styling and layout of web documents. It introduces modern layout techniques like Flexbox and Grid, animations, transitions, and responsive design capabilities that enable developers to create beautiful, responsive web applications.

**Key Point:** CSS3 is about modern layout, responsive design, and creating visually stunning web experiences.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Master CSS3 selectors and specificity
- [ ] Understand Flexbox layout model
- [ ] Master CSS Grid for complex layouts
- [ ] Create responsive designs with media queries
- [ ] Implement animations and transitions
- [ ] Use modern CSS techniques (custom properties, etc.)

---

## 📚 Core Concepts Learned

### 1. **CSS3 Fundamentals**

**Three Ways to Apply CSS:**
```html
<!-- Inline -->
<p style="color: blue;">Text</p>

<!-- Internal -->
<style>
    p { color: blue; }
</style>

<!-- External (recommended) -->
<link rel="stylesheet" href="styles.css">
```

**CSS Selectors:**
```css
/* Element selector */
p { }

/* Class selector */
.classname { }

/* ID selector */
#idname { }

/* Attribute selector */
input[type="text"] { }

/* Pseudo-classes */
a:hover { }
li:first-child { }
p:nth-child(2n) { }

/* Pseudo-elements */
p::first-letter { }
p::before { }

/* Combinators */
div > p { }        /* Child */
div p { }          /* Descendant */
div + p { }        /* Adjacent sibling */
```

**Specificity Order:**
```
!important > Inline > ID > Class > Element
```

### 2. **Flexbox Layout**

Flexbox is a one-dimensional layout model for arranging items in rows or columns.

```css
.container {
    display: flex;
    flex-direction: row;           /* row, column, row-reverse */
    justify-content: center;       /* Main axis alignment */
    align-items: center;           /* Cross axis alignment */
    gap: 20px;                     /* Space between items */
    flex-wrap: wrap;               /* Wrap items */
}

.item {
    flex: 1;                       /* Grow and shrink equally */
    flex-basis: 200px;             /* Base size */
    flex-grow: 1;                  /* Growth factor */
    flex-shrink: 1;                /* Shrink factor */
}
```

**Common Flexbox Properties:**
- `justify-content:` flex-start, center, flex-end, space-between, space-around
- `align-items:` flex-start, center, flex-end, stretch
- `flex-direction:` row, column, row-reverse, column-reverse
- `flex-wrap:` wrap, nowrap, wrap-reverse

### 3. **CSS Grid Layout**

CSS Grid is a two-dimensional layout system for arranging complex layouts.

```css
.grid-container {
    display: grid;
    grid-template-columns: repeat(3, 1fr);  /* 3 equal columns */
    grid-template-rows: auto 1fr auto;      /* Rows */
    gap: 20px;
    grid-auto-flow: dense;
}

.grid-item {
    grid-column: 1 / 3;            /* Span from column 1 to 3 */
    grid-row: 2 / 4;               /* Span from row 2 to 4 */
}
```

**Grid Template:**
```css
.grid {
    display: grid;
    grid-template-columns: 
        [sidebar] 250px 
        [content] 1fr;
    grid-template-rows: 
        [header] 60px 
        [main] auto 
        [footer] 60px;
}
```

### 4. **Responsive Design**

**Mobile-First Approach:**
```css
/* Mobile styles (default) */
.container {
    width: 100%;
    display: block;
}

/* Tablet */
@media (min-width: 768px) {
    .container {
        width: 750px;
    }
}

/* Desktop */
@media (min-width: 1024px) {
    .container {
        width: 1000px;
        display: grid;
    }
}

/* Large screens */
@media (min-width: 1440px) {
    .container {
        width: 1400px;
    }
}
```

**Viewport Meta Tag (HTML):**
```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```

### 5. **Animations & Transitions**

**Transitions:**
```css
.box {
    background: blue;
    transition: background 0.3s ease;
}

.box:hover {
    background: red;
}
```

**Animations:**
```css
@keyframes slideIn {
    0% {
        transform: translateX(-100%);
        opacity: 0;
    }
    50% {
        opacity: 0.5;
    }
    100% {
        transform: translateX(0);
        opacity: 1;
    }
}

.slide {
    animation: slideIn 1s ease-in-out forwards;
    animation-delay: 0.5s;
    animation-iteration-count: infinite;
}
```

### 6. **Advanced CSS Features**

**Custom Properties (CSS Variables):**
```css
:root {
    --primary-color: #3498db;
    --spacing: 16px;
    --border-radius: 4px;
}

.button {
    background: var(--primary-color);
    padding: var(--spacing);
    border-radius: var(--border-radius);
}
```

**Transform:**
```css
.box {
    transform: translate(10px, 20px) rotate(45deg) scale(1.5);
}
```

**Gradients:**
```css
.gradient-linear {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

.gradient-radial {
    background: radial-gradient(circle, #667eea, #764ba2);
}
```

**Shadows:**
```css
.box {
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3);
    text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);
}
```

---

## 💻 Hands-On Exercises

### Exercise 1: Flexbox Layout
**Task:** Create a navigation bar using Flexbox

### Exercise 2: CSS Grid Layout
**Task:** Build a responsive dashboard layout with CSS Grid

### Exercise 3: Responsive Design
**Task:** Create a mobile-responsive website

### Exercise 4: Animations
**Task:** Build animated UI components (buttons, cards)

### Exercise 5: Advanced Styling
**Task:** Create a styled component library

---

## 📝 Assignments

1. **Responsive Website**
   - Create a 3-page website
   - Mobile, tablet, and desktop responsive
   - Use Flexbox and Grid
   - Include animations

2. **UI Component Library**
   - Build reusable CSS components
   - Include buttons, cards, forms
   - Use CSS variables
   - Fully responsive

3. **Interactive Landing Page**
   - Modern design with animations
   - Smooth scrolling
   - Hover effects
   - Call-to-action buttons

---

## 🔗 References

### Official Documentation:
- [MDN: CSS Reference](https://developer.mozilla.org/en-US/docs/Web/CSS)
- [CSS Tricks: Flexbox](https://css-tricks.com/snippets/css/a-guide-to-flexbox/)
- [CSS Tricks: Grid](https://css-tricks.com/snippets/css/complete-guide-grid/)

### Tutorials:
- [Complete Responsive Web Design Course](https://www.freecodecamp.org/)
- [CSS Modern Layouts](https://web.dev/learn/css/)
- [Codecademy CSS Course](https://www.codecademy.com/learn/learn-css)

### Tools:
- [CSS Generators](https://www.cssmatic.com/)
- [Gradient Creator](https://www.colorgradient.dev/)
- [Can I Use?](https://caniuse.com/) - Browser compatibility

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] CSS Fundamentals
- [ ] Flexbox
- [ ] Grid
- [ ] Responsive Design
- [ ] Animations
- [ ] Advanced Features

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
- Move to JavaScript module
- Enhance CSS skills with preprocessors (SASS/LESS)

---

**Last Updated:** June 2026
**Completion Status:** Not Started
