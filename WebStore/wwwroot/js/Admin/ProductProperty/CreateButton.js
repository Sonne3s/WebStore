var CreateButtonSuccess = function (id) {
    let link = $(AttrSelector(DataAttrName.Id, id) + Admin.Component.PropertiesContainer.AddPropertyInputLink.PurposeAttr);
    link.click();
}