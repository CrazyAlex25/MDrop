using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MDrop
{
	public sealed class NotificationIcon : IDisposable
	{
		private NotifyIcon notifyIcon;

        private readonly MainWindow mainWindow;
      
		public NotificationIcon()
		{
			notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = Properties.Resources.favicon;
            var notificationMenu = new ContextMenuStrip();
			notificationMenu.Items.Add("Show", null, onShowClick);
			notificationMenu.Items.Add("Exit", null, onExitClick);

            notifyIcon.ContextMenuStrip = notificationMenu;

            notifyIcon.DoubleClick += onShowClick;

            mainWindow = new MainWindow();
            mainWindow.FormClosing += (o, e) =>
              {
                  if(e.CloseReason!=CloseReason.UserClosing)
                  {
                      mainWindow.Close();
                  }
                  e.Cancel = true;
                  mainWindow.Hide();
              };
            
		}

        private void onShowClick(object sender, EventArgs e)
        {
            mainWindow.Show();
        }

        private void onExitClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
			Application.Exit();
            // HACK: force exit
            Process.GetCurrentProcess().Kill();
		}


        #region dispose
        private bool disposedValue;
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    notifyIcon.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
