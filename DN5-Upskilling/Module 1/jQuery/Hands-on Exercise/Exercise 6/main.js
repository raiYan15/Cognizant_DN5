$(document).ready(function () {
  const $box = $("#interactiveBox");
  const $log = $("#eventLog");

  // 1. .click()
  $box.click(function () {
    $(this).css("background-color", "#dcfce7");
    $log.text("Action: Single Click triggered -> Background changed to light green.");
  });

  // 2. .dblclick()
  $box.dblclick(function () {
    $(this).css("background-color", "#fef08a");
    alert("Double-click event detected on interactive box!");
    $log.text("Action: Double Click triggered -> Alert displayed & background changed to yellow.");
  });

  // 3. .mouseenter()
  $box.mouseenter(function () {
    $(this).css("border-color", "#2563eb");
    $("#hoverStatus").text("Status: Mouse inside box");
  });

  // 4. .mouseleave()
  $box.mouseleave(function () {
    $(this).css("border-color", "#94a3b8");
    $("#hoverStatus").text("Status: Mouse left box");
  });

  // 5. .keypress() (or keydown helper)
  $("#interactiveInput").on("keypress keydown", function (e) {
    $("#keyOutput").text(`Last Key Pressed: '${e.key}' (Keycode: ${e.which})`);
  });
});
