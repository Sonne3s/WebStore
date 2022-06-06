$(function () {
    $(".carousel-indicators button").hover(function () {
        $(this).click();
    });

    $(".carousel-indicators").mouseleave(function () {
        $(this).closest(".carousel").carousel(0);
    });
});