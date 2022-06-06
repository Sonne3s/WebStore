using WebStore.Models.Enumerations;

namespace WebStore.Areas.Admin.ViewModels.ProductProperty
{
    public record PropertyViewModel(PropertyTypeEnumeration Type, int GroupId, string PropertyName, List<string> Values, int? UnitId, string UnitValue);
}
