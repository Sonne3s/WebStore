using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.Areas.Customer.ViewModels.Product
{
    public record ProductListFilterViewModel(
        List<SelectListItem> Type, ProductListFilterProducerViewModel Producer, ProductListFilterItemViewModel Price, List<ProductListFilterItemViewModel> Items);
}
