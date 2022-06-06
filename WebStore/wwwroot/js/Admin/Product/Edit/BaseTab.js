$(function () {
    $("#TypeId").change(function () {
        ChangePropertyEvent($(this), "#EditProductType");
    });

    $("#ProducerId").change(function () {
        ChangePropertyEvent($(this), "#EditProducer");
    });

    $("#CreateProductType").click(function () {
        let url = $(this).attr("data-partial");
        CreateEditPropertyModal(url, "#Modal");
    });

    $("#EditProductType").click(function () {
        let $this = $(this);
        let id = $this.siblings("select").find("option:checked").val();
        let url = $this.attr("data-partial") + "?id=" + id;
        CreateEditPropertyModal(url, "#Modal");
    });

    $("#CreateProducer").click(function () {
        let url = $(this).attr("data-partial");
        CreateEditPropertyModal(url, "#Modal");
    });

    $("#EditProducer").click(function () {
        let $this = $(this);
        let id = $this.siblings("select").find("option:checked").val();
        let url = $this.attr("data-partial") + "?id=" + id;
        CreateEditPropertyModal(url, "#Modal");
    });
});

var updateProducerList = function (id) {
    let url = $("#CreateProducer").attr("data-val") + "?id=" + id;
    UpdateSelectList(url, "#ProducerId", id, "#EditProducer");
    HideModal("#Modal");
}

var updateProductTypesList = function (id) {
    let url = $("#CreateProductType").attr("data-val") + "?id=" + id;
    UpdateSelectList(url, "#TypeId", id, "#EditProductType");
    HideModal("#Modal");
}