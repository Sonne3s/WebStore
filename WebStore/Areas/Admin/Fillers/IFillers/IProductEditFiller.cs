using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.ViewModels.ProductEdit;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers.IFillers
{
    public interface IProductEditFiller
    {
        CreateOrUpdateProductTypeModalViewModel GetFilledCreateProductTypeViewModel(ProductTypeModel model);

        CreateOrUpdateProducerModalViewModel GetFilledCreateProducerViewModel(ProducerModel model);

        List<SelectListItem> GetFilledSelectListItems<T>(
            List<T> items, int? selectedId = null) where T : ISelectListItem;

        ImagesTabViewModel GetFilledImagesTabViewModel(List<ImageModel> target);
    }
}
