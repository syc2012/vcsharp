using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;


namespace MySerialPort
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private StreamWriter logFile = null;

        private string recvMsg;
        private string[] recvBuf;
        private int recvIdx = 0;


        public Form1()
        {
            InitializeComponent();

            serialPort = new SerialPort();

            recvBuf = new string[2];
            recvBuf[0] = string.Empty;
            recvBuf[1] = string.Empty;
            recvMsg = string.Empty;

            BDisconnect.Enabled = false;
            BSend.Enabled = false;
            BClean.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            serialPort.DataReceived -= DataRecvHandler;
            serialPort.Close();
            if (logFile != null)
            {
                logFile.Close();
            }
        }


        delegate void ProcTextCallback(string str);
        private void ProcText(string str)
        {
            if (this.InvokeRequired)
            {
                ProcTextCallback d = new ProcTextCallback(ProcText);
                this.Invoke(d, new object[]{str});
            }
            else
            {
                this.TRecv.Text += str;
                logFile.WriteLine(str);
            }
        }

        private void DataRecvHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType != SerialData.Chars)
            {
                return;
            }
            if (serialPort.BytesToRead <= 0)
            {
                return;
            }

            string data = serialPort.ReadExisting();

            foreach (char c in data)
            {
                recvBuf[recvIdx] += c;
                if (c == 0x0a)
                {
                    recvMsg = recvBuf[recvIdx];
                    //MessageBox.Show(recvMsg);

                    ProcText(recvMsg);

                    recvIdx ^= 0x1;
                    recvBuf[recvIdx] = string.Empty;
                }
            }
        }


        private void BConnect_Click(object sender, EventArgs e)
        {
            if (logFile == null)
            {
                logFile = File.CreateText("MySerialPort.txt");
            }

            try
            {
                recvBuf[0] = string.Empty;
                recvBuf[1] = string.Empty;
                recvMsg = string.Empty;

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataRecvHandler);
                // 設定 Serial Port 參數
                serialPort.PortName = this.TPort.Text.ToString();
                serialPort.BaudRate = Int32.Parse(this.TBaud.Text.ToString());
                serialPort.Parity = 0;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;

                // 開啟 Serial Port
                serialPort.Open();

                this.TRecv.Text = String.Empty;
                BDisconnect.Enabled = true;
                BSend.Enabled = true;
                BClean.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BClean_Click(object sender, EventArgs e)
        {
            this.TSend.Text = String.Empty;
            this.TRecv.Text = String.Empty;
        }

        private void BSend_Click(object sender, EventArgs e)
        {
            byte[] txBuf = Encoding.ASCII.GetBytes(this.TSend.Text + "\r\n");

            try
            {
                logFile.WriteLine(this.TSend.Text.ToString());

                this.TRecv.Text = String.Empty;

                serialPort.Write(txBuf, 0, txBuf.Length);


                #if false
                {
                    int delay = int.Parse(TDelay.Text.ToString());
                    Thread.Sleep(delay);

                    string data = My_SerialPort.ReadExisting();

                    this.TRecv.Text += data + "\r\n";
                    logFile.WriteLine(data + "\r\n");
                }
                #endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BDisconnect_Click(object sender, EventArgs e)
        {
            serialPort.DataReceived -= DataRecvHandler;
            serialPort.Close();

            if (logFile != null)
            {
                logFile.Close();
                logFile = null;
            }

            BDisconnect.Enabled = false;
            BSend.Enabled = false;
            BClean.Enabled = false;
        }
    }
}
