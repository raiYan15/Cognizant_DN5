const communityEvents = [
  { title: "Jazz in the Park", category: "Music", price: "$10" },
  { title: "Neighborhood Bake Sale", category: "Food", price: "Free" },
  { title: "Symphony Orchestra", category: "Music", price: "$25" }
];

// 1. Adding an event using .push()
communityEvents.push({ title: "Rock Band Showcase", category: "Music", price: "$15" });
communityEvents.push({ title: "Pottery Workshop", category: "Crafts", price: "$20" });

// 2. Filtering music events using .filter()
const musicEvents = communityEvents.filter((event) => event.category === "Music");

// 3. Formatting event cards using .map()
const eventCardsHtml = musicEvents
  .map(
    (event) => `
    <div class="event-card">
      <h3>${event.title}</h3>
      <p><strong>Category:</strong> ${event.category}</p>
      <p><strong>Admission:</strong> ${event.price}</p>
    </div>
  `
  )
  .join("");

window.onload = function () {
  document.getElementById("musicEventsList").innerHTML = eventCardsHtml;
};
