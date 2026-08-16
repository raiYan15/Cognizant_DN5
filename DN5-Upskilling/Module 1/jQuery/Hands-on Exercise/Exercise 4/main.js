$(document).ready(function () {
  $("#itemForm").submit(function (e) {
    e.preventDefault();

    const value = $("#itemInput").val().trim();
    if (value) {
      // Create new <li> and append to <ul>
      const newLi = $("<li></li>").text(value);
      $("#itemList").append(newLi);
      $("#itemInput").val("").focus();
    }
  });

  // Remove All button clears the list
  $("#removeAllBtn").click(function () {
    $("#itemList").empty();
  });
});
