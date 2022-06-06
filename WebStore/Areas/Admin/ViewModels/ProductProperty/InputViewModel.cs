namespace WebStore.Areas.Admin.ViewModels.ProductProperty
{
    public record InputViewModel(
        PropertyViewModel Property, int ComponentIndex, int PropertyIndex, bool HasDisabled);
}
