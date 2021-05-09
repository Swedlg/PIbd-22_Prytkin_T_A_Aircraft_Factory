using System.Collections.Generic;

namespace AbstractJewelryShopListImplement.Models
{
    /// <summary>
    /// Украшение
    /// </summary>
    public class Jewel
    {
        public int Id { get; set; }

        public string JewelName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> JewelComponents { get; set; }
    }
}
