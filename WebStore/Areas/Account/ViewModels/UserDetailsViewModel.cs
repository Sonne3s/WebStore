namespace WebStore.Areas.Account.ViewModels
{
    public record UserDetailsViewModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public List<OrdersTableItem> ActiveOrders { get; set; }

        public List<OrdersTableItem> ArchiveOrders { get; set; }

        public ActiveTabsEnum ActiveTab { get; set; }

        public enum ActiveTabsEnum
        {
            Person = 1,
            Orders = 2,
            Archive = 3,
        }

        public class OrdersTableItem
        {
            public string Id { get; set; }

            public string Total { get; set; }

            public string Status { get; set; }
        }
    }
}
