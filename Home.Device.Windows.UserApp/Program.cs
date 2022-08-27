using Home.Device.Windows.UserApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home.Device.Windows.UserApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool shouldStartUi = true;
            if (args != null && args.Length > 0)
            {
                foreach (var arg in args)
                {
                    if (arg.StartsWith("magnet:"))
                    {
                        HandleMagnetDownload(arg);
                        shouldStartUi = false;
                    }
                }
            }

            if (!shouldStartUi)
                return;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var frm = new MainForm();
            frm.ShowInTaskbar = false;
            frm.WindowState = FormWindowState.Minimized;
            //frm.Visible = false;

            

            Application.Run(frm);
        }

        private static void HandleMagnetDownload(string arg)
        {
            var c = HomeDeviceHelper.GetSavedCredentials();
            if (c != null)
            {
                bool b = new DownloadsBll().QueueMagnetDownload(arg).Result;
                if (!b)
                    MessageBox.Show("Unable to add download !", "magnet url handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
