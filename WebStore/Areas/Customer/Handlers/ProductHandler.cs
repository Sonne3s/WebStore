using WebStore.Areas.Customer.Handlers.IHandlers;
using WebStore.Areas.Customer.ViewModels;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Extensions;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Customer.Handlers
{
    public class ProductHandler : IProductHandler
    {
        IProductRepository _productRepository;
        IProductPropertyRepository _propertyRepository;
        IHelperProvider _helperProvider;
        IBuyingHandler _buyingHandler;

        public ProductHandler(IProductRepository productRepository, IProductPropertyRepository propertyRepository, IHelperProvider helperProvider, IBuyingHandler buyingHandler)
        {
            _productRepository = productRepository;
            _propertyRepository = propertyRepository;
            _helperProvider = helperProvider;
            _buyingHandler = buyingHandler;
        }

        public ProductModel GetProduct(int id) 
            => _productRepository.Get(id);

        public List<ProductModel> GetProducts(int chunkSize, int chunkNumber) 
            => _productRepository.GetAll((chunkSize, chunkNumber));

        public List<ProductModel> GetFilteredProducts(
            List<ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int chunkSize, int chunkNumber) paginationFilter) 
            => _productRepository.GetAll(filters, baseFilters, paginationFilter);

        public int GetCount(int chunkSize, int chunkNumber) 
            => _productRepository.GetCount();

        public int GetCount(List<ProductFilterModel> filters, ProductBaseFiltersModel baseFilters) 
            =>  _productRepository.GetCount(filters, baseFilters, (100, 1));

        public List<ProductListFilterItemViewModel> GetFilterProperties() 
            => this.GetSettedOrderFilterProperties(_propertyRepository
                .GetTextPropertiesForFilter()
                    .Select(p => this.GetProductListFilterItemBlockViewModelFromText(p.Group, p.TypeId, p.Values, default(int)))
                .Concat(_propertyRepository.GetIntegerPropertiesForFilter()
                    .Select(p => this.GetProductListFilterItemBlockViewModelFromInteger(p.Group, p.TypeId, p.Values, default(int))))
                .Concat(_propertyRepository.GetDecimalPropertiesForFilter()
                    .Select(p => this.GetProductListFilterItemBlockViewModelFromDecimal(p.Group, p.TypeId, p.Values, default(int))))
                .OrderBy(p => p.Name)
                .ToList());        

        private List<ProductListFilterItemViewModel> GetSettedOrderFilterProperties(List<ProductListFilterItemViewModel> filters)
            => filters.Select(r => r with { OrderId = filters.IndexOf(r) }).ToList();

        private ProductListFilterItemViewModel GetProductListFilterItemBlockViewModelFromText(
            PropertyGroupModel Group, PropertyTypeEnumeration Type, List<PropertyTextValueModel> Values, int index) 
            => new (index, Group.Id, Group.Name, Type, Values.Select(v => v.Value).ToList(), string.Empty);

        private ProductListFilterItemViewModel GetProductListFilterItemBlockViewModelFromInteger(
            PropertyGroupModel Group, PropertyTypeEnumeration Type, List<PropertyIntegerValueModel> Values, int index) 
            => new (index, Group.Id, Group.Name, Type, Values.Select(v => v.Value.ToString()).ToList(), Group.UnitType.Value);

        private ProductListFilterItemViewModel GetProductListFilterItemBlockViewModelFromDecimal(
            PropertyGroupModel Group, PropertyTypeEnumeration Type, List<PropertyDecimalValueModel> Values, int index) 
            => new (index, Group.Id, Group.Name, Type, Values.Select(v => v.Value.ToString()).ToList(), Group.UnitType.Value);

        public List<ProductPaginationItemModel> GetPaginationItems(int productCount, int chunkSize, int paginationSize, int currentPage)
            => _helperProvider.Product.GetPaginationItems(productCount, chunkSize, paginationSize, currentPage);       

        public OrderingModel GetOrCreateCart(HttpContext context)
            => _buyingHandler.GetOrCreateCart(context);

        public OrderingItemModel GetCartItem(HttpContext context, int productId)
            => _buyingHandler.GetOrCreateCart(context).Items.FirstOrDefault(i => i.ProductId == productId);

        public List<ProductTypeModel> GetProductTypes()
            => _productRepository.GetAllProductTypes();

        public List<ProducerModel> GetProducers()
            => _productRepository.GetAllProducers();

        public decimal GetMaxProductPrice()
            => _productRepository.GetMaxPrice();

        public decimal GetMinProductPrice()
            => _productRepository.GetMinPrice();
    }
}
