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
    public partial class SaveMenu : Form
    {
        public SaveMenu()
        {
            InitializeComponent();
        }

        private void SaveMenu_Load(object sender, EventArgs e)
        {
        }

        private void SaveMenu_MouseClick(object sender, MouseEventArgs e)
        {
            Point ptCursor = Cursor.Position;
            ptCursor = PointToClient(ptCursor);
            if (ptCursor.X < 128 && ptCursor.Y < 21)
            {
                Settings.SaveSettingsXML();
                this.Close();
            }
            else if (ptCursor.Y >= 21 && ptCursor.Y < 38)
            {
                this.Close();
                Core.SaveAs SaveAsM = new Core.SaveAs();
                SaveAsM.ShowDialog();
            }
            else if (ptCursor.Y >= 42 && ptCursor.Y <= 67)
            {
                this.Close();
            }
        }

        private void Shades_Tick(object sender, EventArgs e)
        {
            Point ptCursor = Cursor.Position;
            ptCursor = PointToClient(ptCursor);
            if (ptCursor.Y >= 0 && ptCursor.Y < 21)
            {
                this.BackgroundImage = Properties.Resources.Save_SaveOn;
            }
            else if (ptCursor.Y >= 21 && ptCursor.Y <= 38)
            {
                this.BackgroundImage = Properties.Resources.SaveAsOn;
            }
            else if (ptCursor.Y >= 42 && ptCursor.Y <= 67)
            {
                this.BackgroundImage = Properties.Resources.SaveExitOn;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.SaveMenu;
            }
        }
    }
}
