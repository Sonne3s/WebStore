using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class ProductTypeModel : ISelectListItem
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public PropertyGroupModel Group { get; set; }

        public string Value { get; set; }

        public string? Description { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
