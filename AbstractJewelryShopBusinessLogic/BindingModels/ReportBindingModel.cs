using System;

namespace AbstractJewelryShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Отчет
    /// </summary>
    public class ReportBindingModel
    {
        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
