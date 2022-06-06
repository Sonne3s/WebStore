namespace WebStore.ViewComponentModels
{
    public class CartListViewComponentModel
    {
        public IEnumerable<CartListItemModel> CartItems { get; set; }

        public class CartListItemModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string ImageUrl { get; set; }

            public int Count { get; set; }

            public decimal Total { get; set; }

        }
    }
}
