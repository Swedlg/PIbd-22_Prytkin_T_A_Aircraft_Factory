
namespace AbstractJewelryShopView
{
    partial class FormWarehouse
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
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelResponsible = new System.Windows.Forms.Label();
            this.textBoxResponsibleName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(13, 84);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(672, 400);
            this.dataGridView.TabIndex = 5;
            // 
            // Component
            // 
            this.Component.HeaderText = "Компонент";
            this.Component.MinimumWidth = 8;
            this.Component.Name = "Component";
            this.Component.Width = 280;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.MinimumWidth = 8;
            this.Count.Name = "Count";
            this.Count.Width = 130;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(51, 9);
            this.LabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(91, 20);
            this.LabelName.TabIndex = 6;
            this.LabelName.Text = "Название: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(150, 6);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(214, 26);
            this.textBoxName.TabIndex = 7;
            // 
            // labelResponsible
            // 
            this.labelResponsible.AutoSize = true;
            this.labelResponsible.Location = new System.Drawing.Point(13, 54);
            this.labelResponsible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResponsible.Name = "labelResponsible";
            this.labelResponsible.Size = new System.Drawing.Size(129, 20);
            this.labelResponsible.TabIndex = 8;
            this.labelResponsible.Text = "Ответсвенный: ";
            // 
            // textBoxResponsibleName
            // 
            this.textBoxResponsibleName.Location = new System.Drawing.Point(150, 48);
            this.textBoxResponsibleName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxResponsibleName.Name = "textBoxResponsibleName";
            this.textBoxResponsibleName.Size = new System.Drawing.Size(214, 26);
            this.textBoxResponsibleName.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 494);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(318, 52);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(339, 494);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(346, 52);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 561);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxResponsibleName);
            this.Controls.Add(this.labelResponsible);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormWarehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelResponsible;
        private System.Windows.Forms.TextBox textBoxResponsibleName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}