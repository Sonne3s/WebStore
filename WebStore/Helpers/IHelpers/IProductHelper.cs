using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Helpers.IHelpers
{
    public interface IProductHelper
    {
        List<PropertyTypeEnumeration> GetValueTypes();

        string GetValueTypeText(int typeId);

        List<ProductPaginationItemModel> GetPaginationItems(int productCount, int chunkSize, int paginationSize, int currentPage);

        void CorrectPropertyValues(ProductModel product);
    }
}
