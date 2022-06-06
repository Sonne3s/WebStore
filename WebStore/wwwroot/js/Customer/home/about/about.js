$(function () {
    $('[data-bs-toggle="tab"]').click(function() {
        let headerСontainer = $(this).closest('[role="tablist"]');
        let bodyContainer = headerСontainer.siblings(".navigation-tab-body");
        headerСontainer.find('[role="tab"]').removeClass("active");
        bodyContainer.find('[role="tabpanel"]').removeClass("active").removeClass("show");
        $(this).addClass("active");
        $($(this).attr("data-bs-target")).addClass("active").addClass("show");
    });

    $(".phone-number .copy-icon").click(function () {
        navigator.clipboard.writeText($(this).siblings(".segment-number").find(".number").text());
    });
});