using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace SafeBot
{
    public partial class SafeBotMenu : Form
    {
        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle = WS_EX_NOACTIVATE;
                return createParams;
            }
        }

        public SafeBotMenu()
        {
            InitializeComponent();
        }

        private void SafeBotMenu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(461, 19);
            this.Location = new Point(Client.SafeBotMenu_X, Client.SafeBotMenu_Y);
            WindowsHandlers.AnimateWindow(this.Handle, 300, WindowsHandlers.AW_HOR_POSITIVE);
        }

        private void Healerp_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.Healerw.ShowDialog();
        }

        private void SafeBotMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowsHandlers.AnimateWindow(this.Handle, 300, WindowsHandlers.AW_HOR_NEGATIVE | WindowsHandlers.AW_HIDE);
        }

        private void OnFocus_Tick(object sender, EventArgs e)
        {
            if (this.Focused == false)
            {
                WindowsHandlers.AnimateWindow(this.Handle, 300, WindowsHandlers.AW_HOR_NEGATIVE | WindowsHandlers.AW_HIDE);
                this.Dispose(true);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.sHotkeysw.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Save_All_Click(object sender, EventArgs e)
        {
            Core.SaveMenu save = new Core.SaveMenu();
            save.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            save.Show();
        }

        private void Toolsp_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.Toolsw.ShowDialog();
        }

        private void WarToolsMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.WarToolsw.ShowDialog();
        }

        private void Looterp_Click(object sender, EventArgs e)
        {
        }

        private void Scripter_Click(object sender, EventArgs e)
        {
            Ingame.Scripter script = new Ingame.Scripter();
            script.Show();

        }

        private void Settingsp_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.SettingsW.Show();
        }

    }
}
