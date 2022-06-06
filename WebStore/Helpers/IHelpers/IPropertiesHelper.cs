using WebStore.Models;

namespace WebStore.Helpers.IHelpers
{
    public interface IPropertiesHelper
    {
        public string ExtractPropertyValues(PropertyModel property);

        List<string> ExtractPropertyValuesSeparate(PropertyModel property);
    }
}
