//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using WebStore.Handlers.IHandlers;
//using WebStore.Models;
//using WebStore.ViewModels;
//using static WebStore.ViewModels.AccountDetailsViewModel;

//namespace WebStore.Controllers
//{
//    public class AccountController : Controller
//    {
//        IAccountHandler _handler;

//        public AccountController(IAccountHandler handler)
//        {
//            _handler = handler;
//        }

//        [HttpPost]
//        public IActionResult Login(AccountLoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = _handler.GetUser(model.Email, model.Password);
//                if (user != null)
//                {
//                    _handler.Authenticate(user, this.HttpContext); // аутентификация

//                    return RedirectToAction("Index", "Home");
//                }
//                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
//            }

//            return RedirectToAction("Index", "Home");
//        }

//        public async Task<IActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//            return RedirectToAction("Index", "Home");
//        }

//        public IActionResult Register()
//        {
//            return View(new AccountRegisterViewModel());
//        }

//        [HttpPost]
//        public IActionResult Register(AccountRegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var currentUser = _handler.GetIUser(this.HttpContext) as AnonimousUserModel;
//                var user = _handler.Registration(model.Email, model.Password, model.PasswordConfirmation);

//                if(user != null) 
//                {
//                    _handler.UpdateUserInformation(user, model.FirstName, model.LastName, model.MiddleName, model.Address, model.Phone, model.Company);
//                    if (currentUser != null)
//                    {
//                        _handler.MergeWithAnonimousUsers(user, currentUser);
//                        _handler.GetOrCreateCart(user);
//                        _handler.Authenticate(user, this.HttpContext);
//                    }

//                    return RedirectToAction("Index", "Home");
//                }
//            }

//            return View(model);
//        }

//        public IActionResult Details(ActiveTabsEnum tab = ActiveTabsEnum.Person)
//        {
//            var user = _handler.GetIUser(this.HttpContext);
//            switch(user)
//            {
//                case UserModel:
//                    var registeredUser = user as UserModel;
//                    return View(new AccountDetailsViewModel
//                    {
//                        Email = registeredUser.Login,
//                        FirstName = registeredUser.FirstName,
//                        MiddleName = registeredUser.MiddleName,
//                        LastName = registeredUser.LastName,
//                        Address = registeredUser.Address,
//                        Phone = registeredUser.Phone,
//                        Company = registeredUser.Company,
//                        ActiveOrders = _handler.GetActiveOrders(registeredUser.Login),
//                        ArchiveOrders = _handler.GetArchiveOrders(registeredUser.Login),
//                        ActiveTab = tab
//                    });

//                default:
//                    return View(new AccountDetailsViewModel
//                    {
//                        Email = user.Login,
//                        ActiveOrders = _handler.GetActiveOrders(user.Login),
//                        ArchiveOrders = _handler.GetArchiveOrders(user.Login),
//                        ActiveTab = tab
//                    });
//            }
//        }
//    }
//}
