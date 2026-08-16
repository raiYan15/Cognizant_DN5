$(document).ready(function () {
  // Single click: Change background color to red
  $("#colorBtn").click(function () {
    $("#colorBox").css("background-color", "red").text("Color: Red (Single Click)");
  });

  // Double click: Change background color back to white
  $("#colorBtn").dblclick(function () {
    $("#colorBox").css("background-color", "white").text("Color: White (Double Click)");
  });
});
