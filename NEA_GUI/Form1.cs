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
            Server._Server();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string msg;
            msg = formatBox.Text;
            displayBox.AppendText(msg + Environment.NewLine);
            formatBox.Text = string.Empty; 
        }
        public void displayBox_TextChanged(object sender, EventArgs e)
        {
            int lineCount;
            lineCount = displayBox.GetLineFromCharIndex(displayBox.TextLength);
            lineCounter.Text = Convert.ToString(lineCount);  
        }

    }

    public class Server
    {
        public void _Server() 
        {
            TcpListener listener;
            var port = 1200;
            var serverIP = IPAddress.Parse("127.0.0.1");
            byte[] buffer = new byte[512];  
            listener = new TcpListener(serverIP,port);
            string msg;

            using TcpClient tcpClient = listener.AcceptTcpClient();
            
                var netStream = tcpClient.GetStream();
            int streamLength;
            while ((streamLength = netStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                msg = Encoding.UTF8.GetString(buffer,0,buffer.Length);
                displayBox.Text = msg;
            }  
            

        }
    }

}
