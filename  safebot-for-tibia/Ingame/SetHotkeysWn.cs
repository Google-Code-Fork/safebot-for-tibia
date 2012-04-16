using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SafeBot.Ingame
{
    public partial class SetHotkeysWn : Form
    {
        public SetHotkeysWn()
        {
            InitializeComponent();
        }

        private void label10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowsHandlers.ReleaseCapture();
                WindowsHandlers.SendMessage(Handle, WindowsHandlers.WM_NCLBUTTONDOWN, WindowsHandlers.HT_CAPTION, 0);
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void setHotkeys()
        {
            List<string> HotkeyDumb = new List<string>();
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(13));//F1
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(14));//F2
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(15));//F3
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(16));//F4
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(17));//F5
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(18));//F6
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(19));//F7
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(19));//F8
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(20));//F9
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(21));//F10
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(22));//F11
            HotkeyDumb.Add(File.ReadAllLines(Client.Path).ElementAt(23));//F12
            List<string> HotkeyList = new List<string>();

            foreach (string hotkey in HotkeyDumb)
            {
                var Unescape = Regex.Unescape(hotkey);
                var Clean = Unescape.Replace("\"", "");
                var pat = @"Hotkey....(?<F>\d+)\b[,](?<spell>[^.*?,]+)[,](?<id>\d+),\d+,\d+\)";
                var split = Regex.Match(Clean, pat, RegexOptions.IgnoreCase);
                HotkeyList.Add(split.Groups["spell"].ToString());
            }
            foreach (string hotkey in HotkeyDumb)
            {
                var pat = @"Hotkey....(?<F>\d+)\b[,](?<spell>[^.*?,]+)[,](?<id>\d+),\d+,\d+\)";
                var split = Regex.Match(hotkey, pat, RegexOptions.IgnoreCase);
                HotkeyList.Add(split.Groups["id"].ToString());
            }

            foreach (string Item in HotkeyList)
            {
                if (textBox1.Text + "\n" == Item)
                {
                    int i = HotkeyList.IndexOf(textBox1.Text + "\n");
                    int HPhighhtk = i + 1;
                    Hotkeys.HPhighHotkey = HPhighhtk;
                    HPhigh.Text = "F" + HPhighhtk.ToString();
                }
                if (textBox2.Text + "\n" == Item)
                {
                    int i = HotkeyList.IndexOf(textBox2.Text + "\n");
                    int HPhighhtk = i + 1;
                    Hotkeys.HPmidHotkey = HPhighhtk;
                    HPmid.Text = "F" + HPhighhtk.ToString();
                }
                if (textBox3.Text + "\n" == Item)
                {
                    int i = HotkeyList.IndexOf(textBox3.Text + "\n");
                    int HPhighhtk = i + 1;
                    Hotkeys.HPlowHotkey = HPhighhtk;
                    HPlow.Text = "F" + HPhighhtk.ToString();
                }
                if (textBox5.Text + "\n" == Item)
                {
                    int i = HotkeyList.IndexOf(textBox5.Text + "\n");
                    int HPhighhtk = i + 1;
                    Hotkeys.HasteHotkey = HPhighhtk;
                    HasteUp.Text = "F" + HPhighhtk.ToString();
                }
                if (textBox6.Text + "\n" == Item)
                {
                    int i = HotkeyList.IndexOf(textBox6.Text + "\n");
                    int HPhighhtk = i + 1;
                    Hotkeys.ManaShieldHotkey = HPhighhtk;
                    ManaShield.Text = "F" + HPhighhtk.ToString();
                }
                if (textBox7.Text + "\n" == Item)
                {
                    int i = HotkeyList.IndexOf(textBox7.Text + "\n");
                    int HPhighhtk = i + 1;
                    Hotkeys.AntiParalyzeHotkey = HPhighhtk;
                    AP.Text = "F" + HPhighhtk.ToString();
                }
                if (Item == string.Empty)
                {
                    try
                    {
                        switch (textBox4.Text)
                        {
                            case "mp":
                                {
                                    int i = HotkeyList.IndexOf("268");
                                    if (HotkeyList[i].ToString() == "268")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.ManaPotionHotkey = HPhighhtk;
                                        MPhtk.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "smp":
                                {
                                    int i = HotkeyList.IndexOf("237");
                                    if (HotkeyList[i].ToString() == "237")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.ManaPotionHotkey = HPhighhtk;
                                        MPhtk.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "gmp":
                                {
                                    int i = HotkeyList.IndexOf("238");
                                    if (HotkeyList[i].ToString() == "238")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.ManaPotionHotkey = HPhighhtk;
                                        MPhtk.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "gsp":
                                {
                                    int i = HotkeyList.IndexOf("7642");
                                    if (HotkeyList[i].ToString() == "7642")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.ManaPotionHotkey = HPhighhtk;
                                        MPhtk.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch { }
                    try
                    {

                        switch (textBox8.Text)
                        {
                            case "uh":
                                {
                                    int i = HotkeyList.IndexOf("3160");
                                    if (HotkeyList[i].ToString() == "3160")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.UhHotkey = HPhighhtk;
                                        UH.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "mp":
                                {
                                    int i = HotkeyList.IndexOf("268");
                                    if (HotkeyList[i].ToString() == "268")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.UhHotkey = HPhighhtk;
                                        UH.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "smp":
                                {
                                    int i = HotkeyList.IndexOf("237");
                                    if (HotkeyList[i].ToString() == "237")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.UhHotkey = HPhighhtk;
                                        UH.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "gmp":
                                {
                                    int i = HotkeyList.IndexOf("238");
                                    if (HotkeyList[i].ToString() == "238")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.UhHotkey = HPhighhtk;
                                        UH.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            case "gsp":
                                {
                                    int i = HotkeyList.IndexOf("7642");
                                    if (HotkeyList[i].ToString() == "7642")
                                    {
                                        int HPhighhtk = i - 11;
                                        Hotkeys.UhHotkey = HPhighhtk;
                                        UH.Text = "F" + HPhighhtk.ToString();
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch { }
                }
            }
        }


        private void LoadnClose_Click(object sender, EventArgs e)
        {
            setHotkeys();
        }

        private void SetHotkeysWn_Load(object sender, EventArgs e)
        {
            WindowsHandlers.SetForegroundWindow(this.Handle);

            textBox1.Text = Settings.HPHighSpell;
            textBox2.Text = Settings.HPMidSpell;
            textBox3.Text = Settings.HPLowSpell;
            textBox4.Text = Settings.MPid.ToString();
            textBox8.Text = Settings.UHid.ToString();
            textBox7.Text = Settings.AntiParalyzeSpell;
            textBox6.Text = Settings.AutoManaShieldSpell;
            textBox5.Text = Settings.AutoHasteSpell;
        }

        private void SetHotkeysWn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.HPHighSpell = textBox1.Text;
            Settings.HPMidSpell = textBox2.Text;
            Settings.HPLowSpell = textBox3.Text;
            Settings.MPid = textBox4.Text;
            Settings.UHid = textBox8.Text;
            Settings.AntiParalyzeSpell = textBox7.Text;
            Settings.AutoManaShieldSpell = textBox6.Text;
            Settings.AutoHasteSpell = textBox5.Text;
        }
    }
}
