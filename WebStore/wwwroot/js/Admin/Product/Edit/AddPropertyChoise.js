var PropertyScript = function (target) {
    $parent = $(target);

    ActivatePropertiesSelectChangeEvent($(target).find("#PropertiesList"));

    $(target).find("select[data-action='display-block']").change(function () {
        let $this = $(this);
        toggleBorderValidationColor($this);
        hideAllPropertyBlocks();
        showSelectedPropertyBlock($this);

        function toggleBorderValidationColor($target) {
            $("#" + Admin.Edit.FormId).validate().form();
            if ($target.hasClass("valid")) {
                $("#add-property-card").removeClass("error");
                $("#add-property-card").addClass("valid");
            }
            else {
                $("#add-property-card").removeClass("valid");
                $("#add-property-card").addClass("error");
            }
        }
        function hideAllPropertyBlocks() {
            $("[data-action='displayed-block']").addClass("d-none");
        }
        function showSelectedPropertyBlock($target) {
            let groupId = parseInt($target.val(), 10);
            if (!isNaN(groupId)) {
                $("[data-action='displayed-block'][data-group-id='" + groupId + "']").removeClass("d-none");
            }
        }
    });

    $(target).find("button[data-action='success']").click(function () {
        let container = $("#add-property-card");
        $("#" + Admin.Edit.FormId).validate().form();
        if (container.hasClass("valid")) {
            container.replaceWith(getExtractedProperty($("[data-action='displayed-block']:not(.d-none)")));
            $("[data-action='get-partial']").removeClass("d-none");

            function getExtractedProperty($selectedPropertyOperatingShell) {
                let $selectedProperty = $selectedPropertyOperatingShell.find(".form-group");
                activateProperty($selectedProperty);
                return $selectedProperty;

                function activateProperty($target) {
                    $target.find("input, select").removeAttr("disabled");
                    $target.find("button").removeClass("d-none");
                }
            }
        }
    });

    $(target).find("button[data-action='cancel']").click(function () {
        $("#add-property-card").remove();
        $("[data-action='get-partial']").removeClass("d-none");
    });

    $(target).find("[data-action='remove-prop']").click(function () {
        $(this).closest(".form-group").remove();
    });

    $(target).find("#TypeId").change(function () {
        let target = $(this).find('option:selected').attr('data-bs-target');
        $("#unit").addClass("d-none");
        $(target).removeClass("d-none");
    });

    $(target).find("#CreatePropertyModalButton").click(function () {
        $this = $(this);
        let url = $this.attr("data-partial");
        CreateEditPropertyModal(url, "#Modal", PropertyScript)
    });

    $(target).find("#EditPropertyModalButton").click(function () {
        $this = $(this);
        let id = $this.siblings("select").find("option:checked").val();
        let url = $this.attr("data-partial") + "&id=" + id;
        CreateEditPropertyModal(url, "#Modal", PropertyScript)
    });

    $(target).find("#CreateValueUnitModalButton").click(function () {
        let $this = $(this);
        let url = $this.attr("data-partial");
        CreateEditPropertyModal(url, "#SubModal");
    });

    $(target).find("#EditValueUnitModalButton").click(function () {
        let $this = $(this);
        let id = $this.siblings("select").find("option:checked").val();
        let url = $this.attr("data-partial") + "?id=" + id;
        CreateEditPropertyModal(url, "#SubModal");
    });

    $(target).find("[data-action='add-item']").click(function () {
        let $this = $(this);
        let $parent = $this.closest(".card");
        let sample = $parent.find(".sample");
        let clone = sample.clone(true);
        clone.removeClass("sample").removeClass("d-none");
        let last = $parent.find(".input-group:not(.sample)").last();
        last.after(clone);
    });

    $(target).find("[data-action='remove-item']").click(function () {
        let $this = $(this);
        let $parent = $this.closest(".input-group");
        $parent.remove();
    });

    $(target).find("#UnitTypeId").change(function () {
        ChangePropertyEvent($(this), "#EditValueUnitModalButton");
    });
}

var AddProperty = function (url, container) {
    $.ajax({
        url: url,
    }).done(function (data) {
        let $data = $(data);
        PropertyScript($data);
        container.append($data);
    });
}

var ActivatePropertiesSelectChangeEvent = function ($target) {
    $target.change(function () {
        let $this = $(this);
        let id = $this.find("option:checked").val();
        let property = $this.closest(".form-group").next();
        property.remove();
        if (id !== "") {
            let url = $this.attr("data-partial") + "&id=" + id;
            AddProperty(url, $($this.closest(".container.mb-2")));
            ChangePropertyEvent($(this), "#EditPropertyModalButton");
        }
    });
}