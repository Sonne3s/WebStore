using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents
{
    public class ExtractInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string value)
        {
            return View("Default", value);
        }
    }
}
