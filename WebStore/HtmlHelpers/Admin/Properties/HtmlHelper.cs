using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.HtmlHelpers.Admin.Properties
{
    public static class HtmlHelper
    {
        public static PropertyNameAttributes GetPropertyAttributes(this IHtmlHelper htmlHelper, int componentIndex, int propertyIndex)
            => new PropertyNameAttributes(componentIndex, propertyIndex);
    }
}
