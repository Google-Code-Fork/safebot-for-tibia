using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using SafeBot.Ingame;


namespace SafeBot
{
    public class Client
    {
        //Forms
        internal static HealerWn Healerw = new HealerWn();
        internal static SetHotkeysWn sHotkeysw = new SetHotkeysWn();
        internal static WTools WarToolsw = new WTools();
        internal static Tools Toolsw = new Tools();
        internal static ManaBar ManaBarW = new Ingame.ManaBar();
        internal static SettingsWn SettingsW = new SettingsWn();
        internal static Ingame.IntroHUD HUD = new Ingame.IntroHUD();

        //Function Statues
        internal static DateTime LicenseTime;
        internal static DateTime TimeNow;
        internal static string _user;
        internal static string _pw;
        internal static int ManaBarStatus;

        //Player
        internal static int lvl = 200;
        internal static int ManaBarX;
        internal static int ManaBarY;

        //Main Handle
        internal static IntPtr MainhWnd;
        internal static string ClientAdd;
        internal static string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Tibia\Tibia.cfg";

        internal static int HPmiddle = 4;
        internal static int HPbegin = 1;
        internal static int HPend = 87;
        internal static int LooterXTo;
        internal static int LooterYTo;
        internal static int LooterXFrom;
        internal static int LooterYFrom;

        //Actions running
        internal static bool HealerRunning = false;
        internal static bool HasteRunning = false;

        //random generator process name
        internal static string RandomName = "SafeBot";

        // Resolutions 

        internal static int HPScreenX;
        internal static int HPScreenY;
        internal static int FlagsBarx;
        internal static int FlagsBary;
        internal static int MPScreenX;
        internal static int MPScreenY;
        //Login Button
        internal static int LoginButtonX;
        internal static int LoginButtonY;

        internal static int SafeBotMenu_X;
        internal static int SafeBotMenu_Y;
        //containers
        internal static int AmuletX;
        internal static int AmuletY;
        internal static int ContainersX;
        internal static int ContainersY;
        internal static int FirstContainerX;
        internal static int SecondContainerX;
        internal static int ThirdContainerX;
        internal static int FourthContainerX;

        static Color[] GetPixelColumnFast(Bitmap bmp, int x)
        {
            Color[] pixelColumn = new Color[bmp.Height];
            BitmapData pixelData = bmp.LockBits(
              new Rectangle(0, 0, bmp.Width, bmp.Height),
              ImageLockMode.ReadOnly,
              PixelFormat.Format32bppArgb);
            unsafe
            {
                int* pData = (int*)pixelData.Scan0.ToPointer();
                pData += x;
                for (int i = 0; i < bmp.Height; ++i)
                {
                    pixelColumn[i] = Color.FromArgb(*pData);
                    pData += bmp.Width;
                }
            }
            bmp.UnlockBits(pixelData);

            return pixelColumn;
        }

        internal static bool isWearingSSA()
        {
            ContainersX = 1198;
            ContainersY = 190;
            Rectangle rect = new Rectangle(Client.ContainersX, Client.ContainersY, 34, 34);
            Bitmap SSA = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(SSA);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, SSA.Size, CopyPixelOperation.SourceCopy);
            Color[] e = GetPixelColumnFast(SSA, 18);
            for (int i = 0; i < e.Length; i++)
            {
                if ((e[i].R == 232 && e[i].G == 232 && e[i].B == 232) && (e[i + 1].R == 174 && e[i + 1].G == 174 && e[i + 1].B == 174) && (e[i + 2].R == 174 && e[i + 2].G == 174 && e[i + 2].B == 174) && (e[i + 3].R == 227 && e[i + 3].G == 227 && e[i + 3].B == 227))
                    return true;
            }
            return false;
        }

