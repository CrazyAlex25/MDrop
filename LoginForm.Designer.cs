namespace MDrop
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tbEmailCode = new System.Windows.Forms.TextBox();
            this.labelEmailCode = new System.Windows.Forms.Label();
            this.imgCaptcha = new System.Windows.Forms.PictureBox();
            this.tbCaptcha = new System.Windows.Forms.TextBox();
            this.labelCaptcha = new System.Windows.Forms.Label();
            this.btnAuth = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(12, 15);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(60, 15);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(141, 12);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(206, 23);
            this.tbUsername.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(141, 41);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(206, 23);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 44);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            // 
            // tbEmailCode
            // 
            this.tbEmailCode.Location = new System.Drawing.Point(141, 70);
            this.tbEmailCode.Name = "tbEmailCode";
            this.tbEmailCode.Size = new System.Drawing.Size(206, 23);
            this.tbEmailCode.TabIndex = 5;
            this.tbEmailCode.Visible = false;
            // 
            // labelEmailCode
            // 
            this.labelEmailCode.AutoSize = true;
            this.labelEmailCode.Location = new System.Drawing.Point(12, 73);
            this.labelEmailCode.Name = "labelEmailCode";
            this.labelEmailCode.Size = new System.Drawing.Size(65, 15);
            this.labelEmailCode.TabIndex = 4;
            this.labelEmailCode.Text = "EMail code";
            this.labelEmailCode.Visible = false;
            // 
            // imgCaptcha
            // 
            this.imgCaptcha.Location = new System.Drawing.Point(141, 99);
            this.imgCaptcha.Name = "imgCaptcha";
            this.imgCaptcha.Size = new System.Drawing.Size(206, 40);
            this.imgCaptcha.TabIndex = 2;
            this.imgCaptcha.TabStop = false;
            this.imgCaptcha.Visible = false;
            // 
            // tbCaptcha
            // 
            this.tbCaptcha.Location = new System.Drawing.Point(141, 145);
            this.tbCaptcha.Name = "tbCaptcha";
            this.tbCaptcha.Size = new System.Drawing.Size(206, 23);
            this.tbCaptcha.TabIndex = 7;
            this.tbCaptcha.Visible = false;
            // 
            // labelCaptcha
            // 
            this.labelCaptcha.AutoSize = true;
            this.labelCaptcha.Location = new System.Drawing.Point(12, 148);
            this.labelCaptcha.Name = "labelCaptcha";
            this.labelCaptcha.Size = new System.Drawing.Size(51, 15);
            this.labelCaptcha.TabIndex = 6;
            this.labelCaptcha.Text = "Captcha";
            this.labelCaptcha.Visible = false;
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(272, 174);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(75, 23);
            this.btnAuth.TabIndex = 8;
            this.btnAuth.Text = "Auth";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(12, 203);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(335, 78);
            this.tbMessage.TabIndex = 9;
            this.tbMessage.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnAuth;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 293);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.labelCaptcha);
            this.Controls.Add(this.tbCaptcha);
            this.Controls.Add(this.imgCaptcha);
            this.Controls.Add(this.labelEmailCode);
            this.Controls.Add(this.tbEmailCode);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.labelUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tbEmailCode;
        private System.Windows.Forms.Label labelEmailCode;
        private System.Windows.Forms.PictureBox imgCaptcha;
        private System.Windows.Forms.TextBox tbCaptcha;
        private System.Windows.Forms.Label labelCaptcha;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.TextBox tbMessage;
    }
}