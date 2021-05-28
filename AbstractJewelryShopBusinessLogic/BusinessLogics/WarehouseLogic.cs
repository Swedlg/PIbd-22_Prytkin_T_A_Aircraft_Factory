using System;
using System.Collections.Generic;
using System.Text;
using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.Enums;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;

namespace AbstractJewelryShopBusinessLogic.BusinessLogics
{
    public class WarehouseLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;

        private readonly IComponentStorage _componentStorage;

        public WarehouseLogic(IWarehouseStorage warehouseStorage, IComponentStorage componentStorage)
        {
            _warehouseStorage = warehouseStorage;
            _componentStorage = componentStorage;
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return _warehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { _warehouseStorage.GetElement(model) };
            }
            return _warehouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                WarehouseName = model.WarehouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _warehouseStorage.Update(model);
            }
            else
            {
                _warehouseStorage.Insert(model);
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _warehouseStorage.Delete(model);
        }

        public void Restocking(WarehouseBindingModel model, int WarehouseId, int ComponentId, int Count)
        {
            WarehouseViewModel warehouse = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                Id = WarehouseId
            });

            ComponentViewModel component = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = ComponentId
            });

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }

            Dictionary<int, (string, int)> warehouseComponents = warehouse.WarehouseComponents;

            if (warehouseComponents.ContainsKey(ComponentId))
            {
                int count = warehouseComponents[ComponentId].Item2;
                warehouseComponents[ComponentId] = (component.ComponentName, count + Count);
            }
            else
            {
                warehouseComponents.Add(ComponentId, (component.ComponentName, Count));
            }

            _warehouseStorage.Update(new WarehouseBindingModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleName = warehouse.ResponsibleName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            });
        }
    }
}
