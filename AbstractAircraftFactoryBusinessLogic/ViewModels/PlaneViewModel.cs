using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractAircraftFactoryBusinessLogic.ViewModels
{
    /// <summary>
    /// Самолет, изготавливаемый на заводе
    /// </summary>
    public class PlaneViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название самолета")]
        public string PlaneName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> PlaneComponents { get; set; }
    }
}
