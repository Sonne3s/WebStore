using WebStore.Areas.Customer.Fillers;
using WebStore.Areas.Customer.Fillers.IFillers;
using WebStore.Areas.Customer.Handlers;
using WebStore.Areas.Customer.Handlers.IHandlers;

namespace WebStore.DependencyInjections.Customer
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
            collection.AddScoped<IProductHandler, ProductHandler>();
            collection.AddScoped<IBuyingHandler, BuyingHandler>();
        }

        private static void AddFillers(IServiceCollection collection)
        {
            collection.AddScoped<IProductDetailsFiller, ProductDetailsFiller>();
            collection.AddScoped<IProductListFiller, ProductListFiller>();
            collection.AddScoped<IBuyingFiller, BuyingFiller>();

        }
    }
}
