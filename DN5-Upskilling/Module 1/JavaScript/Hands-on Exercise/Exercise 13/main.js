function processRegistration() {
  console.group("Registration Workflow Debugger");

  // Step 1: Read input values
  const name = document.getElementById("debugName").value;
  const eventCategory = document.getElementById("debugCategory").value;
  console.log("Step 1: Input values extracted -> Name:", name, "| Category:", eventCategory);

  // Step 2: Construct payload
  const registrationPayload = {
    user: name,
    category: eventCategory,
    submissionTime: Date.now()
  };
  console.log("Step 2: Constructed payload object ->", registrationPayload);

  // Breakpoint trigger for DevTools Sources tab
  debugger;

  // Step 3: Trigger network transmission
  console.log("Step 3: Sending payload via Fetch API...");
  fetch("https://jsonplaceholder.typicode.com/posts", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(registrationPayload)
  })
    .then((response) => {
      console.log("Step 4: Response status code:", response.status);
      return response.json();
    })
    .then((data) => {
      console.log("Step 5: Server response payload verified ->", data);
      document.getElementById("debugOutput").innerText = "Registration complete! Check Console & Network tabs.";
    })
    .catch((err) => {
      console.error("Step 5 [FAILED]:", err);
    })
    .finally(() => {
      console.groupEnd();
    });
}
