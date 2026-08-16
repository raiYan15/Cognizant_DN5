const allEvents = [
  { name: "Urban Gardening Class", category: "Education" },
  { name: "Salsa Dance Night", category: "Entertainment" },
  { name: "Civic Townhall Meeting", category: "Community" },
  { name: "JavaScript Hackathon", category: "Education" },
  { name: "Standup Comedy Show", category: "Entertainment" }
];

function filterAndSearch() {
  const categoryFilter = document.getElementById("categorySelect").value;
  const searchTerm = document.getElementById("searchInput").value.toLowerCase();

  const filtered = allEvents.filter((item) => {
    const matchesCategory = !categoryFilter || item.category === categoryFilter;
    const matchesSearch = item.name.toLowerCase().includes(searchTerm);
    return matchesCategory && matchesSearch;
  });

  const listContainer = document.getElementById("results");
  listContainer.innerHTML = "";

  if (filtered.length === 0) {
    listContainer.innerHTML = "<p>No matching events found.</p>";
    return;
  }

  filtered.forEach((item) => {
    const div = document.createElement("div");
    div.className = "item-row";
    div.innerHTML = `
      <span><strong>${item.name}</strong> (${item.category})</span>
      <button onclick="alert('You registered for: ${item.name}')">Register</button>
    `;
    listContainer.appendChild(div);
  });
}

// 1. onchange event for category filter
document.getElementById("categorySelect").onchange = filterAndSearch;

// 2. keydown event for search box
document.getElementById("searchInput").addEventListener("keydown", function () {
  setTimeout(filterAndSearch, 50); // slight delay to capture input value
});

window.onload = filterAndSearch;
