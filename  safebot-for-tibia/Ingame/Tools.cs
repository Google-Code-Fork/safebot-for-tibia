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
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            this.Focus();   
        }

        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(Handle, WindowsHandlers.WM_NCLBUTTONDOWN, WindowsHandlers.HT_CAPTION, 0);
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ManaBarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ManaBarCheckBox.Checked)
            {
                Client.ManaBarW.Hide();
                Client.ManaBarStatus = 0;
            }
            else if (ManaBarCheckBox.Checked == true)
            {
                Client.ManaBarW.Show();
                Client.ManaBarStatus = 1;
            }
        }

        private void Haster_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Player.isSelfHasted() && !Player.isSelfProtectionZone() && Client.isClientTop() == true)
                    SendKeys.Send("({F" + Hotkeys.HasteHotkey + "})");
                else
                    return;
            }
            catch { }
        }

        private void HasteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HasteCheckBox.Checked)
                Haster.Start();
            else
                Haster.Stop(); 
        }

        private void AutoManaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoManaCheckBox.Checked)
                AutoMana.Start();
            else
                AutoMana.Stop();
        }

        private void AutoMana_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Player.isSelfManaShielded() && !Player.isSelfProtectionZone() && Client.isClientTop() == true)
                    SendKeys.Send("({F" + Hotkeys.ManaShieldHotkey + "})");
                else
                    return;
            }
            catch { }
        }

        private void AntiParalyzeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AntiParalyzeCheckBox.Checked)
                AntiParalyze.Start();
            else
                AntiParalyze.Stop();
        }

        private void AntiParalyze_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Player.isSelfParalyzed() == true)
                    SendKeys.Send("({F" + Hotkeys.AntiParalyzeHotkey + "})");
                else
                    return;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           WindowsHandlers.CURSORINFO oi = new WindowsHandlers.CURSORINFO();
           WindowsHandlers.GetCursorInfo(out oi);

          // if (oi.hCursor != oi.hCursor)
               MessageBox.Show(oi.hCursor.ToString());
        }

        private void Clickreuse_Tick(object sender, EventArgs e)
        {

        }

        private void Upd_Tick(object sender, EventArgs e)
        {
            if (Haster.Enabled)
                Settings.Haste = true;
            else
                Settings.Haste = false;

            if (AutoMana.Enabled)
                Settings.MS = true;
            else
                Settings.MS = false;
        }

    }
}
