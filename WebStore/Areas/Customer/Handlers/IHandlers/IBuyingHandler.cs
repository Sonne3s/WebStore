using WebStore.Models;

namespace WebStore.Areas.Customer.Handlers.IHandlers
{
    public interface IBuyingHandler
    {
        OrderingItemModel AddToCart(int productId, HttpContext context);

        OrderingItemModel RemoveFromCart(int productId, HttpContext context);

        OrderingModel GetOrCreateCart(HttpContext context);

        int GetQuantityGoodsInCart(HttpContext context);

        int GetQuantityGoodsInCartByProduct(HttpContext context, int productId);

        OrderingModel ClearCart(HttpContext context);

        IUserModel GetUser(HttpContext context);
    }
}
