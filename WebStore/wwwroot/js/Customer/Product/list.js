$(function () {
    $(".carousel-indicators button").hover(function () {
        $(this).click();
    });

    $(".carousel-indicators").mouseleave(function () {
        $(this).closest(".carousel").carousel(0);
    });
});
$(function () {
    ApplyPaginationEvents($(".pagination-section"));
});

var ApplyPaginationEvents = function ($target) {
    $target.find(".pagination-link").click(function () {
        $form = $("form#filter");
        $form.find("#CurrentPage").val($(this).attr("data-id"));
        $("form#filter [type='submit']").click();
    });
}
var ApplyProductContainerEvents = function () {
    $productContainer = $("#products-container");
    ApplyPaginationEvents($productContainer);
}
var AddOrRemoveCartItemSuccess = function () {
    ReloadCartOffCanvas();
    UpdateCartOffCanvasButtonItemsCount();

    function ReloadCartOffCanvas() {
        $(Customer.CartOffCanvas.Purpose).click();
    }    
}

var ClearCartSuccess = function () {
    $(Customer.Product.List.Item.CartSection.ReloadButton.Purpose).click();
    UpdateCartOffCanvasButtonItemsCount();
}

var UpdateCartOffCanvasButtonItemsCount = function() {
    $(Customer.Navbar.QuantityGoodsInCart.Purpose).click();
}
$(function () {
    $(".cart-off-canvas .hide-button").click(function () {
        bootstrap.Offcanvas.getInstance($(".cart-off-canvas")[0]).hide();
    });
});
$(function () {
    $(".userbar-menu input").focusin(function () {
        $(this).closest(".userbar-menu").addClass("show");
    });

    $(".userbar-menu input").focusout(function () {
        if (!$(".userbar-menu input").is(":focus")) {
            $(this).closest(".userbar-menu").removeClass("show");
        }
    });
});