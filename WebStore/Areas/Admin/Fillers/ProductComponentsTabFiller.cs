using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.ViewModels;
using WebStore.Areas.Admin.ViewModels.Components;
using WebStore.Helpers.IHelpers;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Areas.Admin.Fillers
{
    public class ProductComponentsTabFiller : IProductComponentsTabFiller
    {
        IHelperProvider _helper;
        IProductComponentFiller _componentFiller;
        IProductPropertyFiller _propertyFiller;

        public ProductComponentsTabFiller(
            IHelperProvider helper, IProductComponentFiller componentFiller, IProductPropertyFiller propertyFiller)
        {
            _helper = helper;
            _componentFiller = componentFiller;
            _propertyFiller = propertyFiller;
        }

        public ComponentsTabViewModel GetFilledComponentViewModels(
            int productId, List<ComponentModel> components, int newComponentIndex = 0)
            => new ComponentsTabViewModel(
                productId, 
                newComponentIndex,
                _componentFiller.GetFilledContainerViewModel(productId, components, newComponentIndex),
                _propertyFiller.GetFilledContainerViewModels(components));

        public ComponentViewModel GetFilledComponentViewModel(int counter, string name)
            => new ComponentViewModel(counter, name, counter == 0);

        private List<PropertyViewModel> GetFilledPropertyViewModels(List<PropertyModel> properties)
        {
            return properties.Select(p => new PropertyViewModel
            (
                (PropertyTypeEnumeration)p.Group.TypeId,
                p.GroupId,
                p.Group.Name,
                _helper.Properties.ExtractPropertyValuesSeparate(p),
                p.Group.UnitType?.Value
            )).ToList();
        }
    }
}
