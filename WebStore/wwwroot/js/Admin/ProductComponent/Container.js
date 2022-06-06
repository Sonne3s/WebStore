var AddProductPropertyContainerSuccess = function (data) {
    $(Admin.ProductComponent.Container.Buttons.AddProductPropertyContainer.Purpose).click();
}

var ReloadComponentContainerSuccess = function (data) {
    ApplyComponentItemEvents($(data));
    SetComponentItemBySelector(Admin.ProductComponent.Item.Purpose + ":last input");
}

var SetComponentItemBySelector = function (selector) {
    $(Admin.ProductComponent.Container.Purpose).find(selector).click();
}

var ApplyComponentItemEvents = function ($target) {
    $target.find("input[type='radio']").click(function () {
        let target = $(this).attr(Bootstrap.DataAttrName.Target);
        $(Admin.Component.PropertiesContainer.PurposeAttr).hide();
        $(Admin.Component.PropertiesContainer.PurposeAttr + AttrSelector(DataAttrName.Id, target)).show();
    });
}