using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Text;

namespace SafeBot
{
    public partial class Settings
    {
        internal static bool Tutorial = false;
        internal static bool Skip = false;
        internal static string Version;
        internal static bool LoggedIn;


        #region HUD
        internal static bool HUD;
        internal static string set;
        internal static bool HealerHP;
        internal static bool HealerMP;
        internal static bool MS;
        internal static bool Haste;
        #endregion

        #region Healer Class
        //HP
        internal static int HP_high;
        internal static int HP_mid;
        internal static int HP_low;
        //MP
        internal static int MP_high;
        internal static int MP_low;

        //Timer HP
        internal static int HP_timer;
        //Timer MP
        internal static int MP_timer;
        #endregion

        #region Hotkeys Class

        internal static string HPHighSpell = "";
        internal static string HPMidSpell = "";
        internal static string HPLowSpell = "";
        internal static string MPid = "";

        internal static string UHid = "3160";

        internal static string AntiParalyzeSpell = "";
        internal static string AutoManaShieldSpell = "";
        internal static string AutoHasteSpell = "";

        #endregion

        internal static void SaveSettings()
        {
            TextWriter sw = new StreamWriter("PCSetting.txt");
            sw.WriteLine(Settings.Tutorial);
            sw.WriteLine(Settings.Skip);
            sw.WriteLine(Settings.HUD);
            sw.Close();
        }

        internal static void SaveSettingsAsXML(string FileName)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.Indent = true;
            XmlWriter xml = XmlWriter.Create(Directory.GetCurrentDirectory() + @"/Settings/"+FileName+".xml", xmlWriterSettings);
            xml.WriteStartElement("UserSettings");

            xml.WriteStartElement("Healer");
            xml.WriteStartElement("HPHigh");
            xml.WriteValue(Settings.HP_high);
            xml.WriteEndElement();

            xml.WriteStartElement("HPMid");
            xml.WriteValue(Settings.HP_mid);
            xml.WriteEndElement();

            xml.WriteStartElement("HPLow");
            xml.WriteValue(Settings.HP_low);
            xml.WriteEndElement();

            xml.WriteStartElement("MPHigh");
            xml.WriteValue(Settings.MP_high);
            xml.WriteEndElement();

            xml.WriteStartElement("MPLow");
            xml.WriteValue(Settings.MP_low);
            xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("Hotkeys");

            xml.WriteStartElement("HPHighSpell");
            xml.WriteValue(Settings.HPHighSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("HPMidSpell");
            xml.WriteValue(Settings.HPMidSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("HPLowSpell");
            xml.WriteValue(Settings.HPLowSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("MPid");
            xml.WriteValue(Settings.MPid);
            xml.WriteEndElement();

            xml.WriteStartElement("UHid");
            xml.WriteValue(Settings.UHid);
            xml.WriteEndElement();

            xml.WriteStartElement("AntiParalyzeSpell");
            xml.WriteValue(Settings.AntiParalyzeSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("AutoManaSpell");
            xml.WriteValue(Settings.AutoManaShieldSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("AutoHasteSpell");
            xml.WriteValue(Settings.AutoHasteSpell);
            xml.WriteEndElement();

            xml.WriteEndDocument();
            xml.Flush();
            xml.Close();
        }

        internal static void SaveSettingsXML()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.Indent = true;
            XmlWriter xml = XmlWriter.Create(Directory.GetCurrentDirectory() + @"/Settings/Settings.xml", xmlWriterSettings);
            xml.WriteStartElement("UserSettings");

            xml.WriteStartElement("Healer");
            xml.WriteStartElement("HPHigh");
            xml.WriteValue(Settings.HP_high);
            xml.WriteEndElement();

            xml.WriteStartElement("HPMid");
            xml.WriteValue(Settings.HP_mid);
            xml.WriteEndElement();

            xml.WriteStartElement("HPLow");
            xml.WriteValue(Settings.HP_low);
            xml.WriteEndElement();

            xml.WriteStartElement("MPHigh");
            xml.WriteValue(Settings.MP_high);
            xml.WriteEndElement();

            xml.WriteStartElement("MPLow");
            xml.WriteValue(Settings.MP_low);
            xml.WriteEndElement();
            xml.WriteEndElement();

            xml.WriteStartElement("Hotkeys");

            xml.WriteStartElement("HPHighSpell");
            xml.WriteValue(Settings.HPHighSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("HPMidSpell");
            xml.WriteValue(Settings.HPMidSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("HPLowSpell");
            xml.WriteValue(Settings.HPLowSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("MPid");
            xml.WriteValue(Settings.MPid);
            xml.WriteEndElement();

            xml.WriteStartElement("UHid");
            xml.WriteValue(Settings.UHid);
            xml.WriteEndElement();

            xml.WriteStartElement("AntiParalyzeSpell");
            xml.WriteValue(Settings.AntiParalyzeSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("AutoManaSpell");
            xml.WriteValue(Settings.AutoManaShieldSpell);
            xml.WriteEndElement();

            xml.WriteStartElement("AutoHasteSpell");
            xml.WriteValue(Settings.AutoHasteSpell);
            xml.WriteEndElement();

            xml.WriteEndDocument();
            xml.Flush();
            xml.Close();
        }
        
    }
}
