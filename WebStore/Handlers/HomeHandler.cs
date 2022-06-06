using WebStore.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Repositories.IRepositories;

namespace WebStore.Handlers
{
    public class HomeHandler : BaseHandler, IHomeHandler
    {
        private readonly IProductRepository _productRepository;

        public HomeHandler(IProductRepository productRepository, IHelperProvider helperProvider) : base(helperProvider)
        {
            _productRepository = productRepository;
        }
    }
}
