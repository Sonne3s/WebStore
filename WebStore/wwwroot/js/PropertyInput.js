$(function () {
    setAddPropertyChoiseHandler($(this));

    $("[data-action='remove-prop']").click(function () {
        $(this).closest(".form-group").remove();
    });

    //CreateProducer
    submitModal($(this));
})

var updatePropertyChoise = function (param) {
    $("#add-property-card").remove();
    getPropertyChoise(param);
    $("#Modal").modal('hide');
}

var setAddPropertyChoiseHandler = function($target) {
    $target.find("button[data-action='get-partial']").click(function () {
        getPropertyChoise(this);
    });
}

var getPropertyChoise = function (param) {
    //$getPropertyChoiseButton = $("button[data-action='get-partial']");
    $this = $(param);
    let url = $this.attr("data-val");

    $.ajax({
        url: url,
    }).done(function (data) {
        let $data = $(data);
        PropertyScript($data);
        $this.before($data);
        $("[data-action='get-partial']").addClass("d-none");
    });
}

/** { "PropertiesList: { "TargetId: '#PropertiesList', Url: '@Url.Action("AddPropertyPropertiesList")' }, PropertyItem: { TargetId: '[data-action=success]', Url: '@Url.Action("AddPropertyPropertyItem")' } } */
var updatePropertiesList = function (parameters) {
    $.ajax({
        url: parameters.PropertiesList.Url,
    }).done(function (data) {
        let $data = $(data);
        PropertyScript($data);
        let $target = $(parameters.PropertiesList.TargetId);
        $target.before($data);
        $target.remove();
        $("#PropertiesList").change();
    });
    $("#Modal").modal('hide');
}