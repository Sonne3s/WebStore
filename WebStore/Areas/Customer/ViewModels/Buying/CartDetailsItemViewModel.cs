namespace WebStore.Areas.Customer.ViewModels.Buying
{
    public record CartDetailsItemViewModel(int ProductId, string Name, string ImageUrl, int Count, decimal Price, decimal Total);
}
