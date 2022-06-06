namespace WebStore.Models
{
    public class PropertyDecimalValueModel
    {
        public int Id { get; set; }

        public decimal Value { get; set; }

        public PropertyModel Property { get; set; }

        public int PropertyId { get; set; }
    }
}
