const eventList = [];

// Function to add event
function addEvent(name, category, maxCapacity) {
  const newEvent = { name, category, maxCapacity, registered: 0 };
  eventList.push(newEvent);
  return newEvent;
}

// Closure to track total registrations across the portal
function createRegistrationTracker() {
  let totalCount = 0;
  return function () {
    totalCount++;
    return totalCount;
  };
}

const trackTotalRegistrations = createRegistrationTracker();

// Function to register a user
function registerUser(eventName) {
  const event = eventList.find((e) => e.name === eventName);
  if (event && event.registered < event.maxCapacity) {
    event.registered++;
    const currentTotal = trackTotalRegistrations();
    return `User registered for ${eventName}. Total portal registrations: ${currentTotal}`;
  }
  return `Registration failed for ${eventName}.`;
}

// Higher-order function accepting a callback filter
function filterEvents(callback) {
  return eventList.filter(callback);
}

function filterEventsByCategory(category) {
  return filterEvents((event) => event.category === category);
}

// Sample initialization
addEvent("Community Coding Workshop", "Education", 20);
addEvent("Local Jazz Concert", "Music", 50);
addEvent("Kids Storytelling Hour", "Education", 15);
addEvent("Folk Dance Night", "Music", 30);

function runDemo() {
  const reg1 = registerUser("Community Coding Workshop");
  const reg2 = registerUser("Local Jazz Concert");
  
  const eduEvents = filterEventsByCategory("Education").map((e) => e.name).join(", ");
  
  document.getElementById("output").innerHTML = `
    <p><strong>Registration 1:</strong> ${reg1}</p>
    <p><strong>Registration 2:</strong> ${reg2}</p>
    <p><strong>Filtered 'Education' Events:</strong> ${eduEvents}</p>
  `;
}

window.onload = runDemo;
