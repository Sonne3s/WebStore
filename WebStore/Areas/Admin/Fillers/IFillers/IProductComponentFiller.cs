using WebStore.Areas.Admin.ViewModels.ProductComponent;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers.IFillers
{
    public interface IProductComponentFiller
    {
        ItemViewModel GetFilledItemViewModel(int counter, string name);

        ContainerViewModel GetFilledContainerViewModel(
            int productId, List<ComponentModel> components, int newComponentIndex);
    }
}
