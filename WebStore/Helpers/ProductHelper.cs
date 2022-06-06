using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Helpers
{
    public class ProductHelper : IProductHelper
    {
        public List<PropertyTypeEnumeration> GetValueTypes()
        {
            return new List<PropertyTypeEnumeration>
            {
                PropertyTypeEnumeration.Text,
                PropertyTypeEnumeration.Integer,
                PropertyTypeEnumeration.Decimal,
            };
        }

        public string GetValueTypeText(int typeId)
        {
            switch (typeId)
            {
                case (int)PropertyTypeEnumeration.Text:
                    return "Свойство с текстовым значением для поиска";

                case (int)PropertyTypeEnumeration.Integer:
                    return "Свойство с целочисленным значением для поиска";

                case (int)PropertyTypeEnumeration.Decimal:
                    return "Свойство с десятичны значением для поиска";

                default:
                    return string.Empty;
            }
        }

        public List<ProductPaginationItemModel> GetPaginationItems(int productCount, int chunkSize, int paginationSize, int currentPage)
        {
            var pagesCount = productCount / chunkSize;
            pagesCount += (productCount % chunkSize) > 0 ? 1 : 0;
            var pages = Enumerable.Empty<ProductPaginationItemModel>();
            for (var id = 1; id <= pagesCount; id++)
            {
                pages = pages.Append(new ProductPaginationItemModel { Id = id, IsCurrent = id == currentPage });
            }
            pages = pages.Skip(this.GetSkipCountForPagination(currentPage, pagesCount, paginationSize)).Take(paginationSize);
            pages = this.СorrectionFirstPaginationItem(pages);
            pages = this.СorrectionLastPaginationItem(pages, pagesCount);

            return pages.ToList();
        }

        private IEnumerable<ProductPaginationItemModel> СorrectionFirstPaginationItem(IEnumerable<ProductPaginationItemModel> pages)
        {
            var firstId = pages.FirstOrDefault()?.Id;
            if (firstId.HasValue && firstId > 1)
            {
                pages = pages.Skip(1);
                pages = pages.Prepend(new ProductPaginationItemModel { Id = 1, IsCurrent = false, IsFirstPage = true });
            }

            return pages;
        }

        private IEnumerable<ProductPaginationItemModel> СorrectionLastPaginationItem(IEnumerable<ProductPaginationItemModel> pages, int pagesCount)
        {
            var lastId = pages.LastOrDefault()?.Id;
            if (lastId.HasValue && lastId < pagesCount)
            {
                pages = pages.Take(pages.Count() - 1);
                pages = pages.Append(new ProductPaginationItemModel { Id = pagesCount, IsCurrent = false, IsLastPage = true });
            }

            return pages;
        }

        private int GetSkipCountForPagination(int currentPage, int pagesCount, int paginationSize)
        {
            var skipCount = currentPage - paginationSize / 2;
            var afterSkippingCount = pagesCount - skipCount;
            if(afterSkippingCount <= paginationSize)
            {
                return skipCount - (paginationSize - (afterSkippingCount));
            }

            return skipCount;
        }

        public void CorrectPropertyValues(ProductModel product)
        {
            //product.Components.FirstOrDefault().Properties.ForEach(p => this.CorrectPropertyValueType(p.PropertyValue));
            //if (product.Components != null)
            //{
            //    product.Components.ForEach(c => c.Properties.ForEach(p => this.CorrectPropertyValueType(p.PropertyValue)));
            //}
        }

        private void CorrectPropertyValueType(PropertyValueModel value)
        {
            switch(value.Group.TypeId)
            {
                case (int)PropertyTypeEnumeration.Text:
                    value.Value = value.Value;
                    break;

                case (int)PropertyTypeEnumeration.Integer:
                    value.Value = value.Value;
                    break;

                case (int)PropertyTypeEnumeration.Decimal:
                    value.Value = value.Value;
                    break;
            }
        }
    }
}
