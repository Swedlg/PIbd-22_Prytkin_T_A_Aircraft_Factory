using AbstractJewelryShopBusinessLogic.Attributes;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления самолета
    /// </summary>
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
