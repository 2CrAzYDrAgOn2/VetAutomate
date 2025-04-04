namespace VetAutomate
{
    partial class AddFormLoans
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
            buttonSave = new Button();
            labelTitle = new Label();
            label1 = new Label();
            labelRegistrationIDLoans = new Label();
            textBoxRegistrationIDLoans = new TextBox();
            labelBookIDLoans = new Label();
            textBoxBookIDLoans = new TextBox();
            labelLoanDateLoans = new Label();
            dateTimePickerLoanDateLoans = new DateTimePicker();
            labelReturnDateLoans = new Label();
            labelIsReturnedLoans = new Label();
            textBoxIsReturnedLoans = new TextBox();
            dateTimePickerReturnDateLoans = new DateTimePicker();
            checkBoxReturnDateLoans = new CheckBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(377, 1017);
            buttonSave.Margin = new Padding(5, 4, 5, 4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(270, 87);
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
            labelTitle.Location = new Point(278, 13);
            labelTitle.Margin = new Padding(5, 0, 5, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(223, 32);
            labelTitle.TabIndex = 7;
            labelTitle.Text = "Создание записи:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(279, 52);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 28);
            label1.TabIndex = 8;
            label1.Text = "Выдача";
            // 
            // labelRegistrationIDLoans
            // 
            labelRegistrationIDLoans.AutoSize = true;
            labelRegistrationIDLoans.BackColor = Color.Transparent;
            labelRegistrationIDLoans.ForeColor = Color.Black;
            labelRegistrationIDLoans.Location = new Point(177, 612);
            labelRegistrationIDLoans.Margin = new Padding(5, 0, 5, 0);
            labelRegistrationIDLoans.Name = "labelRegistrationIDLoans";
            labelRegistrationIDLoans.Size = new Size(155, 20);
            labelRegistrationIDLoans.TabIndex = 9;
            labelRegistrationIDLoans.Text = "Логин пользователя:";
            // 
            // textBoxRegistrationIDLoans
            // 
            textBoxRegistrationIDLoans.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxRegistrationIDLoans.Location = new Point(334, 597);
            textBoxRegistrationIDLoans.Margin = new Padding(5, 4, 5, 4);
            textBoxRegistrationIDLoans.Name = "textBoxRegistrationIDLoans";
            textBoxRegistrationIDLoans.Size = new Size(519, 39);
            textBoxRegistrationIDLoans.TabIndex = 0;
            // 
            // labelBookIDLoans
            // 
            labelBookIDLoans.AutoSize = true;
            labelBookIDLoans.BackColor = Color.Transparent;
            labelBookIDLoans.ForeColor = Color.Black;
            labelBookIDLoans.Location = new Point(226, 672);
            labelBookIDLoans.Margin = new Padding(5, 0, 5, 0);
            labelBookIDLoans.Name = "labelBookIDLoans";
            labelBookIDLoans.Size = new Size(104, 20);
            labelBookIDLoans.TabIndex = 10;
            labelBookIDLoans.Text = "Номер книги:";
            // 
            // textBoxBookIDLoans
            // 
            textBoxBookIDLoans.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxBookIDLoans.Location = new Point(334, 657);
            textBoxBookIDLoans.Margin = new Padding(5, 4, 5, 4);
            textBoxBookIDLoans.Name = "textBoxBookIDLoans";
            textBoxBookIDLoans.Size = new Size(519, 39);
            textBoxBookIDLoans.TabIndex = 1;
            // 
            // labelLoanDateLoans
            // 
            labelLoanDateLoans.AutoSize = true;
            labelLoanDateLoans.BackColor = Color.Transparent;
            labelLoanDateLoans.ForeColor = Color.Black;
            labelLoanDateLoans.Location = new Point(231, 736);
            labelLoanDateLoans.Margin = new Padding(5, 0, 5, 0);
            labelLoanDateLoans.Name = "labelLoanDateLoans";
            labelLoanDateLoans.Size = new Size(100, 20);
            labelLoanDateLoans.TabIndex = 11;
            labelLoanDateLoans.Text = "Дата выдачи:";
            // 
            // dateTimePickerLoanDateLoans
            // 
            dateTimePickerLoanDateLoans.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerLoanDateLoans.Location = new Point(334, 717);
            dateTimePickerLoanDateLoans.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerLoanDateLoans.Name = "dateTimePickerLoanDateLoans";
            dateTimePickerLoanDateLoans.Size = new Size(519, 39);
            dateTimePickerLoanDateLoans.TabIndex = 2;
            // 
            // labelReturnDateLoans
            // 
            labelReturnDateLoans.AutoSize = true;
            labelReturnDateLoans.BackColor = Color.Transparent;
            labelReturnDateLoans.ForeColor = Color.Black;
            labelReturnDateLoans.Location = new Point(223, 792);
            labelReturnDateLoans.Margin = new Padding(5, 0, 5, 0);
            labelReturnDateLoans.Name = "labelReturnDateLoans";
            labelReturnDateLoans.Size = new Size(111, 20);
            labelReturnDateLoans.TabIndex = 12;
            labelReturnDateLoans.Text = "Дата возврата:";
            // 
            // labelIsReturnedLoans
            // 
            labelIsReturnedLoans.AutoSize = true;
            labelIsReturnedLoans.BackColor = Color.Transparent;
            labelIsReturnedLoans.ForeColor = Color.Black;
            labelIsReturnedLoans.Location = new Point(269, 852);
            labelIsReturnedLoans.Margin = new Padding(5, 0, 5, 0);
            labelIsReturnedLoans.Name = "labelIsReturnedLoans";
            labelIsReturnedLoans.Size = new Size(55, 20);
            labelIsReturnedLoans.TabIndex = 13;
            labelIsReturnedLoans.Text = "Статус:";
            // 
            // textBoxIsReturnedLoans
            // 
            textBoxIsReturnedLoans.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxIsReturnedLoans.Location = new Point(334, 837);
            textBoxIsReturnedLoans.Margin = new Padding(5, 4, 5, 4);
            textBoxIsReturnedLoans.Name = "textBoxIsReturnedLoans";
            textBoxIsReturnedLoans.ReadOnly = true;
            textBoxIsReturnedLoans.Size = new Size(519, 39);
            textBoxIsReturnedLoans.TabIndex = 5;
            // 
            // dateTimePickerReturnDateLoans
            // 
            dateTimePickerReturnDateLoans.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerReturnDateLoans.Location = new Point(334, 773);
            dateTimePickerReturnDateLoans.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerReturnDateLoans.Name = "dateTimePickerReturnDateLoans";
            dateTimePickerReturnDateLoans.Size = new Size(278, 39);
            dateTimePickerReturnDateLoans.TabIndex = 3;
            // 
            // checkBoxReturnDateLoans
            // 
            checkBoxReturnDateLoans.AutoSize = true;
            checkBoxReturnDateLoans.BackColor = Color.Transparent;
            checkBoxReturnDateLoans.Font = new Font("Segoe UI", 14.25F);
            checkBoxReturnDateLoans.ForeColor = Color.WhiteSmoke;
            checkBoxReturnDateLoans.Location = new Point(619, 780);
            checkBoxReturnDateLoans.Margin = new Padding(3, 4, 3, 4);
            checkBoxReturnDateLoans.Name = "checkBoxReturnDateLoans";
            checkBoxReturnDateLoans.Size = new Size(258, 36);
            checkBoxReturnDateLoans.TabIndex = 4;
            checkBoxReturnDateLoans.Text = "Еще не возвращена";
            checkBoxReturnDateLoans.UseVisualStyleBackColor = false;
            checkBoxReturnDateLoans.CheckedChanged += CheckBoxReturnDateLoans_CheckedChanged;
            // 
            // AddFormLoans
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1024, 1121);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelRegistrationIDLoans);
            Controls.Add(textBoxRegistrationIDLoans);
            Controls.Add(labelBookIDLoans);
            Controls.Add(textBoxBookIDLoans);
            Controls.Add(labelLoanDateLoans);
            Controls.Add(dateTimePickerLoanDateLoans);
            Controls.Add(labelReturnDateLoans);
            Controls.Add(dateTimePickerReturnDateLoans);
            Controls.Add(checkBoxReturnDateLoans);
            Controls.Add(labelIsReturnedLoans);
            Controls.Add(textBoxIsReturnedLoans);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormLoans";
            Text = "Добавить выдачу";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private Label labelRegistrationIDLoans;
        private TextBox textBoxRegistrationIDLoans;
        private Label labelBookIDLoans;
        private TextBox textBoxBookIDLoans;
        private Label labelLoanDateLoans;
        private DateTimePicker dateTimePickerLoanDateLoans;
        private Label labelReturnDateLoans;
        private Label labelIsReturnedLoans;
        private TextBox textBoxIsReturnedLoans;
        private DateTimePicker dateTimePickerReturnDateLoans;
        private CheckBox checkBoxReturnDateLoans;
    }
}