using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SafeBot.Ingame
{
    public partial class HealerWn : Form
    {
        private Thread SSA;
        Thread oii;
        private System.Timers.Timer SSAT;
        Boolean Login;


        public HealerWn()
        {
            InitializeComponent();
        }


        private void HealerWn_Load(object sender, EventArgs e)
        {
            try 
            {
                MP_high.Value = Settings.MP_high;
                MP_low.Value = Settings.MP_low;
                MPTimer.Value = Settings.MP_timer;
                HP_high.Value = Settings.HP_high;
                HP_mid.Value = Settings.HP_mid;
                HP_low.Value = Settings.HP_low;
                HPTimer.Value = Settings.HP_timer;
            }
            catch { }

            WindowsHandlers.SetForegroundWindow(this.Handle);
            label1.BackColor = Color.Transparent;
            HealerTimer.Start();
            ManaTimer.Start();
        }

        private void HealerWn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.HP_high = Convert.ToInt32(HP_high.Value);
            Settings.HP_mid = Convert.ToInt32(HP_mid.Value);
            Settings.HP_low = Convert.ToInt32(HP_low.Value);
            Settings.HP_timer = Convert.ToInt32(HPTimer.Value);

            Settings.MP_high = Convert.ToInt32(MP_high.Value);
            Settings.MP_low = Convert.ToInt32(MP_low.Value);
            Settings.MP_timer = Convert.ToInt32(MPTimer.Value);

            this.Hide();
        }


        private void pictureBox64_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(Handle, WindowsHandlers.WM_NCLBUTTONDOWN, WindowsHandlers.HT_CAPTION, 0);
            }
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            Login = Client.isLoggedIn();

            if (HealerTimer.Enabled)
                Settings.HealerHP = true;
            else
                Settings.HealerHP = false;

            if (ManaTimer.Enabled)
                Settings.HealerMP = true;
            else
                Settings.HealerMP = false;
        }

        private void HealerTimer_Tick(object sender, EventArgs e)
        {
            Client.HealerRunning = true;
            CurrentHP.Text = Player.HP.ToString() + "%" + " - " + Player.MP.ToString() + "%";

            try
            {
                if (Login == true && UHNoMana.Checked == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Player.HP > 0 && Player.HP < HP_high.Value && Player.HP > 0 && Player.MP < 3 && Hotkeys.UhHotkey != 0)
                {
                    SendKeys.Send("({F" + Hotkeys.UhHotkey + "})");
                }
                else if (Login == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Player.HP > 0 && Player.HP <= HP_high.Value && Player.HP > HP_mid.Value && Player.HP > HP_low.Value && Player.MP >= HP_highMP.Value && Player.MP > 2 && Hotkeys.HPhighHotkey != 0)
                {
                    SendKeys.Send("({F" + Hotkeys.HPhighHotkey + "})");
                }
                else if (Login == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Player.HP > 0 && Player.HP < HP_high.Value && Player.HP <= HP_mid.Value && Player.HP > HP_low.Value && Player.MP >= HP_highMP.Value && Player.MP > 2 && Hotkeys.HPmidHotkey != 0)
                {
                    SendKeys.Send("({F" + Hotkeys.HPmidHotkey + "})");
                }
                else if (Login == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Player.HP > 0 && Player.HP < HP_high.Value && Player.HP < HP_mid.Value && Player.HP <= HP_low.Value && Player.MP >= HP_highMP.Value && Player.MP > 2 && Hotkeys.HPlowHotkey != 0)
                {
                    SendKeys.Send("({F" + Hotkeys.HPlowHotkey + "})");
                }
            }
            catch
            {

            }
        }

        private void TimerHealerPriority_Tick(object sender, EventArgs e)
        {

            if (HealerPriority.Checked && Client.isClientTop() == false && Client.HealerRunning == true && Player.HP < HP_high.Value)
                WindowsHandlers.SetForegroundWindow(WindowsHandlers.FindWindow("TibiaClient", "Tibia"));

            if (Client.HealerRunning == true || Client.HasteRunning == true)
                if (HealerPriority.Checked && Client.isClientTop() == false)
                    WindowsHandlers.FlashWindow(WindowsHandlers.FindWindow("TibiaClient", "Tibia"), true);
                else return;
        }

        public void RefillUpTo()
        {
            try
            {
                if (Client.isLoggedIn() == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Hotkeys.ManaPotionHotkey != 0)
                {
                    do { SendKeys.SendWait("({F" + Hotkeys.ManaPotionHotkey + "})"); Thread.Sleep(Settings.MP_timer); }
                    while (Player.MP < MP_high.Value);
                }
            }
            catch
            {
                return;
            }
        }


        private void ManaTimer_Tick(object sender, EventArgs e)
        {
            if (Client.isLoggedIn() == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Player.MP <= MP_low.Value && MP_low.Value != 0 && Hotkeys.ManaPotionHotkey != 0)
            {
                oii = new Thread(() => RefillUpTo());
                oii.Start();
            }
            else if (Client.isLoggedIn() == true && !Client.isControlkeyDown() && Client.isClientTop() == true && Player.MP <= MP_high.Value && MP_low.Value == 0 && Hotkeys.ManaPotionHotkey != 0)
            {
                SendKeys.Send("({F" + Hotkeys.ManaPotionHotkey + "})");
            }
        }

        private void Timers_Tick(object sender, EventArgs e)
        {
            HPTimer.Value = HealerTimer.Interval;
            MPTimer.Value = ManaTimer.Interval;
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {

        }

        private void SSAhp_CheckedChanged(object sender, EventArgs e)
        {
            if (SSAhp.Checked == true)
            {
                SSAT = new System.Timers.Timer();
                SSAT.AutoReset = false;
                SSAT.Start();
                SSAT.Interval = 1000;
                SSAT.Elapsed += new System.Timers.ElapsedEventHandler(SSATimer_Tick);
            }
            else
                SSATimer.Stop();
        }

        private void WearSSA()
        {
            Client.AmuletX = 1216;
            Client.AmuletY = 206;
            while (Client.isClientTop() == true && Client.isWearingSSA() == false)
            {
                Client.MoveItem(Client.AmuletX, Client.AmuletY, 1217, 467, 250);
            }
        }

        private void SSATimer_Tick(object sender, EventArgs e)
        {
            if (Player.MP < MP_low.Value && Client.isClientTop() == true && Client.isWearingSSA() == false)
            {
                SSA = new Thread(() => WearSSA());
                SSA.Start();
            }

            SSAT.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                HealerTimer.Stop();
            else
                HealerTimer.Start();
        }

        private void HealerWn_VisibleChanged(object sender, EventArgs e)
        {
            Settings.HP_high = Convert.ToInt32(HP_high.Value);
            Settings.HP_mid = Convert.ToInt32(HP_mid.Value);
            Settings.HP_low = Convert.ToInt32(HP_low.Value);
            Settings.HP_timer = Convert.ToInt32(HPTimer.Value);

            Settings.MP_high = Convert.ToInt32(MP_high.Value);
            Settings.MP_low = Convert.ToInt32(MP_low.Value);
            Settings.MP_timer = Convert.ToInt32(MPTimer.Value);

        }

    }
}
