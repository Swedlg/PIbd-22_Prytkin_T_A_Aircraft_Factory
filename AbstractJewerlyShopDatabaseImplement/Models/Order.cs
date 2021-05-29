using AbstractJewelryShopBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbstractJewerlyShopDatabaseImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }

        public int JewelId { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Jewel Jewel { get; set; }

        public virtual Client Client { get; set; }

        public virtual Implementer Implementer { get; set; }
    }
}
