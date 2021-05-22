using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;
using AbstractJewerlyShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractJewerlyShopFileImplement.Implements
{
    public class JewelStorage : IJewelStorage
    {
        private readonly FileDataListSingleton source;

        public JewelStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<JewelViewModel> GetFullList()
        {
            return source.Jewels.Select(CreateModel).ToList();
        }

        public List<JewelViewModel> GetFilteredList(JewelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Jewels
                .Where(rec => rec.JewelName.Contains(model.JewelName))
                .Select(CreateModel)
                .ToList();
        }
        public JewelViewModel GetElement(JewelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var jewel = source.Jewels
                .FirstOrDefault(rec => rec.JewelName == model.JewelName || rec.Id == model.Id);
            return jewel != null ? CreateModel(jewel) : null;
        }
        public void Insert(JewelBindingModel model)
        {

            int maxId = source.Jewels.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Jewel
            {
                Id = maxId + 1,
                JewelComponents = new Dictionary<int, int>()
            };
            source.Jewels.Add(CreateModel(model, element));
        }

        public void Update(JewelBindingModel model)
        {
            var element = source.Jewels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(JewelBindingModel model)
        {
            Jewel element = source.Jewels.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Jewels.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Jewel CreateModel(JewelBindingModel model, Jewel jewel)
        {
            jewel.JewelName = model.JewelName;
            jewel.Price = model.Price;
            // удаляем убранные
            foreach (var key in jewel.JewelComponents.Keys.ToList())
            {
                if (!model.JewelComponents.ContainsKey(key))
                {
                    jewel.JewelComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.JewelComponents)
            {
                if (jewel.JewelComponents.ContainsKey(component.Key))
                {
                    jewel.JewelComponents[component.Key] =
                    model.JewelComponents[component.Key].Item2;
                }
                else
                {
                    jewel.JewelComponents.Add(component.Key, model.JewelComponents[component.Key].Item2);
                }
            }
            return jewel;
        }

        private JewelViewModel CreateModel(Jewel jewel)
        {
            return new JewelViewModel
            {
                Id = jewel.Id,
                JewelName = jewel.JewelName,
                Price = jewel.Price,
                JewelComponents = jewel.JewelComponents.ToDictionary(recPC => recPC.Key, recPC => (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
