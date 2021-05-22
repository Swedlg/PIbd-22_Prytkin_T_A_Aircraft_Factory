using System.ComponentModel.DataAnnotations;

namespace AbstractJewerlyShopDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении erhfitybz
    /// </summary>
    public class JewelComponent
    {
        public int Id { get; set; }

        public int JewelId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual Jewel Jewel { get; set; }
    }
}
