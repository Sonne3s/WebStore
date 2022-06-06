using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.ViewModels.ProductEdit;
using WebStore.Helpers.IHelpers;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers
{
    public class ProductEditFiller : IProductEditFiller
    {
        private IHelperProvider _helper;

        public ProductEditFiller(IHelperProvider helper)
        {
            _helper = helper;
        }

        public CreateOrUpdateProductTypeModalViewModel GetFilledCreateProductTypeViewModel(ProductTypeModel model)
            => new CreateOrUpdateProductTypeModalViewModel(model?.Id, model?.Value, model?.Description);

        public CreateOrUpdateProducerModalViewModel GetFilledCreateProducerViewModel(ProducerModel model)
            => new CreateOrUpdateProducerModalViewModel(model?.Id, model?.Value, model?.Description);

        public List<SelectListItem> GetFilledSelectListItems<T>(List<T> items, int? selectedId = null) where T 
            : ISelectListItem
            => this.GetFilledSelectListItems(items.Select(i 
                => (i.Value, i.Id, items.IndexOf(i))), items.Count, selectedId);

        private List<SelectListItem> GetFilledSelectListItems(
            IEnumerable<(string ItemText, int ItemValue, int ItemIndex)> items, int count, int? selectedItemId)
            => items.Select(i => this.GetFilledSelectListItem(i.ItemText, i.ItemValue, i.ItemIndex, count, selectedItemId))
                .Prepend(new SelectListItem()) //add empty value
                .ToList();

        private SelectListItem GetFilledSelectListItem(
            string itemText, int itemValue, int itemIndex, int listCount, int? selectedId)
            => new SelectListItem(
                itemText,
                itemValue.ToString(),
                selectedId.HasValue
                    ? selectedId != -1
                        ? itemValue == selectedId
                        : (itemIndex + 1) == listCount //set last selected
                    : false);

        public ImagesTabViewModel GetFilledImagesTabViewModel(List<ImageModel> images)
            => new ImagesTabViewModel(this.GetFilledImageViewModels(images));

        private List<ImageViewModel> GetFilledImageViewModels(List<ImageModel> images)
            => images.Select(i => new ImageViewModel(
                i.Id, Path.GetFileName(i.Src), _helper.File.GetBase64SrcData(i.Src))).ToList();
    }
}
