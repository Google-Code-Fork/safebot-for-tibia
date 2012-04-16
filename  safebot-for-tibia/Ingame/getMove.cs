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
    public partial class getMove : Form
    {
        public getMove()
        {
            InitializeComponent();
        }

        private void getMove_Load(object sender, EventArgs e)
        {
            this.Size = new Size(32, 32);
            this.BackColor = Color.White;
            this.AllowTransparency = true;
            this.TransparencyKey = Color.Transparent;
            this.TopMost = true;
        }

        private void getMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void getMove_MouseUp(object sender, MouseEventArgs e)
        {

        }

    }
}
