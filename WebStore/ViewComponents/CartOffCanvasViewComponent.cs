using Microsoft.AspNetCore.Mvc;
using WebStore.Helpers.IHelpers;
using WebStore.Repositories.IRepositories;
using WebStore.ViewComponentModels;

namespace WebStore.ViewComponents
{
    public class CartOffCanvasViewComponent : ViewComponent
    {
        private ICartRepository _orderRepository;
        private IUserHelper _userHelper;
        private IOrderHelper _orderHelper;

        public CartOffCanvasViewComponent(ICartRepository orderRepository, IUserHelper userHelper, IOrderHelper orderHelper)
        {
            _orderRepository = orderRepository;
            _userHelper = userHelper;
            _orderHelper = orderHelper;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userHelper.GetUserOrDefault(this.HttpContext);

            return View(new CartOffCanvasViewComponentModel
            {
                Total = _orderRepository.GetTotal(user),
                Count = _orderHelper.GetOrCreateCart(user)?.Items?.Sum(i => i.Count) ?? 0,
            });
        }
    }
}
