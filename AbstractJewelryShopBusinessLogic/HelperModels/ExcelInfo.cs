using AbstractJewelryShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportJewelComponentViewModel> JewelComponents { get; set; }
    }
}
