using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Customer.Fillers.IFillers;
using WebStore.Areas.Customer.Handlers.IHandlers;

namespace WebStore.Areas.Customer.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Customer")]
    public class BuyingController : Controller
    {
        private IBuyingHandler _handler;
        private IBuyingFiller _filler;

        public BuyingController(IBuyingHandler handler, IBuyingFiller filler)
        {
            _handler = handler;
            _filler = filler;
        }

        public IActionResult ListAddToCart(int productId)
            => RedirectToAction(
                "ListItemCartSection", 
                "Product", 
                new { 
                    Area = "Customer", 
                    ProductId = _handler.AddToCart(productId, this.HttpContext).ProductId,
                    TempData = this.TempData["action"] = "List"
                });

        public IActionResult ListRemoveFromCart(int productId)
            => RedirectToAction(
                "ListItemCartSection",
                "Product",
                new {
                    Area = "Customer",
                    ProductId = _handler.RemoveFromCart(productId, this.HttpContext)?.ProductId ?? productId,
                    TempData = this.TempData["action"] = "List"
                });

        public IActionResult DetailsAddToCart(int productId)
            => RedirectToAction(
                "DetailsCartSection",
                "Product",
                new
                {
                    Area = "Customer",
                    ProductId = _handler.AddToCart(productId, this.HttpContext).ProductId,
                    TempData = this.TempData["action"] = "Details"
                });

        public IActionResult DetailsRemoveFromCart(int productId)
            => RedirectToAction(
                "DetailsCartSection",
                "Product",
                new
                {
                    Area = "Customer",
                    ProductId = _handler.RemoveFromCart(productId, this.HttpContext)?.ProductId ?? productId,
                    TempData = this.TempData["action"] = "Details"
                });

        public IActionResult ClearCart()
            => RedirectToAction(nameof(CartOffCanvas), _handler.ClearCart(this.HttpContext));

        public IActionResult CartOffCanvas()
            => ViewComponent("CartOffCanvas");
            //=> View(_filler.GetFilledCartOffCanvasViewModel(_handler.GetOrCreateCart(this.HttpContext)));

        public string QuantityGoodsInCart() 
            => _handler.GetQuantityGoodsInCart(this.HttpContext).ToString();

        public int QuantityGoodsInCartByProduct(int productId) 
            => _handler.GetQuantityGoodsInCartByProduct(this.HttpContext, productId);

        public IActionResult CartDetails()
            => View(_filler.GetFillerCartDetailsViewModel(_handler.GetOrCreateCart(this.HttpContext)));

        public IActionResult CartDetailsAddToCart(int productId)
            => RedirectToAction("CartDetails", new { ProductId = _handler.AddToCart(productId, this.HttpContext).ProductId });

        public IActionResult CartDetailsRemoveFromCart(int productId)
            => RedirectToAction("CartDetails", new { ProductId = _handler.RemoveFromCart(productId, this.HttpContext)?.ProductId ?? productId });

        public IActionResult CheckOut() 
            => View(_filler.GetFilledCheckOutViewModel(_handler.GetUser(this.HttpContext)));

        //[HttpPost]
        //public IActionResult CheckOut(BuyingCheckOutViewModel model)
        //{
        //    var isOk = _handler.CheckOut(model, this.HttpContext);
        //    if (isOk)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(model);
        //}
    }
}
