using WebStore.Areas.Admin.ViewModels;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers.IFillers
{
    public interface IProductFiller
    {
        EditViewModel GetFilledEditViewModel(
            ProductModel product,
            List<ProductTypeModel> productTypes,
            List<ProducerModel> producers);
    }
}
