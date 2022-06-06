using Property = WebStore.Areas.Admin.ViewModels.ProductProperty;

namespace WebStore.Areas.Admin.ViewModels.ProductComponent
{
    public record ContainerViewModel(List<ItemViewModel> Items, int ProductId, int? NewIndex, string NewName);
}
