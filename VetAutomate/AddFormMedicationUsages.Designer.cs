namespace VetAutomate
{
    partial class AddFormMedicationUsages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMedicationUsages));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelPetIDMedicationUsages = new Label();
            comboBoxPetIDMedicationUsages = new ComboBox();
            labelVetIDMedicationUsages = new Label();
            comboBoxVetIDMedicationUsages = new ComboBox();
            labelMedicationIDMedicationUsages = new Label();
            comboBoxMedicationIDMedicationUsages = new ComboBox();
            labelQuantityUsed = new Label();
            textBoxQuantityUsed = new TextBox();
            labelPurposeMedicationUsages = new Label();
            textBoxPurposeMedicationUsages = new TextBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(241, 9);
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
            label1.Location = new Point(242, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(219, 21);
            label1.TabIndex = 11;
            label1.Text = "Использование лекарства";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(328, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelPetIDMedicationUsages
            // 
            labelPetIDMedicationUsages.AutoSize = true;
            labelPetIDMedicationUsages.ForeColor = Color.Black;
            labelPetIDMedicationUsages.Location = new Point(166, 471);
            labelPetIDMedicationUsages.Margin = new Padding(4, 0, 4, 0);
            labelPetIDMedicationUsages.Name = "labelPetIDMedicationUsages";
            labelPetIDMedicationUsages.Size = new Size(60, 15);
            labelPetIDMedicationUsages.TabIndex = 18;
            labelPetIDMedicationUsages.Text = "Питомец:";
            // 
            // comboBoxPetIDMedicationUsages
            // 
            comboBoxPetIDMedicationUsages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPetIDMedicationUsages.Font = new Font("Segoe UI", 14.25F);
            comboBoxPetIDMedicationUsages.FormattingEnabled = true;
            comboBoxPetIDMedicationUsages.Location = new Point(232, 460);
            comboBoxPetIDMedicationUsages.Name = "comboBoxPetIDMedicationUsages";
            comboBoxPetIDMedicationUsages.Size = new Size(455, 33);
            comboBoxPetIDMedicationUsages.TabIndex = 13;
            // 
            // labelVetIDMedicationUsages
            // 
            labelVetIDMedicationUsages.AutoSize = true;
            labelVetIDMedicationUsages.ForeColor = Color.Black;
            labelVetIDMedicationUsages.Location = new Point(158, 510);
            labelVetIDMedicationUsages.Margin = new Padding(4, 0, 4, 0);
            labelVetIDMedicationUsages.Name = "labelVetIDMedicationUsages";
            labelVetIDMedicationUsages.Size = new Size(68, 15);
            labelVetIDMedicationUsages.TabIndex = 19;
            labelVetIDMedicationUsages.Text = "Ветеринар:";
            // 
            // comboBoxVetIDMedicationUsages
            // 
            comboBoxVetIDMedicationUsages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVetIDMedicationUsages.Font = new Font("Segoe UI", 14.25F);
            comboBoxVetIDMedicationUsages.FormattingEnabled = true;
            comboBoxVetIDMedicationUsages.Location = new Point(232, 499);
            comboBoxVetIDMedicationUsages.Name = "comboBoxVetIDMedicationUsages";
            comboBoxVetIDMedicationUsages.Size = new Size(455, 33);
            comboBoxVetIDMedicationUsages.TabIndex = 14;
            // 
            // labelMedicationIDMedicationUsages
            // 
            labelMedicationIDMedicationUsages.AutoSize = true;
            labelMedicationIDMedicationUsages.ForeColor = Color.Black;
            labelMedicationIDMedicationUsages.Location = new Point(159, 548);
            labelMedicationIDMedicationUsages.Margin = new Padding(4, 0, 4, 0);
            labelMedicationIDMedicationUsages.Name = "labelMedicationIDMedicationUsages";
            labelMedicationIDMedicationUsages.Size = new Size(67, 15);
            labelMedicationIDMedicationUsages.TabIndex = 20;
            labelMedicationIDMedicationUsages.Text = "Лекарство:";
            // 
            // comboBoxMedicationIDMedicationUsages
            // 
            comboBoxMedicationIDMedicationUsages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedicationIDMedicationUsages.Font = new Font("Segoe UI", 14.25F);
            comboBoxMedicationIDMedicationUsages.FormattingEnabled = true;
            comboBoxMedicationIDMedicationUsages.Location = new Point(232, 537);
            comboBoxMedicationIDMedicationUsages.Name = "comboBoxMedicationIDMedicationUsages";
            comboBoxMedicationIDMedicationUsages.Size = new Size(455, 33);
            comboBoxMedicationIDMedicationUsages.TabIndex = 15;
            // 
            // labelQuantityUsed
            // 
            labelQuantityUsed.AutoSize = true;
            labelQuantityUsed.ForeColor = Color.Black;
            labelQuantityUsed.Location = new Point(151, 587);
            labelQuantityUsed.Margin = new Padding(4, 0, 4, 0);
            labelQuantityUsed.Name = "labelQuantityUsed";
            labelQuantityUsed.Size = new Size(75, 15);
            labelQuantityUsed.TabIndex = 21;
            labelQuantityUsed.Text = "Количество:";
            // 
            // textBoxQuantityUsed
            // 
            textBoxQuantityUsed.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxQuantityUsed.Location = new Point(232, 576);
            textBoxQuantityUsed.Margin = new Padding(4, 3, 4, 3);
            textBoxQuantityUsed.Name = "textBoxQuantityUsed";
            textBoxQuantityUsed.Size = new Size(455, 33);
            textBoxQuantityUsed.TabIndex = 16;
            // 
            // labelPurposeMedicationUsages
            // 
            labelPurposeMedicationUsages.AutoSize = true;
            labelPurposeMedicationUsages.ForeColor = Color.Black;
            labelPurposeMedicationUsages.Location = new Point(161, 626);
            labelPurposeMedicationUsages.Margin = new Padding(4, 0, 4, 0);
            labelPurposeMedicationUsages.Name = "labelPurposeMedicationUsages";
            labelPurposeMedicationUsages.Size = new Size(60, 15);
            labelPurposeMedicationUsages.TabIndex = 22;
            labelPurposeMedicationUsages.Text = "Причина:";
            // 
            // textBoxPurposeMedicationUsages
            // 
            textBoxPurposeMedicationUsages.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPurposeMedicationUsages.Location = new Point(232, 615);
            textBoxPurposeMedicationUsages.Margin = new Padding(4, 3, 4, 3);
            textBoxPurposeMedicationUsages.Name = "textBoxPurposeMedicationUsages";
            textBoxPurposeMedicationUsages.Size = new Size(455, 33);
            textBoxPurposeMedicationUsages.TabIndex = 17;
            // 
            // AddFormMedicationUsages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelPetIDMedicationUsages);
            Controls.Add(comboBoxPetIDMedicationUsages);
            Controls.Add(labelVetIDMedicationUsages);
            Controls.Add(comboBoxVetIDMedicationUsages);
            Controls.Add(labelMedicationIDMedicationUsages);
            Controls.Add(comboBoxMedicationIDMedicationUsages);
            Controls.Add(labelQuantityUsed);
            Controls.Add(textBoxQuantityUsed);
            Controls.Add(labelPurposeMedicationUsages);
            Controls.Add(textBoxPurposeMedicationUsages);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMedicationUsages";
            Text = "Добавить использование лекарства";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelPetIDMedicationUsages;
        private ComboBox comboBoxPetIDMedicationUsages;
        private Label labelVetIDMedicationUsages;
        private ComboBox comboBoxVetIDMedicationUsages;
        private Label labelMedicationIDMedicationUsages;
        private ComboBox comboBoxMedicationIDMedicationUsages;
        private Label labelQuantityUsed;
        private TextBox textBoxQuantityUsed;
        private Label labelPurposeMedicationUsages;
        private TextBox textBoxPurposeMedicationUsages;
    }
}