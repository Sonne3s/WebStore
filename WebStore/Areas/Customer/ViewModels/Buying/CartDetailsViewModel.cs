namespace WebStore.Areas.Customer.ViewModels.Buying
{
    public record CartDetailsViewModel(int TotalCount, decimal TotalPrice, List<CartDetailsItemViewModel> Items);
}
