namespace WebStore.HtmlHelpers
{
    public static class DataAttributes
    {
        public static class AttributeName
        {
            public const string Purpose = "data-purpose";
            public const string Id = "data-id";
            
            public static class Bootstrap
            {
                public const string Target = "data-bs-target";
                public const string Toggle = "data-bs-toggle";
            }

            public static class Ajax
            {
                public static class Unobtrusive
                {
                    public const string Ajax = "data-ajax";

                    public const string Method = "data-ajax-method";

                    public const string Mode = "data-ajax-mode";

                    public const string Update = "data-ajax-update";

                    public const string Success = "data-ajax-success";
                }
            }

            public static class Modal
            {

            }
        }

        public static string InsertAttribute(string attributeName, string attrbuteValue)
        {
            return $"{attributeName}='{attrbuteValue}'";
        }

        public static string InsertAttributeSelector(string attributeName, string attrbuteValue)
        {
            return $"[{InsertAttribute(attributeName, attrbuteValue)}]";
        }
    }
}
