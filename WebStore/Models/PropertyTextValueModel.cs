namespace WebStore.Models
{
    public class PropertyTextValueModel
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string? Description { get; set; }

        public PropertyModel Property { get; set; }

        public int PropertyId { get; set; }
    }
}
