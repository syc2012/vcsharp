using System;
using System.Diagnostics;
using System.Collections;
using System.Text;

using PCSC;
using PCSC.Iso7816;


namespace USIM
{
    public class SCard
    {
        SCardContext m_context = null;
        SCardReader m_reader = null;
        SCardPCI m_ioreq = null;
        IntPtr m_pci;

        public bool m_verbose;


        public SCard()
        {
            m_verbose = false;
        }

        ResponseApdu SendAPDU(CommandApdu apdu)
        {
            var recvBuff = new byte[256];
            SCardError error;

            error = m_reader.Transmit(m_pci, apdu.ToArray(), m_ioreq, ref recvBuff);
            if (error != SCardError.Success)
            {
                Console.WriteLine("ERR: " + SCardHelper.StringifyError( error ));
            }

            var resp = new ResponseApdu(recvBuff, apdu.Case, m_reader.ActiveProtocol);

            return resp;
        }

        private bool SelectMf()
        {
            bool success = false;

            var apdu = new CommandApdu(IsoCase.Case3Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x00,
                P2 = 0x0C,
                Data = new byte[] { 0x3F, 0x00 }
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x61) || (resp.SW1 == 0x90) || (resp.SW1 == 0x9F))
            {
                if ( m_verbose )
                {
                    Console.WriteLine("# select MF");
                }
                success = true;
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to select MF {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return success;
        }

        private bool SelectEfDir()
        {
            bool success = false;

            var apdu = new CommandApdu(IsoCase.Case3Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x00,
                P2 = 0x04,
                Data = new byte[] { 0x2F, 0x00 }
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x61) || (resp.SW1 == 0x90) || (resp.SW1 == 0x9F))
            {
                if ( m_verbose )
                {
                    Console.WriteLine("# select EF_DIR");
                }
                success = true;
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to select EF_DIR {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return success;
        }

        private bool SelectAdf()
        {
            bool success = false;

            byte[] aid = new byte[7] { 0xA0, 0x00, 0x00, 0x00, 0x87, 0x10, 0x02 };

            var apdu = new CommandApdu(IsoCase.Case3Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x04,
                P2 = 0x04,
                Data = aid
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x61) || (resp.SW1 == 0x90) || (resp.SW1 == 0x9F))
            {
                if (m_verbose)
                {
                    Console.WriteLine("# select ADF");
                }

                byte[] data = GetResponse(resp.SW2);
                if (data != null)
                {
                    success = true;
                }
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to select ADF {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return success;
        }

        private bool SelectEfIccid()
        {
            bool success = false;

            var apdu = new CommandApdu(IsoCase.Case3Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x00,
                P2 = 0x04,
                Data = new byte[] { 0x2F, 0xE2 }
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x61) || (resp.SW1 == 0x90) || (resp.SW1 == 0x9F))
            {
                if (m_verbose)
                {
                    Console.WriteLine("# select EF_ICCID");
                }
                success = true;
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to select EF_ICCID {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return success;
        }

        private bool SelectEfImsi()
        {
            bool success = false;

            var apdu = new CommandApdu(IsoCase.Case3Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.SelectFile,
                P1 = 0x00,
                P2 = 0x04,
                Data = new byte[] { 0x6F, 0x07 }
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x61) || (resp.SW1 == 0x90) || (resp.SW1 == 0x9F))
            {
                if ( m_verbose )
                {
                    Console.WriteLine("# select EF_IMSI");
                }
                success = true;
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to select EF_IMSI {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return success;
        }

        private byte[] ReadBinary(byte length)
        {
            byte[] data = null;

            var apdu = new CommandApdu(IsoCase.Case2Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.ReadBinary,
                P1 = 0x00,
                P2 = 0x00,
                Le = length
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x90) && (resp.SW2 == 0x00))
            {
                if ( m_verbose )
                {
                    Console.WriteLine("# read binary");
                }
                data = resp.GetData();
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to read binary {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return data;
        }

        private byte[] GetResponse(byte length)
        {
            byte[] data = null;

            var apdu = new CommandApdu(IsoCase.Case2Short, m_reader.ActiveProtocol)
            {
                CLA = 0x00,
                Instruction = InstructionCode.GetResponse,
                P1 = 0x00,
                P2 = 0x00,
                Le = length
            };

            var resp = SendAPDU( apdu );
            if ((resp.SW1 == 0x90) && (resp.SW2 == 0x00))
            {
                if (m_verbose)
                {
                    Console.WriteLine("# get repsonse");
                }
                data = resp.GetData();
            }
            else
            {
                Console.WriteLine(
                    "ERR: fail to get response {0:X} {1:X}",
                    resp.SW1,
                    resp.SW2
                );
            }

            return data;
        }


        public bool EF_ICCID()
        {
            string idStr;

            if ( !SelectMf() ) return false;
            if ( !SelectEfIccid() ) return false;

            byte[] iccid = ReadBinary( 10 );
            if (iccid == null) return false;

            byte digit;

            idStr = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                digit = (byte)((iccid[i]     ) & 0xF);
                if (digit == 0xF) break;

                idStr += digit.ToString();

                digit = (byte)((iccid[i] >> 4) & 0xF);
                if (digit == 0xF) break;

                idStr += digit.ToString();
            }

            Console.WriteLine("EF_ICCID: " + idStr);
            return true;
        }

        public bool EF_IMSI()
        {
            string mccStr;
            string mncStr;
            string msinStr;

            if (!SelectMf()) return false;
            if (!SelectAdf()) return false;
            if (!SelectEfImsi()) return false;

            byte[] imsi = ReadBinary(9);
            if (imsi == null) return false;

            byte digit;

            mccStr = string.Empty;
            digit = (byte)((imsi[1] >> 4) & 0xF);
            mccStr += digit.ToString();
            digit = (byte)((imsi[2]     ) & 0xF);
            mccStr += digit.ToString();
            digit = (byte)((imsi[2] >> 4) & 0xF);
            mccStr += digit.ToString();

            mncStr = string.Empty;
            digit = (byte)((imsi[3]     ) & 0xF);
            mncStr += digit.ToString();
            digit = (byte)((imsi[3] >> 4) & 0xF);
            mncStr += digit.ToString();

            msinStr = string.Empty;
            digit = (byte)((imsi[4]     ) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[4] >> 4) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[5]) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[5] >> 4) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[6]) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[6] >> 4) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[7]) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[7] >> 4) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[8]) & 0xF);
            msinStr += digit.ToString();
            digit = (byte)((imsi[8] >> 4) & 0xF);
            msinStr += digit.ToString();

            Console.WriteLine("EF_IMSI: " + mccStr + "." + mncStr + "." + msinStr);
            return true;
        }

        public bool Connect()
        {
            SCardProtocol protocol;
            SCardState state;
            SCardError error;


            m_context = new SCardContext();
            m_context.Establish( SCardScope.System );

            var nameList = m_context.GetReaders();

            foreach (string name in nameList)
            {
                Console.WriteLine( name );

                m_reader = new SCardReader( m_context );
                error = m_reader.Connect(name, SCardShareMode.Exclusive, SCardProtocol.Any);
                if (error != SCardError.Success)
                {
                    Console.WriteLine("ERR: fail to connect card reader");
                    m_context.Release();
                    return false;
                }

                break;
            }

            if (m_reader == null)
            {
                Console.WriteLine("ERR: no any card reader");
                m_context.Release();
                return false;
            }


            string[] testStr;
            byte[] testByte;

            error = m_reader.Status(out testStr, out state, out protocol, out testByte);
            if (error != SCardError.Success)
            {
                Console.WriteLine("ERR: reader is not ready");
                m_reader.Disconnect( SCardReaderDisposition.Reset );
                m_context.Release();
                return false;
            }

            error = m_reader.BeginTransaction();
            if (error != SCardError.Success)
            {
                Console.WriteLine("ERR: fail to begin transaction");
                m_reader.Disconnect( SCardReaderDisposition.Reset );
                m_context.Release();
                return false;
            }


            m_pci = SCardPCI.GetPci( m_reader.ActiveProtocol );
            m_ioreq = new SCardPCI();


            return true;
        }

        public void Disconnect()
        {
            m_reader.EndTransaction( SCardReaderDisposition.Leave );
            m_reader.Disconnect( SCardReaderDisposition.Reset );
            m_context.Release();
        }
    }
}
