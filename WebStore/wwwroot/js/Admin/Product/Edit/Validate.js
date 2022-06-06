$(function () {
    SetValidatePlacement($("form"));
})

var SetValidatePlacement = function ($form) {
    return $form.validate({
        errorPlacement: function (error, element) {
            element.closest(".form-group").append(error);
        }
    });
}