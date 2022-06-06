using WebStore.Areas.Customer.ViewModels.Details;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models;

namespace WebStore.Areas.Customer.Fillers.IFillers
{
    public interface IProductDetailsFiller
    {
        ProductDetailsViewModel GetFilledProductDetailsViewModel(
            ProductModel product, OrderingItemModel cart);

        CartSectionViewModel GetFilledCartSectionViewModel(
            ProductModel product, OrderingItemModel cartItem);
    }
}
