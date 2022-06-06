using WebStore.Areas.Account.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Account.Handlers
{
    public class PurchaseHandler : IPurchaseHandler
    {
        IHelperProvider _helper;
        ICartRepository _purchaseRepository;

        public PurchaseHandler(ICartRepository purchaseRepository, IHelperProvider helper)
        {
            _purchaseRepository = purchaseRepository;
            _helper = helper;
        }

        public List<OrderingModel> GetActivePurchases(IUserModel user) =>
            _purchaseRepository.GetAll(user, OrderStatusEnumeration.Actively);

        public List<OrderingModel> GetArchivePurchases(IUserModel user) =>
            _purchaseRepository.GetAll(user, OrderStatusEnumeration.Done);

        public IUserModel GetIUser(HttpContext context)
            => _helper.User.GetUserOrDefault(context);
    }
}
