$(document).ready(function () {
  // 1. Handle button click using jQuery
  $("#registerBtn").click(function () {
    $("#confirmationBox").text("Registration confirmed for Volunteer Drive!").fadeIn(400);
  });

  // 2. Using .fadeOut() and .fadeIn() to toggle card visibility
  $("#hideCardBtn").click(function () {
    $("#featuredEventCard").fadeOut(500);
  });

  $("#showCardBtn").click(function () {
    $("#featuredEventCard").fadeIn(500);
  });
});
