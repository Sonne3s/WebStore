using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models.Enumerations;

namespace WebStore.ViewComponents
{
    public class ExtractValueViewComponent : ViewComponent
    {
        public string Invoke(PropertyViewModel property)
        {
            return ExtractValueViewComponent.Get(property);
        }

        public static string Get(PropertyViewModel property)
        {
            switch (property.Type)
            {
                case PropertyTypeEnumeration.Text:
                    return property.Value;

                case PropertyTypeEnumeration.Integer:
                case PropertyTypeEnumeration.Decimal:
                    return $"{ property.Value } { property.UnitValue }";
            }

            throw new Exception("unknown property value type");
        }
    }
}
