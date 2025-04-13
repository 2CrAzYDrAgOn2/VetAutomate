namespace VetAutomate
{
    partial class AddFormMedications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormMedications));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelNameMedications = new Label();
            textBoxNameMedications = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
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
            label1.Size = new Size(93, 21);
            label1.TabIndex = 11;
            label1.Text = "Лекарство";
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
            // labelNameMedications
            // 
            labelNameMedications.AutoSize = true;
            labelNameMedications.ForeColor = Color.Black;
            labelNameMedications.Location = new Point(222, 480);
            labelNameMedications.Margin = new Padding(4, 0, 4, 0);
            labelNameMedications.Name = "labelNameMedications";
            labelNameMedications.Size = new Size(62, 15);
            labelNameMedications.TabIndex = 15;
            labelNameMedications.Text = "Название:";
            // 
            // textBoxNameMedications
            // 
            textBoxNameMedications.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNameMedications.Location = new Point(292, 469);
            textBoxNameMedications.Margin = new Padding(4, 3, 4, 3);
            textBoxNameMedications.Name = "textBoxNameMedications";
            textBoxNameMedications.Size = new Size(455, 33);
            textBoxNameMedications.TabIndex = 12;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.ForeColor = Color.Black;
            labelDescription.Location = new Point(219, 525);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(65, 15);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "Описание:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxDescription.Location = new Point(292, 514);
            textBoxDescription.Margin = new Padding(4, 3, 4, 3);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(455, 33);
            textBoxDescription.TabIndex = 13;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.ForeColor = Color.Black;
            labelPrice.Location = new Point(246, 573);
            labelPrice.Margin = new Padding(4, 0, 4, 0);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(38, 15);
            labelPrice.TabIndex = 17;
            labelPrice.Text = "Цена:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPrice.Location = new Point(292, 562);
            textBoxPrice.Margin = new Padding(4, 3, 4, 3);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(455, 33);
            textBoxPrice.TabIndex = 14;
            // 
            // AddFormMedications
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelNameMedications);
            Controls.Add(textBoxNameMedications);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelPrice);
            Controls.Add(textBoxPrice);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormMedications";
            Text = "Добавить лекарство";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelNameMedications;
        private TextBox textBoxNameMedications;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Label labelPrice;
        private TextBox textBoxPrice;
    }
}