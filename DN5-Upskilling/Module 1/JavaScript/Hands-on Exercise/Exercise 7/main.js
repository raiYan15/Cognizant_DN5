const sampleEvents = [
  { id: 1, title: "Garden Planting Day", spots: 5, isRegistered: false },
  { id: 2, title: "Robotics Exhibition", spots: 8, isRegistered: false },
  { id: 3, title: "Community 5K Walk", spots: 12, isRegistered: false }
];

function buildEventList() {
  const container = document.querySelector("#eventListContainer");
  container.innerHTML = "";

  sampleEvents.forEach((evt) => {
    // 1. createElement()
    const card = document.createElement("div");
    card.className = "dom-card";

    const titleEl = document.createElement("h3");
    titleEl.innerText = evt.title;

    const spotsEl = document.createElement("p");
    spotsEl.id = `spots-${evt.id}`;
    spotsEl.innerText = `Available Spots: ${evt.spots}`;

    const actionBtn = document.createElement("button");
    actionBtn.id = `btn-${evt.id}`;
    actionBtn.className = evt.isRegistered ? "btn-cancel" : "btn-reg";
    actionBtn.innerText = evt.isRegistered ? "Cancel Registration" : "Register Now";

    // 2. Dynamic UI updates on click
    actionBtn.onclick = function () {
      if (!evt.isRegistered) {
        if (evt.spots > 0) {
          evt.spots--;
          evt.isRegistered = true;
        }
      } else {
        evt.spots++;
        evt.isRegistered = false;
      }
      buildEventList();
    };

    card.appendChild(titleEl);
    card.appendChild(spotsEl);
    card.appendChild(actionBtn);
    container.appendChild(card);
  });
}

window.onload = buildEventList;
