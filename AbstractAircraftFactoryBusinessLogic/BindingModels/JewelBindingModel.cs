using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Самолет, изготавливаемый на заводе
    /// </summary>
    public class JewelBindingModel
    {
        public int? Id { get; set; }

        public string JewelName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> JewelComponents { get; set; }
    }
}
