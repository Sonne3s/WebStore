using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.ViewModels;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Account.Fillers
{
    public class PurchaseFiller : IPurchaseFiller
    {
        IHelperProvider _helper;

        public PurchaseFiller(IHelperProvider helper)
        {
            _helper = helper;
        }

        public PurchaseListViewModel GetFilledPurchaseListViewModel(List<OrderingModel> activePurchases, List<OrderingModel> archivePurchases)
            => new PurchaseListViewModel(this.GetFilledPurchaseListItemViewModels(activePurchases), this.GetFilledPurchaseListItemViewModels(archivePurchases));

        private List<PurchaseListItemViewModel> GetFilledPurchaseListItemViewModels(List<OrderingModel> purchases)
            => purchases.Select(p => this.GetFilledPurchaseListItemViewModel(p)).ToList();

        private PurchaseListItemViewModel GetFilledPurchaseListItemViewModel(OrderingModel purchase)
            => new PurchaseListItemViewModel(
                purchase.Id.ToString(), _helper.Order.GetStatusText((OrderStatusEnumeration)purchase.Status), purchase.Items.Sum(i => i.Product.Price * i.Count).ToString());
    }
}
