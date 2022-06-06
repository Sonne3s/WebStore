using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents
{
    public class AddRemoveToCartButtonsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke((int ProductId, int Count, decimal Total) value)
        {
            return View(value);
        }
    }
}
