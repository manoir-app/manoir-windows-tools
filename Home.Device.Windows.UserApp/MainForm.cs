using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Home.Device.Windows.UserApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            using (var k = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
            {
                if (k != null)
                {
                    var val = (int)k.GetValue("SystemUsesLightTheme");
                    if (val == 0)
                        notifyIcon1.Icon = new Icon(typeof(MainForm).Assembly.GetManifestResourceStream("Home.Device.Windows.UserApp.icon-clair.ico"));
                    else
                        notifyIcon1.Icon = new Icon(typeof(MainForm).Assembly.GetManifestResourceStream("Home.Device.Windows.UserApp.icon-noir.ico"));
                }
            }

            notifyIcon1.Text = "Home Automation";

            if (CheckCredentials())
            {
                SignalRClient.SetupSignalRClient();
            }
        }

        
       

        private bool CheckCredentials()
        {
            var c = HomeDeviceHelper.GetSavedCredentials();
            if(c==null)
            {
                menuItemConnexion.Visible = true;
                menuSeparatorConnexion.Visible = true;
                pnlConnexion.Visible = true;
                return false;
            }
            else
            {
                menuItemConnexion.Visible = false;
                menuSeparatorConnexion.Visible = false;
                pnlConnexion.Visible = false;
                return true;
            }
        }


        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1.ContextMenuStrip.Show();
        }

        bool isExiting = false;

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem == menuitemExit)
            {
                isExiting = true;
                Application.Exit();
            }
            else if (e.ClickedItem == menuItemConnexion)
            {
                ShowTheDialog();
            }
        }

       

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExiting)
                return;

            e.Cancel = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void ShowTheDialog()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private async void btnConnexion_Click(object sender, EventArgs e)
        {
            txtServer.Enabled = false;
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
            btnConnexion.Enabled = false;

            await HomeDeviceHelper.TestConnection(txtServer.Text, txtUser.Text, txtPassword.Text);

            this.Invoke(new Action(() => { 
                if(CheckCredentials())
                {
                    SignalRClient.SetupSignalRClient();
                    this.ShowInTaskbar = false;
                    this.WindowState = FormWindowState.Minimized;
                }
                txtServer.Enabled = true;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                btnConnexion.Enabled = true;
            }));
        }
    }
}
