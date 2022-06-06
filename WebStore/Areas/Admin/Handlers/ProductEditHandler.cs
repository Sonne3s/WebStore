using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Admin.Handlers
{
    public class ProductEditHandler : IProductEditHandler
    {
        private IProductRepository _productRepository;

        public ProductEditHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region ProductTypes

        public int CreateOrUpdateProductType(int id, string productTypeName, string productTypeDescription)
            => id == default(int)
                ? _productRepository.CreateProductType(productTypeName, productTypeDescription).Id
                : _productRepository.UpdateProductType(id, productTypeName, productTypeDescription).Id;

        public int DeleteProductType(int id) => _productRepository.RemoveProductType(id).Id;

        public List<ProductTypeModel> GetProductTypes() => _productRepository.GetAllProductTypes();

        public ProductTypeModel GetProductTypeFromProduct(int productId) 
            => _productRepository.GetProductTypeFromProduct(productId);

        public ProductTypeModel? GetProductType(int? id)
            => !id.HasValue 
                ? null 
                : id == -1 
                    ? _productRepository.GetLastProductType() 
                    : _productRepository.GetProductType(id.Value);

        #endregion ProductTypes

        #region Producers

        public int CreateOrUpdateProducer(int id, string name, string description)
            => id == default(int)
                ? _productRepository.CreateProducer(name, description).Id
                : _productRepository.UpdateProducer(id, name, description).Id;

        public int DeleteProducer(int id) => _productRepository.RemoveProducer(id).Id;

        public List<ProducerModel> GetProducers() => _productRepository.GetAllProducers();

        public ProducerModel GetProducerFromProduct(int productId) 
            =>_productRepository.GetProducerForProduct(productId);

        public ProducerModel? GetProducer(int? id) => !id.HasValue
            ? null
            : id == -1
                ? _productRepository.GetLastProducer()
                : _productRepository.GetProducer(id.Value);

        #endregion Producers
    }
}
