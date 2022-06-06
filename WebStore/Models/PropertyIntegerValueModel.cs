namespace WebStore.Models
{
    public class PropertyIntegerValueModel
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public PropertyModel Property { get; set; }

        public int PropertyId { get; set; }
    }
}
