using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Extensions;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers
{
    public class ProductFiller : IProductFiller
    {
        private IProductComponentsTabFiller _productComponentsTabFiller;
        private IProductEditFiller _productEditFiller;

        public ProductFiller(
            IProductComponentsTabFiller productComponentsTabFiller, IProductEditFiller productEditFiller)
        {
            _productComponentsTabFiller = productComponentsTabFiller;
            _productEditFiller = productEditFiller;
        }

        public EditViewModel GetFilledEditViewModel(
            ProductModel product, 
            List<ProductTypeModel> productTypes, 
            List<ProducerModel> producers)
            => new EditViewModel
            {
                Id = product?.Id,
                Description = product?.Description,
                Name = product?.Name,
                Price = (product?.Price)?.ToInputNumber(),
                ProductTypes = _productEditFiller.GetFilledSelectListItems(productTypes, product?.ProductType?.Id),
                Producers = _productEditFiller.GetFilledSelectListItems(producers, product?.Producer?.Id),
                ComponentsTab = product != null
                    ? _productComponentsTabFiller.GetFilledComponentViewModels(
                        product.Id,
                        product.Components,
                        product.Components.Count)
                    : null,
                ImagesTab = product != null
                    ? _productEditFiller.GetFilledImagesTabViewModel(product.Images)
                    : null
            };
    }
}
