using WebStore.Areas.Account.ViewModels;
using WebStore.Models;

namespace WebStore.Areas.Account.Handlers.IHandlers
{
    public interface IAuthHandler
    {
        AnonimousUserModel GetAnonimousUser(HttpContext context);

        UserModel Registration(string email, string password, string passwordConfrmation);

        UserModel UpdateUserInformation(AuthRegistrationViewModel viewModel, UserModel user);

        UserModel MigrateCart(UserModel newUser, AnonimousUserModel previousUser);

        Task Authenticate(UserModel user, HttpContext context);

        UserModel GetUser(string email, string password);
    }
}
