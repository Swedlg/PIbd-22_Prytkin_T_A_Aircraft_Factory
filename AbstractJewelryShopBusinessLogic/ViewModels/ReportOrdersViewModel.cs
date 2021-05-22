using AbstractJewelryShopBusinessLogic.Enums;
using System;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }

        public string JewelName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }
    }
}
