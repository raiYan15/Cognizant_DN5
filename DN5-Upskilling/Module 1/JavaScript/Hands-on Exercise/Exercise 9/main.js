// 1. Fetching using Promises (.then & .catch)
function fetchWithPromises() {
  showSpinner(true);
  fetch("events.json")
    .then((response) => {
      if (!response.ok) throw new Error("Network response was not ok");
      return response.json();
    })
    .then((data) => {
      renderData(data, "Loaded via Promises (.then / .catch)");
    })
    .catch((error) => {
      showError(error.message);
    })
    .finally(() => {
      showSpinner(false);
    });
}

// 2. Fetching using Async / Await
async function fetchWithAsyncAwait() {
  showSpinner(true);
  try {
    const response = await fetch("events.json");
    if (!response.ok) throw new Error("HTTP error " + response.status);
    const data = await response.json();
    renderData(data, "Loaded via Async / Await");
  } catch (error) {
    showError(error.message);
  } finally {
    showSpinner(false);
  }
}

function showSpinner(show) {
  document.getElementById("spinner").style.display = show ? "inline-block" : "none";
}

function showError(msg) {
  document.getElementById("eventList").innerHTML = `<p style="color:red;">Error: ${msg}</p>`;
}

function renderData(items, methodLabel) {
  let html = `<h4>${methodLabel}</h4>`;
  items.forEach((item) => {
    html += `
      <div class="async-card">
        <h4>${item.title}</h4>
        <p>Date: ${item.date} | Available Seats: ${item.seats}</p>
      </div>
    `;
  });
  document.getElementById("eventList").innerHTML = html;
}
