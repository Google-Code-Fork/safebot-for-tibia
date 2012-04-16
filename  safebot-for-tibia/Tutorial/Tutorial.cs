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
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            this.Hide();
            SafeBot.Tutorial.TutorialHealer Healerfrm = new SafeBot.Tutorial.TutorialHealer();
            Healerfrm.ShowDialog();
        }

        private void DontShow_CheckedChanged(object sender, EventArgs e)
        {
            if (DontShow.Enabled == true)
            {
                Settings.Skip = true;
                Settings.SaveSettings();
            }
        }
    }
}
