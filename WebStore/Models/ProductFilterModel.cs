using WebStore.Models.Enumerations;

namespace WebStore.Models
{
    public class ProductFilterModel
    {
        public int GroupId { get; set; }

        public PropertyTypeEnumeration Type { get; set; }

        public List<string> Values { get; set; }
    }
}
