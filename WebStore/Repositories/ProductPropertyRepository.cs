using Microsoft.EntityFrameworkCore;
using WebStore.Extensions;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.Fillers;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories
{
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        public IEnumerable<IGrouping<PropertyGroupModel, PropertyValueModel>> GetForFilterAll()
        {
            return new List<IGrouping<PropertyGroupModel, PropertyValueModel>>();
        }

        #region ProductProperties

        public List<PropertyModel> GetAll()
        {
            using (var db = new Context())
            {
                return db.Property.ToList();
            }
        }

        public void AddRange(List<PropertyModel> properties)
        {
            using (var db = new Context())
            {
                db.Property.AddRange(properties);
                db.SaveChanges();
            }
        }

        #endregion ProductProperties

        #region ProductPropertyValues

        public List<PropertyValueModel> GetAllPropertyValues()
        {
            using (var db = new Context())
            {
                return new List<PropertyValueModel>();
                //return db.PropertyValues.ToList();
            }
        }

        public void PropertyValuesAddRange(List<PropertyValueModel> values)
        {
            using (var db = new Context())
            {
                //db.PropertyValues.AddRange(values);
            }
        }

        public List<(PropertyGroupModel Group, PropertyTypeEnumeration TypeId, List<PropertyTextValueModel> Values)> GetTextPropertiesForFilter()
        {
            using (var db = new Context())
            {
                return db.PropertyTextValues.Include(p => p.Property).ThenInclude(p => p.Group).ThenInclude(g => g.UnitType).ToList()
                    .GroupBy(p => p.Property.Group)
                    .Select(g => new { Id = g.Key, Values = g.GroupBy(p => p.Value).Select(d => d.First()) .ToList()})
                    .ToList()
                    .Select(p => (p.Id, PropertyTypeEnumeration.Text, p.Values)).ToList();
            }
        }

        public List<(PropertyGroupModel Group, PropertyTypeEnumeration TypeId, List<PropertyIntegerValueModel> Values)> GetIntegerPropertiesForFilter()
        {
            using (var db = new Context())
            {
                return db.PropertyIntegerValues.Include(p => p.Property).ThenInclude(p => p.Group).ThenInclude(g => g.UnitType).ToList()
                    .GroupBy(p => p.Property.Group)
                    .Select(g => new { 
                        Id = g.Key, 
                        Values = new List<PropertyIntegerValueModel> { 
                            g.FirstOrDefault(f => f.Value == g.Min(m => m.Value)),
                            g.FirstOrDefault(f => f.Value == g.Max(m => m.Value))} })
                    .ToList()
                    .Select(p => (p.Id, PropertyTypeEnumeration.Integer, p.Values)).ToList();
            }
        }

        public List<(PropertyGroupModel Group, PropertyTypeEnumeration TypeId, List<PropertyDecimalValueModel> Values)> GetDecimalPropertiesForFilter()
        {
            using (var db = new Context())
            {
                return db.PropertyDecimalValues.Include(p => p.Property).ThenInclude(p => p.Group).ThenInclude(g => g.UnitType).ToList()
                    .GroupBy(p => p.Property.Group)
                    .Select(g => new {
                        Id = g.Key,
                        Values = new List<PropertyDecimalValueModel> {
                            g.FirstOrDefault(f => f.Value == g.Min(m => m.Value)),
                            g.FirstOrDefault(f => f.Value == g.Max(m => m.Value))}
                    })
                    .ToList()
                    .Select(p => (p.Id, PropertyTypeEnumeration.Decimal, p.Values)).ToList();
            }
        }

        #endregion ProductPropertyValues

        #region ProductPropertyValueUnits

        public PropertyUnitModel CreatePropertyValueUnit(string name)
        {
            using (var db = new Context())
            {
                var unit = new PropertyUnitModel
                {
                    Value = name,
                };
                db.PropertyUnits.Add(unit);
                db.SaveChanges();

                return unit;
            }
        }

        public PropertyUnitModel RemovePropertyValueUnit(int id)
        {
            using (var db = new Context())
            {
                var unit = db.PropertyUnits.FirstOrDefault(p => p.Id == id);
                db.PropertyUnits.Remove(unit);
                db.SaveChanges();

                return unit;
            }
        }

        public PropertyUnitModel UpdatePropertyValueUnit(int id, string value)
        {
            using (var db = new Context())
            {
                var unit = db.PropertyUnits.FirstOrDefault(u => u.Id == id);
                unit.Value = value;
                db.PropertyUnits.Update(unit);
                db.SaveChanges();

                return unit;
            }
        }

        public PropertyUnitModel GetPropertyValueUnit(int? id)
        {
            if(!id.HasValue)
            {
                return null;
            }

            using (var db = new Context())
            {
                return db.PropertyUnits.FirstOrDefault(u => u.Id == id);
            }
        }

        public PropertyUnitModel GetLastPropertyValueUnit()
        {
            using (var db = new Context())
            {
                return db.PropertyUnits.OrderByDescending(u => u.Id).FirstOrDefault();
            }
        }

        public List<PropertyUnitModel> GetAllUnits()
        {
            using (var db = new Context())
            {
                return db.PropertyUnits.ToList();
            }
        }

        public void UnitsAddRange(List<PropertyUnitModel> units)
        {
            using (var db = new Context())
            {
                db.PropertyUnits.AddRange(units);
                db.SaveChanges();
            }
        }

        #endregion ProductPropertyValueUnits
    }
}
