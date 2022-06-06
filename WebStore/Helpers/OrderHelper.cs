using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;

namespace WebStore.Helpers
{
    public class OrderHelper : IOrderHelper
    {
        private ICartRepository _orderRepository;

        public OrderHelper(ICartRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public string GetStatusText(OrderStatusEnumeration status)
        {
            switch(status)
            {
                case OrderStatusEnumeration.Cart:
                    return "Текущая корзина";

                case OrderStatusEnumeration.Actively:
                    return "В обработке";

                case OrderStatusEnumeration.Done:
                    return "Заказ исполнен";

                case OrderStatusEnumeration.Cancelled:
                    return "Заказ отменен";

                    default: return string.Empty;
            }
        }

        public OrderingModel GetOrCreateCart(IUserModel user)
        {
            var cart = _orderRepository.GetCart(user, true);
            if (cart == null)
            {
                cart = _orderRepository.Create(user);
            }

            return cart;
        }

        public UserModel CreateIfNotExist(UserModel user)
        {
            if (_orderRepository.GetCart(user, true) == null)
            {
                _orderRepository.Create(user);
            }

            return user;
        }
    }
}
