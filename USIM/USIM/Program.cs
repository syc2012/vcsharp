using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace USIM
{
    class Program
    {

        static void Main(string[] args)
        {
            SCard usim = new SCard();

            if ((args.Length > 0) && (args[0].Equals("-v")))
            {
                //Console.WriteLine("verbose on");
                usim.m_verbose = true;
            }

            if (usim.Connect() == true)
            {
                usim.EF_ICCID();
                usim.EF_IMSI();
                usim.Disconnect();
            }
        }
    }
}
