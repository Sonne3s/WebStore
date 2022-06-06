using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class PropertyValueModel
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public PropertyGroupModel Group { get; set; }

        public string Value { get; set; }

        public string? Description { get; set; }

        public PropertyModel Property { get; set; }

        public int PropertyId { get; set; }
    }
}
