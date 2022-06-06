namespace WebStore.ViewComponentModels
{
    public class PropertyDecimalInputViewComponentModel
    {
        public int Id { get; set; }

        public string IdAttribute { get; set; }

        public string NameAttribute { get; set; }

        public string Placeholder { get; set; }

        public List<string> Values { get; set; }

        public string Label { get; set; }

        public bool HasDisabled { get; set; }

        public string UnitValue { get; set; }

        public bool ShowDeleteButton { get; set; }
    }
}
