const eventName = "Community Tech Workshop";
const eventDate = "October 15, 2026";
let availableSeats = 25;

function displayEventInfo() {
  const info = `Event: ${eventName} | Date: ${eventDate} | Seats Remaining: ${availableSeats}`;
  document.getElementById("eventDetails").innerText = info;
}

function registerSeat() {
  if (availableSeats > 0) {
    availableSeats--;
    displayEventInfo();
  } else {
    alert("Sorry, all seats are booked!");
  }
}

function cancelSeat() {
  availableSeats++;
  displayEventInfo();
}

window.onload = displayEventInfo;
