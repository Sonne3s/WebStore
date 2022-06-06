using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.ViewModels.ProductProperty;
using WebStore.Models;

namespace WebStore.Areas.Admin.Fillers.IFillers
{
    public interface IProductPropertyFiller
    {
        TypeSelectionViewModel GetFilledTypeSelectionViewModel(
            int componentIndex, int propertyIndex, List<PropertyGroupModel> propertyGroups, int? selectedPropertyId = null);

        InputViewModel GetFilledInputViewModel(
            PropertyGroupModel group, int ComponentIndex, int PropertyIndex, bool HasDisabled);

        List<PropertyViewModel> GetFilledPropertyViewModels(List<PropertyModel> properties);

        ContainerViewModel GetFilledContainerViewModel(
            int index, string name, bool isActive, List<InputViewModel> properties);

        List<ContainerViewModel> GetFilledContainerViewModels(List<ComponentModel> components);

        AddButtonViewModel GetFilledAddButtonViewModel(int componentIndex, int propertyIndex, int? groupId = null);

        CreationPageViewModel GetFilledCreationPageViewModel(int componentIndex, int propertyIndex, PropertyGroupModel group, List<PropertyUnitModel> units);

        CreationPageViewModel GetFilledCreationPageViewModel(
            int? componentIndex, int? propertyIndex, int? groupId, string groupName, string groupDescription, int? typeId, List<SelectListItem> types, int? unitId, List<PropertyUnitModel> units);

        CreationPageViewModel GetFilledCreationPageViewModel(
            int? componentIndex, int? propertyIndex, int? groupId, string groupName, string groupDescription, int? typeId, List<SelectListItem> types, int? unitId, List<SelectListItem> units);

        UnitCreationPageViewModel GetFilledUnitCreationPageViewModel(PropertyUnitModel unit, int? groupId, int? typeId);
    }
}
