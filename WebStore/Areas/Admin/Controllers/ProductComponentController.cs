using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels.ProductComponent;

namespace WebStore.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductComponentController : Controller
    {
        private IProductComponentFiller _filler;
        private IProductComponentHandler _handler;

        public ProductComponentController(IProductComponentFiller filler, IProductComponentHandler handler)
        {
            _filler = filler;
            _handler = handler;
        }

        public IActionResult Item(string name, int counter) => View(_filler.GetFilledItemViewModel(counter, name));

        public IActionResult Container(ContainerViewModel viewModel) => View(_handler.InsertNewItem(viewModel));
    }
}
