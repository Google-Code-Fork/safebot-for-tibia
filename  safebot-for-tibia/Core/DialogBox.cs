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
    public partial class DialogBox : Form
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            this.Focus();   
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Text = DialogBoxProperties.body;
            OK_btn.Text = DialogBoxProperties.OkButton;
            label10.Text = DialogBoxProperties.Title;
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            WindowsHandlers.SetWindowPos(Client.MainhWnd, new IntPtr(-1), 0, 0, 0, 0, WindowsHandlers.SetWindowPosFlags.SWP_NOMOVE | WindowsHandlers.SetWindowPosFlags.SWP_NOSIZE | WindowsHandlers.SetWindowPosFlags.SWP_SHOWWINDOW);
            this.Close();
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
    }
}
