using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

using MDrop.Http;
using MDrop.MagicDrop;

namespace MDrop
{
    public partial class MainWindow : Form
    {
        private readonly HttpClient httpClient;
        private readonly MagicDropManager magicDropManager;

        UserSettings userSettings;

        private readonly Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            labelCurrentUser.Text = string.Empty;


            this.FormClosing += (o, e) =>
             {
                 userSettings.Save();
             };

            btnAuth.BackColor = Color.Red;


            userSettings = UserSettings.Load();

            httpClient = new HttpClient(new CookiesStoreHandler());
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

            magicDropManager = new MagicDropManager(httpClient);

            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Start();

            Task.Run(async () =>
            {
                if (!await CheckAuth())
                {
                    btnAuth_Click(this, EventArgs.Empty);
                }
            });
        }



        private async Task<bool> CheckAuth()
        {
            var auth = await magicDropManager.CheckAuthorizedAsync();
            btnAuth.BackColor = auth ? Color.Green : Color.Red;
            return auth;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {

            ChangeTimerInterval();
            await CheckAuth();
            var status = await magicDropManager.RegisterFreeCaseAsync();
            statusLine.Text = DateTime.Now.ToShortTimeString()+"   "+status.ToString();

            var lastUser = await magicDropManager.GetLastWinnerAsync();

            labelCurrentUser.Text = lastUser.username;

            var item = WinnerToListViewItem(lastUser.winner);

            if (!string.IsNullOrEmpty(lastUser.username) &&
                item.Text.Contains(lastUser.username))
            {
                item.BackColor = Color.Red;
            }

            listView1.BeginUpdate();
            listView1.Items.Add(item);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Items[listView1.Items.Count - 1].EnsureVisible();
            listView1.EndUpdate();
        }

        private ListViewItem WinnerToListViewItem(MagicDropWinner winner)
        {
            return new ListViewItem(new string[]
            {
                winner.Date,
                winner.Winner,
                winner.Weapon,
                winner.Skin,
                winner.Price
            });

        }



        private void ChangeTimerInterval()
        {
            int max_minutes = 10;
            var rnd = new Random();
            var minutes = rnd.Next(max_minutes / 2, max_minutes);
            var interval = DateTime.Now.AddMinutes(minutes) - DateTime.Now;

            timer.Interval = (int)interval.TotalMilliseconds;
        }



        private async void btnAuth_Click(object sender, EventArgs e)
        {
            var steam = new Steam.SteamLoginManager(httpClient);
            var form = new LoginForm(userSettings, steam);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await steam.LoginOpenIdAsync(magicDropManager.OpenIdUrl);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Timer_Tick(this, EventArgs.Empty);
        }
    }
}
