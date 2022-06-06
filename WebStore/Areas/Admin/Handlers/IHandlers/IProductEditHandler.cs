using WebStore.Models;

namespace WebStore.Areas.Admin.Handlers.IHandlers
{
    public interface IProductEditHandler
    {
        int CreateOrUpdateProductType(int id, string productTypeName, string productTypeDescription);

        ProductTypeModel GetProductType(int? id);

        int DeleteProductType(int id);

        List<ProductTypeModel> GetProductTypes();

        ProductTypeModel GetProductTypeFromProduct(int productId);

        int CreateOrUpdateProducer(int id, string name, string description);

        int DeleteProducer(int id);

        ProducerModel GetProducerFromProduct(int productId);

        ProducerModel GetProducer(int? id);

        List<ProducerModel> GetProducers();
    }
}
