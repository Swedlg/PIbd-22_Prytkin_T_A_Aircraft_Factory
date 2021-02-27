using AbstractAircraftFactoryBusinessLogic.BindingModels;
using AbstractAircraftFactoryBusinessLogic.BusinessLogics;
using AbstractAircraftFactoryBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractAircraftFactoryView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PlaneLogic _logicP;

        private readonly OrderLogic _logicO;
        public FormCreateOrder(PlaneLogic logicP, OrderLogic logicO)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listOfPlanes = _logicP.Read(null);
                if (listOfPlanes != null)
                {
                    comboBoxPlane.DataSource = listOfPlanes;
                    comboBoxPlane.DisplayMember = "PlaneName";
                    comboBoxPlane.ValueMember = "Id";
                    comboBoxPlane.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxPlane.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {

                    //MessageBox.Show("Все норм");


                    int id = Convert.ToInt32(comboBoxPlane.SelectedValue);
                    PlaneViewModel plane = _logicP.Read(new PlaneBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * plane?.Price ?? 0).ToString();
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

        private void ComboBoxPlane_SelectedIndexChanged(object sender, EventArgs e)
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
            if (comboBoxPlane.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    PlaneId = Convert.ToInt32(comboBoxPlane.SelectedValue),
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
