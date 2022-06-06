using WebStore.Areas.Admin.ViewModels;
using WebStore.Models;

namespace WebStore.Areas.Admin.Handlers.IHandlers
{
    public interface IProductHandler
    {
        List<ProductModel> GetAll();

        ProductModel Get(int? id);

        List<EditViewModel.ImageModel> ImagesToBase64(List<ImageModel> target);

        bool Add(ProductModel product);

        void Delete(int productId);

        ProductTypeModel GetProductTypeFromProduct(int productId);

        List<ProductTypeModel> GetProductTypes();

        ProducerModel GetProducerFromProduct(int productId);

        List<ProducerModel> GetProducers();

        int GetNewComponentId();

        ProductModel GetProductByForm(IFormCollection form, EditViewModel viewModel);

        void ClearDb();
    }
}
