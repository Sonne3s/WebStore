using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Admin.ViewModels
{
    public record PropertyViewModel(PropertyTypeEnumeration Type, int GroupId, string PropertyName, List<string> Values, string UnitValue);
}
