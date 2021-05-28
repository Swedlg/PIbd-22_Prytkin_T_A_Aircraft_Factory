using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Самолет, изготавливаемый на заводе
    /// </summary>
    [DataContract]
    public class JewelViewModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        [DisplayName("Название украшения")]
        public string JewelName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> JewelComponents { get; set; }
    }
}
