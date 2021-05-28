using System;
using System.Collections.Generic;
using System.Text;
using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.ViewModels;

namespace AbstractJewelryShopBusinessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();

        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);

        WarehouseViewModel GetElement(WarehouseBindingModel model);

        void Insert(WarehouseBindingModel model);

        void Update(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);
    }
}
