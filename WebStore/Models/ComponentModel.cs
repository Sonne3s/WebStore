using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class ComponentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductModel Product { get; set; }

        public int ProductId { get; set; }

        public List<PropertyModel> Properties { get; set; }

    }
}
