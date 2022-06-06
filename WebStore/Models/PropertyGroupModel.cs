namespace WebStore.Models
{
    public class PropertyGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public int? UnitTypeId { get; set; }

        public PropertyUnitModel UnitType { get; set; }

        public string? Description { get; set; }

        public List<PropertyModel> Properties { get; set; }
    }
}
