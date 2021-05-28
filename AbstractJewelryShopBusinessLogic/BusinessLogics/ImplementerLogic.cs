using System;
using System.Collections.Generic;
using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;

namespace AbstractJewelryShopBusinessLogic.BusinessLogics
{
    public class ImplementerLogic
    {
        private readonly IImplementerStorage _implementerStorage;

        public ImplementerLogic(IImplementerStorage implementerStorage)
        {
            _implementerStorage = implementerStorage;
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return _implementerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ImplementerViewModel> { _implementerStorage.GetElement(model) };
            }
            return _implementerStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            var implementer = _jewelStorage.GetElement(new JewelBindingModel
            {
                Id = model.Id,
                JewelName = model.JewelName,
                Price = model.Price,
                JewelComponents = model.JewelComponents,
            });
            if (implementer != null && implementer.Id != model.Id)
            {
                throw new Exception("Уже есть украшение с таким названием");
            }
            if (model.Id.HasValue)
            {
                _jewelStorage.Update(model);
            }
            else
            {
                _jewelStorage.Insert(model);
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            var element = _implementerStorage.GetElement(new ImplementerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            _implementerStorage.Delete(model);
        }
    }
}
