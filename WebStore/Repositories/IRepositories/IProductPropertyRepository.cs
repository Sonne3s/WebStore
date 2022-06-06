using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories.IRepositories
{
    public interface IProductPropertyRepository
    {
        IEnumerable<IGrouping<PropertyGroupModel, PropertyValueModel>> GetForFilterAll();

        List<PropertyModel> GetAll();

        void AddRange(List<PropertyModel> properties);

        List<PropertyValueModel> GetAllPropertyValues();

        List<(PropertyGroupModel Group, PropertyTypeEnumeration TypeId, List<PropertyTextValueModel> Values)> GetTextPropertiesForFilter();

        List<(PropertyGroupModel Group, PropertyTypeEnumeration TypeId, List<PropertyIntegerValueModel> Values)> GetIntegerPropertiesForFilter();

        List<(PropertyGroupModel Group, PropertyTypeEnumeration TypeId, List<PropertyDecimalValueModel> Values)> GetDecimalPropertiesForFilter();

        void PropertyValuesAddRange(List<PropertyValueModel> values);

        PropertyUnitModel CreatePropertyValueUnit(string name);

        PropertyUnitModel RemovePropertyValueUnit(int id);

        PropertyUnitModel UpdatePropertyValueUnit(int id, string value);

        void UnitsAddRange(List<PropertyUnitModel> units);

        List<PropertyUnitModel> GetAllUnits();

        PropertyUnitModel GetPropertyValueUnit(int? id);

        PropertyUnitModel GetLastPropertyValueUnit();
    }
}
