using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessengerServer
{
    public partial class Form1 : Form
    {
        ServerManager mServer;
        int mPort = 1100;
        delegate void SetServerMsgCallback(object sender, EventArgs e);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mServer = new ServerManager(mPort);
            mServer.BufferChanged += new EventHandler(mServer_BufferChanged);
            mServer.DoRun();
            this.richTextBox1.AppendText("dfadsfasdfads");

        }

        void mServer_BufferChanged(object sender, EventArgs e)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                SetServerMsgCallback d = new SetServerMsgCallback(mServer_BufferChanged);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.richTextBox1.AppendText(mServer.getBuffer());
            }
        }

        void setMsgChange()
        {
        }
    }
}
