$('.modal').on('hidden.bs.modal', function () {
    $this = $(this);
    if ($this.attr("id") == "SubModal") {
        ShowModal("#Modal");
    }
    HideModal("#" + $(this).attr("id"));
});

$('.modal').on('shown.bs.modal', function () {
    ShowModal("#" + $(this).attr("id"));
});

var HideModal = function (modalId) {
    $(modalId).modal('hide');
    HideModalContent($(modalId).find(".modal-content"));
    InsertSpinner($(modalId).find(".modal-content"));
}

var ShowModal = function (modalId) {
    $(modalId).modal('show');
    ShowModalContent($(modalId).find(".modal-content"));
    RemoveSpinner($(modalId));
}

var submitModal = function ($parent) {
    $parent.find("[data-action='submit']").click(function () {
        $this = $(this);
        let $modal = $this.closest(".modal");
        $form = $modal.find("form");
        if (SetValidatePlacement($form).form()) {
            $form.submit();
        }
    });
}

var CreateEditPropertyModal = function (url, modalId, customActions) {
    $.ajax({
        url: url,
    }).done(function (data) {
        let $data = $(data);
        if (customActions) {
            customActions($data);
        }
        ActivateDeleteButton($data);
        submitModal($data);
        let $modal = $(modalId + " .modal-content");
        $modal.empty()
        $modal.append($data);
    });
}

var ActivateDeleteButton = function ($target) {
    $target.find("[data-action='delete']").click(function () {
        let deleteUrl = $(this).attr("data-delete-url");
        let updateSelectUrl = $(this).attr("data-update-select-url");
        let selectId = $(this).attr("data-select-id");
        let editButtonId = $(this).attr("data-edit-button-id");
        let modalId = $(this).closest(".modal").attr("id");
        let customActions;
        if (selectId == "PropertiesList") {
            customActions = ActivatePropertiesSelectChangeEvent;
        }
        $.get(deleteUrl, function (data) {
            UpdateSelectList(updateSelectUrl, "#" + selectId, "", "#" + editButtonId, customActions);
            HideModal("#" + modalId);
        });
    });
}

var ShowModalContent = function ($target) {
    $target.find(".modal-header").removeClass("d-none");
    $target.find(".modal-body").removeClass("d-none");
    $target.find(".modal-footer").removeClass("d-none");
}

var HideModalContent = function ($target) {
    $target.find(".modal-header").addClass("d-none");
    $target.find(".modal-body").addClass("d-none");
    $target.find(".modal-footer").addClass("d-none");
}

var RefreshModalContent = function ($target) {
    $target.empty();
    $target.append($("<div class='modal-header'></div>"));
    $target.append($("<div class='modal-body'></div>"));
    $target.append($("<div class='modal-footer'></div>"));
}