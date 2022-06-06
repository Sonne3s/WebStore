using WebStore.Areas.Account.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;
using static WebStore.Areas.Account.ViewModels.UserDetailsViewModel;

namespace WebStore.Areas.Account.Handlers
{
    public class UserHandler : IUserHandler
    {
        IHelperProvider _helper;
        ICartRepository _purchaseRepository;

        public UserHandler(IHelperProvider helper, ICartRepository purchaseRepository)
        {
            _helper = helper;
            _purchaseRepository = purchaseRepository;
        }

        public IUserModel GetIUser(HttpContext context) 
            => _helper.User.GetUserOrDefault(context);

        public List<OrdersTableItem> GetActiveOrders(string login)
        {
            var user = _helper.User.GetRegisteredUser(login);

            return _purchaseRepository.GetAll(user, OrderStatusEnumeration.Actively).Select(o => new OrdersTableItem
            {
                Id = o.Id.ToString(),
                Status = _helper.Order.GetStatusText((OrderStatusEnumeration)o.Status),
                Total = o.Items.Sum(i => i.Product.Price * i.Count).ToString()
            }).ToList();
        }

        public List<OrdersTableItem> GetArchiveOrders(string login)
        {
            var user = _helper.User.GetRegisteredUser(login);

            return _purchaseRepository.GetAll(user, OrderStatusEnumeration.Done).Select(o => new OrdersTableItem
            {
                Id = o.Id.ToString(),
                Status = _helper.Order.GetStatusText((OrderStatusEnumeration)o.Status),
                Total = o.Items.Sum(i => i.Product.Price * i.Count).ToString()
            }).ToList();
        }
    }
}
