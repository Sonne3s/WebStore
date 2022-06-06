using System.Security.Principal;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Handlers.IHandlers
{
    public interface IBuyingHandler
    {
        void AddToCart(int productId, HttpContext context);

        void RemoveFromCart(int productId, HttpContext context);

        UserModel GetUser(IIdentity identity);

        bool CheckOut(BuyingCheckOutViewModel viewModel, HttpContext context);
    }
}
