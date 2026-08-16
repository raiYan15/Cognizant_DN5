$(document).ready(function () {
  $("#btnHide").click(function () {
    $(".box").hide();
  });

  $("#btnShow").click(function () {
    $(".box").show();
  });

  $("#btnFadeOut").click(function () {
    $(".box").fadeOut(600);
  });

  $("#btnFadeIn").click(function () {
    $(".box").fadeIn(600);
  });

  $("#btnToggle").click(function () {
    $(".box").toggle();
  });

  // Bonus: Method chaining
  $("#btnSlideChain").click(function () {
    $(".box").slideUp(400).delay(1000).slideDown(400);
  });
});
