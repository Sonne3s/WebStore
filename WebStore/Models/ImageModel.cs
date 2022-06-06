namespace WebStore.Models
{
    public class ImageModel
    {
        public int Id { get; set; }

        public string Src { get; set; }

        public ProductModel Product { get; set; }

        public int ProductId { get; set; }
    }
}
