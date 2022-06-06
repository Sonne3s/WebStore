using WebStore.Models;

namespace WebStore.Repositories.IRepositories
{
    public interface IPropertyGroupRepository
    {
        PropertyGroupModel Get(int groupId);

        PropertyGroupModel GetLast();

        PropertyGroupModel Create(string name, int valueTypeId, PropertyUnitModel unit, string description);

        PropertyGroupModel Remove(int id);

        PropertyGroupModel Update(int id, string name, int valueTypeId, PropertyUnitModel unit, string description);

        void AddRange(List<PropertyGroupModel> groups);

        List<PropertyGroupModel> GetBase();

        List<PropertyGroupModel> GetAll();

        //List<PropertyGroupModel> GetFromProduct(int productId);
    }
}
