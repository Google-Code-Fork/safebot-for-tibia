using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeBot.Tutorial
{
    public partial class TutorialHealer : Form
    {
        internal static int Steps = 0;
        internal static int HP;
        internal static int MP;
        internal static OpenFileDialog fdlg = new OpenFileDialog();

        public TutorialHealer()
        {
            InitializeComponent();
        }

        private void TutorialHealer_Load(object sender, EventArgs e)
        {
            WindowsHandlers.SetForegroundWindow(this.Handle);
            character.Visible = true;
            say.Visible = true;
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HPMPTimer_Tick(object sender, EventArgs e)
        {
            HP = Player.getHP();
            MP = Player.getMP();
            HPMP.Text = "HP: " + HP.ToString() + " / MP: " + MP.ToString();
        }

        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(Handle, WindowsHandlers.WM_NCLBUTTONDOWN, WindowsHandlers.HT_CAPTION, 0);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Next.Text == "Finish")
            {
                this.Hide();
                SafeBotForm sbload = new SafeBotForm();
                sbload.Show();
            }
            else if (Steps == 0) //start
            {
                say.Text = "";
                say.Text = "SafeBot Says:\r\nWe need to set up the Tibia Client we will use.";
                pictureBox21.Visible = true;
                Browse.Visible = true;
                browseText.Visible = true;
                dragndroptext.Visible = true;
                Steps = 1;
            }
            else if (Steps == 2)
            {
                Client.ClientAdd = browseText.Text;
                Browse.Visible = false;
                browseText.Visible = false;
                dragndroptext.Visible = false;
                pictureBox21.Visible = false;
                say.Text = "SafeBot Says:\r\nGood! Now that we have a Client to work with we are going to\r\nOpen it up and test the Reading System.";
                if (WindowsHandlers.FindWindow("TibiaClient", "Tibia") == IntPtr.Zero)
                {
                    ProcessStartInfo psi = new ProcessStartInfo(Client.ClientAdd);
                    psi.UseShellExecute = true; // to avoid opening currently running Tibia's
                    psi.WorkingDirectory = System.IO.Path.GetDirectoryName(Client.ClientAdd);
                    Process.Start(psi);
                    Steps = 3;
                }
                else
                {
                    Steps = 3;
                }
            }
            else if (Steps == 3)
            {
                WindowsHandlers.SetForegroundWindow(WindowsHandlers.FindWindow("TibiaClient", "Tibia"));
                Client.setResolution();
                HPMP.Visible = true;
                HPMPTimer.Start();
                if (Client.isLoggedIn() == false)
                {
                    TimeSpan time = new TimeSpan(0, 0, 0, 0, 199);
                    Client.MoveMouse(new Point(Client.LoginButtonX, Client.LoginButtonY), time);
                    System.Threading.Thread.Sleep(time);
                    WindowsHandlers.mouse_event(WindowsHandlers.MouseFlags.LEFTDOWN, Client.LoginButtonX, Client.LoginButtonY, 0, UIntPtr.Zero);
                    WindowsHandlers.mouse_event(WindowsHandlers.MouseFlags.LEFTUP, Client.LoginButtonX, Client.LoginButtonY, 0, UIntPtr.Zero);
                    say.Text = "SafeBot Says:\r\nYou got to Log in first!";
                    this.Location = new Point(this.Location.X +100, this.Location.Y +100);
                }
                else
                {
                    if ((HP != 101 && MP != 0))
                        Steps = 4;
                    else
                        Steps = 3;
                }
            }
            else if (Steps == 4)
            {
                Steps = 5;
                healer.Visible = true;
                say.Text = "SafeBot Says:\r\nNow set up the healing as your needs where High would be exura, \r\nMid Exura Gran and Low Exura Vita in a Mage";
                System.Threading.Thread.Sleep(500);
            }
            else if (Steps == 5)
            {
                Steps = 6;
                Settings.HP_high = Convert.ToInt32(HP_high.Value);
                Settings.HP_mid = Convert.ToInt32(HP_mid.Value);
                Settings.HP_low = Convert.ToInt32(HP_low.Value);
                healer.Visible = false;
                say.Text = "SafeBot Says:\r\nExcellent! Now Mana, You can set up the High only and you will be\r\nmanteined in that mana% if you set High and Low\r\nYou will starting filling from low => high when low is reached";
                Mana.Visible = true;
            }
            else if (Steps == 6)
            {
                Mana.Visible = false;
                Settings.MP_high = Convert.ToInt32(MP_high.Value);
                Settings.MP_low = Convert.ToInt32(MP_low.Value);
                Settings.Tutorial = true;
                say.Text = "SafeBot Says:\r\nVery Good, We are done with the Healer now.\r\nYou can now start playing around with the SafeBot";
                Settings.SaveSettings();
                Next.Text = "Finish";
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Please select the Tibia Client";
            fdlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
               browseText.Text = fdlg.FileName;
               Steps = 2;
            }
        }

        private void HP_high_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}