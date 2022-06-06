using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.Handlers.IHandlers;
using WebStore.Areas.Account.ViewModels;
using WebStore.Handlers.IHandlers;
using WebStore.Models;

namespace WebStore.Areas.Account.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Account")]
    public class AuthController : Controller
    {
        IAuthFiller _filler;
        IAuthHandler _handler;

        public AuthController(IAuthHandler handler, IAuthFiller filler)
        {
            _handler = handler;
            _filler = filler;
        }

        [HttpGet]
        public IActionResult Registration(
            string Email, string FirstName, string MiddleName, string LastName, string Address, string Phone, string Company)
            => this.SetRefferer(this.View(_filler.GetFilledAuthRegistrationViewModel(Email, FirstName, MiddleName, LastName, Address, Phone, Company)));

        private IActionResult SetRefferer(IActionResult result)
            => this.SetRefferer(
                result, Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(HttpContext.Request) != HttpContext.Request.Headers["Referer"].FirstOrDefault());

        private IActionResult SetRefferer(IActionResult result, bool checkReferrer)
            => checkReferrer
                ? this.SetRefferer(result, checkReferrer, this.ViewData["Referrer"] = HttpContext.Request.Headers["Referer"].FirstOrDefault())
                : result;

        private IActionResult SetRefferer(IActionResult result, bool checkReferrer, object setReferrer)
            => result;

        [HttpPost]
        public IActionResult Registration(AuthRegistrationViewModel model)
            => ModelState.IsValid
                ? this.RedirectToRefferer(this.Registration(model, this.HttpContext), this.HttpContext)
                : View(model);

        private Task Registration(AuthRegistrationViewModel model, HttpContext context)
            => _handler.Authenticate(
                    _handler.MigrateCart(
                        _handler.UpdateUserInformation(model, _handler.Registration(model.Email, model.Password, model.PasswordConfirmation)),
                        _handler.GetAnonimousUser(context)), context);

        [HttpPost]
        public IActionResult LogIn(string email, string password)
            => this.RedirectToRefferer(_handler.Authenticate(_handler.GetUser(email, password), this.HttpContext), this.HttpContext);

        [HttpGet]
        public async Task<IActionResult> LogOut()
            => this.RedirectToRefferer(HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme), this.HttpContext);

        private IActionResult RedirectToRefferer(Task task, HttpContext context)
            => Redirect(this.ViewData["Referrer"]?.ToString() ?? HttpContext.Request.Headers["Referer"].FirstOrDefault() ?? string.Empty);
    }
}
