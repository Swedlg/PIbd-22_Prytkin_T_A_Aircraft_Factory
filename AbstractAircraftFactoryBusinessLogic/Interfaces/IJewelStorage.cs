using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.Interfaces
{
    public interface IJewelStorage
    {
        List<JewelViewModel> GetFullList();

        List<JewelViewModel> GetFilteredList(JewelBindingModel model);

        JewelViewModel GetElement(JewelBindingModel model);

        void Insert(JewelBindingModel model);

        void Update(JewelBindingModel model);

        void Delete(JewelBindingModel model);
    }
}
