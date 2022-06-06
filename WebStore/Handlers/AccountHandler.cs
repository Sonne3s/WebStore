using WebStore.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;
using static WebStore.ViewModels.AccountDetailsViewModel;

namespace WebStore.Handlers
{
    public class AccountHandler : BaseHandler, IAccountHandler
    {
        IUserRepository _userRepository;
        ICartRepository _orderRepository;

        public AccountHandler(IUserRepository userRepository, ICartRepository orderRepository, IHelperProvider helperProvider) : base(helperProvider)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public UserModel Registration(string email, string password, string passwordConfrmation)
        {
            return _userRepository.Create(email, password);
        }

        public bool UpdateUserInformation(UserModel user, string firstName, string lastName, string middleName, string address, string phone, string company)
        {

            if(firstName != null)
            {
                user.FirstName = firstName;
            }

            if(lastName != null)
            {
                user.LastName = lastName;
            }

            if(middleName != null)
            {
                user.MiddleName = middleName;
            }

            if(address != null)
            {
                user.Address = address;
            }

            if (phone != null)
            {
                user.Phone = phone;
            }

            if (company != null)
            {
                user.Company = company;
            }

            return _userRepository.Update(user) != null;
        }

        public OrderingModel GetOrCreateCart(UserModel user)
        {
            return base.Helper.Order.GetOrCreateCart(user);
        }

        public UserModel GetUser(string email, string password)
        {
            return base.Helper.User.GetRegisteredUser(email, password);
        }

        public IUserModel GetIUser(HttpContext context)
        {
            return base.Helper.User.GetUserOrDefault(context);
        }

        public UserModel MergeWithAnonimousUsers(UserModel user, AnonimousUserModel anonimous) 
        {
            _orderRepository.ChangeUser(user, anonimous);
            _userRepository.DeleteAnonimous(anonimous);

            return user;
        }

        public List<OrdersTableItem> GetActiveOrders(string login)
        {
            var user = _userRepository.Get(login);

            return _orderRepository.GetAll(user, OrderStatusEnumeration.Actively).Select(o => new OrdersTableItem
            {
                Id = o.Id.ToString(),
                Status = base.Helper.Order.GetStatusText((OrderStatusEnumeration)o.Status),
                Total = o.Items.Sum(i => i.Product.Price * i.Count).ToString()
            }).ToList();
        }

        public List<OrdersTableItem> GetArchiveOrders(string login)
        {
            var user = _userRepository.Get(login);

            return _orderRepository.GetAll(user, OrderStatusEnumeration.Done).Select(o => new OrdersTableItem
            {
                Id = o.Id.ToString(),
                Status = base.Helper.Order.GetStatusText((OrderStatusEnumeration)o.Status),
                Total = o.Items.Sum(i => i.Product.Price * i.Count).ToString()
            }).ToList();
        }

        public new Task Authenticate(UserModel user, HttpContext context)
        {
            return base.Helper.User.Authenticate(user, context);
        }
    }
}
