using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Areas.Admin.ViewModels.Components;
using WebStore.Extensions;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductHandler _handler;
        private IHelperProvider _helpers;
        private IProductFiller _filler;

        public ProductController(IProductHandler handler, IHelperProvider helpers, IProductFiller filler)
        {
            _handler = handler;
            _helpers = helpers;
            _filler = filler;
        }

        #region Products

        public IActionResult List() 
            => View(new AdminProductListViewModel { Products = _handler.GetAll() });

        [HttpGet]
        public IActionResult Edit(int? id)
            => View(_filler.GetFilledEditViewModel(
                    _handler.Get(id), _handler.GetProductTypes(), _handler.GetProducers()));

        [HttpPost]
        public bool Edit(EditViewModel model)
        {
            var form = this.Request.Form;
            var product = _handler.GetProductByForm(form, model);

            _handler.Add(product);

            return true;
        }

        public IActionResult Delete(int productId)
        {
            _handler.Delete(productId);

            return RedirectToAction(nameof(this.List));
        }

        #endregion Products

        public IActionResult ClearDb()
        {
            _handler.ClearDb();

            return RedirectToAction(nameof(List));
        }
    }
}
