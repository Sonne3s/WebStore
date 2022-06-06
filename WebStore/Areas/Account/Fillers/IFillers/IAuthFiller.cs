using WebStore.Areas.Account.ViewModels;

namespace WebStore.Areas.Account.Fillers.IFillers
{
    public interface IAuthFiller
    {
        AuthRegistrationViewModel GetFilledAuthRegistrationViewModel(
            string Email, string FirstName, string MiddleName, string LastName, string Address, string Phone, string Company);
    }
}
