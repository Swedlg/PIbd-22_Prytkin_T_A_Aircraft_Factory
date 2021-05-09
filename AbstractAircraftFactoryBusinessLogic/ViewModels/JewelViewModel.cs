using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Самолет, изготавливаемый на заводе
    /// </summary>
    public class JewelViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название украшения")]
        public string JewelName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> JewelComponents { get; set; }
    }
}
