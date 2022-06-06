using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories
{
    public class BaseProductRepository : IBaseProductRepository
    {
        public void ClearDb()
        {
            Context.Clear();
        }

        public void Add(ProductModel product)
        {
            using(var db = new Context())
            {
                db.Product.Add(product);
                db.SaveChanges();
            }
        }

        public void AddRange(List<ProductModel> products)
        {
            using (var db = new Context())
            {
                db.Product.AddRange(products);
                db.SaveChanges();
            };
        }

        public void Delete(int id)
        {
            using (var db = new Context())
            {
                var product = db.Product.FirstOrDefault(p => p.Id == id);
                db.Product.Remove(product);
                db.SaveChanges();
            }
        }

        public ProductModel Get(int? productId)
        {
            using (var db = new Context())
            {
                return db.Product
                    .Include(p => p.Images)
                    .Include(p => p.Producer)
                    .Include(p => p.ProductType)
                    .Include(p => p.Components)
                        .ThenInclude(c => c.Properties)
                            .ThenInclude(p => p.Group)
                                .ThenInclude(g => g.UnitType)
                    .Include(p => p.Components)
                        .ThenInclude(c => c.Properties)
                            .ThenInclude(prop => prop.PropertyTextValues)
                    .Include(p => p.Components)
                        .ThenInclude(c => c.Properties)
                            .ThenInclude(prop => prop.PropertyIntegerValues)
                    .Include(p => p.Components)
                        .ThenInclude(c => c.Properties)
                            .ThenInclude(prop => prop.PropertyDecimalValues)
                    .FirstOrDefault(p => p.Id == productId);
            };
        }

        public void Replace(ProductModel newProduct)
        {
            using (var db = new Context())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    var product = db.Product.Where(p => p.Id == newProduct.Id);
                    db.PropertyTextValues.RemoveRange(product.SelectMany(c => c.Components).SelectMany(p => p.Properties).SelectMany(v => v.PropertyTextValues));
                    db.PropertyIntegerValues.RemoveRange(product.SelectMany(c => c.Components).SelectMany(p => p.Properties).SelectMany(v => v.PropertyIntegerValues));
                    db.PropertyDecimalValues.RemoveRange(product.SelectMany(c => c.Components).SelectMany(p => p.Properties).SelectMany(v => v.PropertyDecimalValues));
                    db.Property.RemoveRange(product.SelectMany(c => c.Components).SelectMany(p => p.Properties));
                    db.Components.RemoveRange(product.SelectMany(c => c.Components));
                    db.Images.RemoveRange(product.SelectMany(p => p.Images));
                    db.Product.RemoveRange(product);
                    db.Product.Add(newProduct);

                    db.SaveChanges();
                    dbContextTransaction.Commit();
                }
            };
        }

        public List<ProductModel> GetAll()
        {
            using (var db = new Context())
            {
                this.ProductLoadEntities(db);

                return db.Product.ToList();
            }
        }

        public List<ProductModel> GetAll((int chunkSize, int chunkNumber) paginationFilter)
        {
            using (var db = new Context())
            {
                this.ProductLoadEntities(db);

                return ApplyPaginationFilter(db.Product, paginationFilter).ToList();
            }
        }

        public List<ProductModel> GetAll(List<Models.ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int chunkSize, int chunkNumber) paginationFilter)
        {
            using (var db = new Context())
            {
                this.ProductLoadEntities(db);

                return this.GetFilteredQuerable(filters, baseFilters, paginationFilter, db.Product).ToList();
            }
        }

        public int GetCount(List<Models.ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int chunkSize, int chunkNumber) paginationFilter)
        {
            using (var db = new Context())
            {
                return this.GetFilteredQuerable(filters, baseFilters, paginationFilter, db.Product).Count();
            }
        }

        public int GetCount((int chunkSize, int chunkNumber) paginationFilter)
        {
            using (var db = new Context())
            {
                return ApplyPaginationFilter(db.Product, paginationFilter).Count();
            }
        }

        public int GetCount()
        {
            using (var db = new Context())
            {
                return db.Product.Count();
            }
        }

        #region Privates

        private void ProductLoadEntities(Context db)
        {
            db.Images.Load();
            db.Producers.Load();
            db.ProductTypes.Load();
            db.Components.Load();
            db.PropertyGroups.Load();
            db.Property.Load();
            db.PropertyTextValues.Load();
            db.PropertyIntegerValues.Load();
            db.PropertyDecimalValues.Load();
            db.PropertyUnits.Load();
        }

        private IQueryable<ProductModel> ApplyPaginationFilter(IQueryable<ProductModel> products, (int ChunkSize, int ChunkNumber) paginationFilter)
        {
            return products.Skip(paginationFilter.ChunkSize * (paginationFilter.ChunkNumber - 1)).Take(paginationFilter.ChunkSize);
        }

        private IQueryable<ProductModel> GetFilteredQuerable(
            List<Models.ProductFilterModel> filters, ProductBaseFiltersModel baseFilters, (int ChunkSize, int ChunkNumber) paginationFilter, IQueryable<ProductModel> products)
        {
            products = this.GetFilteredProductsByBaseFilters(products, baseFilters);
            products = this.GetFilteredProductsByTextProperties(products, filters);
            products = this.GetFilteredProductsByIntegerProperties(products, filters);
            products = this.GetFilteredProductsByDecimalProperties(products, filters);

            return ApplyPaginationFilter(products, paginationFilter);
        }

        private IQueryable<ProductModel> GetFilteredProductsByBaseFilters(IQueryable<ProductModel> products, ProductBaseFiltersModel baseFilters)
        {
            products = this.GetFilteredProductsByProductType(products, baseFilters.Type);
            products = this.GetFilteredProductsByProducer(products, baseFilters.Producer);
            products = this.GetFilteredProductsByPrice(products, baseFilters.MinPrice, baseFilters.MaxPrice);

            return products;
        }

        private IQueryable<ProductModel> GetFilteredProductsByProductType(IQueryable<ProductModel> products, int productTypeId)
        {
            return products.Where(p => p.ProductTypeId == productTypeId);
        }

        private IQueryable<ProductModel> GetFilteredProductsByProducer(IQueryable<ProductModel> products, List<int> producerIds)
        {
            return producerIds == null || producerIds.Count == 0 
                ? products 
                : products.Where(p => producerIds.Contains(p.ProducerId));
        }

        private IQueryable<ProductModel> GetFilteredProductsByPrice(IQueryable<ProductModel> products, decimal minPrice, decimal maxPrice)
        {
            products = this.GetFilteredProductsByMinPrice(products, minPrice);
            products = this.GetFilteredProductsByMaxPrice(products, maxPrice);

            return products;
        }

        private IQueryable<ProductModel> GetFilteredProductsByMinPrice(IQueryable<ProductModel> products, decimal minPrice)
        {
            return products.Where(p => p.Price > minPrice);
        }

        private IQueryable<ProductModel> GetFilteredProductsByMaxPrice(IQueryable<ProductModel> products, decimal maxPrice)
        {
            return maxPrice == 0 
                ? products 
                : products.Where(p => p.Price < maxPrice);
        }

        private IQueryable<ProductModel> GetFilteredProductsByTextProperties(IQueryable<ProductModel> products, List<Models.ProductFilterModel> filters)
        {
            foreach (var filter in filters.Where(f => f.Type == PropertyTypeEnumeration.Text))
            {
                products = products
                    .Where(p => p.Components
                        .Any(c => c.Properties
                            .Any(prop => prop.GroupId == filter.GroupId && prop.PropertyTextValues.Any(v => filter.Values.Any(f => f == v.Value)))));
            }

            return products;
        }

        private IQueryable<ProductModel> GetFilteredProductsByIntegerProperties(IQueryable<ProductModel> products, List<Models.ProductFilterModel> filters)
        {
            foreach (var filter in filters.Where(f => f.Type == PropertyTypeEnumeration.Integer))
            {
                var intFilterValue = default(int);
                var filterValue = filter.Values.FirstOrDefault();
                if (filterValue != null && int.TryParse(filterValue, out intFilterValue))
                {
                    products = this.GetFilteredProductsByIntegerPropertiesMinValue(products, filter.GroupId, intFilterValue);
                }
                filterValue = filter.Values.LastOrDefault();
                if (filterValue != null && int.TryParse(filterValue, out intFilterValue))
                {
                    products = this.GetFilteredProductsByIntegerPropertiesMaxValue(products, filter.GroupId, intFilterValue);
                }
            }

            return products;
        }

        private IQueryable<ProductModel> GetFilteredProductsByIntegerPropertiesMinValue(IQueryable<ProductModel> products, int propertyGroupId, int minFilterValue)
        {
            return products
                .Where(p => p.Components
                    .Any(c => c.Properties
                        .Any(prop =>
                            prop.GroupId == propertyGroupId &&
                            prop.PropertyIntegerValues.Any(v => v.Value >= minFilterValue))));
        }

        private IQueryable<ProductModel> GetFilteredProductsByIntegerPropertiesMaxValue(IQueryable<ProductModel> products, int propertyGroupId, int maxFilterValue)
        {
            return products
                .Where(p => p.Components
                    .Any(c => c.Properties
                        .Any(prop =>
                            prop.GroupId == propertyGroupId &&
                            prop.PropertyIntegerValues.Any(v => v.Value <= maxFilterValue))));
        }

        private IQueryable<ProductModel> GetFilteredProductsByDecimalProperties(IQueryable<ProductModel> products, List<Models.ProductFilterModel> filters)
        {
            foreach (var filter in filters.Where(f => f.Type == PropertyTypeEnumeration.Decimal))
            {
                var decimalFilterValue = default(decimal);
                var filterValue = filter.Values.FirstOrDefault();
                if (filterValue != null && decimal.TryParse(filterValue, out decimalFilterValue))
                {
                    products = this.GetFilteredProductsByDecimalPropertiesMinValue(products, filter.GroupId, decimalFilterValue);
                }
                filterValue = filter.Values.LastOrDefault();
                if (filterValue != null && decimal.TryParse(filterValue, out decimalFilterValue))
                {
                    products = this.GetFilteredProductsByDecimalPropertiesMaxValue(products, filter.GroupId, decimalFilterValue);
                }
            }

            return products;
        }

        private IQueryable<ProductModel> GetFilteredProductsByDecimalPropertiesMinValue(IQueryable<ProductModel> products, int propertyGroupId, decimal minFilterValue)
        {
            return products
                .Where(p => p.Components
                    .Any(c => c.Properties
                        .Any(prop =>
                            prop.GroupId == propertyGroupId &&
                            prop.PropertyDecimalValues.Any(v => v.Value >= minFilterValue))));
        }

        private IQueryable<ProductModel> GetFilteredProductsByDecimalPropertiesMaxValue(IQueryable<ProductModel> products, decimal propertyGroupId, decimal maxFilterValue)
        {
            return products
                .Where(p => p.Components
                    .Any(c => c.Properties
                        .Any(prop =>
                            prop.GroupId == propertyGroupId &&
                            prop.PropertyDecimalValues.Any(v => v.Value <= maxFilterValue))));
        }

        #endregion Privates
    }
}
