using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.HtmlHelpers.Admin.Components
{
    public static class HtmlHelper
    {
        public static ComponentNameAttributes GetComponentAttributes(this IHtmlHelper htmlHelper, int componentIndex)
            => new ComponentNameAttributes(componentIndex);
    }
}
