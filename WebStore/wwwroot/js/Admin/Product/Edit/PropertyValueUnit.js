var updatePropertyUnitList = function (id) {
    let url = $("#CreateValueUnitModalButton").attr("data-val") + "?id=" + id;
    UpdateSelectList(url, "#UnitTypeId", id, "#EditValueUnitModalButton");
    HideModal("#SubModal");
    $("#Modal").modal('show');
}