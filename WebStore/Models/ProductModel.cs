namespace WebStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ProductTypeId { get; set; }

        public ProductTypeModel ProductType { get; set; }

        public string? Description { get; set; }

        public ProducerModel Producer { get; set; }

        public int ProducerId { get; set; }

        public List<ComponentModel> Components { get; set; }

        public List<ImageModel> Images { get; set; } 
    }
}
