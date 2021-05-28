using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;
using AbstractJewerlyShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractJewerlyShopFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses.Select(CreateModel).ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses.Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .Select(CreateModel).ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var warehouse = source.Warehouses
                .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Warehouse
            {
                Id = maxId + 1,
                WarehouseComponents = new Dictionary<int, int>()
            };
            source.Warehouses.Add(CreateModel(model, element));
        }

        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsibleName = model.ResponsibleName;
            warehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] =
                    model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key,
                    model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsibleName = warehouse.ResponsibleName,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents
                    .ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id ==
                    recPC.Key)?.ComponentName, recPC.Value))
            };
        }

        /// <summary>
        /// Проверить достаточно ли компонентов на складе для изготовления украшения
        /// </summary>
        /// <param name="JewelId">ID украшения</param>
        /// <param name="Count">Количество экземпляров украшения</param>
        /// <returns></returns>
        public bool EnoughComponents(int JewelId, int Count)
        {
            //Получаем список всех складов
            var warehouseList = GetFullList();

            //Получаем словарь компонентов выбранного украшения
            var componentDictionary = source.Jewels.FirstOrDefault(rec => rec.Id == JewelId).JewelComponents;
            
            //Количество компонентов умножается на количество изделий экземпляров украшений
            //Получается общее количество определенного компонента в заказе
            componentDictionary = componentDictionary.ToDictionary(rec => rec.Key, rec => rec.Value * Count);


            Dictionary<int, int> Have = new Dictionary<int, int>();

            //Подсчитываем хватит ли на складе компонентов
            foreach (var neededComponent in componentDictionary)
            {
                int neededCount = neededComponent.Value;
                foreach (var warehouse in warehouseList)
                {
                    if (warehouse.WarehouseComponents.ContainsKey(neededComponent.Key))
                    {
                        neededCount -= warehouse.WarehouseComponents[neededComponent.Key].Item2;
                    }
                }
                if (neededCount > 0)
                {
                    //Если не хватает компонентов
                    return false;
                }
            }

            //Вычитаем компоненты со склада
            foreach (var neededComponent in componentDictionary)
            {
                int neededCount = neededComponent.Value;
                foreach (var warehouse in warehouseList)
                {
                    if (warehouse.WarehouseComponents.ContainsKey(neededComponent.Key))
                    {
                        //Если на складе точно не хватит компонентов 
                        if (neededCount >= warehouse.WarehouseComponents[neededComponent.Key].Item2)
                        {
                            neededCount -= warehouse.WarehouseComponents[neededComponent.Key].Item2;
                            warehouse.WarehouseComponents.Remove(neededComponent.Key);
                        }
                        else
                        {
                            warehouse.WarehouseComponents[neededComponent.Key] = (warehouse.WarehouseComponents[neededComponent.Key].Item1, warehouse.WarehouseComponents[neededComponent.Key].Item2 - neededCount);
                        }
                    }
                    //Обновляем склад
                    Update(new WarehouseBindingModel
                    {
                        Id = warehouse.Id,
                        WarehouseName = warehouse.WarehouseName,
                        ResponsibleName = warehouse.ResponsibleName,
                        DateCreate = warehouse.DateCreate,
                        WarehouseComponents = warehouse.WarehouseComponents
                    });
                }
            }

            return true;
        }
    }
}
