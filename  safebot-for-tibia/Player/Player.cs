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

namespace SafeBot
{

    public partial class Player
    {
        internal static int HP;
        internal static int MP;
        internal static Bitmap hpbmp;
        internal static Bitmap hastebmp;
        internal static Bitmap pzbmp;

        internal static int getHP()
        {
            try
            {
                int HPmiddle = 0;
                int HPbegin = 0;
                int HPend = 87;
                int totalEnd = 0;
                int totalbegin = 0;
                int totalMiddle = 0;

                Rectangle rect = new Rectangle(Client.HPScreenX, Client.HPScreenY, 92, 12);
                Bitmap hpbmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(hpbmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, hpbmp.Size, CopyPixelOperation.SourceCopy);

                for (int y = 1; y < 5; y++)
                {
                    Color HPscanbegin = hpbmp.GetPixel(y, 5);
                    if (HPscanbegin.R == 120 && HPscanbegin.B == 64 && HPscanbegin.G == 61)
                        totalbegin = (1 * 100) / 90;
                    else if (HPscanbegin.R == 211 && HPscanbegin.B == 79 && HPscanbegin.G == 79)
                        totalbegin = (2 * 100) / 90;
                    else if (HPscanbegin.R == 219 && HPscanbegin.B == 79 && HPscanbegin.G == 79)
                    {
                        HPbegin++;
                        totalbegin = (HPbegin * 100) / 90;
                    }
                    else { }
                }

                for (int x = 5; x < 87; x++)
                {
                    Color HPscan = hpbmp.GetPixel(x, 2);
                    if (HPscan.R == 144 && HPscan.B == 46 && HPscan.G == 46)
                    {
                        HPmiddle++;
                        totalMiddle = (HPmiddle * 100) / 90;
                    }
                    else { }
                }

                for (int z = 87; z < 91; z++)
                {
                    Color HPscanend = hpbmp.GetPixel(z, 5);
                    if (HPscanend.R == 219 && HPscanend.B == 79 && HPscanend.G == 79)
                    {
                        HPend++;
                        totalEnd = (HPend * 100) / 90;
                    }
                    else if (HPscanend.R == 194 && HPscanend.B == 74 && HPscanend.G == 74)
                        totalEnd = (89 * 100) / 90;
                    else if (HPscanend.R == 100 && HPscanend.B == 49 && HPscanend.G == 46)
                        totalEnd = (90 * 100) / 90;
                    else { }
                }

                hpbmp.Dispose();
                g.Dispose();
                //red hp
                if (HPbegin >= 0 && HPmiddle <= 5 && HPend <= 87)
                    return totalbegin;
                else if (HPbegin > 0 && HPmiddle > 5 && HPend <= 87)
                    return totalMiddle;
                else if (HPbegin > 0 && HPmiddle > 5 && HPend >= 87)
                    return totalEnd;
                else { return 101; }
            }
            catch
            {
                return 101;
            }

        }
        internal static int getMP()
        {
            try
            {
                int MPmiddle = 0;
                int MPbegin = 0;
                int MPend = 87;
                int totalEnd = 0;
                int totalbegin = 0;
                int totalMiddle = 0;

                Rectangle rect = new Rectangle(Client.MPScreenX, Client.MPScreenY, 92, 12);
                hpbmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(hpbmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, hpbmp.Size, CopyPixelOperation.SourceCopy);

                for (int y = 1; y < 5; y++)
                {
                    Color HPscanbegin = hpbmp.GetPixel(y, 5);
                    if (HPscanbegin.R == 55 && HPscanbegin.B == 71 && HPscanbegin.G == 60)
                        totalbegin = 0;
                    if (HPscanbegin.R == 61 && HPscanbegin.B == 125 && HPscanbegin.G == 61)
                        totalbegin = (1 * 100) / 90;
                    else if (HPscanbegin.R == 82 && HPscanbegin.B == 211 && HPscanbegin.G == 79)
                        totalbegin = (2 * 100) / 90;
                    else if (HPscanbegin.R == 83 && HPscanbegin.B == 218 && HPscanbegin.G == 80)
                    {
                        MPbegin++;
                        totalbegin = (MPbegin * 100) / 90;
                    }
                    else { }
                }

                for (int z = 87; z < 91; z++)
                {
                    Color HPscanend = hpbmp.GetPixel(z, 5);
                    if (HPscanend.R == 83 && HPscanend.B == 218 && HPscanend.G == 80)
                    {
                        MPend++;
                        totalEnd = (MPend * 100) / 90;
                    }
                    else if (HPscanend.R == 77 && HPscanend.B == 194 && HPscanend.G == 74)
                        totalEnd = (89 * 100) / 90;
                    else if (HPscanend.R == 45 && HPscanend.B == 105 && HPscanend.G == 45)
                        totalEnd = (90 * 100) / 90;
                    else { }
                }

                for (int x = 5; x < 87; x++)
                {
                    Color HPscan = hpbmp.GetPixel(x, 2);
                    if (HPscan.R == 47 && HPscan.B == 145 && HPscan.G == 45)
                    {
                        MPmiddle++;
                        totalMiddle = (MPmiddle * 100) / 90;
                    }
                    else { }
                }
                hpbmp.Dispose();
                g.Dispose();

                if (MPbegin >= 0 && MPmiddle <= 5 && MPend <= 87)
                    return totalbegin;
                else if (MPbegin > 0 && MPmiddle > 5 && MPend <= 87)
                    return totalMiddle;
                else if (MPbegin > 0 && MPmiddle > 5 && MPend >= 87)
                    return totalEnd;
                else { return 101; }
            }
            catch
            {
                return 101;
            }

        }
        internal static bool isSelfHasted()
        {
            try
            {
                Rectangle rect = new Rectangle(Client.FlagsBarx, Client.FlagsBary, 108, 13);
                hastebmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(hastebmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, hastebmp.Size, CopyPixelOperation.SourceCopy);
                UnsafeBitmap test = new UnsafeBitmap(hastebmp);
                test.LockBitmap();

                for (int i = 4; i < 108; )
                {
                    PixelData flag_one = test.GetPixel(i, 3);
                    PixelData flag_two = test.GetPixel(i + 1, 3);
                    i = i + 10;
                    if ((flag_one.red == 68 && flag_one.green == 59 && flag_one.blue == 44) && (flag_two.red == 184 && flag_two.green == 166 && flag_two.blue == 138))
                        hastebmp.Dispose();
                    g.Dispose();
                    test.Dispose();
                    return true;
                }
                hastebmp.Dispose();
                g.Dispose();
                test.Dispose();
                return false;
            }
            catch
            {
                return false;
            }

        }
        internal static bool isSelfPoisoned()
        {
            try
            {
                Rectangle rect = new Rectangle(Client.FlagsBarx, Client.FlagsBary, 108, 13);
                hastebmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(hastebmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, hastebmp.Size, CopyPixelOperation.SourceCopy);
                UnsafeBitmap test = new UnsafeBitmap(hastebmp);
                test.LockBitmap();

                for (int i = 4; i < 108; )
                {
                    PixelData flag_one = test.GetPixel(i, 6);
                    PixelData flag_two = test.GetPixel(i + 1, 6);
                    i = i + 10;
                    if ((flag_one.red == 46 && flag_one.green == 85 && flag_one.blue == 52) && (flag_two.red == 64 && flag_two.green == 198 && flag_two.blue == 82))
                        hastebmp.Dispose();
                    g.Dispose();
                    test.Dispose();
                    return true;
                }

                hastebmp.Dispose();
                g.Dispose();
                test.Dispose();
                return false;
            }
            catch
            {
                return false;
            }

        }
        internal static bool isSelfProtectionZone()
        {
            try
            {
                Rectangle rect = new Rectangle(Client.FlagsBarx, Client.FlagsBary, 108, 13);
                pzbmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(pzbmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, pzbmp.Size, CopyPixelOperation.SourceCopy);
                UnsafeBitmap test = new UnsafeBitmap(pzbmp);
                test.LockBitmap();

                for (int i = 2; i < 108; )
                {
                    PixelData flag_one = test.GetPixel(i, 6);
                    PixelData flag_two = test.GetPixel(i + 1, 6);
                    i = i + 10;
                    if ((flag_one.red == 201 && flag_one.green == 217 && flag_one.blue == 244) && (flag_two.red == 255 && flag_two.green == 255 && flag_two.blue == 255))
                        hastebmp.Dispose();
                    g.Dispose();
                    test.Dispose();
                    return true;
                }
                hastebmp.Dispose();
                g.Dispose();
                test.Dispose();

                return false;
            }
            catch
            {
                return false;
            }
        }
        internal static bool isSelfManaShielded()
        {
            try
            {
                Rectangle rect = new Rectangle(Client.FlagsBarx, Client.FlagsBary, 108, 13);
                pzbmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(pzbmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, pzbmp.Size, CopyPixelOperation.SourceCopy);
                UnsafeBitmap test = new UnsafeBitmap(pzbmp);
                test.LockBitmap();

                for (int i = 2; i < 108; )
                {
                    PixelData flag_one = test.GetPixel(i, 6);
                    PixelData flag_two = test.GetPixel(i + 1, 6);
                    i = i + 10;
                    if ((flag_one.red == 41 && flag_one.green == 45 && flag_one.blue == 148) && (flag_two.red == 92 && flag_two.green == 106 && flag_two.blue == 220))
                        hastebmp.Dispose();
                    g.Dispose();
                    test.Dispose();
                    return true;
                }
                hastebmp.Dispose();
                g.Dispose();
                test.Dispose();
                return false;
            }
            catch
            {
                return false;
            }
        }
        internal static bool isSelfParalyzed()
        {
            try
            {
                Rectangle rect = new Rectangle(Client.FlagsBarx, Client.FlagsBary, 108, 13);
                pzbmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(pzbmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, pzbmp.Size, CopyPixelOperation.SourceCopy);
                UnsafeBitmap test = new UnsafeBitmap(pzbmp);
                test.LockBitmap();

                for (int i = 2; i < 108; )
                {
                    PixelData flag_one = test.GetPixel(i, 6);
                    PixelData flag_two = test.GetPixel(i + 1, 6);
                    i = i + 10;
                    if ((flag_one.red == 129 && flag_one.green == 24 && flag_one.blue == 23) && (flag_two.red == 144 && flag_two.green == 20 && flag_two.blue == 20))
                        hastebmp.Dispose();
                    g.Dispose();
                    test.Dispose();
                    return true;
                }
                hastebmp.Dispose();
                g.Dispose();
                test.Dispose();
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
