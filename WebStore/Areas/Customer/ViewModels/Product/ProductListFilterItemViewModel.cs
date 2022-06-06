using WebStore.Models.Enumerations;

namespace WebStore.Areas.Customer.ViewModels.Product
{
    public record ProductListFilterItemViewModel(int OrderId, int GroupId, string Name, PropertyTypeEnumeration Type, List<string> Values, string UnitName);
}
