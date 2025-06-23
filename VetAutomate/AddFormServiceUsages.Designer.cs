namespace VetAutomate
{
    partial class AddFormServiceUsages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormServiceUsages));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labePetIDServiceUsages = new Label();
            comboBoxPetIDServiceUsages = new ComboBox();
            labelVetIDServiceUsages = new Label();
            comboBoxVetIDServiceUsages = new ComboBox();
            labelServiceIDServiceUsages = new Label();
            comboBoxServiceIDServiceUsages = new ComboBox();
            labelPurposeServiceUsages = new Label();
            textBoxPurposeServiceUsages = new TextBox();
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
            label1.Size = new Size(143, 21);
            label1.TabIndex = 11;
            label1.Text = "Оказание услуги";
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
            // labePetIDServiceUsages
            // 
            labePetIDServiceUsages.AutoSize = true;
            labePetIDServiceUsages.ForeColor = Color.Black;
            labePetIDServiceUsages.Location = new Point(169, 429);
            labePetIDServiceUsages.Margin = new Padding(4, 0, 4, 0);
            labePetIDServiceUsages.Name = "labePetIDServiceUsages";
            labePetIDServiceUsages.Size = new Size(60, 15);
            labePetIDServiceUsages.TabIndex = 16;
            labePetIDServiceUsages.Text = "Питомец:";
            // 
            // comboBoxPetIDServiceUsages
            // 
            comboBoxPetIDServiceUsages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPetIDServiceUsages.Font = new Font("Segoe UI", 14.25F);
            comboBoxPetIDServiceUsages.FormattingEnabled = true;
            comboBoxPetIDServiceUsages.Location = new Point(235, 418);
            comboBoxPetIDServiceUsages.Name = "comboBoxPetIDServiceUsages";
            comboBoxPetIDServiceUsages.Size = new Size(455, 33);
            comboBoxPetIDServiceUsages.TabIndex = 12;
            // 
            // labelVetIDServiceUsages
            // 
            labelVetIDServiceUsages.AutoSize = true;
            labelVetIDServiceUsages.ForeColor = Color.Black;
            labelVetIDServiceUsages.Location = new Point(161, 468);
            labelVetIDServiceUsages.Margin = new Padding(4, 0, 4, 0);
            labelVetIDServiceUsages.Name = "labelVetIDServiceUsages";
            labelVetIDServiceUsages.Size = new Size(68, 15);
            labelVetIDServiceUsages.TabIndex = 17;
            labelVetIDServiceUsages.Text = "Ветеринар:";
            // 
            // comboBoxVetIDServiceUsages
            // 
            comboBoxVetIDServiceUsages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVetIDServiceUsages.Font = new Font("Segoe UI", 14.25F);
            comboBoxVetIDServiceUsages.FormattingEnabled = true;
            comboBoxVetIDServiceUsages.Location = new Point(234, 457);
            comboBoxVetIDServiceUsages.Name = "comboBoxVetIDServiceUsages";
            comboBoxVetIDServiceUsages.Size = new Size(455, 33);
            comboBoxVetIDServiceUsages.TabIndex = 13;
            // 
            // labelServiceIDServiceUsages
            // 
            labelServiceIDServiceUsages.AutoSize = true;
            labelServiceIDServiceUsages.ForeColor = Color.Black;
            labelServiceIDServiceUsages.Location = new Point(182, 506);
            labelServiceIDServiceUsages.Margin = new Padding(4, 0, 4, 0);
            labelServiceIDServiceUsages.Name = "labelServiceIDServiceUsages";
            labelServiceIDServiceUsages.Size = new Size(47, 15);
            labelServiceIDServiceUsages.TabIndex = 18;
            labelServiceIDServiceUsages.Text = "Услуга:";
            // 
            // comboBoxServiceIDServiceUsages
            // 
            comboBoxServiceIDServiceUsages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceIDServiceUsages.Font = new Font("Segoe UI", 14.25F);
            comboBoxServiceIDServiceUsages.FormattingEnabled = true;
            comboBoxServiceIDServiceUsages.Location = new Point(234, 495);
            comboBoxServiceIDServiceUsages.Name = "comboBoxServiceIDServiceUsages";
            comboBoxServiceIDServiceUsages.Size = new Size(455, 33);
            comboBoxServiceIDServiceUsages.TabIndex = 14;
            // 
            // labelPurposeServiceUsages
            // 
            labelPurposeServiceUsages.AutoSize = true;
            labelPurposeServiceUsages.ForeColor = Color.Black;
            labelPurposeServiceUsages.Location = new Point(169, 547);
            labelPurposeServiceUsages.Margin = new Padding(4, 0, 4, 0);
            labelPurposeServiceUsages.Name = "labelPurposeServiceUsages";
            labelPurposeServiceUsages.Size = new Size(60, 15);
            labelPurposeServiceUsages.TabIndex = 19;
            labelPurposeServiceUsages.Text = "Причина:";
            // 
            // textBoxPurposeServiceUsages
            // 
            textBoxPurposeServiceUsages.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPurposeServiceUsages.Location = new Point(235, 534);
            textBoxPurposeServiceUsages.Margin = new Padding(4, 3, 4, 3);
            textBoxPurposeServiceUsages.Name = "textBoxPurposeServiceUsages";
            textBoxPurposeServiceUsages.Size = new Size(455, 33);
            textBoxPurposeServiceUsages.TabIndex = 15;
            // 
            // AddFormServiceUsages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labePetIDServiceUsages);
            Controls.Add(comboBoxPetIDServiceUsages);
            Controls.Add(labelVetIDServiceUsages);
            Controls.Add(comboBoxVetIDServiceUsages);
            Controls.Add(labelServiceIDServiceUsages);
            Controls.Add(comboBoxServiceIDServiceUsages);
            Controls.Add(labelPurposeServiceUsages);
            Controls.Add(textBoxPurposeServiceUsages);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormServiceUsages";
            Text = "Добавить оказание услуги";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labePetIDServiceUsages;
        private ComboBox comboBoxPetIDServiceUsages;
        private Label labelVetIDServiceUsages;
        private ComboBox comboBoxVetIDServiceUsages;
        private Label labelServiceIDServiceUsages;
        private ComboBox comboBoxServiceIDServiceUsages;
        private Label labelPurposeServiceUsages;
        private TextBox textBoxPurposeServiceUsages;
    }
}