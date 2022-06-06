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