$(function () {
    $("#add-property-value").click(function () {
        let $sample = $("#PropertyValues");
        let index = parseInt($sample.attr("data-index"));
        $sample.attr("data-index", index + 1);
        let $newProperty = $sample.clone();
        $newProperty.attr("name", $newProperty.attr("name") + "[" + index + "]");
        $newProperty.attr("id", $newProperty.attr("id") + "[" + index + "]");
        $newProperty.removeClass("sample").removeClass("d-none");
        $sample.before($newProperty);
    });
});