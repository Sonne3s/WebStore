using WebStore.Helpers.IHelpers;

namespace WebStore.Handlers
{
    public class BaseHandler
    {
        protected IHelperProvider Helper { get; }

        public BaseHandler(IHelperProvider helperProder)
        {
            Helper = helperProder;
        }
    }
}
