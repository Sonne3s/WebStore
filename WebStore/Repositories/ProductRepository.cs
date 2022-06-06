using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories
{
    public class ProductRepository : BaseProductRepository, IProductRepository
    {
        #region Components

        public List<ComponentModel> GetComponents(int productId)
        {
            using (var db = new Context())
            {
                return db.Components
                    .Include(c => c.Properties)
                        .ThenInclude(p => p.Group)
                    .Include(c => c.Properties)
                        .ThenInclude(c => c.PropertyTextValues)
                    .Include(c => c.Properties)
                        .ThenInclude(c => c.PropertyIntegerValues)
                    .Include(c => c.Properties)
                        .ThenInclude(c => c.PropertyDecimalValues)
                    .Where(c => c.ProductId == productId)
                    .ToList();
            }
        }

        public int GetLastComponentId()
        {
            using(var db = new Context())
            {
                return db.Components.OrderByDescending(c => c.Id).FirstOrDefault()?.Id ?? 0;
            }
        }

        #endregion Components

        #region ProductTypes

        public ProductTypeModel CreateProductType(string productTypeName, string productTypeDescription)
        {
            using (var db = new Context())
            {
                var group = db.PropertyGroups.FirstOrDefault(g => g.Id == (int)BasePropertyGroupIdEnumeration.ProductType);

                var productType = new ProductTypeModel
                {
                    Value = productTypeName,
                    Description = productTypeDescription,
                    Group = group,
                    GroupId = group.Id,
                };
                db.ProductTypes.Add(productType);
                db.SaveChanges();

                return productType;
            }
        }

        public ProductTypeModel RemoveProductType(int id)
        {
            using (var db = new Context())
            {
                var productType = db.ProductTypes.FirstOrDefault(p => p.Id == id);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                return productType;
            }
        }

        public ProductTypeModel UpdateProductType(int id, string value, string description)
        {
            using (var db = new Context())
            { 
                var productType = db.ProductTypes.FirstOrDefault(p => p.Id == id);
                productType.Value = value;
                productType.Description = description;
                db.SaveChanges();

                return productType;
            }
        }

        public ProductTypeModel GetProductType(int id)
        {
            using (var db = new Context())
            {
                return db.ProductTypes.FirstOrDefault(t => t.Id == id);
            }
        }

        public ProductTypeModel GetLastProductType()
        {
            using (var db = new Context())
            {
                return db.ProductTypes.OrderByDescending(p => p.Id).FirstOrDefault();
            }
        }

        public ProductTypeModel GetProductTypeFromProduct(int productId)
        {
            using (var db = new Context())
            {
                return db.ProductTypes.FirstOrDefault(t => t.Products.Any(p => p.Id == productId));
            }
        }

        public List<ProductTypeModel> GetAllProductTypes()
        {
            using (var db = new Context())
            {
                return db.ProductTypes.ToList();
            }
        }

        public void ProductTypesAddRange(List<ProductTypeModel> productTypes)
        {
            using (var db = new Context())
            {
                db.ProductTypes.AddRange(productTypes);
                db.SaveChanges();
            }
        }

        #endregion ProductTypes

        #region Producers

        public ProducerModel CreateProducer(string name, string description)
        {
            using (var db = new Context())
            {
                var producer = new ProducerModel
                {
                    Value = name,
                    GroupId = (int)BasePropertyGroupIdEnumeration.Producer,
                    Description = description,
                };
                db.Producers.Add(producer);
                db.SaveChanges();

                return producer;
            }
        }

        public ProducerModel RemoveProducer(int id)
        {
            using (var db = new Context())
            {
                var producer = db.Producers.FirstOrDefault(p => p.Id == id);
                db.Producers.Remove(producer);
                db.SaveChanges();

                return producer;
            }
        }

        public ProducerModel UpdateProducer(int id, string value, string description)
        {
            using (var db = new Context())
            {
                var producer = db.Producers.FirstOrDefault(p => p.Id == id);
                producer.Value = value;
                producer.Description = description;
                db.SaveChanges();

                return producer;
            }
        }

        public ProducerModel GetProducerForProduct(int productId)
        {
            using (var db = new Context())
            {
                return db.Producers.FirstOrDefault(p => p.Products.Any(pt => pt.Id == productId));
            }
        }

        public ProducerModel GetProducer(int id)
        {
            using (var db = new Context())
            {
                return db.Producers.FirstOrDefault(p => p.Id == id);
            }
        }

        public ProducerModel GetLastProducer()
        {
            using (var db = new Context())
            {
                return db.Producers.OrderByDescending(p => p.Id).FirstOrDefault();
            }
        }

        public List<ProducerModel> GetAllProducers()
        {
            using (var db = new Context())
            {
                return db.Producers.ToList();
            }
        }

        public void ProducersAddRange(List<ProducerModel> producers)
        {
            using (var db = new Context())
            {
                db.Producers.AddRange(producers);
                db.SaveChanges();
            }
        }

        #endregion Producers

        #region Images

        public List<ImageModel> GetAllImages()
        {
            using (var db = new Context())
            {
                return db.Images.ToList();
            }
        }

        public void ImagesAddRange(List<ImageModel> images)
        {
            using (var db = new Context())
            {
                db.Images.AddRange(images);
                db.SaveChanges();
            }
        }

        #endregion Images

        #region Other

        public (decimal MinPrice, decimal MaxPrice) GetPriceRange()
        {
            using (var db = new Context())
            {
                return (db.Product.Min(p => p.Price), db.Product.Max(p => p.Price));
            }
        }

        public decimal GetMaxPrice()
        {
            using (var db = new Context())
            {
                return db.Product.Max(p => p.Price);
            }
        }

        public decimal GetMinPrice()
        {
            using (var db = new Context())
            {
                return db.Product.Min(p => p.Price);
            }
        }

        #endregion Other
    }
}
