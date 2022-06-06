namespace WebStore.ViewModels
{
    public class BuyingCheckOutViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public DeliveryData Installation { get; set; }

        public DeliveryData Delivery { get; set; }

        public string DeliveryTypeInstallation { get; set; }

        public string DeliveryTypeDelivery { get; set; }

        public string DeliveryTypePickup { get; set; }

        public int PaymentMethod { get; set; }

        public class DeliveryData
        {
            public string Address { get; set; }

            public string DateAndTime { get; set; }

            public string Other { get; set; }
        }
    }
}
