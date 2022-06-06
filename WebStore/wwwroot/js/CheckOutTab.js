$(function () {
    $("input[role='tab']").click(function () {
        $(this).closest(".nav.nav-tabs").find("input[role='tab']").removeClass("active");
    });
});