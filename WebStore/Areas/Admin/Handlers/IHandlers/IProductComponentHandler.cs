using WebStore.Areas.Admin.ViewModels.ProductComponent;
using WebStore.Models;

namespace WebStore.Areas.Admin.Handlers.IHandlers
{
    public interface IProductComponentHandler
    {
        List<ComponentModel> GetComponents(int productId);

        ContainerViewModel InsertNewItem(ContainerViewModel target);
    }
}
