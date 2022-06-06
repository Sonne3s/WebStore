$(function () {
    $(".cart-off-canvas .hide-button").click(function () {
        bootstrap.Offcanvas.getInstance($(".cart-off-canvas")[0]).hide();
    });
});