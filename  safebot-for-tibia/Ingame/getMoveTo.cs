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
    public partial class getMoveTo : Form
    {
        public getMoveTo()
        {
            InitializeComponent();
        }

        private void getMoveTo_Load(object sender, EventArgs e)
        {
            this.Size = new Size(32, 32);
            this.BackColor = Color.White;
            this.AllowTransparency = true;
            this.TransparencyKey = Color.Transparent;
            this.TopMost = true;
        }

        private void getMoveTo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
    }
}
