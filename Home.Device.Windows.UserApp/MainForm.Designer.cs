
namespace Home.Device.Windows.UserApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemConnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparatorConnexion = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlConnexion = new System.Windows.Forms.Panel();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlConnexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.menuMain;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnexion,
            this.menuSeparatorConnexion,
            this.menuitemExit});
            this.menuMain.Name = "contextMenuStrip1";
            this.menuMain.Size = new System.Drawing.Size(149, 58);
            this.menuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // menuItemConnexion
            // 
            this.menuItemConnexion.Name = "menuItemConnexion";
            this.menuItemConnexion.Size = new System.Drawing.Size(148, 24);
            this.menuItemConnexion.Text = "Connexion";
            // 
            // menuSeparatorConnexion
            // 
            this.menuSeparatorConnexion.Name = "menuSeparatorConnexion";
            this.menuSeparatorConnexion.Size = new System.Drawing.Size(145, 6);
            // 
            // menuitemExit
            // 
            this.menuitemExit.Name = "menuitemExit";
            this.menuitemExit.Size = new System.Drawing.Size(148, 24);
            this.menuitemExit.Text = "Exit";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 125);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(625, 81);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOME AUTOMATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlConnexion
            // 
            this.pnlConnexion.Controls.Add(this.btnConnexion);
            this.pnlConnexion.Controls.Add(this.txtPassword);
            this.pnlConnexion.Controls.Add(this.label5);
            this.pnlConnexion.Controls.Add(this.txtUser);
            this.pnlConnexion.Controls.Add(this.label4);
            this.pnlConnexion.Controls.Add(this.txtServer);
            this.pnlConnexion.Controls.Add(this.label3);
            this.pnlConnexion.Controls.Add(this.label2);
            this.pnlConnexion.Location = new System.Drawing.Point(12, 126);
            this.pnlConnexion.Name = "pnlConnexion";
            this.pnlConnexion.Size = new System.Drawing.Size(616, 222);
            this.pnlConnexion.TabIndex = 2;
            // 
            // btnConnexion
            // 
            this.btnConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(221)))));
            this.btnConnexion.ForeColor = System.Drawing.Color.White;
            this.btnConnexion.Location = new System.Drawing.Point(449, 175);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(141, 38);
            this.btnConnexion.TabIndex = 7;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(175, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "ex : #password#";
            this.txtPassword.Size = new System.Drawing.Size(415, 27);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mot de passe";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(175, 109);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "ex : adminuser";
            this.txtUser.Size = new System.Drawing.Size(415, 27);
            this.txtUser.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Utilisateur";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(175, 53);
            this.txtServer.Name = "txtServer";
            this.txtServer.PlaceholderText = "ex : home.mondomaine.com";
            this.txtServer.Size = new System.Drawing.Size(415, 27);
            this.txtServer.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nom du serveur";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(417, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vous n\'êtes pas connecté à votre mesh Home Automation.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.pnlConnexion);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Automation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlConnexion.ResumeLayout(false);
            this.pnlConnexion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuitemExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlConnexion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnexion;
        private System.Windows.Forms.ToolStripSeparator menuSeparatorConnexion;
    }
}

