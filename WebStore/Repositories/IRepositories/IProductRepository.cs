using WebStore.Models;

namespace WebStore.Repositories.IRepositories
{
    public interface IProductRepository : IBaseProductRepository
    {
        List<ComponentModel> GetComponents(int productId);

        int GetLastComponentId();

        List<ProductTypeModel> GetAllProductTypes();

        void ProductTypesAddRange(List<ProductTypeModel> productTypes);

        ProductTypeModel CreateProductType(string productTypeName, string productTypeDescription);

        ProductTypeModel RemoveProductType(int id);

        ProductTypeModel GetLastProductType();

        ProductTypeModel UpdateProductType(int id, string value, string description);

        ProductTypeModel GetProductType(int productId);

        ProductTypeModel GetProductTypeFromProduct(int productId);

        ProducerModel GetProducerForProduct(int productId);

        ProducerModel CreateProducer(string name, string description);

        ProducerModel RemoveProducer(int id);

        ProducerModel UpdateProducer(int id, string value, string description);

        List<ProducerModel> GetAllProducers();

        ProducerModel GetProducer(int id);

        ProducerModel GetLastProducer();

        void ProducersAddRange(List<ProducerModel> producers);

        List<ImageModel> GetAllImages();

        void ImagesAddRange(List<ImageModel> images);

        (decimal MinPrice, decimal MaxPrice) GetPriceRange();

        decimal GetMaxPrice();

        decimal GetMinPrice();
    }
}
