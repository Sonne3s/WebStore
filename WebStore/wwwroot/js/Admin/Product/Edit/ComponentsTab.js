$(function () {
    ApplyComponentInputEvents($(Admin.Component.Item.PurposeAttr));
})

var AddComponentPropertiesContainer = function () {
    let $link = $("#AddComponentPropertiesContainer");
    updateLink($link);
    $link.click();

    function updateLink($link) {
        let $lastComponent = $(Admin.Component.Item.PurposeAttr.LastSelector());
        let name = $lastComponent.find("input[type='text']").val();
        let index = $lastComponent.find("input[type='radio']").attr(Bootstrap.DataAttrName.Target);
        $link.attr("href", $link.attr("href") + "?name=" + name + "&counter=" + index);
    }
}

var SetLastComponent = function () {
    let lastComponent = $(Admin.Component.Item.PurposeAttr.LastSelector());
    ApplyComponentInputEvents(lastComponent);
    lastComponent.find("input[type='radio']").click();
}

var ApplyComponentInputEvents = function($target) {
    $target.find("input[type='radio']").click(function () {
        let target = $(this).attr(Bootstrap.DataAttrName.Target);
        $(Admin.Component.PropertiesContainer.PurposeAttr).hide();
        $(Admin.Component.PropertiesContainer.PurposeAttr + AttrSelector(DataAttrName.Id, target)).show();
    });
}
