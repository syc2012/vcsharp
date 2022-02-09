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
    public class MXA
    {
        private Form1 m_form = null;
        private SocketProxy m_socketProxy = null;

        public MXA(Form1 form)
        {
            m_socketProxy = new SocketProxy();
            m_form = form;
        }

        public bool ConnectLAN(string ip, string port)
        {
            m_form.ConsolePrint("MXA  " + ip + " " + port + "\r\n");

            m_socketProxy.Connect(ip, port);
            if ( m_socketProxy._isConnected )
            {
                m_form.ConsolePrint("MXA connected throufh LAN: " + m_socketProxy.GetModelName() + "\r\n\r\n");
                return true;
            }

            return false;
        }

        public void DisconnectLAN()
        {
            proxySend("CALC:MARK1:FCO OFF");
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
            proxySend(":INST SA;*WAI");
            Thread.Sleep(100);
            proxySend("FREQ:SPAN 1MHz");
            Thread.Sleep(100);
            proxySend("SWE:POIN 1001");
            Thread.Sleep(100);
            proxySend("BWID:AUTO ON");
            Thread.Sleep(100);
            proxySend("BWID:VID:AUTO ON");
            Thread.Sleep(100);
        }

        public void SetFreq(uint freq, int reflevel)
        {
            double sampleFreq = 3932.16;
            double offset = 0;

            proxySend("TRAC:TYPE WRIT");
            Thread.Sleep(100);
            offset = (freq >= (sampleFreq / 2)) ? -6 : 6;
            proxySend(string.Format("FREQ:CENT {0}MHz", freq + offset));
            Thread.Sleep(100);
            proxySend(string.Format("DISP:WIND:TRAC:Y:RLEV {0}dBm", reflevel));
            Thread.Sleep(100);
            proxySend("BWID:AUTO ON");
            Thread.Sleep(100);
            proxySend("BAND 9.1KHZ");
            Thread.Sleep(100);
            proxySend("BAND:VID 9.1KHZ");
            Thread.Sleep(100);
            proxySend("TRAC1:TYPE AVER");
            Thread.Sleep(100);
            proxySend("CALC:MARK1:FCO ON");
            Thread.Sleep(100);
        }

        public double GetPeakValue()
        {
            double result = 0;
            uint i = 0;

            proxySend("CALC:MARK1:MAX");
            Thread.Sleep(100);

            for (; i<10; i++)
            {
                result += Convert.ToDouble(proxyQuery("CALC:MARK1:Y?"));
                //Thread.Sleep(100);
            }

            return (result/10);
        }
    }
}

