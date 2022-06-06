using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.Areas.Admin.ViewModels.ProductProperty
{
    public record CreationPageViewModel(int? ComponentIndex, int? PropertyIndex, int? Id, string Name, string Description, int? TypeId, List<SelectListItem> Types, int? UnitId, List<SelectListItem> Units);
}
