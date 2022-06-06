$(function () {
    ApplyInputEvents(this);
});

var ApplyInputEvents = function (data) {
    let $data = $(data);
    $data.find(Admin.ProductProperty.Input.Button.Remove.Purpose).click(function () {
        let $inputsContainer = $(this).closest(Admin.Component.PropertiesContainer.Container.Purpose);
        let inputPurpose = Admin.ProductProperty.Input.Container.Purpose;

        if ($inputsContainer.find(inputPurpose).length > 1) {
            $(this).closest(Admin.ProductProperty.Input.Container.Purpose).remove();
        }
    });

    $data.find(Admin.ProductProperty.Input.Item.Button.Remove.Purpose).click(function () {
        let $inputContainer = $(this).closest(Admin.ProductProperty.Input.Container.Purpose);
        let inputItemPurpose = Admin.ProductProperty.Input.Item.Container.Purpose;

        if ($inputContainer.find(inputItemPurpose).length > 1) {
            $(this).closest(Admin.ProductProperty.Input.Item.Container.Purpose).remove();
        }
    });
}