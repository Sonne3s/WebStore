using WebStore.Areas.Account.Handlers.IHandlers;
using WebStore.Areas.Account.ViewModels;
using WebStore.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Account.Handlers
{
    public class AuthHandler : IAuthHandler
    {
        IUserRepository _userRepository;
        ICartRepository _orderRepository;
        IHelperProvider _helper;
        IAccountHandler _handler;

        public AuthHandler(IUserRepository userRepository, ICartRepository orderRepository, IAccountHandler handler, IHelperProvider helper)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _handler = handler;
            _helper = helper;
        }

        public AnonimousUserModel GetAnonimousUser(HttpContext context)
            => _handler.GetIUser(context) as AnonimousUserModel;

        public UserModel Registration(string email, string password, string passwordConfrmation)
            => _userRepository.Create(email, password);

        public UserModel UpdateUserInformation(AuthRegistrationViewModel viewModel, UserModel user)
            => _userRepository.Update(this.GetFilledUserModel(viewModel, user));

        private UserModel GetFilledUserModel(AuthRegistrationViewModel viewModel, UserModel user)
        {
            user.FirstName = viewModel.FirstName;            
            user.LastName = viewModel.LastName;        
            user.MiddleName = viewModel.Company;          
            user.Address = viewModel.Address;           
            user.Phone = viewModel.Phone;           
            user.Company = viewModel.Company;

            return user;
        }

        public UserModel MigrateCart(UserModel newUser, AnonimousUserModel previousUser)
            => _helper.Order.CreateIfNotExist(_handler.MergeWithAnonimousUsers(newUser, previousUser));

        public Task Authenticate(UserModel user, HttpContext context)
            => _helper.User.Authenticate(user, context);

        public UserModel GetUser(string email, string password) => 
            _helper.User.GetRegisteredUser(email, password);
    }
}
