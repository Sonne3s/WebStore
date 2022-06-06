namespace WebStore.Models
{
    public class OrderingItemModel
    {
        public int Id { get; set; }

        public Guid OrderingId { get; set; }

        public OrderingModel Ordering { get; set; }

        public int ProductId { get; set; }

        public ProductModel Product { get; set; }

        public int Count { get; set; }
    }
}
