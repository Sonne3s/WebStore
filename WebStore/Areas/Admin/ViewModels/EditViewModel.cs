using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.ViewModels.Components;
using WebStore.Areas.Admin.ViewModels.ProductEdit;
using WebStore.Models;

namespace WebStore.Areas.Admin.ViewModels
{
    public class EditViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public List<SelectListItem> ProductTypes { get; set; }

        public int TypeId { get; set; }

        public string Description { get; set; }

        public List<SelectListItem> Producers { get; set; }

        public int ProducerId { get; set; }

        public ComponentsTabViewModel ComponentsTab { get; set; }

        public ImagesTabViewModel ImagesTab { get; set; }

        public class ImageModel
        {
            public int Id { get; set; }

            public string Base64 { get; set; }

            public string Name { set; get; }
        }
    }
}
