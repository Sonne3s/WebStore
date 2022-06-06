using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Customer.Fillers.IFillers;
using WebStore.Areas.Customer.ViewModels;
using WebStore.Areas.Customer.ViewModels.Product;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Customer.Fillers
{
    public class ProductListFiller : IProductListFiller
    {
        public ProductListViewModel GetFilledProductListViewModel(
            OrderingModel cart,
            List<ProductModel> products,
            List<ProductTypeModel> productTypes,
            List<ProducerModel> producers,
            decimal minPrice, 
            decimal maxPrice,
            List<ProductListFilterItemViewModel> filterItems,
            List<PaginationItemViewModel> pages) 
                => new(
                    this.GetFilledProductListFilterViewModel(productTypes, producers, this.GetFilledProductListFilterItemViewModel(minPrice, maxPrice), filterItems), 
                    this.GetFilledProductListItemViewModels(products, cart), pages);

        private ProductListFilterViewModel GetFilledProductListFilterViewModel(
            List<ProductTypeModel> productTypes, List<ProducerModel> producers, ProductListFilterItemViewModel price, List<ProductListFilterItemViewModel> Items)
            => new ProductListFilterViewModel(this.GetFilledSelectListItem(productTypes), this.GetFilledProductListFilterProducerViewModel(producers), price, Items);

        private List<SelectListItem> GetFilledSelectListItem(List<ProductTypeModel> productTypes)
            => productTypes.Select(t => new SelectListItem(t.Value, t.Id.ToString())).ToList();

        private ProductListFilterItemViewModel GetFilledProductListFilterItemViewModel(decimal minPrice, decimal maxPrice)
            => this.GetFilledProductListFilterItemViewModel(
                default(int), 
                default(int),
                "Цена", 
                PropertyTypeEnumeration.Decimal, 
                new List<string> { minPrice.ToString(), maxPrice.ToString() },
                "₽");

        private ProductListFilterProducerViewModel GetFilledProductListFilterProducerViewModel(List<ProducerModel> producers)
            => new ProductListFilterProducerViewModel(producers.Select(p => ValueTuple.Create(p.Id, p.Value)).ToList());

        private ProductListFilterItemViewModel GetFilledProductListFilterItemViewModel(
            int orderId, int groupId, string name, PropertyTypeEnumeration type, List<string> values, string UnitValue)
            => new ProductListFilterItemViewModel(orderId, groupId, name, type, values, UnitValue);

        public List<ProductListItemViewModel> GetFilledProductListItemViewModels(List<ProductModel> products, OrderingModel cart) =>
            products.Select(p =>
                this.GetFilledProductListItemViewModel(p, cart.Items.FirstOrDefault(i => i.ProductId == p.Id)?.Count ?? default(int))).ToList();

        private ProductListItemViewModel GetFilledProductListItemViewModel(ProductModel product, int count)
            => new ProductListItemViewModel(product.Id, $"{product.ProductType.Value} {product.Producer.Value} {product.Name}", product.Price, count, product.Price * count, this.GetSrcImages(product.Images));

        public PaginationViewModel GetPaginationViewModel(int CurrentPage, (List<int> Pages, int? FirstPage, int? LastPage) Pages) => 
            new PaginationViewModel(CurrentPage, Pages.Pages, Pages.FirstPage, Pages.LastPage);

        public List<PaginationItemViewModel> GetFilledPaginationItemViewModels(List<ProductPaginationItemModel> Pages) =>
            Pages.Select(p => new PaginationItemViewModel(p.Id, p.IsCurrent, p.IsFirstPage, p.IsLastPage)).ToList();

        private List<string> GetSrcImages(List<ImageModel> images) => images.Select(i => i.Src).ToList();

        public ProductListItemCartSectionViewModel GetFilledProductListItemCartSectionViewModel(OrderingItemModel cartItem, int productId)
            => new ProductListItemCartSectionViewModel(
                productId, 
                cartItem?.Count ?? default(int), 
                (cartItem?.Product?.Price ?? default(int)) * (cartItem?.Count ?? default(int)));
    }
}
