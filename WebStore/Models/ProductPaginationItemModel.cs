namespace WebStore.Models
{
    public class ProductPaginationItemModel
    {
        public int Id { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public bool NeedDots { get; set; }
    }
}
