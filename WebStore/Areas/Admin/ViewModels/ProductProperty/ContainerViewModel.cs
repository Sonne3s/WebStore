namespace WebStore.Areas.Admin.ViewModels.ProductProperty
{
    public record ContainerViewModel(
        int Index, string Name, bool IsActive, AddButtonViewModel Button, List<InputViewModel> Properties);
}
