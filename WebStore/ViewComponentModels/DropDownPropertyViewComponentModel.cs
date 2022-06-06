using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebStore.ViewComponentModels
{
    public class DropDownPropertyViewComponentModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasSelected { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}
