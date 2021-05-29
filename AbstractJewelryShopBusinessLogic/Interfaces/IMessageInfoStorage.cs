using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractJewelryShopBusinessLogic.Interfaces
{
    interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);

        void Insert(MessageInfoBindingModel model);
    }
}
