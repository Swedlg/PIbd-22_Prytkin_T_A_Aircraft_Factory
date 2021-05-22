using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractJewerlyShopDatabaseImplement.Models
{
    /// <summary>
    /// Украшение
    /// </summary>
    public class Jewel
    {
        public int? Id { get; set; }

        [Required]
        public string JewelName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("JewelId")]
        public virtual List<JewelComponent> JewelComponent { get; set; }

        [ForeignKey("JewelId")]
        public virtual List<Order> Order { get; set; }
    }
}
