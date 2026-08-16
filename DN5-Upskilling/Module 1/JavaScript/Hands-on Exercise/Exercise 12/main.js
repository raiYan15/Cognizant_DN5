function submitRegistration() {
  const statusEl = document.getElementById("postStatus");
  statusEl.className = "info";
  statusEl.innerText = "Transmitting registration to server...";

  const payload = {
    userName: document.getElementById("postName").value,
    eventSelected: document.getElementById("postEvent").value,
    timestamp: new Date().toISOString()
  };

  // Simulating network delay before POSTing with fetch
  setTimeout(() => {
    fetch("https://jsonplaceholder.typicode.com/posts", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(payload)
    })
      .then((res) => {
        if (!res.ok) throw new Error("Server rejected request");
        return res.json();
      })
      .then((data) => {
        statusEl.className = "success";
        statusEl.innerText = `Registration confirmed! Server Record ID: ${data.id}`;
      })
      .catch((err) => {
        statusEl.className = "error";
        statusEl.innerText = `Registration failed: ${err.message}`;
      });
  }, 1200);
}
