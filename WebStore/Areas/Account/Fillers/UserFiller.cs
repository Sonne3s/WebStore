using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.ViewModels;
using WebStore.Models;
using static WebStore.Areas.Account.ViewModels.UserDetailsViewModel;

namespace WebStore.Areas.Account.Fillers
{
    public class UserFiller : IUserFiller
    {
        public UserDetailsViewModel GetFilledUserDetailsViewModel(UserModel user, List<OrdersTableItem> ActiveOrders, List<OrdersTableItem> ArchiveOrders, ActiveTabsEnum tab)
            => new UserDetailsViewModel
            {
                Email = user.Login,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Address = user.Address,
                Phone = user.Phone,
                Company = user.Company,
                ActiveOrders = ActiveOrders,
                ArchiveOrders = ArchiveOrders,
                ActiveTab = tab
            };

        public UserDetailsViewModel GetFilledIUserDetailsViewModel(IUserModel user, List<OrdersTableItem> ActiveOrders, List<OrdersTableItem> ArchiveOrders, ActiveTabsEnum tab)
            => new UserDetailsViewModel
            {
                Email = user.Login,
                ActiveOrders = ActiveOrders,
                ArchiveOrders = ArchiveOrders,
                ActiveTab = tab
            };
    }
}
