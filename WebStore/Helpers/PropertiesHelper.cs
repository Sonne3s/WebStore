using System.Globalization;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Helpers
{
    public class PropertiesHelper : IPropertiesHelper
    {
        public string ExtractPropertyValues(PropertyModel property)
        {
            switch (property.Group.TypeId)
            {
                case (int)PropertyTypeEnumeration.Text:
                    return string.Join(" / ", property.PropertyTextValues.Select(p => p.Value));

                case (int)PropertyTypeEnumeration.Integer:
                    return string.Join(" / ", property.PropertyIntegerValues.Select(p => p.Value));

                case (int)PropertyTypeEnumeration.Decimal:
                    return string.Join(" / ", property.PropertyDecimalValues.Select(p => p.Value));
            }

            throw new Exception("unknown property value type");
        }

        public List<string> ExtractPropertyValuesSeparate(PropertyModel property)
        {
            switch (property.Group.TypeId)
            {
                case (int)PropertyTypeEnumeration.Text:
                    return property.PropertyTextValues.Select(p => p.Value).ToList();

                case (int)PropertyTypeEnumeration.Integer:
                    return property.PropertyIntegerValues.Select(p => p.Value.ToString()).ToList();

                case (int)PropertyTypeEnumeration.Decimal:
                    return property.PropertyDecimalValues.Select(p => p.Value.ToString(CultureInfo.GetCultureInfo("en-US"))).ToList();
            }

            throw new Exception("unknown property value type");
        }
    }
}
