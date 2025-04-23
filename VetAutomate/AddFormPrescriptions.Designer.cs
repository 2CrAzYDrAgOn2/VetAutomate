namespace VetAutomate
{
    partial class AddFormPrescriptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormPrescriptions));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelPetIDPrescriptions = new Label();
            labelVetIDPrescriptions = new Label();
            labelMedicationIDPrescriptions = new Label();
            labelDosage = new Label();
            textBoxDosage = new TextBox();
            labelInstructions = new Label();
            textBoxInstructions = new TextBox();
            comboBoxPetIDPrescriptions = new ComboBox();
            comboBoxVetIDPrescriptions = new ComboBox();
            comboBoxMedicationIDPrescriptions = new ComboBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(240, 9);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 23;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(241, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 24;
            label1.Text = "Запись в книжке";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(327, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 22;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelPetIDPrescriptions
            // 
            labelPetIDPrescriptions.AutoSize = true;
            labelPetIDPrescriptions.ForeColor = Color.Black;
            labelPetIDPrescriptions.Location = new Point(217, 458);
            labelPetIDPrescriptions.Margin = new Padding(4, 0, 4, 0);
            labelPetIDPrescriptions.Name = "labelPetIDPrescriptions";
            labelPetIDPrescriptions.Size = new Size(60, 15);
            labelPetIDPrescriptions.TabIndex = 32;
            labelPetIDPrescriptions.Text = "Питомец:";
            // 
            // labelVetIDPrescriptions
            // 
            labelVetIDPrescriptions.AutoSize = true;
            labelVetIDPrescriptions.ForeColor = Color.Black;
            labelVetIDPrescriptions.Location = new Point(209, 503);
            labelVetIDPrescriptions.Margin = new Padding(4, 0, 4, 0);
            labelVetIDPrescriptions.Name = "labelVetIDPrescriptions";
            labelVetIDPrescriptions.Size = new Size(68, 15);
            labelVetIDPrescriptions.TabIndex = 33;
            labelVetIDPrescriptions.Text = "Ветеринар:";
            // 
            // labelMedicationIDPrescriptions
            // 
            labelMedicationIDPrescriptions.AutoSize = true;
            labelMedicationIDPrescriptions.ForeColor = Color.Black;
            labelMedicationIDPrescriptions.Location = new Point(210, 551);
            labelMedicationIDPrescriptions.Margin = new Padding(4, 0, 4, 0);
            labelMedicationIDPrescriptions.Name = "labelMedicationIDPrescriptions";
            labelMedicationIDPrescriptions.Size = new Size(67, 15);
            labelMedicationIDPrescriptions.TabIndex = 34;
            labelMedicationIDPrescriptions.Text = "Лекарство:";
            // 
            // labelDosage
            // 
            labelDosage.AutoSize = true;
            labelDosage.ForeColor = Color.Black;
            labelDosage.Location = new Point(241, 593);
            labelDosage.Margin = new Padding(4, 0, 4, 0);
            labelDosage.Name = "labelDosage";
            labelDosage.Size = new Size(36, 15);
            labelDosage.TabIndex = 35;
            labelDosage.Text = "Доза:";
            // 
            // textBoxDosage
            // 
            textBoxDosage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDosage.Location = new Point(288, 582);
            textBoxDosage.Margin = new Padding(4, 3, 4, 3);
            textBoxDosage.Name = "textBoxDosage";
            textBoxDosage.Size = new Size(455, 33);
            textBoxDosage.TabIndex = 30;
            // 
            // labelInstructions
            // 
            labelInstructions.AutoSize = true;
            labelInstructions.ForeColor = Color.Black;
            labelInstructions.Location = new Point(201, 638);
            labelInstructions.Margin = new Padding(4, 0, 4, 0);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(76, 15);
            labelInstructions.TabIndex = 36;
            labelInstructions.Text = "Инструкция:";
            // 
            // textBoxInstructions
            // 
            textBoxInstructions.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxInstructions.Location = new Point(288, 627);
            textBoxInstructions.Margin = new Padding(4, 3, 4, 3);
            textBoxInstructions.Name = "textBoxInstructions";
            textBoxInstructions.Size = new Size(455, 33);
            textBoxInstructions.TabIndex = 31;
            // 
            // comboBoxPetIDPrescriptions
            // 
            comboBoxPetIDPrescriptions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPetIDPrescriptions.Font = new Font("Segoe UI", 14.25F);
            comboBoxPetIDPrescriptions.FormattingEnabled = true;
            comboBoxPetIDPrescriptions.Location = new Point(288, 447);
            comboBoxPetIDPrescriptions.Name = "comboBoxPetIDPrescriptions";
            comboBoxPetIDPrescriptions.Size = new Size(455, 33);
            comboBoxPetIDPrescriptions.TabIndex = 0;
            // 
            // comboBoxVetIDPrescriptions
            // 
            comboBoxVetIDPrescriptions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVetIDPrescriptions.Font = new Font("Segoe UI", 14.25F);
            comboBoxVetIDPrescriptions.FormattingEnabled = true;
            comboBoxVetIDPrescriptions.Location = new Point(288, 492);
            comboBoxVetIDPrescriptions.Name = "comboBoxVetIDPrescriptions";
            comboBoxVetIDPrescriptions.Size = new Size(455, 33);
            comboBoxVetIDPrescriptions.TabIndex = 1;
            // 
            // comboBoxMedicationIDPrescriptions
            // 
            comboBoxMedicationIDPrescriptions.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMedicationIDPrescriptions.Font = new Font("Segoe UI", 14.25F);
            comboBoxMedicationIDPrescriptions.FormattingEnabled = true;
            comboBoxMedicationIDPrescriptions.Location = new Point(288, 540);
            comboBoxMedicationIDPrescriptions.Name = "comboBoxMedicationIDPrescriptions";
            comboBoxMedicationIDPrescriptions.Size = new Size(455, 33);
            comboBoxMedicationIDPrescriptions.TabIndex = 2;
            // 
            // AddFormPrescriptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelPetIDPrescriptions);
            Controls.Add(comboBoxPetIDPrescriptions);
            Controls.Add(labelVetIDPrescriptions);
            Controls.Add(comboBoxVetIDPrescriptions);
            Controls.Add(labelMedicationIDPrescriptions);
            Controls.Add(comboBoxMedicationIDPrescriptions);
            Controls.Add(labelDosage);
            Controls.Add(textBoxDosage);
            Controls.Add(labelInstructions);
            Controls.Add(textBoxInstructions);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormPrescriptions";
            Text = "Добавить запись в книжку";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelPetIDPrescriptions;
        private Label labelVetIDPrescriptions;
        private Label labelMedicationIDPrescriptions;
        private Label labelDosage;
        private TextBox textBoxDosage;
        private Label labelInstructions;
        private TextBox textBoxInstructions;
        private ComboBox comboBoxPetIDPrescriptions;
        private ComboBox comboBoxVetIDPrescriptions;
        private ComboBox comboBoxMedicationIDPrescriptions;
    }
}