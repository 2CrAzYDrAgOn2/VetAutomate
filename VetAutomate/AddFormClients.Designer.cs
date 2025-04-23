namespace VetAutomate
{
    partial class AddFormClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormClients));
            buttonSave = new Button();
            labelTitle = new Label();
            label1 = new Label();
            labelFullNameClients = new Label();
            textBoxFullNameClients = new TextBox();
            labelPhoneClients = new Label();
            maskedTextBoxPhoneClients = new MaskedTextBox();
            labelEmailClients = new Label();
            textBoxEmailClients = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelRegistrationDate = new Label();
            dateTimePickerRegistrationDate = new DateTimePicker();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(330, 763);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(243, 10);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 25);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(244, 39);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 8;
            label1.Text = "Клиент";
            // 
            // labelFullNameClients
            // 
            labelFullNameClients.AutoSize = true;
            labelFullNameClients.ForeColor = Color.Black;
            labelFullNameClients.Location = new Point(246, 458);
            labelFullNameClients.Margin = new Padding(4, 0, 4, 0);
            labelFullNameClients.Name = "labelFullNameClients";
            labelFullNameClients.Size = new Size(37, 15);
            labelFullNameClients.TabIndex = 21;
            labelFullNameClients.Text = "ФИО:";
            // 
            // textBoxFullNameClients
            // 
            textBoxFullNameClients.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxFullNameClients.Location = new Point(292, 448);
            textBoxFullNameClients.Margin = new Padding(4, 3, 4, 3);
            textBoxFullNameClients.Name = "textBoxFullNameClients";
            textBoxFullNameClients.Size = new Size(455, 33);
            textBoxFullNameClients.TabIndex = 15;
            // 
            // labelPhoneClients
            // 
            labelPhoneClients.AutoSize = true;
            labelPhoneClients.ForeColor = Color.Black;
            labelPhoneClients.Location = new Point(222, 504);
            labelPhoneClients.Margin = new Padding(4, 0, 4, 0);
            labelPhoneClients.Name = "labelPhoneClients";
            labelPhoneClients.Size = new Size(58, 15);
            labelPhoneClients.TabIndex = 22;
            labelPhoneClients.Text = "Телефон:";
            // 
            // maskedTextBoxPhoneClients
            // 
            maskedTextBoxPhoneClients.Font = new Font("Segoe UI", 14.25F);
            maskedTextBoxPhoneClients.Location = new Point(292, 494);
            maskedTextBoxPhoneClients.Margin = new Padding(3, 2, 3, 2);
            maskedTextBoxPhoneClients.Mask = "+7 (999) 999-99-99";
            maskedTextBoxPhoneClients.Name = "maskedTextBoxPhoneClients";
            maskedTextBoxPhoneClients.Size = new Size(455, 33);
            maskedTextBoxPhoneClients.TabIndex = 16;
            // 
            // labelEmailClients
            // 
            labelEmailClients.AutoSize = true;
            labelEmailClients.ForeColor = Color.Black;
            labelEmailClients.Location = new Point(238, 551);
            labelEmailClients.Margin = new Padding(4, 0, 4, 0);
            labelEmailClients.Name = "labelEmailClients";
            labelEmailClients.Size = new Size(44, 15);
            labelEmailClients.TabIndex = 23;
            labelEmailClients.Text = "Почта:";
            // 
            // textBoxEmailClients
            // 
            textBoxEmailClients.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxEmailClients.Location = new Point(292, 541);
            textBoxEmailClients.Margin = new Padding(4, 3, 4, 3);
            textBoxEmailClients.Name = "textBoxEmailClients";
            textBoxEmailClients.Size = new Size(455, 33);
            textBoxEmailClients.TabIndex = 17;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.ForeColor = Color.Black;
            labelAddress.Location = new Point(238, 593);
            labelAddress.Margin = new Padding(4, 0, 4, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(43, 15);
            labelAddress.TabIndex = 24;
            labelAddress.Text = "Адрес:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxAddress.Location = new Point(292, 583);
            textBoxAddress.Margin = new Padding(4, 3, 4, 3);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(455, 33);
            textBoxAddress.TabIndex = 18;
            // 
            // labelRegistrationDate
            // 
            labelRegistrationDate.AutoSize = true;
            labelRegistrationDate.ForeColor = Color.Black;
            labelRegistrationDate.Location = new Point(174, 636);
            labelRegistrationDate.Margin = new Padding(4, 0, 4, 0);
            labelRegistrationDate.Name = "labelRegistrationDate";
            labelRegistrationDate.Size = new Size(108, 15);
            labelRegistrationDate.TabIndex = 26;
            labelRegistrationDate.Text = "Дата регистрации:";
            // 
            // dateTimePickerRegistrationDate
            // 
            dateTimePickerRegistrationDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerRegistrationDate.Location = new Point(292, 622);
            dateTimePickerRegistrationDate.Name = "dateTimePickerRegistrationDate";
            dateTimePickerRegistrationDate.Size = new Size(455, 33);
            dateTimePickerRegistrationDate.TabIndex = 20;
            // 
            // AddFormClients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelFullNameClients);
            Controls.Add(textBoxFullNameClients);
            Controls.Add(labelPhoneClients);
            Controls.Add(maskedTextBoxPhoneClients);
            Controls.Add(labelEmailClients);
            Controls.Add(textBoxEmailClients);
            Controls.Add(labelAddress);
            Controls.Add(textBoxAddress);
            Controls.Add(labelRegistrationDate);
            Controls.Add(dateTimePickerRegistrationDate);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormClients";
            Text = "Добавить клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private Label labelFullNameClients;
        private TextBox textBoxFullNameClients;
        private Label labelPhoneClients;
        private MaskedTextBox maskedTextBoxPhoneClients;
        private Label labelEmailClients;
        private TextBox textBoxEmailClients;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private Label labelRegistrationDate;
        private DateTimePicker dateTimePickerRegistrationDate;
    }
}