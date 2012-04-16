using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SafeBot.Ingame
{
    public partial class SettingsWn : Form
    {
        public SettingsWn()
        {
            InitializeComponent();
        }

        private void SettingsWn_Load(object sender, EventArgs e)
        {
            settings_updater.Start();

            user.Text = Client._user;
            if ((Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Days > 999)
                LicenseLbl.Text = "License Remaining: Life Time Subscription.";
            else if ((Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Days > 30)
                LicenseLbl.Text = "License Remaining: " + (Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Days + " Days left";
            else if ((Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Days > 1 && (Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Days <= 30)
                LicenseLbl.Text = "License Remaining: " + (Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Days + " Days left";
            else if ((Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Hours < 24)
                LicenseLbl.Text = "License Remaining: " + (Client.LicenseTime.ToUniversalTime() - Client.TimeNow.ToUniversalTime()).Hours + " hours left";

            HUDe.Checked = Settings.HUD;
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(Handle, WindowsHandlers.WM_NCLBUTTONDOWN, WindowsHandlers.HT_CAPTION, 0);
            }
        }

        private void settings_updater_Tick(object sender, EventArgs e)
        {
            string drivePath = Directory.GetCurrentDirectory();
            var textFiles = Directory.GetFiles(drivePath+"/Settings/", "*.xml", SearchOption.TopDirectoryOnly);
            List<string> listing = new List<string>();
            foreach (string Line in textFiles)
            {
                listing.Add(System.IO.Path.GetFileName(Line));
            }
            listBox1.DataSource = listing;
            settings_updater.Stop();
        }

        private void LoadnClose_Click(object sender, EventArgs e)
        {
            try
            {
                string set = "Settings/" + listBox1.SelectedItem.ToString();
                Settings.set = listBox1.SelectedItem.ToString();
                // Create an XmlReader
                //Create the XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.Load(set);
                try
                {
                    XmlNodeList elemList = doc.GetElementsByTagName("HPHigh");
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        Settings.HP_high = Convert.ToInt32(elemList[i].InnerText);
                    }
                    XmlNodeList HPmiddle = doc.GetElementsByTagName("HPMid");
                    for (int i = 0; i < HPmiddle.Count; i++)
                    {
                        Settings.HP_mid = Convert.ToInt32(HPmiddle[i].InnerText);
                    }
                    XmlNodeList HPlow = doc.GetElementsByTagName("HPLow");
                    for (int i = 0; i < HPlow.Count; i++)
                    {
                        Settings.HP_low = Convert.ToInt32(HPlow[i].InnerText);
                    }
                    XmlNodeList MPHigh = doc.GetElementsByTagName("MPHigh");
                    for (int i = 0; i < MPHigh.Count; i++)
                    {
                        Settings.MP_high = Convert.ToInt32(MPHigh[i].InnerText);
                    }
                    XmlNodeList MPLow = doc.GetElementsByTagName("MPLow");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.MP_low = Convert.ToInt32(MPLow[i].InnerText);
                    }
                    XmlNodeList HPHighSpell = doc.GetElementsByTagName("HPHighSpell");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.HPHighSpell = HPHighSpell[i].InnerText;
                    }
                    XmlNodeList HPMidSpell = doc.GetElementsByTagName("HPMidSpell");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.HPMidSpell = HPMidSpell[i].InnerText;
                    }
                    XmlNodeList HPLowSpell = doc.GetElementsByTagName("HPLowSpell");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.HPLowSpell = HPLowSpell[i].InnerText;
                    }
                    XmlNodeList MPid = doc.GetElementsByTagName("MPid");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.MPid = MPid[i].InnerText;
                    }
                    XmlNodeList UHid = doc.GetElementsByTagName("UHid");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.UHid = UHid[i].InnerText;
                    }
                    XmlNodeList AP = doc.GetElementsByTagName("AntiParalyzeSpell");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.AntiParalyzeSpell = AP[i].InnerText;
                    }
                    XmlNodeList MS = doc.GetElementsByTagName("AutoManaSpell");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.AutoManaShieldSpell = MS[i].InnerText;
                    }
                    XmlNodeList ASH = doc.GetElementsByTagName("AutoHasteSpell");
                    for (int i = 0; i < MPLow.Count; i++)
                    {
                        Settings.AutoHasteSpell = ASH[i].InnerText;
                    }
                }
                catch
                {
                    Client.ShowDialogBox("Settings File is Corrupt.", "Manage Settings :: Error!", "Ok");
                }
            }
            catch
            {
                Client.ShowDialogBox("Directory is empty.", "Manage Settings :: Error!", "Ok");
            }
        }

        private void HUD_Tick(object sender, EventArgs e)
        {

        }

        private void HUDe_CheckedChanged(object sender, EventArgs e)
        {
            if (HUDe.Checked)
            {
                Settings.HUD = true;
                Settings.SaveSettings();
            }
            else if (!HUDe.Checked)
            {
                if (Client.HUD.IsHandleCreated == true)
                {
                    Settings.HUD = false;
                    Settings.SaveSettings();
                    Client.HUD.Close();
                }
                Settings.HUD = false;
                Settings.SaveSettings();
            }

        }
    }
}