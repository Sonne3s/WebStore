using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.Handlers.IHandlers;
using WebStore.Models;
using static WebStore.Areas.Account.ViewModels.UserDetailsViewModel;

namespace WebStore.Areas.Account.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Account")]
    public class UserController : Controller
    {
        IUserHandler _handler;
        IUserFiller _filler;

        public UserController(IUserHandler handler, IUserFiller filler) 
        {
            _handler = handler;
            _filler = filler;
        }
        //public IActionResult Details() => View();
        public IActionResult Details(ActiveTabsEnum tab = ActiveTabsEnum.Person)
        {
            var user = _handler.GetIUser(this.HttpContext);
            switch (user)
            {
                case UserModel:
                    return View(_filler.GetFilledUserDetailsViewModel(user as UserModel, _handler.GetActiveOrders(user.Login), _handler.GetArchiveOrders(user.Login), tab));

                default:
                    return View(_filler.GetFilledIUserDetailsViewModel(user, _handler.GetActiveOrders(user.Login), _handler.GetArchiveOrders(user.Login), tab));
            }
        }

        public IActionResult Settings() => View();
    }
}
