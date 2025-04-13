namespace VetAutomate
{
    partial class AddFormServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormServices));
            labelTitle = new Label();
            label1 = new Label();
            buttonSave = new Button();
            labelServiceName = new Label();
            textBoxServiceName = new TextBox();
            labelPriceServices = new Label();
            textBoxPriceServices = new TextBox();
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
            label1.Size = new Size(62, 21);
            label1.TabIndex = 24;
            label1.Text = "Услуга";
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
            // labelServiceName
            // 
            labelServiceName.AutoSize = true;
            labelServiceName.ForeColor = Color.Black;
            labelServiceName.Location = new Point(185, 458);
            labelServiceName.Margin = new Padding(4, 0, 4, 0);
            labelServiceName.Name = "labelServiceName";
            labelServiceName.Size = new Size(93, 15);
            labelServiceName.TabIndex = 29;
            labelServiceName.Text = "Наименование:";
            // 
            // textBoxServiceName
            // 
            textBoxServiceName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxServiceName.Location = new Point(289, 447);
            textBoxServiceName.Margin = new Padding(4, 3, 4, 3);
            textBoxServiceName.Name = "textBoxServiceName";
            textBoxServiceName.Size = new Size(455, 33);
            textBoxServiceName.TabIndex = 27;
            // 
            // labelPriceServices
            // 
            labelPriceServices.AutoSize = true;
            labelPriceServices.ForeColor = Color.Black;
            labelPriceServices.Location = new Point(240, 503);
            labelPriceServices.Margin = new Padding(4, 0, 4, 0);
            labelPriceServices.Name = "labelPriceServices";
            labelPriceServices.Size = new Size(38, 15);
            labelPriceServices.TabIndex = 30;
            labelPriceServices.Text = "Цена:";
            // 
            // textBoxPriceServices
            // 
            textBoxPriceServices.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxPriceServices.Location = new Point(289, 492);
            textBoxPriceServices.Margin = new Padding(4, 3, 4, 3);
            textBoxPriceServices.Name = "textBoxPriceServices";
            textBoxPriceServices.Size = new Size(455, 33);
            textBoxPriceServices.TabIndex = 28;
            // 
            // AddFormServices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelServiceName);
            Controls.Add(textBoxServiceName);
            Controls.Add(labelPriceServices);
            Controls.Add(textBoxPriceServices);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormServices";
            Text = "Добавить услугу";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private Button buttonSave;
        private Label labelServiceName;
        private TextBox textBoxServiceName;
        private Label labelPriceServices;
        private TextBox textBoxPriceServices;
    }
}