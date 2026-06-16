# HTML5 - Comprehensive Notes

## 📌 Overview

HTML5 (HyperText Markup Language 5) is the fifth and current major version of HTML. It represents the standard markup language for creating web pages and web applications. HTML5 introduces semantic elements, improved multimedia support, better form controls, and APIs for building modern web applications.

**Key Point:** HTML5 is about semantic markup, accessibility, and providing meaning to web content.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand HTML5 structure and semantic elements
- [ ] Master form controls and validation
- [ ] Work with multimedia elements (audio, video)
- [ ] Implement accessibility best practices
- [ ] Use HTML5 APIs (canvas, storage, geolocation)
- [ ] Write clean, semantic markup

---

## 📚 Core Concepts Learned

### 1. **HTML5 Document Structure**
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Page Title</title>
</head>
<body>
    <!-- Content -->
</body>
</html>
```

**Key Elements:**
- `<!DOCTYPE html>` - HTML5 document type declaration
- `<html>` - Root element
- `<head>` - Contains metadata
- `<meta charset>` - Character encoding
- `<meta viewport>` - Responsive design
- `<body>` - Visible content

### 2. **Semantic Elements**

HTML5 provides semantic elements that clearly describe their meaning:

| Element | Purpose |
|---------|---------|
| `<header>` | Introductory content or navigation |
| `<nav>` | Navigation links |
| `<main>` | Main content of the document |
| `<article>` | Independent, self-contained content |
| `<section>` | Thematic grouping of content |
| `<aside>` | Sidebar or related content |
| `<footer>` | Footer or closing section |

**Benefits of Semantic HTML:**
- Better accessibility for screen readers
- Improved SEO
- Cleaner, more readable code
- Better document structure

### 3. **Form Elements & Input Types**

HTML5 introduces new input types and validation:

```html
<form action="/submit" method="post">
    <!-- Text inputs -->
    <input type="text" name="username" required>
    <input type="email" name="email" required>
    <input type="password" name="password">

    <!-- HTML5 input types -->
    <input type="number" name="age" min="1" max="100">
    <input type="date" name="birthdate">
    <input type="email" name="email">
    <input type="url" name="website">
    <input type="color" name="favorite-color">
    <input type="range" name="volume" min="0" max="100">
    <input type="search" name="query">
    <input type="tel" name="phone">

    <!-- Other form elements -->
    <textarea name="message" rows="10" cols="50"></textarea>
    <select name="category">
        <option>-- Select --</option>
        <option value="category1">Category 1</option>
    </select>

    <!-- Native validation -->
    <input type="submit" value="Submit">
</form>
```

**Form Validation:**
- Built-in HTML5 validation (required, pattern, min, max)
- Email, URL, number validation
- Custom validation with JavaScript

### 4. **Multimedia Elements**

```html
<!-- Audio -->
<audio controls>
    <source src="audio.mp3" type="audio/mpeg">
    <source src="audio.ogg" type="audio/ogg">
    Your browser does not support the audio element.
</audio>

<!-- Video -->
<video width="320" height="240" controls>
    <source src="movie.mp4" type="video/mp4">
    <source src="movie.ogg" type="video/ogg">
    Your browser does not support the video tag.
</video>
```

### 5. **HTML5 APIs**

**Canvas API:**
```html
<canvas id="myCanvas" width="200" height="100"></canvas>
<script>
    const canvas = document.getElementById('myCanvas');
    const ctx = canvas.getContext('2d');
    ctx.fillStyle = 'blue';
    ctx.fillRect(10, 10, 100, 50);
</script>
```

**Local Storage:**
```javascript
// Store data
localStorage.setItem('username', 'John');

// Retrieve data
const username = localStorage.getItem('username');

// Remove data
localStorage.removeItem('username');

// Clear all
localStorage.clear();
```

**Geolocation API:**
```javascript
if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition((position) => {
        console.log(position.coords.latitude);
        console.log(position.coords.longitude);
    });
}
```

### 6. **Accessibility (a11y)**

**ARIA Attributes:**
```html
<button aria-label="Close menu" aria-expanded="false">
    ×
</button>

<nav aria-label="Main navigation">
    <!-- Navigation items -->
</nav>
```

**Best Practices:**
- Use semantic HTML elements
- Add alt text to images: `<img alt="Description">`
- Use proper heading hierarchy (h1 → h2 → h3)
- Ensure color contrast ratio ≥ 4.5:1
- Make forms accessible with labels
- Test with screen readers

---

## 💻 Hands-On Exercises

### Exercise 1: Create a Semantic Web Page
**Task:** Build a webpage with header, nav, main content, and footer

### Exercise 2: Build a Form with Validation
**Task:** Create a user registration form with HTML5 validation

### Exercise 3: Multimedia Page
**Task:** Create a page with audio and video elements

### Exercise 4: Canvas Drawing
**Task:** Draw shapes on an HTML5 canvas

### Exercise 5: Local Storage Todo App
**Task:** Build a simple todo app that persists data

---

## 📝 Assignments

1. **Portfolio Website**
   - Create a personal portfolio with semantic HTML
   - Must include header, navigation, sections, and footer
   - Must be responsive
   - Use HTML5 validation in contact form

2. **Interactive Quiz**
   - Build a quiz application
   - Store results in local storage
   - Use semantic HTML elements
   - Include form validation

3. **Multimedia Gallery**
   - Create a gallery with images, audio, and video
   - Use semantic HTML structure
   - Ensure accessibility

---

## 🔗 References

### Official Documentation:
- [MDN: HTML Elements](https://developer.mozilla.org/en-US/docs/Web/HTML/Element)
- [W3C HTML5 Specification](https://html.spec.whatwg.org/)
- [MDN: Web Forms](https://developer.mozilla.org/en-US/docs/Learn/Forms)

### Tutorials:
- [freeCodeCamp HTML Tutorial](https://www.freecodecamp.org/learn/responsive-web-design/)
- [W3Schools HTML5 Tutorial](https://www.w3schools.com/html/default.asp)
- [Codecademy HTML Course](https://www.codecademy.com/learn/learn-html)

### Accessibility:
- [WebAIM](https://webaim.org/)
- [MDN: Accessibility](https://developer.mozilla.org/en-US/docs/Web/Accessibility)
- [WCAG Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] HTML5 Structure
- [ ] Semantic Elements
- [ ] Forms & Validation
- [ ] Multimedia
- [ ] APIs
- [ ] Accessibility

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
- Move to CSS3 module
- Build projects combining HTML5 + CSS3

---

**Last Updated:** June 2026
**Completion Status:** Not Started
