namespace WebStore.Areas.Customer.ViewModels.Product
{
    public record PaginationViewModel(int CurrentPage, List<int> Pages, int? FirstPage, int? LastPage);

    public record PaginationItemViewModel(int Id, bool IsActive, bool IsFirst, bool IsLast, string? AlterValue = null);
}
