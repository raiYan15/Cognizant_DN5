const events = [
  { id: 1, title: "Art in the Park", seats: 10, isPast: false },
  { id: 2, title: "Coding Bootcamp", seats: 0, isPast: false },
  { id: 3, title: "Spring Marathon", seats: 50, isPast: true },
  { id: 4, title: "Jazz Night", seats: 15, isPast: false }
];

function renderEvents() {
  const container = document.getElementById("eventsContainer");
  container.innerHTML = "";

  events.forEach((event) => {
    // Conditionals: check if past or fully booked
    if (event.isPast) {
      return; // Skip past events
    }

    const card = document.createElement("div");
    card.className = "event-card";

    let statusText = "";
    let btnDisabled = "";

    if (event.seats === 0) {
      statusText = "<span style='color:red;'>Fully Booked</span>";
      btnDisabled = "disabled";
    } else {
      statusText = `<span style='color:green;'>Seats Available: ${event.seats}</span>`;
    }

    card.innerHTML = `
      <h3>${event.title}</h3>
      <p>${statusText}</p>
      <button ${btnDisabled} onclick="registerForEvent(${event.id})">Register</button>
    `;

    container.appendChild(card);
  });
}

function registerForEvent(eventId) {
  try {
    const event = events.find((e) => e.id === eventId);
    if (!event) {
      throw new Error("Event not found in the registry.");
    }
    if (event.seats <= 0) {
      throw new Error("Registration failed: Event is full.");
    }

    event.seats--;
    alert(`Successfully registered for ${event.title}!`);
    renderEvents();
  } catch (error) {
    console.error("Error during registration:", error.message);
    alert(`Error: ${error.message}`);
  }
}

window.onload = renderEvents;
