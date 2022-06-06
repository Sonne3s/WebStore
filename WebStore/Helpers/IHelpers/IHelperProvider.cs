namespace WebStore.Helpers.IHelpers
{
    public interface IHelperProvider
    {
        IFileHelper File { get; }

        IOrderHelper Order { get; }

        IProductHelper Product { get; }

        IUserHelper User { get; }

        IPropertiesHelper Properties { get; }
    }
}
