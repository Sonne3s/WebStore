using WebStore.Models.Enumerations;

namespace WebStore.Areas.Admin.ViewModels.Components
{
    public record PropertyValueViewModel(
        PropertyTypeEnumeration Type, int GroupId, string PropertyName, List<string> Values, string UnitValue);
}
