var ApplyUnitSelectionEvents = function ($target) {
    let unitCreationPageEditButtonClickEvent = function () {
        $(Admin.ProductProperty.CreationPage.UnitSelection.Buttons.Edit).click(function () {
            //$(Admin.ProductProperty.CreationPage.Form.Purpose).attr("novalidate", "");
        })
    }

    let formSubmitEvent = function () {
        $(Admin.ProductProperty.CreationPage.Form.Purpose).submit(function () {
            //$(this).removeAttr("novalidate");
        });
    }

    unitCreationPageEditButtonClickEvent();
    formSubmitEvent();
}