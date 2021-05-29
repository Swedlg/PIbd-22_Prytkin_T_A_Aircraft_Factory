using System;
using AbstractJewelryShopBusinessLogic.BusinessLogics;
using System.Windows.Forms;

namespace AbstractJewelryShopView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;

        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