        internal static bool getContainerSSA()
        {
            ContainersX = 1188;
            ContainersY = 370;
            Rectangle rect = new Rectangle(Client.ContainersX, Client.ContainersY, 178, 398);
            Bitmap SSA = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(SSA);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, SSA.Size, CopyPixelOperation.SourceCopy);
            Color[] e = GetPixelColumnFast(SSA, 29);
            for (int i = 0; i < e.Length; i++)
            {
                if ((e[i].R == 232 && e[i].G == 232 && e[i].B == 232) && (e[i + 1].R == 174 && e[i + 1].G == 174 && e[i + 1].B == 174) && (e[i + 2].R == 174 && e[i + 2].G == 174 && e[i + 2].B == 174) && (e[i + 3].R == 227 && e[i + 3].G == 227 && e[i + 3].B == 227))
                    return true;
            }
            return false;
        }

        internal static void ShowDialogBox(string Body, string Title, string Button)
        {
            DialogBoxProperties.body = Body;
            DialogBoxProperties.Title = Title;
            DialogBoxProperties.OkButton = Button;
            DialogBox dialogbox = new DialogBox();
            dialogbox.Show();
        }
        internal static bool isLoggedIn()
        {
            try
            {
                Rectangle rect = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Bitmap online = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(online);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, online.Size, CopyPixelOperation.SourceCopy);

                Color HPscanbegin = online.GetPixel(20, 100);
                if (HPscanbegin.R == 4 && HPscanbegin.B == 32 && HPscanbegin.G == 16)
                {
                    online.Dispose();
                    g.Dispose();
                    return false;
                }
                else
                {
                    online.Dispose();
                    g.Dispose();
                    return true;
                }
            }
            catch
            { return true; }

        }
        internal static void setResolution()
        {
            try
            {
                MySql.Data.MySqlClient.MySqlConnection con = new
    MySql.Data.MySqlClient.MySqlConnection("Server=safebresolutions.db.9086649.hostedresource.com;Database=safebresolutions;Uid=resolutionsro;Pwd=SaFeBotCD1@@");

                string cmd = "SELECT `Height`,`Width`,`HPX`,`HPY`,`MPX`,`MPY`,`FlagX`,`FlagY`,`MenuX`,`MenuY`,`BarX`,`BarY`,`LoginX`,`LoginY` FROM `Rx` WHERE `Height` = " + Screen.PrimaryScreen.Bounds.Height + " and `Width` =" + Screen.PrimaryScreen.Bounds.Width;
                con.Open();

                MySql.Data.MySqlClient.MySqlCommand getAccount = new MySql.Data.MySqlClient.MySqlCommand(cmd, con);
                MySql.Data.MySqlClient.MySqlDataReader dr = getAccount.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        if (dr["Width"].Equals(Screen.PrimaryScreen.Bounds.Width) && dr["Height"].Equals(Screen.PrimaryScreen.Bounds.Height))
                        {
                            HPScreenX = Convert.ToInt32(dr["HPX"].ToString());
                            HPScreenY = Convert.ToInt32(dr["HPY"].ToString());
                            MPScreenX = Convert.ToInt32(dr["MPX"].ToString());
                            MPScreenY = Convert.ToInt32(dr["MPY"].ToString());
                            FlagsBarx = Convert.ToInt32(dr["FlagX"].ToString());
                            FlagsBary = Convert.ToInt32(dr["FlagY"].ToString());
                            SafeBotMenu_X = Convert.ToInt32(dr["MenuX"].ToString());
                            SafeBotMenu_Y = Convert.ToInt32(dr["MenuY"].ToString());
                            ManaBarX = Convert.ToInt32(dr["BarX"].ToString());
                            ManaBarY = Convert.ToInt32(dr["BarY"].ToString());
                            LoginButtonX = Convert.ToInt32(dr["LoginX"].ToString());
                            LoginButtonY = Convert.ToInt32(dr["LoginY"].ToString());
                        }
                    }
                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("There was an error while we tried to match up your current resolution.\r\nPlease Try Again Later. If it keeps not working please contact me at admin@tibiasafebot.com");
                        Application.Exit();
                    }
                }
                catch
                {
                    MessageBox.Show("There was an error while we tried to match up your current resolution.\r\nPlease Try Again Later. If it keeps not working please contact me at admin@tibiasafebot.com");
                }

                dr.Close();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Make sure you are connected to the Internet");
            }
        }
        //catch no resolution available
        /*
            else
            {
                if (MessageBox.Show("There was an error while we tried to set up your current resolution, if you wish the developer to add a resolution for your screen please click 'Yes'", "Disclaimer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    IntPtr Tibia = WindowsHandlers.FindWindow("TibiaClient", "Tibia");
                    if (Tibia == IntPtr.Zero)
                    {
                        MessageBox.Show("Tibia Client not found, SafeBot Will now exit.", "Open Tibia Client");
                        Application.Exit();
                    }
                    else
                    {
                        WindowsHandlers.SetForegroundWindow(WindowsHandlers.FindWindow("TibiaClient", "Tibia"));
                        MemoryStream ms = new MemoryStream();
                        System.Threading.Thread.Sleep(500);
                        Rectangle rect = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        Bitmap firstbmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                        Graphics g = Graphics.FromImage(firstbmp);
                        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, firstbmp.Size, CopyPixelOperation.SourceCopy);

                        firstbmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        String s = Convert.ToBase64String(ms.ToArray());

                        byte[] img = Convert.FromBase64String(s);
                        System.IO.File.WriteAllBytes(Screen.PrimaryScreen.Bounds.Width + "x" + Screen.PrimaryScreen.Bounds.Height + ".png", img);

                        MessageBox.Show("A imagine file (.png) has been generated in the directory please send this email to: admin@safebot.com or post it in the forum http://www.tibiasafebot.com/forums", "Screen Resolution");
                        Application.Exit();
                    }
                }
                else
                {
                    return;
                }
            }*/
        internal static bool isControlkeyDown()
        {
            if (Control.ModifierKeys == Keys.ControlKey)
                return true;
            else return false;
        }
        internal static void MoveItem(int xfrom, int yfrom, int xto, int yto, int waittime)
        {
            TimeSpan time = new TimeSpan(0,0,0,0,waittime);
            Client.MoveMouse(new Point(xto, yto), time);
            System.Threading.Thread.Sleep(waittime);

            WindowsHandlers.mouse_event(WindowsHandlers.MouseFlags.LEFTDOWN, xfrom, yfrom, 0, UIntPtr.Zero);
            Client.MoveMouse(new Point(xfrom, yfrom), time);
            WindowsHandlers.mouse_event(WindowsHandlers.MouseFlags.LEFTUP, xfrom, yfrom, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(waittime/3);
        }
        internal static void MoveMouse(Point newPosition, TimeSpan duration)
        {
            Point start = Cursor.Position;
            int sleep = 10;
            //PointF iterPoint = start;
            // Find the vector between start and newPosition   
            double deltaX = newPosition.X - start.X;
            double deltaY = newPosition.Y - start.Y;
            // start a timer    
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double timeFraction = 0.0;
            do
            {
                timeFraction = (double)stopwatch.Elapsed.Ticks / duration.Ticks;
                if (timeFraction > 1.0)
                    timeFraction = 1.0;
                PointF curPoint = new PointF((float)(start.X + timeFraction * deltaX), (float)(start.Y + timeFraction * deltaY));
                WindowsHandlers.SetCursorPos(Point.Round(curPoint).X, Point.Round(curPoint).Y);
                System.Threading.Thread.Sleep(sleep);
            } while (timeFraction < 1.0);
        }
        internal static Rectangle getClientDimensions()
        {
            Rectangle ClientSize = new Rectangle();
            WindowsHandlers.RECT rct;

            WindowsHandlers.GetWindowRect(WindowsHandlers.FindWindow("TibiaClient", "Tibia"), out rct);

            ClientSize.X = rct.Left;
            ClientSize.Y = rct.Top;
            ClientSize.Width = rct.Right - rct.Left;
            ClientSize.Height = rct.Bottom - rct.Top;

            return ClientSize;
        }
        internal static bool isClientTop()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = WindowsHandlers.GetForegroundWindow();

            if (WindowsHandlers.GetWindowText(handle, Buff, nChars) > 0)
            {
                if (Buff.ToString() == "Tibia")
                    return true;
            }
            else
            {
                return false;
            }
            return false;
        }
        internal static bool isBotTop()
        {
            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = WindowsHandlers.GetForegroundWindow();

            if (WindowsHandlers.GetWindowText(handle, Buff, nChars) > 0)
            {
                if (Buff.ToString() == Client.RandomName)
                    return true;
            }
            else
            {
                return false;
            }
            return false;
        }
        public static DateTime GetDummyDate()
        {
            return new DateTime(1000, 1, 1); //to check if we have an online date or not.
        }
        public static DateTime GetNISTDate()
        {
            System.Random ran = new System.Random(DateTime.Now.Millisecond);
            DateTime date = GetDummyDate();
            string serverResponse = string.Empty;

            // Represents the list of NIST servers
            string[] servers = new string[] {
                         "time-a.nist.gov",
                         "nist1-chi.ustiming.org",
                         "ntp-nist.ldsbc.edu"                    
                          };

            // Try each server in random order to avoid blocked requests due to too frequent request
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    // Open a StreamReader to a random time server
                    StreamReader reader = new StreamReader(new System.Net.Sockets.TcpClient(servers[ran.Next(0, servers.Length)], 13).GetStream());
                    serverResponse = reader.ReadToEnd();
                    reader.Close();

                    // Check to see that the signature is there
                    if (serverResponse.Length > 47 && serverResponse.Substring(38, 9).Equals("UTC(NIST)"))
                    {
                        // Parse the date
                        int jd = int.Parse(serverResponse.Substring(1, 5));
                        int yr = int.Parse(serverResponse.Substring(7, 2));
                        int mo = int.Parse(serverResponse.Substring(10, 2));
                        int dy = int.Parse(serverResponse.Substring(13, 2));
                        int hr = int.Parse(serverResponse.Substring(16, 2));
                        int mm = int.Parse(serverResponse.Substring(19, 2));
                        int sc = int.Parse(serverResponse.Substring(22, 2));

                        if (jd > 51544)
                            yr += 2000;
                        else
                            yr += 1999;

                        date = new DateTime(yr, mo, dy, hr, mm, sc);

                        // Exit the loop
                        break;
                    }

                }
                catch
                {
                    /* Do Nothing...try the next server */
                }
            }

            return date;
        }


    }

}