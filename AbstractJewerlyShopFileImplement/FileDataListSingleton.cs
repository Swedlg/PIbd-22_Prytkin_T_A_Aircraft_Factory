using AbstractJewelryShopBusinessLogic.Enums;
using AbstractJewerlyShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AbstractJewerlyShopFileImplement
{
    public class FileDataListSingleton
    {

        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string JewelFileName = "Jewel.xml";

        private readonly string WarehouseFileName = "Warehouse.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Jewel> Jewels { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Jewels = LoadJewels();
            Warehouses = LoadWarehouses();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveJewels();
            SaveWarehouses();
        }

        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }

        private List<Jewel> LoadJewels()
        {
            var list = new List<Jewel>();
            if (File.Exists(JewelFileName))
            {
                XDocument xDocument = XDocument.Load(JewelFileName);
                var xElements = xDocument.Root.Elements("Jewel").ToList();
                foreach (var elem in xElements)
                {
                    var jewelComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("JewelComponents").Elements("JewelComponent").ToList())
                    {
                        jewelComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Jewel
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        JewelName = elem.Element("JewelName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        JewelComponents = jewelComp
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        JewelId = Convert.ToInt32(elem.Element("JewelId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToInt32(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }

        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();
            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();
                foreach (var elem in xElements)
                {
                    var warComp = new Dictionary<int, int>();
                    foreach (var component in
                    elem.Element("WarehouseComponents").Elements("WarehouseComponent").ToList())
                    {
                        warComp.Add(Convert.ToInt32(component.Element("Key").Value),
                        Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value,
                        ResponsibleName = elem.Element("ResponsibleName").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        WarehouseComponents = warComp
                    });
                }
            }
            return list;
        }

        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }

        private void SaveJewels()
        {
            if (Jewels != null)
            {
                var xElement = new XElement("Jewels");
                foreach (var jewel in Jewels)
                {
                    var compElement = new XElement("JewelComponents");
                    foreach (var component in jewel.JewelComponents)
                    {
                        compElement.Add(new XElement("JewelComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Jewel",
                    new XAttribute("Id", jewel.Id),
                    new XElement("JewelName", jewel.JewelName),
                    new XElement("Price", jewel.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(JewelFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("JewelId", order.JewelId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveWarehouses()
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");
                foreach (var warehouse in Warehouses)
                {
                    var compElement = new XElement("WarehouseComponents");
                    foreach (var component in warehouse.WarehouseComponents)
                    {
                        compElement.Add(new XElement("WarehouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Warehouse",
                    new XAttribute("Id", warehouse.Id),
                    new XElement("WarehouseName", warehouse.WarehouseName),
                    new XElement("ResponsibleName", warehouse.ResponsibleName),
                    new XElement("DateCreate", warehouse.DateCreate),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }
    }
}
