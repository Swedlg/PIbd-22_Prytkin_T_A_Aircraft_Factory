using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractJewelryShopBusinessLogic.Attributes;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Самолет, изготавливаемый на заводе
    /// </summary>
    [DataContract]
    public class JewelViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int? Id { get; set; }

        [DataMember]
        [Column(title: "Название украшения", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string JewelName { get; set; }

        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> JewelComponents { get; set; }
    }
}
