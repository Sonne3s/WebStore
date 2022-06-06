var ApplyCreationPageEvents = function ($target) {
    ApplyUnitSelectionEvents();

    $target.find("select[name='TypeId']").change(function () {
        toggleUnitSelection($(this).find("option"));
    });

    let toggleUnitSelection = function ($items) {
        let unitContainer = $(Admin.ProductProperty.CreationPage.UnitSelection.PurposeSelector);
        let unitSelect = unitContainer.find("select");
        switch ($items.filter(":selected").val()) {
            case Admin.ProductProperty.CreationPage.TypeId.Text: {
                unitContainer.addClass("d-none");
                unitSelect.prop('required', false);
                break;
            }
            case Admin.ProductProperty.CreationPage.TypeId.Integer: {
                unitContainer.removeClass("d-none");
                unitSelect.prop('required', true);
                break;
            }
            case Admin.ProductProperty.CreationPage.TypeId.Decimal: {
                unitContainer.removeClass("d-none");
                unitSelect.prop('required', true);
                break;
            }
        }
    }

}