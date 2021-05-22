using AbstractJewelryShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<JewelViewModel> Jewels { get; set; }
    }
}
