namespace WebStore.Areas.Account.ViewModels
{
    public record PurchaseListViewModel(List<PurchaseListItemViewModel> ActivePurchaseList, List<PurchaseListItemViewModel> ArchivePurchaseList);
}
