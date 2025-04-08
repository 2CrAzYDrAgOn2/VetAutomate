namespace VetAutomate
{
    partial class AddFormPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormPayments));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelInvoiceIDPayments = new Label();
            textBoxInvoiceIDPayments = new TextBox();
            labelAmount = new Label();
            textBoxAmount = new TextBox();
            labelPaymentDate = new Label();
            dateTimePickerPaymentDate = new DateTimePicker();
            labelPaymentMethod = new Label();
            comboBoxPaymentMethod = new ComboBox();
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
            labelTitle.TabIndex = 10;
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
            label1.Size = new Size(67, 21);
            label1.TabIndex = 11;
            label1.Text = "Оплата";
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
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelInvoiceIDPayments
            // 
            labelInvoiceIDPayments.AutoSize = true;
            labelInvoiceIDPayments.ForeColor = Color.Black;
            labelInvoiceIDPayments.Location = new Point(207, 460);
            labelInvoiceIDPayments.Margin = new Padding(4, 0, 4, 0);
            labelInvoiceIDPayments.Name = "labelInvoiceIDPayments";
            labelInvoiceIDPayments.Size = new Size(76, 15);
            labelInvoiceIDPayments.TabIndex = 16;
            labelInvoiceIDPayments.Text = "Номер чека:";
            // 
            // textBoxInvoiceIDPayments
            // 
            textBoxInvoiceIDPayments.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxInvoiceIDPayments.Location = new Point(291, 449);
            textBoxInvoiceIDPayments.Margin = new Padding(4, 3, 4, 3);
            textBoxInvoiceIDPayments.Name = "textBoxInvoiceIDPayments";
            textBoxInvoiceIDPayments.Size = new Size(455, 33);
            textBoxInvoiceIDPayments.TabIndex = 12;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.ForeColor = Color.Black;
            labelAmount.Location = new Point(240, 505);
            labelAmount.Margin = new Padding(4, 0, 4, 0);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(43, 15);
            labelAmount.TabIndex = 17;
            labelAmount.Text = "Итого:";
            // 
            // textBoxAmount
            // 
            textBoxAmount.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxAmount.Location = new Point(291, 494);
            textBoxAmount.Margin = new Padding(4, 3, 4, 3);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(455, 33);
            textBoxAmount.TabIndex = 13;
            // 
            // labelPaymentDate
            // 
            labelPaymentDate.AutoSize = true;
            labelPaymentDate.ForeColor = Color.Black;
            labelPaymentDate.Location = new Point(204, 553);
            labelPaymentDate.Margin = new Padding(4, 0, 4, 0);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(79, 15);
            labelPaymentDate.TabIndex = 18;
            labelPaymentDate.Text = "Дата оплаты:";
            // 
            // dateTimePickerPaymentDate
            // 
            dateTimePickerPaymentDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerPaymentDate.Location = new Point(291, 539);
            dateTimePickerPaymentDate.Name = "dateTimePickerPaymentDate";
            dateTimePickerPaymentDate.Size = new Size(455, 33);
            dateTimePickerPaymentDate.TabIndex = 14;
            // 
            // labelPaymentMethod
            // 
            labelPaymentMethod.AutoSize = true;
            labelPaymentMethod.ForeColor = Color.Black;
            labelPaymentMethod.Location = new Point(187, 595);
            labelPaymentMethod.Margin = new Padding(4, 0, 4, 0);
            labelPaymentMethod.Name = "labelPaymentMethod";
            labelPaymentMethod.Size = new Size(96, 15);
            labelPaymentMethod.TabIndex = 19;
            labelPaymentMethod.Text = "Способ оплаты:";
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.AutoCompleteCustomSource.AddRange(new string[] { "Наличными", "Картой" });
            comboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentMethod.Font = new Font("Segoe UI", 14.25F);
            comboBoxPaymentMethod.FormattingEnabled = true;
            comboBoxPaymentMethod.Items.AddRange(new object[] { "Наличными", "Картой" });
            comboBoxPaymentMethod.Location = new Point(291, 584);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(455, 33);
            comboBoxPaymentMethod.TabIndex = 15;
            // 
            // AddFormPayments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelInvoiceIDPayments);
            Controls.Add(textBoxInvoiceIDPayments);
            Controls.Add(labelAmount);
            Controls.Add(textBoxAmount);
            Controls.Add(labelPaymentDate);
            Controls.Add(dateTimePickerPaymentDate);
            Controls.Add(labelPaymentMethod);
            Controls.Add(comboBoxPaymentMethod);
            Controls.Add(buttonSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddFormPayments";
            Text = "Добавить оплату";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelInvoiceIDPayments;
        private TextBox textBoxInvoiceIDPayments;
        private Label labelAmount;
        private TextBox textBoxAmount;
        private Label labelPaymentDate;
        private DateTimePicker dateTimePickerPaymentDate;
        private Label labelPaymentMethod;
        private ComboBox comboBoxPaymentMethod;
    }
}