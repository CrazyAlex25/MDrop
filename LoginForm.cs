using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using MDrop.Steam;
using MDrop.Steam.Data;

namespace MDrop
{
    public partial class LoginForm : Form
    {
        private readonly UserSettings userSettings;
        private readonly SteamLoginManager steam;
        private readonly SteamUser user;

        public LoginForm(UserSettings userSettings,SteamLoginManager steam)
        {
            InitializeComponent();
            this.userSettings = userSettings;
            this.steam = steam;

            user = new SteamUser
            {
                Username = userSettings.Username,
                Password = userSettings.Password
            };

            Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbUsername.Text = user.Username;
            tbPassword.Text = user.Password;


            this.FormClosing += (o, e) =>
            {
                userSettings.Username = user.Username;
                userSettings.Password = user.Password;
                userSettings.Save();
            };

            if (!string.IsNullOrEmpty(user.Username) &&
                !string.IsNullOrEmpty(user.Password))
            {
                btnAuth_Click(this, EventArgs.Empty);
            }
        }

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            user.Username = tbUsername.Text;
            user.Password = tbPassword.Text;
            user.EMailCode = tbEmailCode.Text;
            user.Captcha = tbCaptcha.Text;

        


            var status = await steam.Login(user);
            if (status.Success)
            {
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

         
            labelEmailCode.Visible = status.EMailAuth_Needed;
            tbEmailCode.Visible = status.EMailAuth_Needed;

            labelCaptcha.Visible = status.Captcha_Needed;
            tbCaptcha.Visible = status.Captcha_Needed;
            imgCaptcha.Visible = status.Captcha_Needed;
            if(status.CaptchaImg!=null)
                imgCaptcha.Image = GetBitmap(status.CaptchaImg);

            tbMessage.Visible = !status.Success;
            tbMessage.Text = status.Message;
        }
        private Bitmap GetBitmap(byte[] data)
        {
            using(var mem=new MemoryStream(data))
            {
                return new Bitmap(mem);
            }
        }
    }
}
