using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.Interfaces;
using AbstractJewelryShopBusinessLogic.ViewModels;
using AbstractJewerlyShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AbstractJewerlyShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Jewel)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        JewelName = rec.Jewel.JewelName,
                        JewelId = rec.JewelId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                    })
                    .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractJewerlyShopDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Jewel)
                    .Where(rec =>
                        model.DateFrom.HasValue && model.DateTo.HasValue &&
                        rec.DateCreate.Date >= model.DateFrom.Value.Date &&
                        rec.DateCreate.Date <= model.DateTo.Value.Date)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        JewelName = rec.Jewel.JewelName,
                        JewelId = rec.JewelId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
                })
                .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractJewerlyShopDatabase())
            {
                var order = context.Orders
                    .Include(rec => rec.Jewel)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                    return order != null ?
                    new OrderViewModel
                        {
                        Id = order.Id,
                        JewelName = order.Jewel.JewelName,
                        JewelId = order.JewelId,
                        Count = order.Count,
                        Sum = order.Sum,
                        Status = order.Status,
                        DateCreate = order.DateCreate,
                        DateImplement = order.DateImplement
                    } : null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractJewerlyShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.JewelId = model.JewelId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
