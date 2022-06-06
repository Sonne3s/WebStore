using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.Fillers;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories
{
    public class PropertyGroupRepository : IPropertyGroupRepository
    {
        public PropertyGroupModel Get(int groupId)
        {
            using (var db = new Context())
            {
                return db.PropertyGroups.Include(g => g.UnitType).FirstOrDefault(g => g.Id == groupId);
            }
        }

        public PropertyGroupModel GetLast()
        {
            using (var db = new Context())
            {
                return db.PropertyGroups.OrderByDescending(p => p.Id).Include(g => g.UnitType).FirstOrDefault();
            }
        }

        public PropertyGroupModel Create(string name, int valueTypeId, PropertyUnitModel unit, string description)
        {
            using(var db = new Context())
            {
                var group = new PropertyGroupModel
                {
                    Name = name,
                    TypeId = valueTypeId,
                    UnitTypeId = unit?.Id,
                    Description = description,
                };
                db.PropertyGroups.Add(group);
                db.SaveChanges();

                return group;
            }
        }

        public PropertyGroupModel Remove(int id)
        {
            try
            {
                using (var db = new Context())
                {
                    var group = db.PropertyGroups.FirstOrDefault(p => p.Id == id);
                    db.PropertyGroups.Remove(group);
                    db.SaveChanges();

                    return group;
                }
            }
            catch
            {
                return null;
            }
        }

        public PropertyGroupModel Update(int id, string name, int valueTypeId, PropertyUnitModel unit, string description)
        {
            using (var db = new Context())
            {
                var group = db.PropertyGroups.FirstOrDefault(g => g.Id == id);
                group.Name = name;
                group.Description = description;
                group.TypeId = valueTypeId;
                group.UnitTypeId = unit?.Id;
                db.PropertyGroups.Update(group);
                db.SaveChanges();

                return group;
            }
        }

        public void AddRange(List<PropertyGroupModel> groups)
        {
            using (var db = new Context())
            {
                db.PropertyGroups.AddRange(groups);
                db.SaveChanges();
            }
        }

        public List<PropertyGroupModel> GetBase()
        {
            using (var db = new Context())
            {
                return db.PropertyGroups.Where(p => p.Id == (int)BasePropertyGroupIdEnumeration.ProductType || p.Id == (int)BasePropertyGroupIdEnumeration.Producer).ToList();
            }
            //return FakeRepositoriesFiller.GetBasePropertyGroupModels();
        }

        public List<PropertyGroupModel> GetAll()
        {
            using (var db = new Context())
            {
                return db.PropertyGroups.Except(db.PropertyGroups.Where(p => p.Id == (int)BasePropertyGroupIdEnumeration.ProductType || p.Id == (int)BasePropertyGroupIdEnumeration.Producer)).Include(g => g.UnitType).ToList();
            }
        }

        //public List<PropertyGroupModel> GetFromProduct(int productId)
        //{
        //    using (var db = new Context())
        //    {
        //        return db.Product.FirstOrDefault(p => p.Id == productId).Components.FirstOrDefault().Properties.Select(p => p.PropertyValue.Group).ToList();
        //    }
        //}
    }
}
