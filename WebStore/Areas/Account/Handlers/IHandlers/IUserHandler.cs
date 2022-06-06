using WebStore.Models;
using static WebStore.Areas.Account.ViewModels.UserDetailsViewModel;

namespace WebStore.Areas.Account.Handlers.IHandlers
{
    public interface IUserHandler
    {
        IUserModel GetIUser(HttpContext context);

        List<OrdersTableItem> GetActiveOrders(string login);

        List<OrdersTableItem> GetArchiveOrders(string login);
    }
}
