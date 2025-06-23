namespace VetAutomate
{
    partial class AddFormMedicationSupplies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMedicationSupplies));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelMedicationIDMedicationSupplies = new Label();
            comboBoxMedicationIDMedicationSuppplies = new ComboBox();
            labelSupplyDate = new Label();
            dateTimePickerSupplyDate = new DateTimePicker();
            labelQuantitySupplied = new Label();
            textBoxQuantitySupplied = new TextBox();
            labelSupplierName = new Label();
            textBoxSupplierName = new TextBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(244, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 10;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(245, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(167, 21);
            label1.TabIndex = 11;
            label1.Text = "Поставка лекарства";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(331, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelMedicationIDMedicationSupplies
            // 
            labelMedicationIDMedicationSupplies.AutoSize = true;
            labelMedicationIDMedicationSupplies.ForeColor = Color.Black;
            labelMedicationIDMedicationSupplies.Location = new Point(231, 458);
            labelMedicationIDMedicationSupplies.Margin = new Padding(4, 0, 4, 0);
            labelMedicationIDMedicationSupplies.Name = "labelMedicationIDMedicationSupplies";
            labelMedicationIDMedicationSupplies.Size = new Size(67, 15);
            labelMedicationIDMedicationSupplies.TabIndex = 16;
            labelMedicationIDMedicationSupplies.Text = "Лекарство:";
            // 
            // comboBoxMedicationIDMedicationSuppplies
            // 
            comboBoxMedicationIDMedicationSuppplies.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedicationIDMedicationSuppplies.Font = new Font("Segoe UI", 14.25F);
            comboBoxMedicationIDMedicationSuppplies.FormattingEnabled = true;
            comboBoxMedicationIDMedicationSuppplies.Location = new Point(305, 447);
            comboBoxMedicationIDMedicationSuppplies.Name = "comboBoxMedicationIDMedicationSuppplies";
            comboBoxMedicationIDMedicationSuppplies.Size = new Size(455, 33);
            comboBoxMedicationIDMedicationSuppplies.TabIndex = 12;
            // 
            // labelSupplyDate
            // 
            labelSupplyDate.AutoSize = true;
            labelSupplyDate.ForeColor = Color.Black;
            labelSupplyDate.Location = new Point(210, 500);
            labelSupplyDate.Margin = new Padding(4, 0, 4, 0);
            labelSupplyDate.Name = "labelSupplyDate";
            labelSupplyDate.Size = new Size(88, 15);
            labelSupplyDate.TabIndex = 17;
            labelSupplyDate.Text = "Дата поставки:";
            // 
            // dateTimePickerSupplyDate
            // 
            dateTimePickerSupplyDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerSupplyDate.Location = new Point(305, 486);
            dateTimePickerSupplyDate.Name = "dateTimePickerSupplyDate";
            dateTimePickerSupplyDate.Size = new Size(455, 33);
            dateTimePickerSupplyDate.TabIndex = 13;
            // 
            // labelQuantitySupplied
            // 
            labelQuantitySupplied.AutoSize = true;
            labelQuantitySupplied.ForeColor = Color.Black;
            labelQuantitySupplied.Location = new Point(221, 536);
            labelQuantitySupplied.Margin = new Padding(4, 0, 4, 0);
            labelQuantitySupplied.Name = "labelQuantitySupplied";
            labelQuantitySupplied.Size = new Size(75, 15);
            labelQuantitySupplied.TabIndex = 18;
            labelQuantitySupplied.Text = "Количество:";
            // 
            // textBoxQuantitySupplied
            // 
            textBoxQuantitySupplied.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxQuantitySupplied.Location = new Point(304, 525);
            textBoxQuantitySupplied.Margin = new Padding(4, 3, 4, 3);
            textBoxQuantitySupplied.Name = "textBoxQuantitySupplied";
            textBoxQuantitySupplied.Size = new Size(455, 33);
            textBoxQuantitySupplied.TabIndex = 14;
            // 
            // labelSupplierName
            // 
            labelSupplierName.AutoSize = true;
            labelSupplierName.ForeColor = Color.Black;
            labelSupplierName.Location = new Point(220, 575);
            labelSupplierName.Margin = new Padding(4, 0, 4, 0);
            labelSupplierName.Name = "labelSupplierName";
            labelSupplierName.Size = new Size(73, 15);
            labelSupplierName.TabIndex = 19;
            labelSupplierName.Text = "Поставщик:";
            // 
            // textBoxSupplierName
            // 
            textBoxSupplierName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxSupplierName.Location = new Point(305, 564);
            textBoxSupplierName.Margin = new Padding(4, 3, 4, 3);
            textBoxSupplierName.Name = "textBoxSupplierName";
            textBoxSupplierName.Size = new Size(455, 33);
            textBoxSupplierName.TabIndex = 15;
            // 
            // AddFormMedicationSupplies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelMedicationIDMedicationSupplies);
            Controls.Add(comboBoxMedicationIDMedicationSuppplies);
            Controls.Add(labelSupplyDate);
            Controls.Add(dateTimePickerSupplyDate);
            Controls.Add(labelQuantitySupplied);
            Controls.Add(textBoxQuantitySupplied);
            Controls.Add(labelSupplierName);
            Controls.Add(textBoxSupplierName);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMedicationSupplies";
            Text = "Добавить поставку лекарств";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelMedicationIDMedicationSupplies;
        private ComboBox comboBoxMedicationIDMedicationSuppplies;
        private Label labelSupplyDate;
        private DateTimePicker dateTimePickerSupplyDate;
        private Label labelQuantitySupplied;
        private TextBox textBoxQuantitySupplied;
        private Label labelSupplierName;
        private TextBox textBoxSupplierName;
    }
}