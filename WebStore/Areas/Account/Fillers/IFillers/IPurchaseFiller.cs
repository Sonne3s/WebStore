using WebStore.Areas.Account.ViewModels;
using WebStore.Models;

namespace WebStore.Areas.Account.Fillers.IFillers
{
    public interface IPurchaseFiller
    {
        PurchaseListViewModel GetFilledPurchaseListViewModel(List<OrderingModel> activePurchases, List<OrderingModel> archivePurchases);
    }
}
