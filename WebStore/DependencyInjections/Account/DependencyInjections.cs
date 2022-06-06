using WebStore.Areas.Account.Fillers;
using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.Handlers;
using WebStore.Areas.Account.Handlers.IHandlers;

namespace WebStore.DependencyInjections.Account
{
    public class DependencyInjections
    {
        public static void AddScoped(IServiceCollection collection)
        {
            DependencyInjections.AddHandlers(collection);
            DependencyInjections.AddFillers(collection);
        }

        private static void AddHandlers(IServiceCollection collection)
        {
            collection.AddScoped<IAuthHandler, AuthHandler>();
            collection.AddScoped<IUserHandler, UserHandler>();
            collection.AddScoped<IPurchaseHandler, PurchaseHandler>();            
        }

        private static void AddFillers(IServiceCollection collection)
        {
            collection.AddScoped<IAuthFiller, AuthFiller>();
            collection.AddScoped<IUserFiller, UserFiller>();
            collection.AddScoped<IPurchaseFiller, PurchaseFiller>();
        }
    }
}
