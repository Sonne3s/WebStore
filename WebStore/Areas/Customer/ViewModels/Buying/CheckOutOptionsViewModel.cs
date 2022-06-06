namespace WebStore.Areas.Customer.ViewModels.Buying
{
    public record CheckOutOptionsViewModel(string DeliveryTypeInstallation, string DeliveryTypeDelivery, string DeliveryTypePickup, string PaymentMethod);
}
