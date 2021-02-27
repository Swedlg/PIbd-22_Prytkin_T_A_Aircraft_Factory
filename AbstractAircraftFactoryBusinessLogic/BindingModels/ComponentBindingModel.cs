using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractAircraftFactoryBusinessLogic.BindingModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления самолета
    /// </summary>
    public class ComponentBindingModel
    {
        public int? Id { get; set; }

        public string ComponentName { get; set; }
    }
}
