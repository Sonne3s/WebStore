using WebStore.Areas.Admin.Fillers.IFillers;

namespace WebStore.Areas.Admin.Fillers
{
    public class ProductFillerProvider : IProductFillerProvider
    {
        public IProductComponentsTabFiller ProductComponentsTabFiller { get; set; }

        public ProductFillerProvider(IProductComponentsTabFiller productComponentsTabFiller)
        {
            ProductComponentsTabFiller = productComponentsTabFiller;
        }
    }
}
