
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AbstractJewelryShopBusinessLogic.BusinessLogics;
using AbstractJewelryShopBusinessLogic.ViewModels;
using AbstractJewelryShopBusinessLogic.BindingModels;
using System.Collections.Generic;

namespace AbstractJewerlyShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly JewelLogic _jewel;
        private readonly OrderLogic _main;

        public MainController(OrderLogic order, JewelLogic jewel, OrderLogic main)
        {
            _order = order;
            _jewel = jewel;
            _main = main;
        }
        [HttpGet]
        public List<JewelViewModel> GetJewelList() => _jewel.Read(null)?.ToList();

        [HttpGet]
        public JewelViewModel GetJewel(int jewelId) => _jewel.Read(new JewelBindingModel { Id = jewelId })?[0]; 

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
