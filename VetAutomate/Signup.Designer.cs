namespace VetAutomate
{
    partial class Signup
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
            buttonEnter = new Button();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            labelRegister = new Label();
            labelPassword = new Label();
            labelLogin = new Label();
            buttonClear = new Button();
            buttonShow = new Button();
            SuspendLayout();
            // 
            // buttonEnter
            // 
            buttonEnter.BackColor = Color.Transparent;
            buttonEnter.FlatStyle = FlatStyle.Flat;
            buttonEnter.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonEnter.ForeColor = Color.Black;
            buttonEnter.Location = new Point(485, 465);
            buttonEnter.Margin = new Padding(3, 4, 3, 4);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(263, 124);
            buttonEnter.TabIndex = 2;
            buttonEnter.Text = "Войти";
            buttonEnter.UseVisualStyleBackColor = false;
            buttonEnter.Click += ButtonEnter_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxPassword.Location = new Point(339, 333);
            textBoxPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxPassword.MaxLength = 50;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '•';
            textBoxPassword.Size = new Size(551, 114);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxLogin.Location = new Point(339, 201);
            textBoxLogin.Margin = new Padding(3, 4, 3, 4);
            textBoxLogin.MaxLength = 50;
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(551, 114);
            textBoxLogin.TabIndex = 0;
            // 
            // labelRegister
            // 
            labelRegister.AutoSize = true;
            labelRegister.BackColor = Color.Transparent;
            labelRegister.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelRegister.ForeColor = Color.Black;
            labelRegister.Location = new Point(341, 16);
            labelRegister.Name = "labelRegister";
            labelRegister.Size = new Size(514, 106);
            labelRegister.TabIndex = 5;
            labelRegister.Text = "Регистрация";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelPassword.ForeColor = Color.Black;
            labelPassword.Location = new Point(14, 337);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(348, 106);
            labelPassword.TabIndex = 7;
            labelPassword.Text = "Пароль:";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.BackColor = Color.Transparent;
            labelLogin.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelLogin.ForeColor = Color.Black;
            labelLogin.Location = new Point(62, 205);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(295, 106);
            labelLogin.TabIndex = 6;
            labelLogin.Text = "Логин:";
            // 
            // buttonClear
            // 
            buttonClear.BackColor = Color.Transparent;
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(1032, 16);
            buttonClear.Margin = new Padding(3, 4, 3, 4);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(106, 124);
            buttonClear.TabIndex = 3;
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += ButtonClear_Click;
            // 
            // buttonShow
            // 
            buttonShow.BackColor = Color.Transparent;
            buttonShow.BackgroundImageLayout = ImageLayout.Center;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.Location = new Point(898, 333);
            buttonShow.Margin = new Padding(3, 4, 3, 4);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(106, 124);
            buttonShow.TabIndex = 4;
            buttonShow.UseVisualStyleBackColor = false;
            buttonShow.Click += ButtonShow_Click;
            // 
            // Signup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 716);
            Controls.Add(textBoxLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonEnter);
            Controls.Add(buttonClear);
            Controls.Add(buttonShow);
            Controls.Add(labelRegister);
            Controls.Add(labelLogin);
            Controls.Add(labelPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            Name = "Signup";
            Text = "Signup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEnter;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label labelRegister;
        private Label labelPassword;
        private Label labelLogin;
        private Button buttonClear;
        private Button buttonShow;
    }
}