using Microsoft.AspNetCore.Mvc;
using WebStore.Helpers.IHelpers;

namespace WebStore.ViewComponents
{
    public class UserbarViewComponent : ViewComponent
    {
        private IHelperProvider _helper;

        public UserbarViewComponent(IHelperProvider helper)
        {
            _helper = helper;
        }

        public IViewComponentResult Invoke()
            => View((_helper.User.GetUserOrDefault(this.HttpContext), _helper.User));
    }
}
