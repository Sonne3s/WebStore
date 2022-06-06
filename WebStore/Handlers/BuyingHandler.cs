using System.Security.Principal;
using WebStore.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;
using WebStore.ViewModels;

namespace WebStore.Handlers
{
    public class BuyingHandler : BaseHandler, IBuyingHandler
    {
        private ICartRepository _orderRepository;
        private IProductRepository _productRepository;

        public BuyingHandler(ICartRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository, IHelperProvider helperProvider) : base(helperProvider)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void AddToCart(int productId, HttpContext context)
        {
            var user = base.Helper.User.GetUserOrDefault(context);
            var cart = base.Helper.Order.GetOrCreateCart(user);
            var cartItem = cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem == null)
            {
                var product = _productRepository.Get(productId);
                cartItem = new OrderingItemModel
                {
                    Id = (cart.Items.Count > 0 ? cart.Items.Max(i => i.Id) : default(int)) + 1 ,
                    Count = 1,
                    Ordering = cart,
                    OrderingId = cart.Id,
                    ProductId = product.Id,
                    Product = product,
                };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
        }

        public void RemoveFromCart(int productId, HttpContext context)
        {
            var user = base.Helper.User.GetUserOrDefault(context);
            var cart = base.Helper.Order.GetOrCreateCart(user);
            var cartItem = cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem == null) 
            { 
                return; 
            }
            if (cartItem.Count == 1)
            {
                cart.Items.Remove(cartItem);
            }
            else
            {
                cartItem.Count--;
            }
        }

        public UserModel GetUser(IIdentity identity)
        {
            UserModel user = null;

            if (identity != null && identity.Name != null)
            {
                user = base.Helper.User.GetRegisteredUser(identity.Name);
            }

            return user == null ? new UserModel() : user;
        }

        public bool CheckOut(BuyingCheckOutViewModel viewModel, HttpContext context)
        {
            try
            {
                var user = base.Helper.User.GetUserOrDefault(context);
                var cart = base.Helper.Order.GetOrCreateCart(user);
                if (!string.IsNullOrEmpty(viewModel.DeliveryTypeInstallation))
                {
                    _orderRepository.SetInformation(cart, viewModel.Email, viewModel.FullName, viewModel.Phone, viewModel.Company, viewModel.Installation.Address, viewModel.Installation.DateAndTime, viewModel.Installation.Other, (int)DeliveryTypeEnumeration.Installation);
                }
                if (!string.IsNullOrEmpty(viewModel.DeliveryTypeDelivery))
                {
                    _orderRepository.SetInformation(cart, viewModel.Email, viewModel.FullName, viewModel.Phone, viewModel.Company, viewModel.Delivery.Address, viewModel.Delivery.DateAndTime, viewModel.Delivery.Other, (int)DeliveryTypeEnumeration.Delivery);
                }
                if (!string.IsNullOrEmpty(viewModel.DeliveryTypePickup))
                {
                    _orderRepository.SetInformation(cart, viewModel.Email, viewModel.FullName, viewModel.Phone, viewModel.Company, null, null, null, (int)DeliveryTypeEnumeration.Pickup);
                }
                _orderRepository.SetStatus(cart, OrderStatusEnumeration.Actively);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
