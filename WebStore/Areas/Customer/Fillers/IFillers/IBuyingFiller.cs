using WebStore.Areas.Customer.ViewModels.Buying;
using WebStore.Models;

namespace WebStore.Areas.Customer.Fillers.IFillers
{
    public interface IBuyingFiller
    {
        CartOffCanvasViewModel GetFilledCartOffCanvasViewModel(OrderingModel cart);

        CartDetailsViewModel GetFillerCartDetailsViewModel(OrderingModel cart);

        CheckOutViewModel GetFilledCheckOutViewModel(IUserModel user);
    }
}
