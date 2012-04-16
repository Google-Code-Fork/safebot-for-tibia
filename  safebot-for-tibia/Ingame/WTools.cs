using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SafeBot.Ingame
{
    public partial class WTools : Form
    {
        private static int port = 7575;
        private static TcpClient tcpclnt;
        private static NetworkStream NaviStream;
        private static Socket socket;


        public WTools()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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

        private void SetNavigationServer()
        {
            try
            {

                IPAddress ipAddress = IPAddress.Any;
                TcpListener listener = new TcpListener(ipAddress, port);
                listener.Start();

                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + "  Server is running";
                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + "  Listening on port " + port;
                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + "  Waiting for connections...";
                NaviConsole.SelectionStart = NaviConsole.Text.Length;
                NaviConsole.ScrollToCaret();
                NaviPrintLine.Clear();

                while (true)
                {
                    Socket s = listener.AcceptSocket();
                    NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + "  Connection accepted from " + s.RemoteEndPoint;
                    NaviConsole.SelectionStart = NaviConsole.Text.Length;
                    NaviConsole.ScrollToCaret();
                    NaviPrintLine.Clear();

                    byte[] b = new byte[65535];
                    int k = s.Receive(b);
                    string oi = Encoding.ASCII.GetString(b);
                    /*
                    NaviConsole.Text += Environment.NewLine + DateTime.Now.ToShortTimeString() + "Received:" + oi;*/

                    if (oi.ToString().Contains("password"))
                    {
                        ASCIIEncoding enc = new ASCIIEncoding();
                            NaviConsole.Text += Environment.NewLine + DateTime.Now.ToShortTimeString() + "  \nSent Response";
                            NaviConsole.SelectionStart = NaviConsole.Text.Length;
                            NaviConsole.ScrollToCaret();
                            NaviPrintLine.Clear();
                            NaviConsole.Text += s.Receive(b);
                    }
                    else
                    {
                        MessageBox.Show("It is not");
                    }
                }
            }
            catch
            {
                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + "  There was an error while the server tried to go online. Make sure your ports are opened.";
                NaviConsole.SelectionStart = NaviConsole.Text.Length;
                NaviConsole.ScrollToCaret();
                NaviPrintLine.Clear();
            }
            
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Thread oi = new Thread(new ThreadStart(SetNavigationServer));

            if (NaviPrintLine.Text == "/start")
            {
                oi.Start();
            }
            if (NaviPrintLine.Text == "/stop")
            {

                NaviConsole.ForeColor = Color.Red;
                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + "  function is still not implemented";
                NaviConsole.SelectionStart = NaviConsole.Text.Length;
                NaviConsole.ScrollToCaret();
                NaviPrintLine.Clear();
            }
            if (NaviPrintLine.Text == "/send")
            {
                try
                { // sends the text with timeout 10s
                    Send(socket, Encoding.UTF8.GetBytes(textBox2.Text), 0, textBox2.Text.Length, 5000);
                }
                catch { }
            }

        }

        private void WTools_Load(object sender, EventArgs e)
        {
           NaviPrintLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IP = IPAddressString.Text;

            try
            {
                tcpclnt = new TcpClient();
                socket = new Socket(AddressFamily.InterNetwork,
   SocketType.Stream, ProtocolType.Tcp);
                socket = tcpclnt.Client;
                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + DateTime.Now.ToShortTimeString() + "  Connecting....";
                NaviConsole.SelectionStart = NaviConsole.Text.Length;
                NaviConsole.ScrollToCaret();
                NaviPrintLine.Clear();
                tcpclnt.Connect(IP, 7575);
                NaviStream = tcpclnt.GetStream();
                KeepAlive.Start();
            }

            catch
            {
                    DateTime now = DateTime.Now;
                    NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + now.ToShortTimeString() +" Unable to establish a connection.";
                    NaviConsole.SelectionStart = NaviConsole.Text.Length;
                    NaviConsole.ScrollToCaret();
                    NaviPrintLine.Clear();
                    return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tcpclnt.Connected == true)
            {

                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + DateTime.Now.ToShortTimeString() + "  You are now disconnected! Good bye.";
                NaviConsole.SelectionStart = NaviConsole.Text.Length;
                NaviConsole.ScrollToCaret();
                NaviPrintLine.Clear();
                tcpclnt.Close();
                KeepAlive.Stop();
            }
            else
            {
                NaviConsole.Text+= Environment.NewLine + DateTime.Now.ToShortTimeString() + DateTime.Now.ToShortTimeString() + "  You are not connected to a server.";
                NaviConsole.SelectionStart = NaviConsole.Text.Length;
                NaviConsole.ScrollToCaret();
                NaviPrintLine.Clear();
            }
        }

        public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably empty, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (received < size);
        }

        public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;  // how many bytes is already sent
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably full, wait and try again
                        Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (sent < size);
        }

        private void KeepAlive_Tick(object sender, EventArgs e)
        {
            byte[] dumb = StrToByteArray("");
            Send(socket, dumb, 0, 0, 1000);
        }

    }
}
