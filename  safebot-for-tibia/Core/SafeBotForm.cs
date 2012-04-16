using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeBot
{
    public partial class SafeBotForm : Form
    {
        public int animationTime;
        public int flags;

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

        public SafeBotForm()
        {
            InitializeComponent();
            Client.setResolution();
        }

        private void SafeBot_Load(object sender, EventArgs e)
        {
            WindowsHandlers.SetForegroundWindow(this.Handle);
            this.Size = new Size(15, 15);
            this.Location = new Point(Client.SafeBotMenu_X, Client.SafeBotMenu_Y);
            this.BackgroundImage = Properties.Resources.SB;
            WindowsHandlers.AnimateWindow(this.Handle, 400, WindowsHandlers.AW_BLEND);
            if (Settings.HUD == true)
            {
                Client.HUD.Location = new Point(10, 40);
                Client.HUD.Size = new Size(132, 114);
                Settings.set = ">None";
                Client.HUD.Show();
            }
            else
            {
                return;
            }
        }

        private void SafeBot_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.On_SB;
        }

        private void SafeBot_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.SB;
            SafeBotMenu MenuLoad = new SafeBotMenu();
            MenuLoad.Show();
        }

        private void Hider_Tick(object sender, EventArgs e)
        {
            if (!Client.isClientTop())
                this.Hide();
            else
                this.Show();
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            Player.HP = Player.getHP();
            Player.MP = Player.getMP();
        }
    }
}