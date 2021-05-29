using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.Interfaces
{
    public interface IImplementerStorage
    {
        List<ImplementerViewModel> GetFullList();

        List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model);

        ImplementerViewModel GetElement(ImplementerBindingModel model);

        void Insert(ImplementerBindingModel model);

        void Update(ImplementerBindingModel model);

        void Delete(ImplementerBindingModel model);
    }
}
