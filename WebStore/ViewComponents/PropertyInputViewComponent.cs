using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Extensions;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;
using WebStore.ViewComponentModels;

namespace WebStore.ViewComponents
{
    public class PropertyInputViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PropertyViewModel property, int componentId, bool hasDisabled, bool canBeDeleted)
        {
            switch (property.Type)
            {
                case PropertyTypeEnumeration.Text:
                    return this.TextInput(property, componentId, hasDisabled, canBeDeleted);

                case PropertyTypeEnumeration.Integer:
                    return this.IntegerInput(property, componentId, hasDisabled, canBeDeleted);

                case PropertyTypeEnumeration.Decimal:
                    return this.DecimalInput(property, componentId, hasDisabled, canBeDeleted);
            }

            throw new Exception("unknown value type");
        }

        public IViewComponentResult TextInput(PropertyViewModel property, int componentId, bool hasDisabled, bool canBeDeleted)
        {
            return View("Text", new PropertyTextInputViewComponentModel
            {
                IdAttribute = $"Component{componentId}Prop{property.GroupId}",
                NameAttribute = $"Component{componentId}Prop{property.GroupId}",
                Label = property.PropertyName,
                Placeholder = "",
                Values = property.Values != null ? property.Values.Select(v => v.ToString()).ToList() : new List<string>(),
                HasDisabled = hasDisabled,
                ShowDeleteButton = canBeDeleted,
            });
        }

        public IViewComponentResult IntegerInput(PropertyViewModel property, int componentId, bool hasDisabled, bool canBeDeleted)
        {
            return View("Integer", new PropertyIntegerInputViewComponentModel
            {
                IdAttribute = $"Component{componentId}Prop{property.GroupId}",
                NameAttribute = $"Component{componentId}Prop{property.GroupId}",
                Label = property.PropertyName,
                Placeholder = "",
                Values = property.Values != null ? property.Values.Select(v => v.ToString()).ToList() : new List<string>(),
                HasDisabled = hasDisabled,
                UnitValue = property.UnitValue,
                ShowDeleteButton = canBeDeleted,
            });
        }

        public IViewComponentResult DecimalInput(PropertyViewModel property, int componentId, bool hasDisabled, bool canBeDeleted)
        {
            return View("Decimal", new PropertyDecimalInputViewComponentModel
            {
                IdAttribute = $"Component{componentId}Prop{property.GroupId}",
                NameAttribute = $"Component{componentId}Prop{property.GroupId}",
                Label = property.PropertyName,
                Placeholder = "",
                Values = property.Values != null ? property.Values.Select(v => v.ToString()).ToList() : new List<string>(),
                HasDisabled = hasDisabled,
                UnitValue = property.UnitValue,
                ShowDeleteButton = canBeDeleted,
            });
        }
    }
}
