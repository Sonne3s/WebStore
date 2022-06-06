using Newtonsoft.Json;
using System.Globalization;
using System.Text.RegularExpressions;
using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Areas.Admin.ViewModels.Components;
using WebStore.Areas.Admin.ViewModels.ProductProperty;
using WebStore.Extensions;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories;
using WebStore.Repositories.IRepositories;
using static WebStore.Helpers.FileHelper;
using PropertyViewModel = WebStore.Areas.Admin.ViewModels.PropertyViewModel;

namespace WebStore.Areas.Admin.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private IProductRepository _productRepository;
        private IPropertyGroupRepository _groupRepository;
        private IProductEditHandler _productEditHandler;
        private IHelperProvider _helper;

        public ProductHandler(
            IProductRepository productRepository, 
            IPropertyGroupRepository groupRepository,
            IProductEditHandler productEditHandler,
            IHelperProvider helper)
        {
            _productRepository = productRepository;
            _groupRepository = groupRepository;
            _productEditHandler = productEditHandler;
            _helper = helper;
        }

        #region Products

        public List<ProductModel> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductModel Get(int? id)
        {
            return _productRepository.Get(id);
        }

        public bool Add(ProductModel product)
        {
            if (product.Id != null && product.Id > 0)
            {
                _productRepository.Replace(product);
            }
            else
            {
                _productRepository.Add(product);
            }

            return true;
        }

        public void Delete(int productId)
        {
            _productRepository.Delete(productId);
        }
        private ProductModel GetProductByViewModel(EditViewModel viewModel)
        {
            return new ProductModel
            {
                Id = viewModel.Id.HasValue ? viewModel.Id.Value : default(int),
                Name = viewModel.Name,
                Price = viewModel.Price.ToDecimal(out _),
                ProductTypeId = viewModel.TypeId,
                ProducerId = viewModel.ProducerId,
                Description = viewModel.Description,
                Components = viewModel.ComponentsTab.PropertyContainers.Select(c => this.GetComponentByViewModel(c)).ToList()
            };
        }

        private ComponentModel GetComponentByViewModel(ContainerViewModel viewModel)
        {
            return new ComponentModel
            {
                Name = viewModel.Name,
                Properties = viewModel.Properties.Select(p => this.GetPropertyByViewModel(p)).ToList()
            };
        }

        private PropertyModel GetPropertyByViewModel(InputViewModel viewModel)
        {
            var property = new PropertyModel
            {
                GroupId = viewModel.Property.GroupId,
            };

            switch (viewModel.Property.Type)
            {
                case PropertyTypeEnumeration.Text:
                    property.PropertyTextValues = viewModel.Property.Values.Select(v => new PropertyTextValueModel { Value = v }).ToList();
                    break;

                case PropertyTypeEnumeration.Integer:
                    property.PropertyIntegerValues = viewModel.Property.Values.Select(v => new PropertyIntegerValueModel { Value = Int32.Parse(v) }).ToList();
                    break;

                case PropertyTypeEnumeration.Decimal:
                    property.PropertyDecimalValues = viewModel.Property.Values.Select(v => new PropertyDecimalValueModel { Value = Decimal.Parse(v, new NumberFormatInfo { NumberDecimalSeparator = "." }) }).ToList();
                    break;
            }

            return property;
        }

        public ProductModel GetProductByForm(IFormCollection form, EditViewModel viewModel)
        {
            var product = this.GetProductByViewModel(viewModel);
            //var componentList = this.GetComponents(form, product).ToList();
            //this.FillComponentList(form, componentList, product);
            //product.Components = componentList;
            //product.Components.ForEach(c => c.Id = 0);
            product.Images = this.GetImagesByForm(form, product).ToList();
            //_productRepository.ImagesAddRange(product.Images);
            //_propertyRepository.AddRange(componentList.SelectMany(c => c.Properties).ToList());
            //_propertyRepository.PropertyValuesAddRange(componentList.SelectMany(c => c.Properties).Select(p => p.PropertyValue).ToList());

            return product;
        }

        #endregion Products

        #region ProductTypes

        public List<ProductTypeModel> GetProductTypes()
        {
            return _productEditHandler.GetProductTypes();
        }

        public ProductTypeModel GetProductTypeFromProduct(int productId)
        {
            return _productRepository.GetProductTypeFromProduct(productId);
        }

        #endregion ProductTypes

        #region Producers
        public ProducerModel GetProducerFromProduct(int productId)
        {
            return _productRepository.GetProducerForProduct(productId);
        }

        public List<ProducerModel> GetProducers()
        {
            return _productEditHandler.GetProducers();
        }

        #endregion Producers

        #region Components

        public int GetNewComponentId()
        {
            return _productRepository.GetLastComponentId() + 1;
        }

        private IEnumerable<ComponentModel> GetComponents(IFormCollection form, ProductModel product)
        {
            Regex propertyComponentNameRegexp = new Regex(@"(?<=Component)\d*(?=Name)", RegexOptions.IgnoreCase);

            foreach (var prop in form)
            {
                var componentIdWithName = default(int);
                var hasComponentName = int.TryParse(propertyComponentNameRegexp.Match(prop.Key).Value, out componentIdWithName);

                if (hasComponentName)
                {
                    yield return new ComponentModel
                    {
                        Id = componentIdWithName,
                        Name = prop.Value,
                        Properties = new List<PropertyModel>(),
                        Product = product,
                        ProductId = product.Id,
                    };
                }
            }
        }

        private void FillComponentList(IFormCollection form, List<ComponentModel> components, ProductModel product)
        {
            Regex propertyComponentIdRegexp = new Regex(@"(?<=Component)\d*", RegexOptions.IgnoreCase);
            Regex propertyGroupIdRegexp = new Regex(@"(?<=Prop)\d*", RegexOptions.IgnoreCase);

            foreach (var prop in form)
            {
                var componentId = default(int);
                int.TryParse(propertyComponentIdRegexp.Match(prop.Key).Value, out componentId);
                var component = components.FirstOrDefault(c => c.Id == componentId);
                var groupId = default(int);
                var hasGroup = int.TryParse(propertyGroupIdRegexp.Match(prop.Key).Value, out groupId);
                var propValue = prop.Value.FirstOrDefault();
                if (hasGroup && !string.IsNullOrEmpty(propValue))
                {
                    component.Properties.Add(this.GetProperty(propValue, _groupRepository.Get(groupId), component));
                }
            }
        }

        private PropertyModel GetProperty(string propValue, PropertyGroupModel group, ComponentModel component)
        {
            var property = new PropertyModel();
            property.Component = component;
            property.ComponentId = component.Id;
            property.GroupId = group.Id;
            switch (group.TypeId)
            {
                case (int)PropertyTypeEnumeration.Text:
                    property.PropertyTextValues = new List<PropertyTextValueModel> { this.GetPropertyTextValue(propValue) };
                    break;

                case (int)PropertyTypeEnumeration.Integer:
                    break;

                case (int)PropertyTypeEnumeration.Decimal:
                    property.PropertyDecimalValues = new List<PropertyDecimalValueModel> { this.GetPropertyDecimalValue(propValue) };
                    break;
            }

            return property;
        }

        private PropertyTextValueModel GetPropertyTextValue(string propValue)
        {
            return new PropertyTextValueModel
            {
                Description = null,
                Value = propValue,
            };
        }

        private PropertyIntegerValueModel GetPropertyIntegerValue(string propValue)
        {
            return new PropertyIntegerValueModel
            {
                Value = int.Parse(propValue),
            };
        }

        private PropertyDecimalValueModel GetPropertyDecimalValue(string propValue)
        {
            return new PropertyDecimalValueModel
            {
                Value = decimal.Parse(propValue),
            };
        }

        #endregion Components

        #region Images

        public List<EditViewModel.ImageModel> ImagesToBase64(List<ImageModel> target)
        {
            return target.Select(i => new EditViewModel.ImageModel
            {
                Id = i.Id,
                Base64 = _helper.File.GetBase64SrcData(i.Src),
                Name = Path.GetFileName(i.Src)
            }).ToList();
        }

        private IEnumerable<ImageModel> GetImagesByForm(IFormCollection form, ProductModel product)
        {
            var guid = Guid.NewGuid();
            string relativePath = $"{guid.ToString()}-{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}";
            string path = Path.Combine(_helper.File.ProductImagesFolderPath, relativePath);
            Directory.CreateDirectory(path);
            foreach (IFormFile file in form.Files)
            {
                if (file.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                    string filePath = Path.Combine(path, fileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    yield return new ImageModel
                    {
                        Src = Path.Combine(_helper.File.RelativeProductImagesFolderPath, relativePath, fileName),
                        Product = product,
                        ProductId = product.Id,
                    };
                }
            }
        }

        #endregion Images

        public void ClearDb()
        {
            _productRepository.ClearDb();
        }
    }
}
