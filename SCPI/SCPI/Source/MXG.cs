using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using SCPI;


namespace SCPI
{
    public class MXG
    {
        private Form1 m_form = null;
        private SocketProxy m_socketProxy = null;

        public MXG(Form1 form)
        {
            m_socketProxy = new SocketProxy();
            m_form = form;
        }

        public bool ConnectLAN(string ip, string port)
        {
            m_form.ConsolePrint("MXG  " + ip + " " + port + "\r\n");

            m_socketProxy.Connect(ip, port);
            if ( m_socketProxy._isConnected )
            {
                m_form.ConsolePrint("MXG connected throufh LAN: " + m_socketProxy.GetModelName() + "\r\n\r\n");
                return true;
            }

            return false;
        }

        public void DisconnectLAN()
        {
            //proxySend("CALC:MARK1:FCO OFF");
            m_socketProxy.Close();
        }

        public void proxySend(string cmd)
        {
            m_socketProxy.Send(cmd);
            Thread.Sleep(100);
        }

        public string proxyQuery(string cmd)
        {
            return m_socketProxy.Query(cmd);
            //Thread.Sleep(200);
        }

        public void Reset()
        {
            //proxySend(":INST SA;*WAI");
            //Thread.Sleep(200);

            //proxySend("FREQ:SPAN 1MHz");
            //Thread.Sleep(200);

            //proxySend("SWE:POIN 1001");
            //Thread.Sleep(200);

            //proxySend("BWID:AUTO ON");
            //proxySend("BWID:VID:AUTO ON");
            //Thread.Sleep(200);
        }

        public void SetFreq(uint freq, double output)
        {
            proxySend("OUTP:STAT OFF");
            proxySend(string.Format("FREQ {0} MHz", freq));
            proxySend(":OUTPut:MODulation:STATe ON");
            proxySend("OUTP:STAT ON");
            proxySend(string.Format("POW:AMPL {0} dBm", output));
        }
    }
}

