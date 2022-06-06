$(function () {
    $(".userbar-menu input").focusin(function () {
        $(this).closest(".userbar-menu").addClass("show");
    });

    $(".userbar-menu input").focusout(function () {
        if (!$(".userbar-menu input").is(":focus")) {
            $(this).closest(".userbar-menu").removeClass("show");
        }
    });
});