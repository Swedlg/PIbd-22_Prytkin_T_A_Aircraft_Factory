using AbstractJewelryShopBusinessLogic.BindingModels;
using AbstractJewelryShopBusinessLogic.BusinessLogics;
using AbstractJewelryShopBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractJewelryShopView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly JewelLogic _jewelLogic;

        private readonly OrderLogic _orderLogic;

        public FormCreateOrder(JewelLogic jewelLogic, OrderLogic orderLogic)
        {
            InitializeComponent();
            _jewelLogic = jewelLogic;
            _orderLogic = orderLogic;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listOfJewels = _jewelLogic.Read(null);
                if (listOfJewels != null)
                {
                    comboBoxJewel.DataSource = listOfJewels;
                    comboBoxJewel.DisplayMember = "JewelName";
                    comboBoxJewel.ValueMember = "Id";
                    comboBoxJewel.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxJewel.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxJewel.SelectedValue);
                    JewelViewModel jewel = _jewelLogic.Read(new JewelBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * jewel?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxJewel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxJewel.SelectedValue == null)
            {
                MessageBox.Show("Выберите украшение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _orderLogic.CreateOrder(new CreateOrderBindingModel
                {
                    JewelId = Convert.ToInt32(comboBoxJewel.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
