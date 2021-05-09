using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.BusinessLogics
{
    public class JewelLogic
    {
        private readonly IJewelStorage _jewelStorage;

        public JewelLogic(IJewelStorage jewelStorage)
        {
            _jewelStorage = jewelStorage;
        }

        public List<JewelViewModel> Read(JewelBindingModel model)
        {
            if (model == null)
            {
                return _jewelStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<JewelViewModel> { _jewelStorage.GetElement(model) };
            }
            return _jewelStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(JewelBindingModel model)
        {
            var jewel = _jewelStorage.GetElement(new JewelBindingModel
            {
                Id = model.Id,
                JewelName = model.JewelName,
                Price = model.Price,
                JewelComponents = model.JewelComponents,
            });
            if (jewel != null && jewel.Id != model.Id)
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

        public void Delete(JewelBindingModel model)
        {
            var jewel = _jewelStorage.GetElement(new JewelBindingModel {
                Id = model.Id,
                JewelName = model.JewelName,
                Price = model.Price,
                JewelComponents = model.JewelComponents,
            });
            if (jewel == null)
            {
                throw new Exception("Украшение не найдено");
            }
            _jewelStorage.Delete(model);
        }
    }
}
