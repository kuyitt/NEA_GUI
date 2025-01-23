namespace NEA_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Send = new Button();
            formatBox = new TextBox();
            displayBox = new TextBox();
            lineCounter = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // Send
            // 
            Send.Location = new Point(587, 457);
            Send.Name = "Send";
            Send.Size = new Size(87, 24);
            Send.TabIndex = 0;
            Send.Text = "Send";
            Send.UseVisualStyleBackColor = true;
            Send.Click += Send_Click;
            // 
            // formatBox
            // 
            formatBox.Location = new Point(13, 458);
            formatBox.Name = "formatBox";
            formatBox.Size = new Size(568, 23);
            formatBox.TabIndex = 2;
            // 
            // displayBox
            // 
            displayBox.Location = new Point(13, 12);
            displayBox.Multiline = true;
            displayBox.Name = "displayBox";
            displayBox.ReadOnly = true;
            displayBox.Size = new Size(661, 439);
            displayBox.TabIndex = 3;
            displayBox.TextChanged += displayBox_TextChanged;
            // 
            // lineCounter
            // 
            lineCounter.Location = new Point(680, 12);
            lineCounter.Name = "lineCounter";
            lineCounter.ReadOnly = true;
            lineCounter.Size = new Size(57, 23);
            lineCounter.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1362, 707);
            Controls.Add(lineCounter);
            Controls.Add(displayBox);
            Controls.Add(formatBox);
            Controls.Add(Send);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Send;
        private TextBox formatBox;
        private TextBox displayBox;
        private TextBox lineCounter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
