using WebStore.Areas.Customer.ViewModels;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models;

namespace WebStore.Areas.Customer.Fillers.IFillers
{
    public interface IProductListFiller
    {
        //ProductListViewModel GetFilledProductListViewModel(
        //    List<ProductModel> products,
        //    List<ProductListFilterItemBlockViewModel> filters, 
        //    PaginationViewModel paginationFilter);

        ProductListViewModel GetFilledProductListViewModel(
            OrderingModel cart,
            List<ProductModel> products,
            List<ProductTypeModel> productTypes,
            List<ProducerModel> producers,
            decimal minPrice,
            decimal maxPrice,
            List<ProductListFilterItemViewModel> filterItems,
            List<PaginationItemViewModel> pages);

        List<ProductListItemViewModel> GetFilledProductListItemViewModels(List<ProductModel> products, OrderingModel cart);

        PaginationViewModel GetPaginationViewModel(int CurrentPage, (List<int> Pages, int? FirstPage, int? LastPage) Pages);

        List<PaginationItemViewModel> GetFilledPaginationItemViewModels(List<ProductPaginationItemModel> Pages);

        ProductListItemCartSectionViewModel GetFilledProductListItemCartSectionViewModel(OrderingItemModel cartItem, int productId);
    }
}
