using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NEA_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }
        private void Send_Click(object sender, EventArgs e)
        {
            string msg;
            msg = formatBox.Text;

            tcpClient client = new tcpClient();
            client.Connect(msg);
        }
        public void displayBox_TextChanged(object sender, EventArgs e)
        {
            int lineCount;
            lineCount = displayBox.GetLineFromCharIndex(displayBox.TextLength);
            lineCounter.Text = Convert.ToString(lineCount);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int port = 16000;
            IPAddress IP = IPAddress.Parse("192.168.0.23");

            TcpListener server = new TcpListener(IP, port);

            server.Start();

            int bufferSize = 256;

            byte[] rawData = new byte[bufferSize];
            string msg = string.Empty;

            while (true)
            {
                Invoke(new Action(() => displayBox.AppendText("Waiting for connection... on " + Environment.NewLine)));

                // var startClient = new tcpClient();
                // startClient.Connect();

                using TcpClient client = server.AcceptTcpClient();
                Invoke(new Action(() => displayBox.AppendText("Connected" + Environment.NewLine)));

                NetworkStream clientStream = client.GetStream();
                int dataLength;

                while ((dataLength = clientStream.Read(rawData, 0, bufferSize)) != 0)
                {
                    msg = Encoding.UTF8.GetString(rawData, 0, dataLength);
                    Invoke(new Action(() => displayBox.AppendText(msg + Environment.NewLine)));
                    }
                }
            }
        }
    }

class tcpClient
{
    public void Connect(string msg)
    {
        int port = 16000;
        string IP = "127.0.0.1";

        using TcpClient client = new TcpClient(IP, port);
        
        byte[] msgByte = Encoding.UTF8.GetBytes(msg);

        NetworkStream clientStream = client.GetStream();
        clientStream.Write(msgByte, 0, msgByte.Length);

    }
}


