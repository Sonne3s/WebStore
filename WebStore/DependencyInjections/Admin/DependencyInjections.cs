using WebStore.Areas.Admin.Fillers;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.Handlers;
using WebStore.Areas.Admin.Handlers.IHandlers;

namespace WebStore.DependencyInjections.Admin
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
            collection.AddScoped<IProductPropertyHandler, ProductPropertyHandler>();
            collection.AddScoped<IDataMigrationHandler, DataMigrationHandler>();
            collection.AddScoped<IProductComponentHandler, ProductComponentHandler>();
            collection.AddScoped<IProductEditHandler, ProductEditHandler>();
        }

        private static void AddFillers(IServiceCollection collection)
        {
            
            collection.AddScoped<IProductFiller, ProductFiller>();
            collection.AddScoped<IProductPropertyFiller, ProductPropertyFiller>();
            collection.AddScoped<IProductComponentsTabFiller, ProductComponentsTabFiller>();
            collection.AddScoped<IProductFillerProvider, ProductFillerProvider>();
            collection.AddScoped<IProductComponentFiller, ProductComponentFiller>();
            collection.AddScoped<IProductEditFiller, ProductEditFiller>();            
        }
    }
}
