using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels.ProductComponent;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Admin.Handlers
{
    public class ProductComponentHandler : IProductComponentHandler
    {
        private IProductRepository _productRepository;

        public ProductComponentHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ComponentModel> GetComponents(int productId) 
            => _productRepository.GetComponents(productId);

        public ContainerViewModel InsertNewItem(ContainerViewModel target)
            => target with 
            { 
                Items = this.InsertNewItem(
                    target.Items != null ? target.Items : new List<ItemViewModel>(), target.NewIndex.Value, target.NewName),
                NewIndex = target.NewIndex + 1
            };

        private List<ItemViewModel> InsertNewItem(List<ItemViewModel> target, int index, string name) 
            => target.Append(new ItemViewModel(index, name, true)).ToList();
    }
}
