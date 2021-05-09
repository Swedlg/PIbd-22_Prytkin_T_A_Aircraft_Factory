using System.ComponentModel;

namespace AbstractJewelryShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления самолета
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
