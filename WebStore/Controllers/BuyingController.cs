using Microsoft.AspNetCore.Mvc;
using WebStore.Handlers.IHandlers;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class BuyingController : Controller
    {
        private IBuyingHandler _handler;
        public BuyingController(IBuyingHandler handler)
        {
            _handler = handler;
        }

        //public IActionResult CartDetails()
        //{
        //    return View();
        //}

        //public IActionResult AddToCart(int productId)
        //{
        //    _handler.AddToCart(productId, this.HttpContext);

        //    return Redirect(Request.Headers["Referer"].ToString()); ;
        //}

        //public IActionResult RemoveFromCart(int productId)
        //{
        //    _handler.RemoveFromCart(productId, this.HttpContext);

        //    return Redirect(Request.Headers["Referer"].ToString()); ;
        //}

        public IActionResult CheckOut()
        {
            var user = _handler.GetUser(this.HttpContext.User?.Identity);

            return View(new BuyingCheckOutViewModel
            {
                Company = user.Company,
                Email = user.Login,
                FullName = $"{user.LastName} {user.FirstName} {user.MiddleName}",
                Phone = user.Phone,
                Installation = new BuyingCheckOutViewModel.DeliveryData
                {
                    Address = user.Address,
                },
                Delivery = new BuyingCheckOutViewModel.DeliveryData
                {
                    Address = user.Address,
                },
            });
        }

        [HttpPost]
        public IActionResult CheckOut(BuyingCheckOutViewModel model)
        {
           var isOk = _handler.CheckOut(model, this.HttpContext);
           if(isOk)
           {
               return RedirectToAction("Index", "Home");
           }

            return View(model);
        }
    }
}
