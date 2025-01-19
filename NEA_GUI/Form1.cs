namespace NEA_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string msg;
            msg = formatBox.Text;
            displayBox.AppendText(msg + Environment.NewLine);
            formatBox.Text = string.Empty;
        }
        private void displayBox_TextChanged(object sender, EventArgs e)
        {
            int lineCount;
            lineCount = displayBox.GetLineFromCharIndex(displayBox.TextLength);
            lineCounter.Text = Convert.ToString(lineCount);  
        }

    }

}
