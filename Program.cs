using System;
using System.Threading;
using System.Windows.Forms;

namespace MDrop
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

		
			// Please use a unique name for the mutex to prevent conflicts with other programs
			using (Mutex mtx = new Mutex(true, typeof(Program).Namespace+"Mutex", out bool isFirstInstance))
			{
				if (isFirstInstance)
				{
					NotificationIcon notificationIcon = new NotificationIcon();
					Application.Run();
					notificationIcon.Dispose();
				}
				else
				{
					// The application is already running
					// TODO: Display message box or change focus to existing application instance
				}
			} 
        }
    }
}
