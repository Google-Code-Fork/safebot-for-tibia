using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafeBot.Core
{
    public partial class SaveAs : Form
    {
        public SaveAs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                Settings.SaveSettingsAsXML(textBox1.Text);
                this.Close();
            }
            else
                Client.ShowDialogBox("You got to specify a File name!", "Save Settings::Error!", "Ok");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(Handle, WindowsHandlers.WM_NCLBUTTONDOWN, WindowsHandlers.HT_CAPTION, 0);
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
