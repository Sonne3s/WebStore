using WebStore.Helpers.IHelpers;
using WebStore.Models;

namespace WebStore.ViewComponentModels
{
    public class NavbarViewComponentModel
    {
        public IUserModel User { get; set; }

        public IUserHelper UserHelper { get; set; }

        public int CartItemsCount { get; set; }
    }
}
