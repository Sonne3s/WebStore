$(function () {
    $("[data-action='next']").click(function () {
        let $this = $(this);
        let $nextTab = $($this.attr("data-next-tab"));
        let $form = $("#" + Admin.Edit.FormId);//$nextTab.closest("form");
        if ($form.validate().form()) {
            $nextTab.tab('show');
        }
    });

    $("button[role='tab']").click(function (e) {
        $form = $("#" + Admin.Edit.FormId);//$(this).closest("form");
        if ($(this).attr("id") === "base-properties-tab" || $("#images-tab.active").length > 0 || $form.validate().form()) {
            $(this).tab('show');
        }
    });
});