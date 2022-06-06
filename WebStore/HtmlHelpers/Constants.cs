using WebStore.Models.Enumerations;

namespace WebStore.HtmlHelpers
{
    public static partial class Constants
    {
        public static class Admin
        {
            public static class Edit
            {
                public static string FormId = "form-edit";
            }

            public static class ProductProperty
            {
                public static class CreationPage
                {
                    public static class TypeId
                    {
                        public static readonly string Text = ((int)PropertyTypeEnumeration.Text).ToString();
                        public static readonly string Integer = ((int)PropertyTypeEnumeration.Integer).ToString();
                        public static readonly string Decimal = ((int)PropertyTypeEnumeration.Decimal).ToString();
                    }
                }
            }
        }
    }
}
