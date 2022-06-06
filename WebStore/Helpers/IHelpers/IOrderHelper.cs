using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Helpers.IHelpers
{
    public interface IOrderHelper
    {
        string GetStatusText(OrderStatusEnumeration status);

        OrderingModel GetOrCreateCart(IUserModel user);

        UserModel CreateIfNotExist(UserModel user);
    }
}
