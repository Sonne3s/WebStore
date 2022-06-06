using WebStore.Areas.Account.Fillers.IFillers;
using WebStore.Areas.Account.ViewModels;

namespace WebStore.Areas.Account.Fillers
{
    public class AuthFiller : IAuthFiller
    {
        public AuthRegistrationViewModel GetFilledAuthRegistrationViewModel(
            string Email, string FirstName, string MiddleName, string LastName, string Address, string Phone, string Company)
            => new AuthRegistrationViewModel(Email, String.Empty, String.Empty, FirstName, MiddleName, LastName, Address, Phone, Company);
    }
}
