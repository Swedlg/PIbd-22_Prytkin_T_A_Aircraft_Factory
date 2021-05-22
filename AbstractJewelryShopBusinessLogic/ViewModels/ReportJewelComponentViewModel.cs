using System;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Отчет по компонентам
    /// </summary>
    public class ReportJewelComponentViewModel
    {
        public string JewelName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
    }
}
