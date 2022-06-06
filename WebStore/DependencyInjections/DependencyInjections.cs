using Microsoft.AspNetCore.StaticFiles;
using WebStore.Handlers;
using WebStore.Handlers.IHandlers;
using WebStore.Helpers;
using WebStore.Helpers.IHelpers;
using WebStore.Repositories;
using WebStore.Repositories.IRepositories;

namespace WebStore.DependencyInjections
{
    public static class DependencyInjections
    {
        public static void AddScoped(IServiceCollection collection)
        {
            DependencyInjections.AddRepositories(collection);
            DependencyInjections.AddHelpers(collection);
            DependencyInjections.AddHandlers(collection);
            DependencyInjections.AddSystem(collection);
            Account.DependencyInjections.AddScoped(collection);
            Admin.DependencyInjections.AddScoped(collection);
            Customer.DependencyInjections.AddScoped(collection);
        }

        private static void AddRepositories(IServiceCollection collection)
        {
            collection.AddScoped<ICartRepository, CartRepository>();            
            collection.AddScoped<IBaseProductRepository, BaseProductRepository>();
            collection.AddScoped<IProductRepository, ProductRepository>();
            collection.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
            collection.AddScoped<IPropertyGroupRepository, PropertyGroupRepository>();
            collection.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddHandlers(IServiceCollection collection)
        {
            collection.AddScoped<IHomeHandler, HomeHandler>();
            collection.AddScoped<IBuyingHandler, BuyingHandler>();
            collection.AddScoped<IAccountHandler, AccountHandler>();
        }

        private static void AddHelpers(IServiceCollection collection)
        {
            collection.AddScoped<IUserHelper, UserHelper>();
            collection.AddScoped<IOrderHelper, OrderHelper>();
            collection.AddScoped<IProductHelper, ProductHelper>();
            collection.AddScoped<IFileHelper, FileHelper>();
            collection.AddScoped<IHelperProvider, HelperProvider>();
            collection.AddScoped<IPropertiesHelper, PropertiesHelper>();           
        }

        private static void AddSystem(IServiceCollection collection)
        {
            collection.AddScoped<IContentTypeProvider, FileExtensionContentTypeProvider>();
        }
    }
}
