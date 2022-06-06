using Microsoft.AspNetCore.Mvc;
using WebStore.Helpers.IHelpers;

namespace WebStore.ViewComponents
{
    public class CartbarViewComponent : ViewComponent
    {
        private IHelperProvider _helper;

        public CartbarViewComponent(IHelperProvider helper)
        {
            _helper = helper;
        }

        public IViewComponentResult Invoke()
            => View(_helper.Order.GetOrCreateCart(_helper.User.GetUserOrDefault(this.HttpContext))?.Items?.Sum(i => i.Count) ?? 0);
    }
}
