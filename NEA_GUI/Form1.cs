using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NEA_GUI
{
    public partial class Form1 : Form
    {
        bool clientNeeded = true;
        TcpClient activeClient;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }
        private void Send_Click(object sender, EventArgs e)
        {
            string msg;
            msg = formatBox.Text;

            byte[] msgByte = Encoding.UTF8.GetBytes(msg);

            if (clientNeeded == true)
            {
                activeClient = Connect();
                clientNeeded = false;
            }

            NetworkStream clientStream = activeClient.GetStream();
            clientStream.Write(msgByte, 0, msgByte.Length);

            string responseString;
            byte[] serverResponse = new byte[256];
            int bytes = clientStream.Read(serverResponse, 0, serverResponse.Length);
            responseString = Encoding.UTF8.GetString(serverResponse,0,bytes);

            MessageBox.Show(responseString);

        }
        public TcpClient Connect()
        {
            int port = 16000;
            string IP = "192.168.0.23";

            TcpClient client = new TcpClient(IP, port);
            clientNeeded = false;

            return client;
        }
        public void DisposeClient(TcpClient client)
        {
            client.Close();
            clientNeeded = true;
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
                Invoke(new Action(() => displayBox.AppendText("Waiting for connection... on " + IP + Environment.NewLine)));

                using TcpClient client = server.AcceptTcpClient();
                Invoke(new Action(() => displayBox.AppendText("Connected" + Environment.NewLine)));

                NetworkStream clientStream = client.GetStream();
                int dataLength;

                while ((dataLength = clientStream.Read(rawData, 0, bufferSize)) != 0)
                {
                    msg = Encoding.UTF8.GetString(rawData, 0, dataLength);
                    Invoke(new Action(() => displayBox.AppendText(msg + Environment.NewLine)));

                    msg = msg.ToUpper();
                    byte[] response = Encoding.UTF8.GetBytes(msg,0, dataLength);

                    clientStream.Write(response, 0, response.Length);
                }
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            DisposeClient(activeClient);
        }
    }
}



