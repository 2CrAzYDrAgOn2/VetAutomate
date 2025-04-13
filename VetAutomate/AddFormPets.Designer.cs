namespace VetAutomate
{
    partial class AddFormPets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormPets));
            buttonSave = new Button();
            labelTitle = new Label();
            label1 = new Label();
            labelNamePets = new Label();
            textBoxNamePets = new TextBox();
            labelSpecies = new Label();
            textBoxSpecies = new TextBox();
            labelBreed = new Label();
            textBoxBreed = new TextBox();
            labelBirthDatePets = new Label();
            dateTimePickerBirthDatePets = new DateTimePicker();
            labelOwnerID = new Label();
            textBoxOwnerID = new TextBox();
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
            label1.Size = new Size(80, 21);
            label1.TabIndex = 8;
            label1.Text = "Питомец";
            // 
            // labelNamePets
            // 
            labelNamePets.AutoSize = true;
            labelNamePets.ForeColor = Color.Black;
            labelNamePets.Location = new Point(232, 458);
            labelNamePets.Margin = new Padding(4, 0, 4, 0);
            labelNamePets.Name = "labelNamePets";
            labelNamePets.Size = new Size(50, 15);
            labelNamePets.TabIndex = 18;
            labelNamePets.Text = "Кличка:";
            // 
            // textBoxNamePets
            // 
            textBoxNamePets.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxNamePets.Location = new Point(292, 448);
            textBoxNamePets.Margin = new Padding(4, 3, 4, 3);
            textBoxNamePets.Name = "textBoxNamePets";
            textBoxNamePets.Size = new Size(455, 33);
            textBoxNamePets.TabIndex = 13;
            // 
            // labelSpecies
            // 
            labelSpecies.AutoSize = true;
            labelSpecies.ForeColor = Color.Black;
            labelSpecies.Location = new Point(215, 504);
            labelSpecies.Margin = new Padding(4, 0, 4, 0);
            labelSpecies.Name = "labelSpecies";
            labelSpecies.Size = new Size(66, 15);
            labelSpecies.TabIndex = 19;
            labelSpecies.Text = "Животное:";
            // 
            // textBoxSpecies
            // 
            textBoxSpecies.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxSpecies.Location = new Point(292, 493);
            textBoxSpecies.Margin = new Padding(4, 3, 4, 3);
            textBoxSpecies.Name = "textBoxSpecies";
            textBoxSpecies.Size = new Size(455, 33);
            textBoxSpecies.TabIndex = 14;
            // 
            // labelBreed
            // 
            labelBreed.AutoSize = true;
            labelBreed.ForeColor = Color.Black;
            labelBreed.Location = new Point(229, 553);
            labelBreed.Margin = new Padding(4, 0, 4, 0);
            labelBreed.Name = "labelBreed";
            labelBreed.Size = new Size(52, 15);
            labelBreed.TabIndex = 20;
            labelBreed.Text = "Порода:";
            // 
            // textBoxBreed
            // 
            textBoxBreed.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxBreed.Location = new Point(292, 542);
            textBoxBreed.Margin = new Padding(4, 3, 4, 3);
            textBoxBreed.Name = "textBoxBreed";
            textBoxBreed.Size = new Size(455, 33);
            textBoxBreed.TabIndex = 15;
            // 
            // labelBirthDatePets
            // 
            labelBirthDatePets.AutoSize = true;
            labelBirthDatePets.ForeColor = Color.Black;
            labelBirthDatePets.Location = new Point(189, 595);
            labelBirthDatePets.Margin = new Padding(4, 0, 4, 0);
            labelBirthDatePets.Name = "labelBirthDatePets";
            labelBirthDatePets.Size = new Size(93, 15);
            labelBirthDatePets.TabIndex = 21;
            labelBirthDatePets.Text = "Дата рождения:";
            // 
            // dateTimePickerBirthDatePets
            // 
            dateTimePickerBirthDatePets.Font = new Font("Segoe UI", 14.25F);
            dateTimePickerBirthDatePets.Location = new Point(293, 581);
            dateTimePickerBirthDatePets.Name = "dateTimePickerBirthDatePets";
            dateTimePickerBirthDatePets.Size = new Size(455, 33);
            dateTimePickerBirthDatePets.TabIndex = 16;
            // 
            // labelOwnerID
            // 
            labelOwnerID.AutoSize = true;
            labelOwnerID.ForeColor = Color.Black;
            labelOwnerID.Location = new Point(217, 639);
            labelOwnerID.Margin = new Padding(4, 0, 4, 0);
            labelOwnerID.Name = "labelOwnerID";
            labelOwnerID.Size = new Size(62, 15);
            labelOwnerID.TabIndex = 22;
            labelOwnerID.Text = "Владелец:";
            // 
            // textBoxOwnerID
            // 
            textBoxOwnerID.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOwnerID.Location = new Point(293, 629);
            textBoxOwnerID.Margin = new Padding(4, 3, 4, 3);
            textBoxOwnerID.Name = "textBoxOwnerID";
            textBoxOwnerID.Size = new Size(455, 33);
            textBoxOwnerID.TabIndex = 17;
            // 
            // AddFormPets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 841);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(labelNamePets);
            Controls.Add(textBoxNamePets);
            Controls.Add(labelSpecies);
            Controls.Add(textBoxSpecies);
            Controls.Add(labelBreed);
            Controls.Add(textBoxBreed);
            Controls.Add(labelBirthDatePets);
            Controls.Add(dateTimePickerBirthDatePets);
            Controls.Add(labelOwnerID);
            Controls.Add(textBoxOwnerID);
            Controls.Add(buttonSave);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFormPets";
            Text = "Добавить питомца";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private Label labelNamePets;
        private TextBox textBoxNamePets;
        private Label labelSpecies;
        private TextBox textBoxSpecies;
        private Label labelBreed;
        private TextBox textBoxBreed;
        private Label labelBirthDatePets;
        private DateTimePicker dateTimePickerBirthDatePets;
        private Label labelOwnerID;
        private TextBox textBoxOwnerID;
    }
}