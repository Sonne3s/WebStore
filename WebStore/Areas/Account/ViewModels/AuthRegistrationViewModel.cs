namespace WebStore.Areas.Account.ViewModels
{
    public record AuthRegistrationViewModel(
        string Email, string Password, string PasswordConfirmation, string FirstName, string MiddleName, string LastName, string Address, string Phone, string Company);
}
