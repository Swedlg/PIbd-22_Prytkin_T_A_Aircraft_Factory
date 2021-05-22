
namespace AbstractJewelryShopView
{
    partial class FormReportJewelComponent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonSaveToExcel = new System.Windows.Forms.Button();
            this.Самолет = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Компонент = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Количество = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Самолет,
            this.Компонент,
            this.Количество});
            this.dataGridView.Location = new System.Drawing.Point(12, 77);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(776, 361);
            this.dataGridView.TabIndex = 0;
            // 
            // ButtonSaveToExcel
            // 
            this.ButtonSaveToExcel.Location = new System.Drawing.Point(319, 12);
            this.ButtonSaveToExcel.Name = "ButtonSaveToExcel";
            this.ButtonSaveToExcel.Size = new System.Drawing.Size(175, 59);
            this.ButtonSaveToExcel.TabIndex = 1;
            this.ButtonSaveToExcel.Text = "Сохранить в Excel";
            this.ButtonSaveToExcel.UseVisualStyleBackColor = true;
            this.ButtonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // Самолет
            // 
            this.Самолет.HeaderText = "Jewel";
            this.Самолет.MinimumWidth = 8;
            this.Самолет.Name = "Украшение";
            this.Самолет.Width = 150;
            // 
            // Компонент
            // 
            this.Компонент.HeaderText = "Component";
            this.Компонент.MinimumWidth = 8;
            this.Компонент.Name = "Компонент";
            this.Компонент.Width = 150;
            // 
            // Количество
            // 
            this.Количество.HeaderText = "Count";
            this.Количество.MinimumWidth = 8;
            this.Количество.Name = "Количество";
            this.Количество.Width = 150;
            // 
            // FormReportPlaneComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonSaveToExcel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportJewelComponent";
            this.Text = "Компоненты по изделиям";
            this.Load += new System.EventHandler(this.FormReportJewelComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonSaveToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Самолет;
        private System.Windows.Forms.DataGridViewTextBoxColumn Компонент;
        private System.Windows.Forms.DataGridViewTextBoxColumn Количество;
    }
}