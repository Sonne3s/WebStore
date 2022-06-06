using WebStore.Models;

namespace WebStore.Areas.Account.Handlers.IHandlers
{
    public interface IPurchaseHandler
    {
        List<OrderingModel> GetActivePurchases(IUserModel user);

        List<OrderingModel> GetArchivePurchases(IUserModel user);

        IUserModel GetIUser(HttpContext context);
    }
}
