using WebStore.Helpers.IHelpers;

namespace WebStore.Helpers
{
    public class HelperProvider : IHelperProvider
    {
        public IFileHelper File { get; }

        public IOrderHelper Order { get; }

        public IProductHelper Product { get; }

        public IUserHelper User { get; }

        public IPropertiesHelper Properties { get; }

        public HelperProvider(IFileHelper file, IOrderHelper order, IProductHelper product, IUserHelper user, IPropertiesHelper properties)
        {
            File = file;
            Order = order;
            Product = product;
            User = user;
            Properties = properties;
        }
    }
}
