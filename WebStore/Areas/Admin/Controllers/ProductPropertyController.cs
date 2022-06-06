using Microsoft.AspNetCore.Mvc;
using WebStore.Areas.Admin.Fillers.IFillers;
using WebStore.Areas.Admin.Handlers.IHandlers;
using WebStore.Areas.Admin.ViewModels.ProductProperty;

namespace WebStore.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ProductPropertyController : Controller
    {
        IProductPropertyHandler _handler;
        IProductPropertyFiller _filler;

        public ProductPropertyController(IProductPropertyHandler handler, IProductPropertyFiller filler)
        {
            _handler = handler;
            _filler = filler;
        }

        public IActionResult TypeSelection(int componentIndex, int propertyIndex, int? groupId)
            => PartialView(_filler.GetFilledTypeSelectionViewModel(componentIndex, propertyIndex, _handler.GetGroups(), groupId));

        public IActionResult Input(int groupId, int componentIndex, int propertyIndex)
            => PartialView(_filler.GetFilledInputViewModel(_handler.GetGroup(groupId), componentIndex, propertyIndex, false));

        public IActionResult TextItem(string value, string nameAttribute, string placeholder, string disabled)
            => View("Input/TextItem", (value, nameAttribute, placeholder, disabled));

        public IActionResult IntegerItem(string value, string unitValue, string nameAttribute, string placeholder, string disabled)
            => View("Input/IntegerItem", (value, unitValue, nameAttribute, placeholder, disabled));

        public IActionResult DecimalItem(string value, string unitValue, string nameAttribute, string placeholder, string disabled)
            => View("Input/DecimalItem", (value, unitValue, nameAttribute, placeholder, disabled));

        public IActionResult AddButton(int groupId, int componentIndex, int propertyIndex)
            => PartialView(_filler.GetFilledAddButtonViewModel(componentIndex, propertyIndex+1, groupId));

        public IActionResult Container(string newName, int newIndex) 
            => View(_filler.GetFilledContainerViewModel(newIndex, newName, false, new List<InputViewModel>()));

        [HttpGet]
        public IActionResult CreationPageCreate(int componentIndex, int propertyIndex)
            => PartialView(nameof(CreationPage), _filler.GetFilledCreationPageViewModel(componentIndex, propertyIndex, null, _handler.GetPropertyValueUnits()));

        [HttpGet]
        public IActionResult CreationPageEdit(int componentIndex, int propertyIndex, int? groupId)
            => PartialView(nameof(CreationPage), _filler.GetFilledCreationPageViewModel(componentIndex, propertyIndex, _handler.GetGroup(groupId), _handler.GetPropertyValueUnits()));

        [HttpPost]
        public IActionResult CreationPage(CreationPageViewModel model)
            => RedirectToAction(
                nameof(TypeSelection), new { ComponentIndex = model.ComponentIndex, PropertyIndex = model.PropertyIndex, GroupId = _handler.CreateOrUpdateGroup(model) });

        public IActionResult UnitSelection(int? id, int? groupId, int? typeId)
            => PartialView(_filler.GetFilledCreationPageViewModel(null, null, groupId, null, null, typeId, null, id, _handler.GetPropertyValueUnits()));

        public IActionResult Delete(int componentIndex, int propertyIndex, int id)
            => RedirectToAction(nameof(TypeSelection), new { ComponentIndex = componentIndex, PropertyIndex = propertyIndex, GroupId = _handler.DeleteGroup(id) });

        [HttpGet]
        public IActionResult UnitCreationPage(int? unitId, int? Id, int? typeId)
            => PartialView(_filler.GetFilledUnitCreationPageViewModel(_handler.GetPropertyValueUnit(unitId), Id, typeId));

        [HttpPost]
        public IActionResult UnitCreationPage(UnitCreationPageViewModel viewModel, int? groupId, int? typeId)
            => RedirectToAction(nameof(UnitSelection), new { Id = _handler.CreateOrUpdatePropertyValueUnit(viewModel.Id, viewModel.Name).Id, GroupId = groupId, TypeId = typeId });

        public IActionResult DeleteUnit(int id, int? groupId, int? typeId)
            => RedirectToAction(nameof(UnitSelection), new { Id = _handler.DeletePropertyValueUnit(id), GroupId = groupId, TypeId = typeId });
    }
}
