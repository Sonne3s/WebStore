using WebStore.Areas.Customer.ViewModels.Details;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Customer.ViewModels.Product
{
    public record ProductDetailsViewModel(ProductViewModel Product, CartSectionViewModel CartSection);

    public record ProductViewModel(
        int Id, string Name, decimal Price, string Description, string Type, string Producer, ImagesViewModel Images, List<PropertiesPageViewModel> PropertiesPages);

    public record ImagesViewModel(List<ImageViewModel> AllImages, List<ImageViewModel> VisibleImages, List<ImageViewModel> HiddenImages);

    public record ImageViewModel(int Id, string Src);

    public record PropertiesPageViewModel(int Id, string Name, List<PropertyViewModel> Properties);

    public record PropertyViewModel(string Name, string Description, string Value, string ValueDescription, PropertyTypeEnumeration Type, string UnitValue);
}
