using WebStore.Areas.Customer.ViewModels;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Customer.Handlers.IHandlers
{
    public interface IProductHandler
    {
        ProductModel GetProduct(int id);

        List<ProductModel> GetProducts(int chunkSize, int chunkNumber);

        List<ProductModel> GetFilteredProducts(List<ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int chunkSize, int chunkNumber) paginationFilter);

        int GetCount(int chunkSize, int chunkNumber);

        int GetCount(List<ProductFilterModel> filters, ProductBaseFiltersModel baseFilters);

        List<ProductListFilterItemViewModel> GetFilterProperties();    

        List<ProductPaginationItemModel> GetPaginationItems(int productCount, int chunkSize, int paginationSize, int currentPage);

        OrderingModel GetOrCreateCart(HttpContext context);

        OrderingItemModel GetCartItem(HttpContext context, int productId);

        List<ProductTypeModel> GetProductTypes();

        List<ProducerModel> GetProducers();

        decimal GetMaxProductPrice();

        decimal GetMinProductPrice();
    }
}
