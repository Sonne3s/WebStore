using Microsoft.AspNetCore.Mvc;
using WebStore.Helpers.IHelpers;
using WebStore.Repositories.IRepositories;
using WebStore.ViewComponentModels;
using static WebStore.ViewComponentModels.CartListViewComponentModel;

namespace WebStore.ViewComponents
{
    public class CartListViewComponent : ViewComponent
    {
        private IUserHelper _userHelper;
        private IOrderHelper _orderHelper;
        public CartListViewComponent(IUserHelper userHelper, IOrderHelper orderHelper)
        {
            _userHelper = userHelper;
            _orderHelper = orderHelper;
        }

        public IViewComponentResult Invoke()
        {
            return View(this.GetCartModel());
        }

        private CartListViewComponentModel GetCartModel()
        {
            return new CartListViewComponentModel
            {
                CartItems = this.GetCartItems()
            };
        }

        private IEnumerable<CartListItemModel> GetCartItems()
        {
            var user = _userHelper.GetUserOrDefault(this.HttpContext);
            var cart = _orderHelper.GetOrCreateCart(user);

            return cart?.Items?.Select(i => new CartListItemModel
            {
                Id = i.Product.Id,
                Count = i.Count,
                Name = $"{i.Product.ProductType.Value} {i.Product.Producer.Value} {i.Product.Name}",
                ImageUrl = i.Product.Images.First().Src,
                Total = i.Product.Price * i.Count,
            }) ?? new List<CartListItemModel>();
        }
    }
}
