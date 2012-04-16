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
    public partial class ManaBar : Form
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

        public ManaBar()
        {
            InitializeComponent();
        }

        private void ManaBar_Load(object sender, EventArgs e)
        {
            this.Size = new Size(27, 4);
            this.Location = new Point(Client.ManaBarX, Client.ManaBarY);
            this.TopMost = true;
            tester.Start();

        }

        private void tester_Tick(object sender, EventArgs e)
        {
            int i;
            int Coloured = Player.MP / 4;
            if (Player.MP != 101)
            {
                Bitmap hpbmp = new Bitmap(pictureBox1.Image);
                for (i = 1; i < Coloured; i++)
                {
                    if (Coloured < 9)
                    {
                        hpbmp.SetPixel(i, 1, Color.Red);
                        hpbmp.SetPixel(i, 2, Color.Red);
                        pictureBox1.Image = hpbmp;
                    }
                    else if (Coloured >= 9 && Coloured <= 17)
                    {
                        hpbmp.SetPixel(i, 1, Color.Yellow);
                        hpbmp.SetPixel(i, 2, Color.Yellow);
                        pictureBox1.Image = hpbmp;
                    }
                    else if (Coloured > 17 && Coloured <= 25)
                    {
                        hpbmp.SetPixel(i, 1, Color.Blue);
                        hpbmp.SetPixel(i, 2, Color.Blue);
                        pictureBox1.Image = hpbmp;
                    }
                    pictureBox1.Refresh(); //Force refresh
                }
                for (int d = 26; d > Coloured-1; d--)
                {
                    hpbmp.SetPixel(d, 1, Color.Black);
                    hpbmp.SetPixel(d, 2, Color.Black);
                }
            }
            else
            {
                return;
            }
        }

        private void checker_Tick(object sender, EventArgs e)
        {
            if (Client.isClientTop() && Client.ManaBarStatus == 1 && Client.isLoggedIn()|| Client.isBotTop() && Client.ManaBarStatus == 1 && Client.isLoggedIn())
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
