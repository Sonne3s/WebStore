using System.Security.Principal;
using WebStore.Models;
using static WebStore.ViewModels.AccountDetailsViewModel;

namespace WebStore.Handlers.IHandlers
{
    public interface IAccountHandler
    {
        UserModel Registration(string email, string password, string passwordConfrmation);

        Task Authenticate(UserModel user, HttpContext context);

        UserModel GetUser(string email, string password);

        IUserModel GetIUser(HttpContext context);

        UserModel MergeWithAnonimousUsers(UserModel user, AnonimousUserModel anonimous);

        bool UpdateUserInformation(UserModel user, string firstName, string lastName, string middleName, string address, string phone, string company);

        OrderingModel GetOrCreateCart(UserModel user);

        List<OrdersTableItem> GetActiveOrders(string login);

        List<OrdersTableItem> GetArchiveOrders(string login);
    }
}
