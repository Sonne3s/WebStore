using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Customer.ViewModels
{
    public record ProductListViewModel(ProductListFilterViewModel Filter, List<ProductListItemViewModel> Products, List<PaginationItemViewModel> Pages);/*PaginationViewModel Pagination*/

    public record ProductListItemViewModel(int Id, string Name, decimal Price, int Count, decimal Total, List<string> Images);

    public record ProductListItemCartSectionViewModel(int ProductId, int Count, decimal Total);

    public record ProductListFilterItemBlockViewModel(int OrderId, int GroupId, string Name, PropertyTypeEnumeration Type, List<string> Values, string UnitName);
}
