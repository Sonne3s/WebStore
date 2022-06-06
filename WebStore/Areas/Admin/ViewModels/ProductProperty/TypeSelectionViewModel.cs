using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.Areas.Admin.ViewModels.ProductProperty
{
    public record TypeSelectionViewModel(int ComponentIndex, int PropertyIndex, List<SelectListItem> PropertyGroups);
}
