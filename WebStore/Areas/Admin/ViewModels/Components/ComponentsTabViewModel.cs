using Property = WebStore.Areas.Admin.ViewModels.ProductProperty;
using Component = WebStore.Areas.Admin.ViewModels.ProductComponent;

namespace WebStore.Areas.Admin.ViewModels.Components
{
    public record ComponentsTabViewModel(
        int ProductId, 
        int NewComponentIndex, 
        Component.ContainerViewModel ComponentContainer, 
        List<Property.ContainerViewModel> PropertyContainers);
}
