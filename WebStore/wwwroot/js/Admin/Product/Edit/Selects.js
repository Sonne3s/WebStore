var ChangePropertyEvent = function ($target, id) {
    let $editButton = $target.siblings(id);
    if ($target.find("option:checked").val() !== "") {
        $editButton.removeAttr("disabled");
    }
    else {
        $editButton.attr("disabled", "disabled");
    }
}

var UpdateSelectList = function (url, selectId, optionId, editButtonId, customActions) {
    $.ajax({
        url: url,
    }).done(function (data) {
        let $data = $(data);
        UpdateSelect($data);
        if (customActions) {
            customActions($data);
        }
        SetSelectOption($data);
        ChangePropertyEvent($data, editButtonId)
    });

    function SetSelectOption($data) {
        if (optionId == -1) {
            $data.find("option:last").attr("selected", "selected");
        }
        else {
            $data.val(optionId);
        }
        $data.change();
    }

    function UpdateSelect($data) {
        let $select = $(selectId);
        $select.before($data);
        $select.remove();
    }
}