$(document).ready(function () {
  // 1. Change text of h1 using $()
  $("h1").text("Updated Title via jQuery $() Selector");

  // 2. Hide one <p> element when button is clicked
  $("#hideBtn").click(function () {
    $("#secondParagraph").hide(400);
  });
});
