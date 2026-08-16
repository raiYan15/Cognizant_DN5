// Event Constructor Function
function EventItem(title, date, maxSeats, bookedSeats) {
  this.title = title;
  this.date = date;
  this.maxSeats = maxSeats;
  this.bookedSeats = bookedSeats;
}

// Adding method to prototype
EventItem.prototype.checkAvailability = function () {
  return this.maxSeats - this.bookedSeats;
};

const annualGala = new EventItem("Annual Community Gala", "November 20, 2026", 100, 78);

function displayObjectProperties() {
  const container = document.getElementById("objectEntries");
  let outputHtml = `<h3>Event: ${annualGala.title}</h3>`;
  outputHtml += `<p><strong>Available Seats (via Prototype Method):</strong> ${annualGala.checkAvailability()}</p>`;
  outputHtml += `<h4>Object.entries() Breakdown:</h4><ul>`;

  // Iterating with Object.entries()
  for (const [key, value] of Object.entries(annualGala)) {
    outputHtml += `<li><strong>${key}:</strong> ${value}</li>`;
  }
  outputHtml += `</ul>`;

  container.innerHTML = outputHtml;
}

window.onload = displayObjectProperties;
