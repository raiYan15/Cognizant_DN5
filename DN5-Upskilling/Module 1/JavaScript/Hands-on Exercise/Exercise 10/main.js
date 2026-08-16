// 1. Default parameters in functions
const createEventSummary = (title = "General Community Meetup", location = "Town Hall", capacity = 50) => {
  return { title, location, capacity };
};

const defaultEvent = createEventSummary();
const customEvent = createEventSummary("Summer Carnival", "Riverside Park", 200);

// 2. Destructuring
const { title: eventName, location: eventVenue, capacity: maxPeople } = customEvent;

// 3. Array cloning & merging using spread operator (...)
const originalEventList = ["Art Expo", "Chess Tourney"];
const updatedEventList = [...originalEventList, "Pottery Class", "Coding Camp"];

function displayModernFeatures() {
  const output = document.getElementById("es6Output");
  output.innerHTML = `
    <p><strong>Default Parameters:</strong> ${defaultEvent.title} at ${defaultEvent.location} (Capacity: ${defaultEvent.capacity})</p>
    <p><strong>Destructured Object:</strong> Name: ${eventName} | Venue: ${eventVenue} | Capacity: ${maxPeople}</p>
    <p><strong>Cloned & Spread Array:</strong> ${updatedEventList.join(", ")}</p>
  `;
}

window.onload = displayModernFeatures;
