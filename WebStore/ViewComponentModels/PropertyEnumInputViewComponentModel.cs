using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.ViewComponentModels
{
    public class PropertyEnumInputViewComponentModel
    {
        public string IdAttribute { get; set; }

        public string NameAttribute { get; set; }

        public string Description { get; set; }

        public bool HasSelected { get; set; }

        public bool HasDisabled { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}
