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
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var frm = new MainForm();
            frm.ShowInTaskbar = false;
            frm.WindowState = FormWindowState.Minimized;
            frm.Visible = false;
            Application.Run(frm);
        }
    }
}
