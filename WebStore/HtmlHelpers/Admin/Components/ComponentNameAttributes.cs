namespace WebStore.HtmlHelpers.Admin.Components
{
    public class ComponentNameAttributes
    {
        private int _index;

        public string Prefix { get => ComponentNameAttributes.GetPrefix(_index); }

        public string Name { get => $"{ Prefix }.Name"; }

        public string PurposeAttribute { get => DataAttributes.InsertAttribute(DataAttributes.AttributeName.Purpose, DataPurposes.TypeSelection); }

    public ComponentNameAttributes(int index)
        {
            _index = index;
        }

        public static string GetPrefix(int index)
        {
            return $"ComponentsTab.PropertyContainers[{ index }]";
        }
    }
}
