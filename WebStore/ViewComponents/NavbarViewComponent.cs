using Microsoft.AspNetCore.Mvc;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Repositories.IRepositories;
using WebStore.ViewComponentModels;

namespace WebStore.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private IUserHelper _userHelper;
        private IOrderHelper _orderHelper;

        public NavbarViewComponent(ICartRepository cartRepository, IUserHelper userHelper, IOrderHelper orderHelper)
        {
            _userHelper = userHelper;
            _orderHelper = orderHelper;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userHelper.GetUserOrDefault(this.HttpContext);

            return View(new NavbarViewComponentModel()
            {
                User = user,
                UserHelper = _userHelper,
                CartItemsCount = _orderHelper.GetOrCreateCart(user)?.Items?.Sum(i => i.Count) ?? 0,
            });
        }
    }
}
