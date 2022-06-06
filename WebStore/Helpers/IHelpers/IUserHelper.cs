using WebStore.Models;

namespace WebStore.Helpers.IHelpers
{
    public interface IUserHelper
    {
        UserModel GetRegisteredUser(string login, string password);

        UserModel GetRegisteredUser(string login);

        IUserModel GetAnonimousUser(string login);

        IUserModel GetUserOrDefault(HttpContext context);

        bool IsAdministrator(IUserModel user);

        bool IsFitter(IUserModel user);

        bool IsManager(IUserModel user);

        Task Authenticate(IUserModel user, HttpContext context);
    }
}
