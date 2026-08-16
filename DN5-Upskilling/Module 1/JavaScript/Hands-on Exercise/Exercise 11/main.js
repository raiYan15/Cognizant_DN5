document.getElementById("eventForm").addEventListener("submit", function (event) {
  // 1. Prevent default submission
  event.preventDefault();

  // Reset previous errors
  document.getElementById("nameError").innerText = "";
  document.getElementById("emailError").innerText = "";
  document.getElementById("formSuccess").innerText = "";

  // 2. Capture form data using form.elements
  const fullName = this.elements["fullName"].value.trim();
  const userEmail = this.elements["userEmail"].value.trim();
  const eventSelect = this.elements["eventSelect"].value;

  let hasError = false;

  // 3. Validation & Inline errors
  if (fullName.length < 3) {
    document.getElementById("nameError").innerText = "Full Name must be at least 3 characters.";
    hasError = true;
  }

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailRegex.test(userEmail)) {
    document.getElementById("emailError").innerText = "Please enter a valid email address.";
    hasError = true;
  }

  if (!hasError) {
    document.getElementById("formSuccess").innerText = `Success! ${fullName} registered for ${eventSelect}.`;
    this.reset();
  }
});
