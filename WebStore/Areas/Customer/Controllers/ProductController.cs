using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Customer.Fillers.IFillers;
using WebStore.Areas.Customer.Handlers.IHandlers;
using WebStore.Areas.Customer.ViewModels;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Controllers.Customer
{

    [Route("[area]/[controller]/[action]")]
    [Area("Customer")]
    public class ProductController : Controller
    {
        private IProductHandler _handler;
        private IProductDetailsFiller _detailsFiller;
        private IProductListFiller _listFiller;
        private const int chunkSize = 8;
        private const int paginationSize = 9;

        public ProductController(IProductHandler handler, IProductDetailsFiller detailsFiller, IProductListFiller listFiller)
        {
            _handler = handler;
            _detailsFiller = detailsFiller;
            _listFiller = listFiller;            
        }

        [HttpGet]
        public IActionResult List(int page = 1) => View(GetListViewModel(_handler.GetProducts(chunkSize, page), page));

        private ProductListViewModel GetListViewModel(List<ProductModel> products, int page) => 
            _listFiller.GetFilledProductListViewModel(
                _handler.GetOrCreateCart(
                    this.HttpContext), 
                    products, 
                    _handler.GetProductTypes(),
                    _handler.GetProducers(),
                    _handler.GetMinProductPrice(),
                    _handler.GetMaxProductPrice(),
                    _handler.GetFilterProperties(), 
                    this.GetPaginationItemViewModels(page, _handler.GetCount(chunkSize, page)));

        private List<PaginationItemViewModel> GetPaginationItemViewModels(int page, int productCount)
            => _listFiller.GetFilledPaginationItemViewModels(_handler.GetPaginationItems(productCount, chunkSize, paginationSize, page));


        [HttpGet]
        public IActionResult Filter() => View(_handler.GetFilterProperties());


        [HttpGet]
        public IActionResult Products(List<ProductModel> products, List<PaginationItemViewModel> pages) 
            =>  PartialView("List\\Products", (_listFiller.GetFilledProductListItemViewModels(products, _handler.GetOrCreateCart(this.HttpContext)), pages));


        [HttpGet]
        public IActionResult Details(int id) => View(this.GetProductDetailsViewModel(_handler.GetProduct(id)));

        private ProductDetailsViewModel GetProductDetailsViewModel(ProductModel product) => 
            _detailsFiller.GetFilledProductDetailsViewModel(
                product, _handler.GetCartItem(this.HttpContext, product.Id));


        [HttpPost]
        public IActionResult Filter(ProductFilterViewModel request) 
        {
            var page = request.CurrentPage ?? 1;
            var filters = this.ToFilters(request);
            var baseFilters = this.ToBaseFilters(request);
            var products = _handler.GetFilteredProducts(filters, baseFilters,(chunkSize, page));

            return this.Products(products, this.GetPaginationItemViewModels(page, _handler.GetCount(filters, baseFilters)));
        }

        private List<ProductFilterModel> ToFilters(ProductFilterViewModel request)
        {
            return request.Properties.Where(p => p.Values != null && p.Values.Count > 0 && p.Values.Any(v => v != null)).Select(p => new ProductFilterModel
            {
                GroupId = p.GroupId,
                Type = (PropertyTypeEnumeration)p.TypeId,
                Values = p.Values
            }).ToList();
        }

        private ProductBaseFiltersModel ToBaseFilters(ProductFilterViewModel request)
            => new ProductBaseFiltersModel
            {
                MaxPrice = request.MaxPrice,
                MinPrice = request.MinPrice,
                Producer = request.Producer,
                Type = request.Type,
            };

        public IActionResult ListItemCartSection(int productId)
            => PartialView(
                "List\\ItemCartSection", 
                _listFiller.GetFilledProductListItemCartSectionViewModel(
                    _handler.GetCartItem(this.HttpContext, productId), productId));

        public IActionResult DetailsCartSection(int productId)
            => PartialView(
                "Details\\CartSection",
                 _detailsFiller.GetFilledCartSectionViewModel(
                    _handler.GetProduct(productId),
                    _handler.GetCartItem(this.HttpContext, productId)));
    }
}