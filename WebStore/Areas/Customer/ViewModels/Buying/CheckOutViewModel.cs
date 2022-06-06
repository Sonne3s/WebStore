namespace WebStore.Areas.Customer.ViewModels.Buying
{
    public record CheckOutViewModel(
        CheckOutPersonalDataViewModel PersonalData, CheckOutDeliveryDataViewModel Installation, CheckOutDeliveryDataViewModel Delivery, CheckOutOptionsViewModel Options);
}
