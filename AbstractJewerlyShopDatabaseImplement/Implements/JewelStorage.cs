using System;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;
using AbstractJewelryShopBusinessLogic.BindingModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AbstractJewerlyShopDatabaseImplement.Models;

namespace AbstractJewerlyShopDatabaseImplement.Implements
{
    public class JewelStorage : IJewelStorage
    {
        public List<JewelViewModel> GetFullList()
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                return context.Jewels
                .Include(rec => rec.JewelComponent)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new JewelViewModel
                {
                    Id = rec.Id,
                    JewelName = rec.JewelName,
                    Price = rec.Price,
                    JewelComponents = rec.JewelComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public List<JewelViewModel> GetFilteredList(JewelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractJewerlyShopDatabase())
            {
                return context.Jewels
                .Include(rec => rec.JewelComponent)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.JewelName.Contains(model.JewelName))
                .ToList()
                .Select(rec => new JewelViewModel
                {
                    Id = rec.Id,
                    JewelName = rec.JewelName,
                    Price = rec.Price,
                    JewelComponents = rec.JewelComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }

        public JewelViewModel GetElement(JewelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractJewerlyShopDatabase())
            {
                var jewel = context.Jewels
                    .Include(rec => rec.JewelComponent)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.JewelName.Equals(model.JewelName) ||
                        rec.Id == model.Id);

                return jewel != null ?
                    new JewelViewModel
                    {
                        Id = jewel.Id,
                        JewelName = jewel.JewelName,
                        Price = jewel.Price,
                        JewelComponents = jewel.JewelComponent
                            .ToDictionary(recPC => recPC.ComponentId, recPC =>
                            (recPC.Component?.ComponentName, recPC.Count))
                    } : null;
            }
        }

        public void Insert(JewelBindingModel model)
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Jewel jewel = CreateModel(model, new Jewel());
                        context.Jewels.Add(jewel);
                        context.SaveChanges();

                        //Вызываем для заполнения таблицы Компонент_Украшения (т.к. раньше id украшения было неизвестно)
                        CreateModel(model, jewel, context);
                        transaction.Commit();     
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(JewelBindingModel model)
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Jewels.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(JewelBindingModel model)
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                Jewel element = context.Jewels.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Jewels.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Jewel CreateModel(JewelBindingModel model, Jewel jewel)
        {
            jewel.JewelName = model.JewelName;
            jewel.Price = model.Price;
            return jewel;
        }

        private Jewel CreateModel(JewelBindingModel model, Jewel jewel, AbstractJewerlyShopDatabase context)
        {
            //Названия не могут повторяться поэтому ID достаем всегда нужный
            jewel.Id = context.Jewels.FirstOrDefault(r => r.JewelName == model.JewelName).Id;

            jewel.JewelName = model.JewelName;
            jewel.Price = model.Price;

            if (model.Id.HasValue)
            {
                var jewelComponents = context.JewelComponents.Where(rec => rec.JewelId == model.Id.Value).ToList();

                // удалили те, которых нет в модели
                context.JewelComponents.RemoveRange(jewelComponents
                    .Where(rec => !model.JewelComponents
                    .ContainsKey(rec.ComponentId))
                    .ToList());

                context.SaveChanges();

                // обновили количество у существующих записей

                foreach (var updateComponent in jewelComponents)
                {
                    updateComponent.Count = model.JewelComponents[updateComponent.ComponentId].Item2;
                    model.JewelComponents.Remove(updateComponent.ComponentId);
                }

                context.SaveChanges(); 
            }

            // добавили новые
            foreach (var component in model.JewelComponents)
            {

                context.JewelComponents.Add(new JewelComponent
                {
                    JewelId = (int)jewel.Id,
                    ComponentId = component.Key,
                    Count = component.Value.Item2
                });
                context.SaveChanges();
            }       

            return jewel;
        }
    }
}
