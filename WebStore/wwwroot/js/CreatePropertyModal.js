$(function () {
    $("#CreatePropertyModalButton").click(function () {
        $this = $(this);
        let url = $this.attr("data-partial");

        $.ajax({
            url: url,
        }).done(function (data) {
            let $data = $(data);
            PropertyScript($data);
            let $modal = $("#Modal .modal-content");
            $modal.append($data);
        });
    });
});