namespace WebStore.Areas.Customer.ViewModels.Product
{
    public record ProductFilterViewModel(
        int Type, decimal MinPrice, decimal MaxPrice, List<int> Producer, List<ProductFilterItemViewModel> Properties, int? CurrentPage);

    public record ProductFilterItemViewModel(int GroupId, int TypeId, List<string> Values);   
}
