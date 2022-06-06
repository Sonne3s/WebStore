using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.Handlers.IHandlers;

namespace WebStore.Areas.Account.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Account")]
    public class PurchaseController : Controller
    {
        private IPurchaseHandler _handler;
        private IPurchaseFiller _filler;

        public PurchaseController(IPurchaseHandler handler, IPurchaseFiller filler)
        {
            _handler = handler;
            _filler = filler;
        }

        public IActionResult List()
            => View(
                _filler.GetFilledPurchaseListViewModel(
                    _handler.GetActivePurchases(_handler.GetIUser(this.HttpContext)), 
                    _handler.GetArchivePurchases(_handler.GetIUser(this.HttpContext))));
    }
}
