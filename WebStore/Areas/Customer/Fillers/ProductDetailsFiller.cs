using WebStore.Areas.Customer.Fillers.IFillers;
using WebStore.Areas.Customer.ViewModels.Details;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Customer.Fillers
{
    public class ProductDetailsFiller : IProductDetailsFiller
    {
        IHelperProvider _helper;

        public ProductDetailsFiller(IHelperProvider helper)
        {
            _helper = helper;
        }

        public ProductDetailsViewModel GetFilledProductDetailsViewModel(
            ProductModel product, OrderingItemModel cartItem)
            => new ProductDetailsViewModel(
                this.GetFilledProductViewModel(product),
                this.GetFilledCartSectionViewModel(product, cartItem));

        public CartSectionViewModel GetFilledCartSectionViewModel(
            ProductModel product, OrderingItemModel cartItem)
            => new CartSectionViewModel(product.Id, cartItem?.Count ?? default(int), product.Price);

        private ProductViewModel GetFilledProductViewModel(ProductModel product)
        {
            return new ProductViewModel(
                product.Id, 
                product.Name, 
                product.Price,
                product.Description,
                product.ProductType.Value,
                product.Producer.Value,
                this.GetFilledImagesViewModel(product.Images), 
                this.GetFilledPropertiesPageViewModels(product.Components));
        }

        private ImagesViewModel GetFilledImagesViewModel(List<ImageModel> images)
        {
            var filledImage = this.GetFilledImageViewModels(images);

            return new ImagesViewModel(filledImage, filledImage.Take(3).ToList(), filledImage.Skip(3).ToList());
        }

        private List<ImageViewModel> GetFilledImageViewModels(List<ImageModel> images)
        {
            return images.Select(i => new ImageViewModel(images.IndexOf(i), i.Src)).ToList();
        }

        private List<PropertiesPageViewModel> GetFilledPropertiesPageViewModels(List<ComponentModel> components)
        {
            return components.Select(c => new PropertiesPageViewModel(components.IndexOf(c), c.Name, this.GetFilledPropertyViewModels(c.Properties))).ToList();
        }

        private List<PropertyViewModel> GetFilledPropertyViewModels(List<PropertyModel> properties)
        {
            return properties.Select(p => new PropertyViewModel(
                p.Group.Name,
                p.Group.Description,
                 _helper.Properties.ExtractPropertyValues(p),
                this.GetPropertyValueDescription(p),
                (PropertyTypeEnumeration)p.Group.TypeId,
                p.Group.UnitType?.Value)).ToList();
        }

        private string GetPropertyValueDescription(PropertyModel property)
        {
            switch (property.Group.TypeId)
            {
                case (int)PropertyTypeEnumeration.Text:
                    //return property.PropertyTextValue.Description;

                case (int)PropertyTypeEnumeration.Integer:
                case (int)PropertyTypeEnumeration.Decimal:
                    return null;
            }

            throw new Exception("unknown property value type");
        }
    }
}
