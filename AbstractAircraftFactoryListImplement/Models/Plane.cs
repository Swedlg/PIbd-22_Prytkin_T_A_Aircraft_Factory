using System.Collections.Generic;

namespace AbstractAircraftFactoryListImplement.Models
{
    /// <summary>
    /// Самолет, изготавливаемый на заводе
    /// </summary>
    public class Plane
    {
        public int Id { get; set; }

        public string PlaneName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> PlaneComponents { get; set; }
    }
}
