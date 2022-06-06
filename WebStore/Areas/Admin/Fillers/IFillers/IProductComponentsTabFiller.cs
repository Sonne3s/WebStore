using WebStore.Areas.Admin.ViewModels;
using WebStore.Areas.Admin.ViewModels.Components;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers.IFillers
{
    public interface IProductComponentsTabFiller
    {
        ComponentsTabViewModel GetFilledComponentViewModels(int productId, List<ComponentModel> components, int newComponentIndex = 0);

        ComponentViewModel GetFilledComponentViewModel(int counter, string name);
    }
}
