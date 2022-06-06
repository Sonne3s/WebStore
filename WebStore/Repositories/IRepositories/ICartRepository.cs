using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories.IRepositories
{
    public interface ICartRepository
    {
        OrderingModel Create(IUserModel user);

        void SetInformation(OrderingModel model, string email, string fullName, string phone, string company, string address, string dateAndTime, string other, int deliveryType);

        void SetStatus(OrderingModel model, OrderStatusEnumeration status);

        OrderingModel GetCart(IUserModel user, bool includeItems);

        List<OrderingModel> GetAll(IUserModel user, OrderStatusEnumeration status);

        decimal GetTotal(IUserModel user);

        bool ChangeUser(UserModel user, AnonimousUserModel anonimous);

        OrderingModel ClearCart(IUserModel user);

        OrderingItemModel GetCartItem(Guid cartId, int productId);

        OrderingItemModel CreateCartItem(Guid cartId, int productId);

        OrderingItemModel RemoveCartItem(int id);

        OrderingItemModel UpdateCartItemCounter(int id, int term);
    }
}
