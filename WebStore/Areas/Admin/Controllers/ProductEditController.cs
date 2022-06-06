using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels.ProductEdit;
using WebStore.Models;

namespace WebStore.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductEditController : Controller
    {
        private IProductEditHandler _handler;
        private IProductEditFiller _filler;

        public ProductEditController(IProductEditHandler handler, IProductEditFiller filler)
        {
            _handler = handler;
            _filler = filler;
        }

        #region ProductTypes

        [HttpPost]
        public IActionResult CreateOrUpdateProductTypeModal(int? typeId)
            => View(_filler.GetFilledCreateProductTypeViewModel(_handler.GetProductType(typeId)));

        [HttpPost]
        public IActionResult CreateOrUpdateProductType(int id, string typeName, string description)
            => RedirectToAction(
                nameof(ProductType), new { Id = _handler.CreateOrUpdateProductType(id, typeName, description) });

        [HttpPost]
        public IActionResult DeleteProductType(int id) => 
            RedirectToAction(nameof(ProductType), new { Id = _handler.DeleteProductType(id) });

        public IActionResult ProductType(int? id)
            => View(_filler.GetFilledSelectListItems(_handler.GetProductTypes(), _handler.GetProductType(id)?.Id));

        #endregion ProductTypes

        #region Producers

        [HttpPost]
        public IActionResult CreateOrUpdateProducerModal(int? producerId)
            => View(_filler.GetFilledCreateProducerViewModel(_handler.GetProducer(producerId)));

        [HttpPost]
        public IActionResult CreateOrUpdateProducer(int id, string producerName, string description)
            => RedirectToAction(
                nameof(Producer), new { Id = _handler.CreateOrUpdateProducer(id, producerName, description) });

        [HttpPost]
        public IActionResult DeleteProducer(int id) =>
            RedirectToAction(nameof(Producer), new { Id = _handler.DeleteProducer(id) });

        public IActionResult Producer(int? id)
            => View(_filler.GetFilledSelectListItems(_handler.GetProducers(), _handler.GetProducer(id)?.Id));

        #endregion Producers
    }
}
