using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels.ProductProperty;
using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Areas.Admin.Handlers
{
    public class ProductPropertyHandler : IProductPropertyHandler
    {
        private IPropertyGroupRepository _groupRepository;
        private IProductPropertyRepository _propertyRepository;

        public ProductPropertyHandler(IPropertyGroupRepository groupRepository, IProductPropertyRepository propertyRepository)
        {
            _groupRepository = groupRepository;
            _propertyRepository = propertyRepository;
        }

        public List<PropertyGroupModel> GetGroups()
        {
            return _groupRepository.GetAll();
        }

        public PropertyGroupModel GetGroup(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            if (id == -1)
            {
                return _groupRepository.GetLast();
            }

            return _groupRepository.Get(id.Value);
        }

        public int CreateOrUpdateGroup(CreationPageViewModel viewModel)
        {            
            var unit = _propertyRepository.GetPropertyValueUnit(viewModel.UnitId);
            if (viewModel.Id.HasValue && viewModel.Id != -1)
            {
                return _groupRepository.Update(viewModel.Id.Value, viewModel.Name, viewModel.TypeId.Value, unit, viewModel.Description).Id;
            }
            else
            {
                return _groupRepository.Create(viewModel.Name, viewModel.TypeId.Value, unit, viewModel.Description).Id;
            }
        }

        public int DeleteGroup(int id)
        {
            return _groupRepository.Remove(id).Id;
        }

        public PropertyUnitModel GetPropertyValueUnit(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            if (id == -1)
            {
                return _propertyRepository.GetLastPropertyValueUnit();
            }

            return _propertyRepository.GetPropertyValueUnit(id.Value);
        }

        public PropertyUnitModel CreateOrUpdatePropertyValueUnit(int? id, string value)
        {
            if (id.HasValue)
            {
                return _propertyRepository.UpdatePropertyValueUnit(id.Value, value);
            }
            else
            {
                return _propertyRepository.CreatePropertyValueUnit(value);
            }
        }

        public int DeletePropertyValueUnit(int id)
        {
            return _propertyRepository.RemovePropertyValueUnit(id).Id;
        }

        public List<PropertyUnitModel> GetPropertyValueUnits()
        {
            return _propertyRepository.GetAllUnits();
        }
    }
}
