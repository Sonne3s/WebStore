using Microsoft.AspNetCore.Mvc.Rendering;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.ViewModels.ProductProperty;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Admin.Fillers
{
    public class ProductPropertyFiller : IProductPropertyFiller
    {
        IHelperProvider _helper;

        public ProductPropertyFiller(IHelperProvider helper)
        {
            _helper = helper;
        }

        public TypeSelectionViewModel GetFilledTypeSelectionViewModel(
            int componentIndex, int propertyIndex, List<PropertyGroupModel> propertyGroups, int? selectedPropertyId = null)
            => new TypeSelectionViewModel(componentIndex, propertyIndex, GetFilledSelectListItems(
                propertyGroups, selectedPropertyId));

        public InputViewModel GetFilledInputViewModel(
            PropertyGroupModel group, int ComponentIndex, int PropertyIndex, bool HasDisabled)
            => new InputViewModel(
                this.GetFilledPropertyViewModel(group), ComponentIndex, PropertyIndex, HasDisabled);

        private PropertyViewModel GetFilledPropertyViewModel(PropertyGroupModel group)
            => new PropertyViewModel(
                (PropertyTypeEnumeration)group.TypeId, 
                group.Id, 
                group.Name, 
                new List<string>(), 
                group.UnitType?.Id, 
                group.UnitType?.Value);

        private PropertyViewModel GetFilledPropertyViewModel(PropertyModel property)
            => new PropertyViewModel(
                (PropertyTypeEnumeration)property.Group.TypeId, 
                property.GroupId,
                property.Group.Name,
                _helper.Properties.ExtractPropertyValuesSeparate(property),
                property.Group.UnitType?.Id,
                property.Group.UnitType?.Value);

        public List<PropertyViewModel> GetFilledPropertyViewModels(List<PropertyModel> properties)
            => properties.Select(p => this.GetFilledPropertyViewModel(p)).ToList();

        private List<InputViewModel> GetFilledInputViewModels(
            List<PropertyModel> properties, int componentIndex, bool hasDisabled)
            => properties.Select(p => this.GetFilledInputViewModel(
                p, componentIndex, properties.IndexOf(p), hasDisabled))
            .ToList();

        private InputViewModel GetFilledInputViewModel(
            PropertyModel property, int componentIndex, int propertyIndex, bool hasDisabled) 
            => new InputViewModel(
                    this.GetFilledPropertyViewModel(property), componentIndex, propertyIndex, hasDisabled);

        public ContainerViewModel GetFilledContainerViewModel(
            int index, string name, bool isActive, List<InputViewModel> properties)
            => new ContainerViewModel(
                index, name, isActive, this.GetFilledAddButtonViewModel(index, properties.Count), properties);

        public List<ContainerViewModel> GetFilledContainerViewModels(List<ComponentModel> components)
            => components.Select(c
                => this.GetFilledContainerViewModel(
                    components.IndexOf(c), 
                    c.Name, components.IndexOf(c) == 0, 
                    this.GetFilledInputViewModels(c.Properties, components.IndexOf(c), false)))
            .ToList();

        public AddButtonViewModel GetFilledAddButtonViewModel(int componentIndex, int propertyIndex, int? groupId = null)
            => new AddButtonViewModel(componentIndex, propertyIndex, groupId);

        public CreationPageViewModel GetFilledCreationPageViewModel(int componentIndex, int propertyIndex, PropertyGroupModel group, List<PropertyUnitModel> units)
            => this.GetFilledCreationPageViewModel(
                componentIndex,
                propertyIndex,
                group?.Id,
                group?.Name,
                group?.Description,
                group?.TypeId,
                this.GetFilledSelectListItems(_helper.Product.GetValueTypes(), group?.TypeId),
                group?.UnitTypeId,
                this.GetFilledSelectListItems(units, group?.UnitTypeId));

        public CreationPageViewModel GetFilledCreationPageViewModel(
            int? componentIndex, int? propertyIndex, int? groupId, string groupName, string groupDescription, int? typeId, List<SelectListItem> types, int? unitId, List<PropertyUnitModel> units)
            => new CreationPageViewModel(componentIndex, propertyIndex, groupId, groupName, groupDescription, typeId, types, unitId, this.GetFilledSelectListItems(units, unitId));

        public CreationPageViewModel GetFilledCreationPageViewModel(
            int? componentIndex, int? propertyIndex, int? groupId, string groupName, string groupDescription, int? typeId, List<SelectListItem> types, int? unitId, List<SelectListItem> units)
            => new CreationPageViewModel(componentIndex, propertyIndex, groupId, groupName, groupDescription, typeId, types, unitId, units);

        public UnitCreationPageViewModel GetFilledUnitCreationPageViewModel(PropertyUnitModel unit, int? groupId, int? typeId)
            => new UnitCreationPageViewModel(unit?.Id, unit?.Value, groupId, typeId);

        private List<SelectListItem> GetFilledSelectListItems(List<PropertyUnitModel> units, int? selectedId)
            => this.GetFilledSelectListItems(units.Select(u => (u.Value, u.Id, units.IndexOf(u))), units.Count, selectedId);

        private List<SelectListItem> GetFilledSelectListItems(List<PropertyTypeEnumeration> propertyTypes, int? selectedId)
            => this.GetFilledSelectListItems(
                propertyTypes.Select(p => 
                    (_helper.Product.GetValueTypeText((int)p), (int)p, propertyTypes.IndexOf(p))), 
                    propertyTypes.Count, 
                    selectedId);

        private List<SelectListItem> GetFilledSelectListItems(List<PropertyGroupModel> propertyGroups, int? selectedId)
            => this.GetFilledSelectListItems(
                propertyGroups.Select(g => (g.Name, g.Id, propertyGroups.IndexOf(g))), propertyGroups.Count, selectedId);

        private List<SelectListItem> GetFilledSelectListItems(
            IEnumerable<(string ItemText, int ItemValue, int ItemIndex)> items, int count, int? selectedItemId) 
            => items.Select(i => this.GetFilledSelectListItem(i.ItemText, i.ItemValue, i.ItemIndex, count, selectedItemId))
                .Prepend(new SelectListItem()) //add empty value
                .ToList();

        private SelectListItem GetFilledSelectListItem(
            string itemText, int itemValue, int itemIndex, int listCount, int? selectedId)
            => new SelectListItem(
                itemText, 
                itemValue.ToString(), 
                selectedId.HasValue 
                    ? selectedId != -1 
                        ? itemValue == selectedId 
                        : (itemIndex + 1) == listCount //set last selected
                    : false);
    }
}