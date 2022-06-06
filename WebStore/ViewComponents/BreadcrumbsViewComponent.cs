using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents
{
    public class BreadcrumbsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<(string Name, string Href, bool IsActive)> breadcrumbs)
        {
            return View(breadcrumbs);
        }
    }
}
