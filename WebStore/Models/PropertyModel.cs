namespace WebStore.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public int ComponentId { get; set; }

        public ComponentModel Component { get; set; }

        public int GroupId { get; set; }

        public PropertyGroupModel Group { get; set; }

        public List<PropertyTextValueModel> PropertyTextValues { get; set; }

        public List<PropertyIntegerValueModel> PropertyIntegerValues { get; set; }

        public List<PropertyDecimalValueModel> PropertyDecimalValues { get; set; }

    }
}
