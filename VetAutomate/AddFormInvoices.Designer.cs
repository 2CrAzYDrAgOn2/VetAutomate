namespace VetAutomate
{
    partial class AddFormInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormInvoices));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelClientIDInvoices = new Label();
            textBoxClientIDInvoices = new TextBox();
            labelTotalAmount = new Label();
            textBoxTotalAmount = new TextBox();
            labelInvoiceDate = new Label();
            dateTimePickerInvoiceDate = new DateTimePicker();
            labelPaid = new Label();
            checkBoxPaid = new CheckBox();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(245, 9);
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
            label1.Location = new Point(246, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 11;
            label1.Text = "Чек";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Transparent;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.Black;
            buttonSave.Location = new Point(332, 762);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(236, 65);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelClientIDInvoices
            // 
            labelClientIDInvoices.AutoSize = true;
            labelClientIDInvoices.ForeColor = Color.Black;
            labelClientIDInvoices.Location = new Point(237, 472);
            labelClientIDInvoices.Margin = new Padding(4, 0, 4, 0);
            labelClientIDInvoices.Name = "labelClientIDInvoices";
            labelClientIDInvoices.Size = new Size(49, 15);
            labelClientIDInvoices.TabIndex = 16;
            labelClientIDInvoices.Text = "Клиент:";
            // 
            // textBoxClientIDInvoices
            // 
            textBoxClientIDInvoices.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxClientIDInvoices.Location = new Point(294, 461);
            textBoxClientIDInvoices.Margin = new Padding(4, 3, 4, 3);
            textBoxClientIDInvoices.Name = "textBoxClientIDInvoices";
            textBoxClientIDInvoices.Size = new Size(455, 33);
            textBoxClientIDInvoices.TabIndex = 12;
            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.ForeColor = Color.Black;
            labelTotalAmount.Location = new Point(243, 517);
            labelTotalAmount.Margin = new Padding(4, 0, 4, 0);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new Size(43, 15);
            labelTotalAmount.TabIndex = 17;
            labelTotalAmount.Text = "Итого:";
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxTotalAmount.Location = new Point(294, 506);
            textBoxTotalAmount.Margin = new Padding(4, 3, 4, 3);
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.Size = new Size(455, 33);
            textBoxTotalAmount.TabIndex = 13;
            // 
            // labelInvoiceDate
            // 
            labelInvoiceDate.AutoSize = true;
            labelInvoiceDate.ForeColor = Color.Black;
            labelInvoiceDate.Location = new Point(172, 565);
            labelInvoiceDate.Margin = new Padding(4, 0, 4, 0);
            labelInvoiceDate.Name = "labelInvoiceDate";
            labelInvoiceDate.Size = new Size(114, 15);
            labelInvoiceDate.TabIndex = 18;
            labelInvoiceDate.Text = "Дата выписывания:";
            // 
            // dateTimePickerInvoiceDate
            // 
            dateTimePickerInvoiceDate.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerInvoiceDate.Location = new Point(294, 551);
            dateTimePickerInvoiceDate.Name = "dateTimePickerInvoiceDate";
            dateTimePickerInvoiceDate.Size = new Size(455, 33);
            dateTimePickerInvoiceDate.TabIndex = 14;
            // 
            // labelPaid
            // 
            labelPaid.AutoSize = true;
            labelPaid.ForeColor = Color.Black;
            labelPaid.Location = new Point(236, 607);
            labelPaid.Margin = new Padding(4, 0, 4, 0);
            labelPaid.Name = "labelPaid";
            labelPaid.Size = new Size(50, 15);
            labelPaid.TabIndex = 19;
            labelPaid.Text = "Оплата:";
            // 
            // checkBoxPaid
            // 
            checkBoxPaid.AutoSize = true;
            checkBoxPaid.Font = new Font("Segoe UI", 14.25F);
            checkBoxPaid.Location = new Point(294, 598);
            checkBoxPaid.Name = "checkBoxPaid";
            checkBoxPaid.Size = new Size(108, 29);
            checkBoxPaid.TabIndex = 15;
            checkBoxPaid.Text = "Оплачен";
            checkBoxPaid.UseVisualStyleBackColor = true;
            // 
            // AddFormInvoices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelClientIDInvoices);
            Controls.Add(textBoxClientIDInvoices);
            Controls.Add(labelTotalAmount);
            Controls.Add(textBoxTotalAmount);
            Controls.Add(labelInvoiceDate);
            Controls.Add(dateTimePickerInvoiceDate);
            Controls.Add(labelPaid);
            Controls.Add(checkBoxPaid);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormInvoices";
            Text = "Добавить чек";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelClientIDInvoices;
        private TextBox textBoxClientIDInvoices;
        private Label labelTotalAmount;
        private TextBox textBoxTotalAmount;
        private Label labelInvoiceDate;
        private DateTimePicker dateTimePickerInvoiceDate;
        private Label labelPaid;
        private CheckBox checkBoxPaid;
    }
}