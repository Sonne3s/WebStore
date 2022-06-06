namespace WebStore.Models
{
    public class ProductBaseFiltersModel
    {
        public int Type { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public List<int> Producer { get; set; }
    }
}
