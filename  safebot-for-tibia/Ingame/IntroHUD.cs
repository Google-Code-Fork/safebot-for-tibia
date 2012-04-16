using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeBot.Ingame
{
    public partial class IntroHUD : Form
    {

        public IntroHUD()
        {
            InitializeComponent();
        }

        private void MagicWallsWn_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            this.Location = new Point(10, 40);
        }

        private void TimerMW_Tick(object sender, EventArgs e)
        {
            if (Client.isClientTop() && Settings.HUD == true)
                this.Show();
            else
                this.Hide();

            sett.Text = ">" + Settings.set;
            if (Settings.HealerHP == true)
                HealerHP.Text = "Healer HP: On";
            else
                HealerHP.Text = "Healer HP:Off";
            if (Settings.HealerMP == true)
                HealerMP.Text = "Healer MP: On";
            else
                HealerMP.Text = "Healer MP: Off";
            if (Settings.MS == true)
                ManaShield.Text = "Mana Shield: On";
            else
                ManaShield.Text = "Mana Shield:Off";
            if (Settings.Haste == true)
               Haste.Text = "Haste: On";
            else
                Haste.Text = "Haste: Off";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Checker_Tick(object sender, EventArgs e)
        {
        }
    }
}
