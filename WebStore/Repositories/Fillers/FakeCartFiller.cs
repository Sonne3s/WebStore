using WebStore.Models;

namespace WebStore.Repositories.Fillers
{
    public class FakeOrderFiller
    {
        private static List<OrderingModel> value;

        static FakeOrderFiller() => value = Initial();

        public static List<OrderingModel> Get() => value;

        private static List<OrderingModel> Initial()
        {
            return new List<OrderingModel>();
        }
    }
}
