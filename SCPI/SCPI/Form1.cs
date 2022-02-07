using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SCPI;

namespace SCPI
{
    public partial class Form1 : Form
    {
        StreamWriter m_logStream = null;
        MXA m_mxa = null;
        MXG m_mxg = null;

        private string m_logName = "SCPI.log";

        public Form1()
        {
            InitializeComponent();
            this.textConsole.Text = string.Empty;
            this.mxaCmd.Enabled = false;
            this.mxgCmd.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_mxa = new MXA(this);
            m_mxg = new MXG(this);

            if (m_logStream == null)
            {
                /* Open log file */
                m_logStream = File.CreateText(m_logName);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_mxa.DisconnectLAN();
            m_mxg.DisconnectLAN();

            if (m_logStream != null)
            {
                m_logStream.Close();
            }
        }

        private void mxaConnect_Click(object sender, EventArgs e)
        {
            bool success;

            //this.textConsole.AppendText("MXA\r\n\r\n");

            success = m_mxa.ConnectLAN(this.mxaIP.Text.ToString(), this.mxaPort.Text.ToString());
            if (success)
            {
                this.mxaConnect.Enabled = false;
                this.mxaCmd.Enabled = true;
            }
        }

        private void mxgConnect_Click(object sender, EventArgs e)
        {
            bool success;

            //this.textConsole.AppendText("MXG\r\n\r\n");

            success = m_mxg.ConnectLAN(this.mxgIP.Text.ToString(), this.mxgPort.Text.ToString());
            if (success)
            {
                this.mxgConnect.Enabled = false;
                this.mxgCmd.Enabled = true;
            }
        }

        private void mxaSend_Click(object sender, EventArgs e)
        {
            m_mxa.proxySend(this.mxaCmd.Text.ToString());
        }

        private void mxgSend_Click(object sender, EventArgs e)
        {
            m_mxg.proxySend(this.mxgCmd.Text.ToString());
        }


        delegate void ConsolePrintCallback(string str);
        public void ConsolePrint(string str)
        {
            if (this.InvokeRequired)
            {
                ConsolePrintCallback d = new ConsolePrintCallback(ConsolePrint);
                this.Invoke(d, new object[] { str });
            }
            else
            {
                this.textConsole.AppendText(str);
                //this.textConsole.Refresh();
            }
        }

    }
}
