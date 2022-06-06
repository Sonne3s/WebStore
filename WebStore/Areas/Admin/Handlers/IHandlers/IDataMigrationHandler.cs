using WebStore.Models;

namespace WebStore.Areas.Admin.Handlers.IHandlers
{
    public interface IDataMigrationHandler
    {
        #region Product

        #region Export

        byte[] GetProductsExportFile();

        #endregion Export

        #region Import

        #region ExtractJsonsAndWriteImages

        (
            string Main,
            string Products,
            string Groups,
            string ProductTypes,
            string Producers,
            string Properties,
            string Values,
            string Units,
            string Images
        ) ExtractJsonsAndWriteImages(IFormFile file);

        #endregion ExtractJsonsAndWriteImages

        #region RepositoryFillers

        #region Products

        List<ProductModel> GetProductsFromJsonString(string json);

        bool ProductsAddRange(List<ProductModel> products);

        #endregion Products

        #region Groups

        List<PropertyGroupModel> GetGroupsFromJsonString(string json);

        bool GroupsAddRange(List<PropertyGroupModel> groups);

        #endregion Groups

        #region ProductTypes

        List<ProductTypeModel> GetProductTypesFromJsonString(string json);

        bool ProductTypesAddRange(List<ProductTypeModel> producers);

        #endregion ProductTypes

        #region Producers

        List<ProducerModel> GetProducersFromJsonString(string json);

        bool ProducersAddRange(List<ProducerModel> producers);

        #endregion Producers

        #region Properties

        List<PropertyModel> GetPropertiesFromJsonString(string json);

        bool PropertiesAddRange(List<PropertyModel> properties);

        #endregion Properties

        #region Values

        List<PropertyValueModel> GetValuesFromJsonString(string json);

        bool ValuesAddRange(List<PropertyValueModel> properties);

        #endregion Values

        #region Units

        List<PropertyUnitModel> GetUnitsFromJsonString(string json);

        bool UnitsAddRange(List<PropertyUnitModel> units);

        #endregion Units

        #region Images

        List<ImageModel> GetImagesFromJsonString(string json);

        bool ImagesAddRange(List<ImageModel> images);

        #endregion Images

        #endregion RepositoryFillers

        #endregion Import

        #endregion Product
    }
}
