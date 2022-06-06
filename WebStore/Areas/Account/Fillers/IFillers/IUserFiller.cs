using WebStore.Areas.Account.ViewModels;
using WebStore.Models;
using static WebStore.Areas.Account.ViewModels.UserDetailsViewModel;

namespace WebStore.Areas.Account.Fillers.IFillers
{
    public interface IUserFiller
    {
        UserDetailsViewModel GetFilledUserDetailsViewModel(UserModel user, List<OrdersTableItem> ActiveOrders, List<OrdersTableItem> ArchiveOrders, ActiveTabsEnum tab);

        UserDetailsViewModel GetFilledIUserDetailsViewModel(IUserModel user, List<OrdersTableItem> ActiveOrders, List<OrdersTableItem> ArchiveOrders, ActiveTabsEnum tab);
    }
}
