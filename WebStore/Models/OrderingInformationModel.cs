namespace WebStore.Models
{
    public class OrderingInformationModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string? Company { get; set; }

        public string? Address { get; set; }

        public string DateAndTime { get; set; }

        public string? Other { get; set; }

        public int DeliveryType { get; set; }

        public OrderingModel Ordering { get; set; }

        public int OrderingId { get; set; }
    }
}
