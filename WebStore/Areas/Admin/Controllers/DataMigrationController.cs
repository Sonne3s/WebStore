using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Admin.Handlers.IHandlers;

namespace WebStore.Areas.Admin.Controllers
{
    public class DataMigrationController : Controller
    {
        IDataMigrationHandler _handler;

        public DataMigrationController(IDataMigrationHandler handler) 
        {
            _handler = handler;
        }

        #region Product

        [HttpGet("Export_products")]
        public IActionResult ExportProducts()
        {
            return File(_handler.GetProductsExportFile(), "application/zip", "CoolLifeData.zip");
        }

        [HttpPost]
        public IActionResult ImportProducts(IFormFile file)
        {
            var content = _handler.ExtractJsonsAndWriteImages(file);

            var products = _handler.GetProductsFromJsonString(content.Products);
            _handler.ProductsAddRange(products);
            var groups = _handler.GetGroupsFromJsonString(content.Groups);
            _handler.GroupsAddRange(groups);
            var productTypes = _handler.GetProductTypesFromJsonString(content.ProductTypes);
            _handler.ProductTypesAddRange(productTypes);
            var producers = _handler.GetProducersFromJsonString(content.Producers);
            _handler.ProducersAddRange(producers);
            var properties = _handler.GetPropertiesFromJsonString(content.Properties);
            _handler.PropertiesAddRange(properties);
            var values = _handler.GetValuesFromJsonString(content.Values);
            _handler.ValuesAddRange(values);
            var units = _handler.GetUnitsFromJsonString(content.Units);
            _handler.UnitsAddRange(units);
            var images = _handler.GetImagesFromJsonString(content.Images);
            _handler.ImagesAddRange(images);

            return RedirectToAction("List", "Product", new { Area = "Admin" });
        }

        #endregion Product
    }
}
