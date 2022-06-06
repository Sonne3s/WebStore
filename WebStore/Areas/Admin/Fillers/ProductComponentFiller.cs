using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.ViewModels.Components;
using WebStore.Areas.Admin.ViewModels.ProductComponent;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers
{
    public class ProductComponentFiller : IProductComponentFiller
    {
        IProductPropertyFiller _propertyFiller;

        public ProductComponentFiller(IProductPropertyFiller propertyFiller)
        {
            _propertyFiller = propertyFiller;
        }

        public ContainerViewModel GetFilledContainerViewModel(
            int productId, List<ComponentModel> components, int newComponentIndex = 0)
            => new ContainerViewModel(
                this.GetFilledItemViewModels(components),
                productId,
                newComponentIndex,
                string.Empty);

        private List<ItemViewModel> GetFilledItemViewModels(List<ComponentModel> components)
            => components.Select(c => this.GetFilledItemViewModel(components.IndexOf(c), c.Name)).ToList();

        public ItemViewModel GetFilledItemViewModel(int counter, string name)
            => new ItemViewModel(counter, name, counter == 0);
    }
}
