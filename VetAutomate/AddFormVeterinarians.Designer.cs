namespace VetAutomate
{
    partial class AddFormVeterinarians
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormVeterinarians));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelFullName = new Label();
            textBoxFullName = new TextBox();
            labelBirthDateVeterinarians = new Label();
            dateTimePickerBirthDateVeterinarians = new DateTimePicker();
            labelBirthPlace = new Label();
            textBoxBirthPlace = new TextBox();
            labelPassportSeries = new Label();
            textBoxPassportSeries = new TextBox();
            labelPassportNumber = new Label();
            textBoxPassportNumber = new TextBox();
            labelPhoneVeterinarians = new Label();
            maskedTextBoxPhoneVeterinarians = new MaskedTextBox();
            labelEmailVeterinarians = new Label();
            textBoxEmailVeterinarians = new TextBox();
            labelINNVeterinarians = new Label();
            textBoxINNVeterinarians = new TextBox();
            labelDateOfEmployment = new Label();
            dateTimePickerDateOfEmployment = new DateTimePicker();
            labelPost = new Label();
            comboBoxPost = new ComboBox();
            labelGender = new Label();
            comboBoxGender = new ComboBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(242, 9);
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
            label1.Location = new Point(243, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 24;
            label1.Text = "Ветеринар";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(329, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 22;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(243, 341);
            labelFullName.Margin = new Padding(4, 0, 4, 0);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(37, 15);
            labelFullName.TabIndex = 38;
            labelFullName.Text = "ФИО:";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxFullName.Location = new Point(291, 330);
            textBoxFullName.Margin = new Padding(4, 3, 4, 3);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(455, 33);
            textBoxFullName.TabIndex = 27;
            // 
            // labelBirthDateVeterinarians
            // 
            labelBirthDateVeterinarians.AutoSize = true;
            labelBirthDateVeterinarians.ForeColor = Color.Black;
            labelBirthDateVeterinarians.Location = new Point(187, 383);
            labelBirthDateVeterinarians.Margin = new Padding(4, 0, 4, 0);
            labelBirthDateVeterinarians.Name = "labelBirthDateVeterinarians";
            labelBirthDateVeterinarians.Size = new Size(93, 15);
            labelBirthDateVeterinarians.TabIndex = 39;
            labelBirthDateVeterinarians.Text = "Дата рождения:";
            // 
            // dateTimePickerBirthDateVeterinarians
            // 
            dateTimePickerBirthDateVeterinarians.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerBirthDateVeterinarians.Location = new Point(291, 369);
            dateTimePickerBirthDateVeterinarians.Name = "dateTimePickerBirthDateVeterinarians";
            dateTimePickerBirthDateVeterinarians.Size = new Size(455, 33);
            dateTimePickerBirthDateVeterinarians.TabIndex = 28;
            // 
            // labelBirthPlace
            // 
            labelBirthPlace.AutoSize = true;
            labelBirthPlace.ForeColor = Color.Black;
            labelBirthPlace.Location = new Point(177, 419);
            labelBirthPlace.Margin = new Padding(4, 0, 4, 0);
            labelBirthPlace.Name = "labelBirthPlace";
            labelBirthPlace.Size = new Size(103, 15);
            labelBirthPlace.TabIndex = 40;
            labelBirthPlace.Text = "Место рождения:";
            // 
            // textBoxBirthPlace
            // 
            textBoxBirthPlace.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxBirthPlace.Location = new Point(291, 408);
            textBoxBirthPlace.Margin = new Padding(4, 3, 4, 3);
            textBoxBirthPlace.Name = "textBoxBirthPlace";
            textBoxBirthPlace.Size = new Size(455, 33);
            textBoxBirthPlace.TabIndex = 29;
            // 
            // labelPassportSeries
            // 
            labelPassportSeries.AutoSize = true;
            labelPassportSeries.ForeColor = Color.Black;
            labelPassportSeries.Location = new Point(182, 458);
            labelPassportSeries.Margin = new Padding(4, 0, 4, 0);
            labelPassportSeries.Name = "labelPassportSeries";
            labelPassportSeries.Size = new Size(98, 15);
            labelPassportSeries.TabIndex = 41;
            labelPassportSeries.Text = "Серия паспорта:";
            // 
            // textBoxPassportSeries
            // 
            textBoxPassportSeries.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPassportSeries.Location = new Point(291, 447);
            textBoxPassportSeries.Margin = new Padding(4, 3, 4, 3);
            textBoxPassportSeries.Name = "textBoxPassportSeries";
            textBoxPassportSeries.Size = new Size(455, 33);
            textBoxPassportSeries.TabIndex = 30;
            // 
            // labelPassportNumber
            // 
            labelPassportNumber.AutoSize = true;
            labelPassportNumber.ForeColor = Color.Black;
            labelPassportNumber.Location = new Point(177, 497);
            labelPassportNumber.Margin = new Padding(4, 0, 4, 0);
            labelPassportNumber.Name = "labelPassportNumber";
            labelPassportNumber.Size = new Size(102, 15);
            labelPassportNumber.TabIndex = 42;
            labelPassportNumber.Text = "Номер паспорта:";
            // 
            // textBoxPassportNumber
            // 
            textBoxPassportNumber.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPassportNumber.Location = new Point(291, 486);
            textBoxPassportNumber.Margin = new Padding(4, 3, 4, 3);
            textBoxPassportNumber.Name = "textBoxPassportNumber";
            textBoxPassportNumber.Size = new Size(455, 33);
            textBoxPassportNumber.TabIndex = 31;
            // 
            // labelPhoneVeterinarians
            // 
            labelPhoneVeterinarians.AutoSize = true;
            labelPhoneVeterinarians.ForeColor = Color.Black;
            labelPhoneVeterinarians.Location = new Point(221, 535);
            labelPhoneVeterinarians.Margin = new Padding(4, 0, 4, 0);
            labelPhoneVeterinarians.Name = "labelPhoneVeterinarians";
            labelPhoneVeterinarians.Size = new Size(58, 15);
            labelPhoneVeterinarians.TabIndex = 43;
            labelPhoneVeterinarians.Text = "Телефон:";
            // 
            // maskedTextBoxPhoneVeterinarians
            // 
            maskedTextBoxPhoneVeterinarians.Font = new Font("Segoe UI", 14.25F);
            maskedTextBoxPhoneVeterinarians.Location = new Point(291, 524);
            maskedTextBoxPhoneVeterinarians.Margin = new Padding(3, 2, 3, 2);
            maskedTextBoxPhoneVeterinarians.Mask = "+7 (999) 999-99-99";
            maskedTextBoxPhoneVeterinarians.Name = "maskedTextBoxPhoneVeterinarians";
            maskedTextBoxPhoneVeterinarians.Size = new Size(455, 33);
            maskedTextBoxPhoneVeterinarians.TabIndex = 32;
            // 
            // labelEmailVeterinarians
            // 
            labelEmailVeterinarians.AutoSize = true;
            labelEmailVeterinarians.ForeColor = Color.Black;
            labelEmailVeterinarians.Location = new Point(235, 575);
            labelEmailVeterinarians.Margin = new Padding(4, 0, 4, 0);
            labelEmailVeterinarians.Name = "labelEmailVeterinarians";
            labelEmailVeterinarians.Size = new Size(44, 15);
            labelEmailVeterinarians.TabIndex = 44;
            labelEmailVeterinarians.Text = "Почта:";
            // 
            // textBoxEmailVeterinarians
            // 
            textBoxEmailVeterinarians.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEmailVeterinarians.Location = new Point(291, 564);
            textBoxEmailVeterinarians.Margin = new Padding(4, 3, 4, 3);
            textBoxEmailVeterinarians.Name = "textBoxEmailVeterinarians";
            textBoxEmailVeterinarians.Size = new Size(455, 33);
            textBoxEmailVeterinarians.TabIndex = 33;
            // 
            // labelINNVeterinarians
            // 
            labelINNVeterinarians.AutoSize = true;
            labelINNVeterinarians.ForeColor = Color.Black;
            labelINNVeterinarians.Location = new Point(242, 614);
            labelINNVeterinarians.Margin = new Padding(4, 0, 4, 0);
            labelINNVeterinarians.Name = "labelINNVeterinarians";
            labelINNVeterinarians.Size = new Size(37, 15);
            labelINNVeterinarians.TabIndex = 45;
            labelINNVeterinarians.Text = "ИНН:";
            // 
            // textBoxINNVeterinarians
            // 
            textBoxINNVeterinarians.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxINNVeterinarians.Location = new Point(291, 603);
            textBoxINNVeterinarians.Margin = new Padding(4, 3, 4, 3);
            textBoxINNVeterinarians.Name = "textBoxINNVeterinarians";
            textBoxINNVeterinarians.Size = new Size(455, 33);
            textBoxINNVeterinarians.TabIndex = 34;
            // 
            // labelDateOfEmployment
            // 
            labelDateOfEmployment.AutoSize = true;
            labelDateOfEmployment.ForeColor = Color.Black;
            labelDateOfEmployment.Location = new Point(181, 656);
            labelDateOfEmployment.Margin = new Padding(4, 0, 4, 0);
            labelDateOfEmployment.Name = "labelDateOfEmployment";
            labelDateOfEmployment.Size = new Size(99, 15);
            labelDateOfEmployment.TabIndex = 46;
            labelDateOfEmployment.Text = "Дата устройства:";
            // 
            // dateTimePickerDateOfEmployment
            // 
            dateTimePickerDateOfEmployment.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerDateOfEmployment.Location = new Point(291, 642);
            dateTimePickerDateOfEmployment.Name = "dateTimePickerDateOfEmployment";
            dateTimePickerDateOfEmployment.Size = new Size(455, 33);
            dateTimePickerDateOfEmployment.TabIndex = 35;
            // 
            // labelPost
            // 
            labelPost.AutoSize = true;
            labelPost.ForeColor = Color.Black;
            labelPost.Location = new Point(207, 692);
            labelPost.Margin = new Padding(4, 0, 4, 0);
            labelPost.Name = "labelPost";
            labelPost.Size = new Size(72, 15);
            labelPost.TabIndex = 47;
            labelPost.Text = "Должность:";
            // 
            // comboBoxPost
            // 
            comboBoxPost.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPost.Font = new Font("Segoe UI", 14.25F);
            comboBoxPost.FormattingEnabled = true;
            comboBoxPost.Items.AddRange(new object[] { "Ветеринар", "Ассистент ветеринара", "Менеджер по работе с клиентами", "Администратор" });
            comboBoxPost.Location = new Point(291, 681);
            comboBoxPost.Name = "comboBoxPost";
            comboBoxPost.Size = new Size(455, 33);
            comboBoxPost.TabIndex = 36;
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.ForeColor = Color.Black;
            labelGender.Location = new Point(246, 731);
            labelGender.Margin = new Padding(4, 0, 4, 0);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(33, 15);
            labelGender.TabIndex = 48;
            labelGender.Text = "Пол:";
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Font = new Font("Segoe UI", 14.25F);
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "Мужской", "Женский" });
            comboBoxGender.Location = new Point(291, 719);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(455, 33);
            comboBoxGender.TabIndex = 37;
            // 
            // AddFormVeterinarians
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelFullName);
            Controls.Add(textBoxFullName);
            Controls.Add(labelBirthDateVeterinarians);
            Controls.Add(dateTimePickerBirthDateVeterinarians);
            Controls.Add(labelBirthPlace);
            Controls.Add(textBoxBirthPlace);
            Controls.Add(labelPassportSeries);
            Controls.Add(textBoxPassportSeries);
            Controls.Add(labelPassportNumber);
            Controls.Add(textBoxPassportNumber);
            Controls.Add(labelPhoneVeterinarians);
            Controls.Add(maskedTextBoxPhoneVeterinarians);
            Controls.Add(labelEmailVeterinarians);
            Controls.Add(textBoxEmailVeterinarians);
            Controls.Add(labelINNVeterinarians);
            Controls.Add(textBoxINNVeterinarians);
            Controls.Add(labelDateOfEmployment);
            Controls.Add(dateTimePickerDateOfEmployment);
            Controls.Add(labelPost);
            Controls.Add(comboBoxPost);
            Controls.Add(labelGender);
            Controls.Add(comboBoxGender);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormVeterinarians";
            Text = "Добавить ветеринара";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelBirthDateVeterinarians;
        private DateTimePicker dateTimePickerBirthDateVeterinarians;
        private Label labelBirthPlace;
        private TextBox textBoxBirthPlace;
        private Label labelPassportSeries;
        private TextBox textBoxPassportSeries;
        private Label labelPassportNumber;
        private TextBox textBoxPassportNumber;
        private Label labelPhoneVeterinarians;
        private MaskedTextBox maskedTextBoxPhoneVeterinarians;
        private Label labelEmailVeterinarians;
        private TextBox textBoxEmailVeterinarians;
        private Label labelINNVeterinarians;
        private TextBox textBoxINNVeterinarians;
        private Label labelDateOfEmployment;
        private DateTimePicker dateTimePickerDateOfEmployment;
        private Label labelPost;
        private ComboBox comboBoxPost;
        private Label labelGender;
        private ComboBox comboBoxGender;
    }
}