using WebStore.HtmlHelpers.Admin.Components;

namespace WebStore.HtmlHelpers.Admin.Properties
{
    public class PropertyNameAttributes
    {
        private int _componentIndex;
        private int _propertyIndex;

        public string Prefix { get => PropertyNameAttributes.GetPrefix(_componentIndex, _propertyIndex); }

        public string Value { get => $"{ Prefix }.Values"; }

        public string GroupId { get => $"{ Prefix }.GroupId"; }

        public string Type { get => $"{ Prefix }.Type"; }

        public string UnitId { get => $"{ Prefix }.UnitId"; }

        public PropertyNameAttributes(int componentIndex, int propertyIndex)
        {
            _componentIndex = componentIndex;
            _propertyIndex = propertyIndex;
        }
        public static string GetPrefix(int componentIndex, int propertyIndex)
        {
            return $"{ ComponentNameAttributes.GetPrefix(componentIndex) }.Properties[{ propertyIndex }].Property";
        }
    }
}
