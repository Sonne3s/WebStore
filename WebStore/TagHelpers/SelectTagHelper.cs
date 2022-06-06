using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebStore.TagHelpers
{
    public class SelectTagHelper : Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
    {
        public bool IsRequired { get; set; }

        public bool IsDisabled { get; set; }

        public SelectTagHelper(IHtmlGenerator generator) : base(generator) { }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(this.IsRequired)
            {
                output.Attributes.SetAttribute("required", "required");
            }

            if (this.IsDisabled)
            {
                output.Attributes.SetAttribute("disabled", "disabled");
            }
        }
    }
}
