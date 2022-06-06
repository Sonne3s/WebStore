using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Helpers
{
    public class UserHelper : IUserHelper
    {
        private IUserRepository _userRepository;
        private ICartRepository _orderRepository;

        public UserHelper(IUserRepository userRepository, ICartRepository orderRepository) 
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public UserModel GetRegisteredUser(string login, string password)
        {
            return _userRepository.Get(login, password);
        }

        public UserModel GetRegisteredUser(string login)
        {
            return _userRepository.Get(login);
        }

        public IUserModel GetAnonimousUser(string login)
        {
            return _userRepository.GetAnonimous(login);
        }

        public IUserModel GetUserOrDefault(HttpContext context)
        {
            var login = context.User.Identity.Name;
            IUserModel user = null;
            if (!string.IsNullOrEmpty(login))
            {
                user = this.GetRegisteredUser(login);
                if(user == null)
                {
                    user = this.GetAnonimousUser(login);
                }
            }

            if (user == null)
            {
                user = _userRepository.CreateAnonimous();
                this.Authenticate(user, context);
                var cart = _orderRepository.GetCart(user, true);
                if (cart == null)
                {
                    _orderRepository.Create(user);
                }
            }

            return user;
        }

        public bool IsAdministrator(IUserModel user)
        {
            return user.Roles.Any(r => r.Id == Models.Enumerations.UserRolesEnumeration.Administrator);
        }

        public bool IsFitter(IUserModel user)
        {
            return user.Roles.Any(r => r.Id == Models.Enumerations.UserRolesEnumeration.Fitter);
        }

        public bool IsManager(IUserModel user)
        {
            return user.Roles.Any(r => r.Id == Models.Enumerations.UserRolesEnumeration.Manager);
        }

        public async Task Authenticate(IUserModel user, HttpContext context)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };
            if (user.Roles != null)
            {
                claims.AddRange(user.Roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r.Name)));
            }
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
