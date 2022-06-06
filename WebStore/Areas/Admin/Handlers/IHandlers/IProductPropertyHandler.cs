using WebStore.Areas.Admin.ViewModels.ProductProperty;
using WebStore.Models;

namespace WebStore.Areas.Admin.Handlers.IHandlers
{
    public interface IProductPropertyHandler
    {
        List<PropertyGroupModel> GetGroups();

        PropertyGroupModel GetGroup(int? id);

        int CreateOrUpdateGroup(CreationPageViewModel viewModel);

        int DeleteGroup(int id);

        PropertyUnitModel GetPropertyValueUnit(int? id);

        PropertyUnitModel CreateOrUpdatePropertyValueUnit(int? id, string value);

        int DeletePropertyValueUnit(int id);

        List<PropertyUnitModel> GetPropertyValueUnits();
    }
}
