using WebStore.Models;

namespace WebStore.Repositories.IRepositories
{
    public interface IBaseProductRepository
    {
        void ClearDb();

        ProductModel Get(int? productId);

        void Add(ProductModel product);

        void AddRange(List<ProductModel> products);

        void Delete(int id);

        void Replace(ProductModel newProduct);

        List<ProductModel> GetAll();

        List<ProductModel> GetAll((int chunkSize, int chunkNumber) paginationFilter);

        List<ProductModel> GetAll(List<Models.ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int chunkSize, int chunkNumber) paginationFilter);

        int GetCount(List<Models.ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int chunkSize, int chunkNumber) paginationFilter);

        int GetCount((int chunkSize, int chunkNumber) paginationFilter);

        int GetCount();
    }
}
