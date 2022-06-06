using WebStore.Areas.Customer.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Customer.Handlers
{
    public class BuyingHandler : IBuyingHandler
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;
        private IHelperProvider _helper;

        public BuyingHandler(ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository, IHelperProvider helperProvider)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _helper = helperProvider;
        }

        public OrderingItemModel AddToCart(int productId, HttpContext context)
            => this.IncreaseCartItemCounter(this.GetOrCreateCartItem(productId, context));

        private OrderingItemModel IncreaseCartItemCounter(OrderingItemModel cartItem)
            => _cartRepository.UpdateCartItemCounter(cartItem.Id, 1);

        private OrderingItemModel GetOrCreateCartItem(int productId, HttpContext context)
            => this.GetOrCreateCartItem(this.GetOrCreateCart(context), productId);

        private OrderingItemModel GetOrCreateCartItem(OrderingModel cart, int productId)
            => _cartRepository.GetCartItem(cart.Id, productId)
            ?? _cartRepository.CreateCartItem(cart.Id, productId);

        public OrderingItemModel RemoveFromCart(int productId, HttpContext context)
            => this.DecreaseOrRemoveCartItemCounter(this.GetCartItem(productId, context));

        private OrderingItemModel DecreaseOrRemoveCartItemCounter(OrderingItemModel cartItem)
            => cartItem != null
                ? this.RemoveCartItem(
                    _cartRepository.UpdateCartItemCounter(cartItem.Id, -1))
                : cartItem;

        private OrderingItemModel RemoveCartItem(OrderingItemModel cartItem)
            => cartItem.Count < 1
                ? _cartRepository.RemoveCartItem(cartItem.Id)
                : cartItem;

        private OrderingItemModel GetCartItem(int productId, HttpContext context)
            => _cartRepository.GetCartItem(this.GetOrCreateCart(context).Id, productId);

        public OrderingModel GetOrCreateCart(HttpContext context)
            => this.GetOrCreateCart(_helper.User.GetUserOrDefault(context));

        private OrderingModel GetOrCreateCart(IUserModel user)
            => _cartRepository.GetCart(user, true) 
            ?? _cartRepository.Create(user);

        public int GetQuantityGoodsInCart(HttpContext context)
            => this.GetOrCreateCart(context)?.Items?.Sum(i => i.Count) ?? default(int);

        public int GetQuantityGoodsInCartByProduct(HttpContext context, int productId)
            => this.GetOrCreateCart(context)?
                .Items?
                .FirstOrDefault(i => i.ProductId == productId)?
                .Count 
                ?? default(int);

        public OrderingModel ClearCart(HttpContext context)
            => _cartRepository.ClearCart(_helper.User.GetUserOrDefault(context));

        public IUserModel GetUser(HttpContext context)
            => _helper.User.GetUserOrDefault(context);
    }
}
