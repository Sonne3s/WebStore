namespace WebStore.HtmlHelpers
{
    public static class Ajax
    {
        public class Unobtrusive
        {
            private string _ajax = DataAttributes.InsertAttribute(DataAttributes.AttributeName.Ajax.Unobtrusive.Ajax, "true");

            public MethodValue? Method { get; set; }

            public ModeValue? Mode { get; set; }

            public string Update { get; set; }

            public string Success { get; set; }

            public override string ToString()
            {
                return String.Join(" ", this.GetFilledAttributesList().ToList());
            }

            private IEnumerable<string> GetFilledAttributesList()
            {
                yield return _ajax;
                if(this.Method != null)
                {
                    yield return DataAttributes.InsertAttribute(DataAttributes.AttributeName.Ajax.Unobtrusive.Method, this.Method.ToString());
                }
                if (this.Mode != null)
                {
                    yield return DataAttributes.InsertAttribute(DataAttributes.AttributeName.Ajax.Unobtrusive.Mode, this.Mode.ToString());
                }
                if (this.Update != null)
                {
                    yield return DataAttributes.InsertAttribute(DataAttributes.AttributeName.Ajax.Unobtrusive.Update, this.QuotesReplacement(this.Update));
                }
                if (this.Success != null)
                {
                    yield return DataAttributes.InsertAttribute(DataAttributes.AttributeName.Ajax.Unobtrusive.Success, QuotesReplacement(this.Success));
                }
            }

            private string QuotesReplacement(string target)
            {
                return target.Replace("'", "\"");
            }

            public static implicit operator String(Unobtrusive target)
            {
                return target.ToString();
            }

            public enum MethodValue
            {
                Get,
                Post
            }

            public enum ModeValue
            {
                Replace,
                Before,
                After
            }
        }
    }
}
