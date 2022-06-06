using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;
using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Admin.Handlers
{
    public class DataMigrationHandler : IDataMigrationHandler
    {
        #region Providers

        private IProductRepository _productRepository;
        private IPropertyGroupRepository _groupRepository;
        private IProductPropertyRepository _propertyRepository;
        private IWebHostEnvironment _hostingEnvironment;
        private IHelperProvider _helper;

        #endregion Providers

        #region Constructor

        public DataMigrationHandler(
            IProductRepository productRepository, 
            IPropertyGroupRepository groupRepository, 
            IProductPropertyRepository propertyRepository, 
            IWebHostEnvironment hostingEnvironment, 
            IHelperProvider helper)
        {
            _productRepository = productRepository;
            _groupRepository = groupRepository;
            _propertyRepository = propertyRepository;
            _hostingEnvironment = hostingEnvironment;
            _helper = helper;
        }

        #endregion Constructor

        #region Product

        #region Export

        public byte[] GetProductsExportFile()
        {
            var main = new { Version = Configs.Version };
            var products = this.GetAll();
            var groups = this.GetAllGroup();
            var productTypes = this.GetAllProductTypes();
            var producers = this.GetAllProducers();
            var properties = this.GetAllProperties();
            var values = this.GetAllPropertyValues();
            var units = this.GetAllPropertyValueUnits();
            var images = this.GetAllImages();   

            var jsonMain = _helper.File.GetJsonFromModel(main);
            var jsonProducts = _helper.File.GetJsonFromModel(products);
            var jsonGroups = _helper.File.GetJsonFromModel(groups);
            var jsonProductTypes = _helper.File.GetJsonFromModel(productTypes);
            var jsonProducers = _helper.File.GetJsonFromModel(producers);
            var jsonProperties = _helper.File.GetJsonFromModel(properties);
            var jsonValues = _helper.File.GetJsonFromModel(values);
            var jsonUnits = _helper.File.GetJsonFromModel(units);
            var jsonImages = _helper.File.GetJsonFromModel(images);

            var memoryFiles = new List<(Stream, string)>()
            {
                (_helper.File.GetStreamFromString(jsonMain), "main.json"),
                (_helper.File.GetStreamFromString(jsonProducts), "products.json"),
                (_helper.File.GetStreamFromString(jsonGroups), "groups.json"),
                (_helper.File.GetStreamFromString(jsonProductTypes), "productTypes.json"),
                (_helper.File.GetStreamFromString(jsonProducers), "producers.json"),
                (_helper.File.GetStreamFromString(jsonProperties), "properties.json"),
                (_helper.File.GetStreamFromString(jsonValues), "values.json"),
                (_helper.File.GetStreamFromString(jsonUnits), "units.json"),
                (_helper.File.GetStreamFromString(jsonImages), "images.json"),
            };
            var diskFiles = products.SelectMany(p => p.Images.Select(i => (Path.Combine(_hostingEnvironment.WebRootPath, i.Src), i.Src))).ToList();

            return _helper.File.CreateArchive(memoryFiles, diskFiles);
        }

        #region RepositoriesProvider

        private List<ProductModel> GetAll()
        {
            return _productRepository.GetAll();
        }

        private List<PropertyGroupModel> GetAllGroup()
        {
            return _groupRepository.GetAll();
        }

        private List<PropertyValueModel> GetAllPropertyValues()
        {
            return _propertyRepository.GetAllPropertyValues();
        }
        private List<PropertyUnitModel> GetAllPropertyValueUnits()
        {
            return _propertyRepository.GetAllUnits();
        }

        private List<ProducerModel> GetAllProducers()
        {
            return _productRepository.GetAllProducers();
        }
        private List<ImageModel> GetAllImages()
        {
            return _productRepository.GetAllImages();
        }

        private List<ProductTypeModel> GetAllProductTypes()
        {
            return _productRepository.GetAllProductTypes();
        }

        private List<PropertyModel> GetAllProperties()
        {
            return _propertyRepository.GetAll();
        }

        #endregion RepositoriesProvider

        #endregion Export

        #region Import

        #region ExtractJsonsAndWriteImages

        public (
            string Main,
            string Products,
            string Groups,
            string ProductTypes,
            string Producers,
            string Properties,
            string Values,
            string Units,
            string Images
            ) ExtractJsonsAndWriteImages(IFormFile file)
        {
            return this.ExtractFromZipArchive(file, _hostingEnvironment.WebRootPath);
        }
        #endregion ExtractJsonsAndWriteImages

        #region ExtractFromZipArchive

        private (
            string Main,
            string Products, 
            string Groups,
            string ProductTypes,
            string Producers,
            string Properties,
            string Values,
            string Units,
            string Images
            ) ExtractFromZipArchive(IFormFile file, string folderName)
        {
            using (var stream = file.OpenReadStream())
            using (var archive = new ZipArchive(stream))
            {
                archive.ExtractToDirectory(folderName, true);
                var modelEntry = archive.GetEntry("main.json");
                var main = new StreamReader(modelEntry.Open(), Encoding.Default);

                modelEntry = archive.GetEntry("products.json");
                var products = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("groups.json");
                var groups = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("productTypes.json");
                var productTypes = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("producers.json");
                var producers = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("properties.json");
                var properties = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("values.json");
                var values = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("units.json");
                var units = new StreamReader(modelEntry.Open(), Encoding.Default);
                modelEntry = archive.GetEntry("images.json");
                var images = new StreamReader(modelEntry.Open(), Encoding.Default);

                return (
                    main.ReadToEnd(), 
                    products.ReadToEnd(), 
                    groups.ReadToEnd(), 
                    productTypes.ReadToEnd(), 
                    producers.ReadToEnd(), 
                    properties.ReadToEnd(), 
                    values.ReadToEnd(), 
                    units.ReadToEnd(), 
                    images.ReadToEnd()
                    );
            }
        }

        #endregion ExtractFromZipArchive

        #region RepositoryFillers

        #region Products

        public List<ProductModel> GetProductsFromJsonString(string json)
        {
            var products = this.GetModelFromJsonString<List<ProductModel>>(json);
            products.ForEach(p => _helper.Product.CorrectPropertyValues(p));

            return products;
        }

        public bool ProductsAddRange(List<ProductModel> products)
        {
            _productRepository.AddRange(products);

            return true;
        }

        #endregion Products

        #region Groups

        public List<PropertyGroupModel> GetGroupsFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<PropertyGroupModel>>(json);
        }

        public bool GroupsAddRange(List<PropertyGroupModel> groups)
        {
            _groupRepository.AddRange(groups);

            return true;
        }

        #endregion Groups

        #region ProductTypes

        public List<ProductTypeModel> GetProductTypesFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<ProductTypeModel>>(json);
        }

        public bool ProductTypesAddRange(List<ProductTypeModel> productTypes)
        {
             _productRepository.ProductTypesAddRange(productTypes);

            return true;
        }

        #endregion ProductTypes

        #region Producers

        public List<ProducerModel> GetProducersFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<ProducerModel>>(json);
        }

        public bool ProducersAddRange(List<ProducerModel> producers)
        {
            _productRepository.ProducersAddRange(producers);

            return true;
        }

        #endregion Producers

        #region Properties

        public List<PropertyModel> GetPropertiesFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<PropertyModel>>(json);
        }

        public bool PropertiesAddRange(List<PropertyModel> properties)
        {
            _propertyRepository.AddRange(properties);

            return true;
        }

        #endregion Properties

        #region Values

        public List<PropertyValueModel> GetValuesFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<PropertyValueModel>>(json);
        }

        public bool ValuesAddRange(List<PropertyValueModel> values)
        {
            _propertyRepository.PropertyValuesAddRange(values);

            return true;
        }

        #endregion Values

        #region Units

        public List<PropertyUnitModel> GetUnitsFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<PropertyUnitModel>>(json);
        }

        public bool UnitsAddRange(List<PropertyUnitModel> units)
        {
            _propertyRepository.UnitsAddRange(units);

            return true;
        }

        #endregion Units

        #region Images

        public List<ImageModel> GetImagesFromJsonString(string json)
        {
            return this.GetModelFromJsonString<List<ImageModel>>(json);
        }

        public bool ImagesAddRange(List<ImageModel> images)
        {
            _productRepository.ImagesAddRange(images);

            return true;
        }

        #endregion Images

        private T GetModelFromJsonString<T>(string json)
        {
            var model = JsonConvert.DeserializeObject<T>(json,
            new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            return model;
        }

        #endregion RepositoryFillers

        #endregion Import

        #endregion Product
    }
}
