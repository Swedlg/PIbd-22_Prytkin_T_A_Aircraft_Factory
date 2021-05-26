using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using System.Linq;
using AbstractJewelryShopBusinessLogic.ViewModels;
using AbstractJewelryShopBusinessLogic.BusinessLogics;
using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopListImplement;
using AbstractJewelryShopListImplement.Models;
using AbstractJewelryShopListImplement.Implements;

namespace AbstractJewelryShopView
{
    public partial class FormWarehouseReplenishment : Form
    {

        WarehouseLogic _warehouseLogic;

        public int ComponentId
        {
            get { return Convert.ToInt32(comboBoxComponent.SelectedValue); }
            set { comboBoxComponent.SelectedValue = value; }
        }

        public int WarehouseId
        {
            get { return Convert.ToInt32(comboBoxWarehouse.SelectedValue); }
            set { comboBoxWarehouse.SelectedValue = value; }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormWarehouseReplenishment(ComponentLogic componentlogic, WarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            _warehouseLogic = warehouseLogic;
            List<ComponentViewModel> listComponent = componentlogic.Read(null);
            if (listComponent != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = listComponent;
                comboBoxComponent.SelectedItem = null;
            }

            List<WarehouseViewModel> listWarehouse = _warehouseLogic.Read(null);
            if (listWarehouse != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = listWarehouse;
                comboBoxWarehouse.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            _warehouseLogic.Restocking(new WarehouseBindingModel
            {
                Id = WarehouseId
            }, WarehouseId, ComponentId, Count);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
