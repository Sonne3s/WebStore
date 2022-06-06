$(function () {
    ApplyPaginationEvents($(".pagination-section"));
});

var ApplyPaginationEvents = function ($target) {
    $target.find(".pagination-link").click(function () {
        $form = $("form#filter");
        $form.find("#CurrentPage").val($(this).attr("data-id"));
        $("form#filter [type='submit']").click();
    });
}