using WebStore.Areas.Customer.Fillers.IFillers;
using WebStore.Areas.Customer.ViewModels.Buying;
using WebStore.Models;

namespace WebStore.Areas.Customer.Fillers
{
    public class BuyingFiller : IBuyingFiller
    {
        public CartOffCanvasViewModel GetFilledCartOffCanvasViewModel(OrderingModel cart)
            => new CartOffCanvasViewModel(
                cart.Items.Sum(i => i.Count), cart.Items.Sum(i => i.Count * i.Product.Price));

        public CartDetailsViewModel GetFillerCartDetailsViewModel(OrderingModel cart)
            => new CartDetailsViewModel(
                cart.Items.Sum(i => i.Count), 
                cart.Items.Sum(i => i.Count * i.Product.Price), 
                cart.Items.Select(i => this.GetFilledCartDetailsItemViewModel(i)).ToList());

        private CartDetailsItemViewModel GetFilledCartDetailsItemViewModel(OrderingItemModel cartItem)
            => new CartDetailsItemViewModel(
                cartItem.ProductId,
                $"{cartItem.Product.ProductType.Value} {cartItem.Product.Producer.Value} {cartItem.Product.Name}", 
                cartItem.Product.Images.FirstOrDefault().Src, 
                cartItem.Count, 
                cartItem.Product.Price, 
                cartItem.Count * cartItem.Product.Price);

        public CheckOutViewModel GetFilledCheckOutViewModel(IUserModel user)
            => this.GetFilledCheckOutViewModel(user as UserModel);

        private CheckOutViewModel GetFilledCheckOutViewModel(UserModel user)
            => new CheckOutViewModel(
                this.GetFilledCheckOutPersonalDataViewModel(user),
                this.GetFilledCheckOutDeliveryDataViewModel(user),
                this.GetFilledCheckOutDeliveryDataViewModel(user),
                this.GetFilledCheckOutOptionsViewModel());

        private CheckOutPersonalDataViewModel GetFilledCheckOutPersonalDataViewModel(UserModel user)
            => new CheckOutPersonalDataViewModel(
                this.GetFullName(user), 
                user?.Login ?? string.Empty, 
                user?.Phone ?? string.Empty, 
                user?.Company ?? string.Empty);

        private string GetFullName(UserModel user)
            => string.Join(" ", (new List<string> { user?.LastName, user?.FirstName, user?.MiddleName }).Where(n => n != null));

        private CheckOutDeliveryDataViewModel GetFilledCheckOutDeliveryDataViewModel(UserModel user)
            => new CheckOutDeliveryDataViewModel(user?.Address ?? string.Empty, string.Empty, string.Empty);

        private CheckOutOptionsViewModel GetFilledCheckOutOptionsViewModel()
            => new CheckOutOptionsViewModel(string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
