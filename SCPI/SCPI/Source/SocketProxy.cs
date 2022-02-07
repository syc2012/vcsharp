using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using SCPI;

namespace SCPI
{
    class SocketProxy
    {
        Socket _client = null;
        private byte[] rspReceived;// = new byte[1024];

        public bool _isConnected = false;

        string _modelName = String.Empty;

        public void Connect( string ip, string port )
        {
            byte[] cmdSent = Encoding.ASCII.GetBytes("*IDN?\n");
            rspReceived = new byte[1024];
            int rspLen = 0;


            IPEndPoint ipEP = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _client.Connect(ipEP);

                if( _client.Connected )
                {
                    _client.Send(cmdSent, cmdSent.Length, 0);
                    rspLen = _client.Receive(rspReceived, rspReceived.Length, 0);
                    _modelName = Encoding.ASCII.GetString(rspReceived, 0, rspLen);
                    _isConnected = true;
                }
                //_mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open(String.Format("{0}::{1}::INSTR", gpib, gpibPort));
                //_mbSession.DefaultBufferSize = 20480;
                //_mbSession.Timeout = 10000;

                //------------- Query Command ----------------
                //_modelName = _mbSession.Query("*IDN?\n");

            }
            catch (InvalidCastException invalidCastExp)
            {
                throw invalidCastExp;
            }
            catch (Exception exp)
            {
                throw new Exception("Could not connect to device through Socket: \n" + exp.Message);
            }
            finally
            {

            }
        }

        public string Query(string cmd)
        {
            byte[] cmdSent = Encoding.ASCII.GetBytes(cmd+"\n");
            //byte[] rspReceived = new byte[1024];
            int rspLen = 0;
            string result = null;

            if (_isConnected)
            {
                try
                {
                    _client.Send(cmdSent, cmdSent.Length, 0);
                    rspLen = _client.Receive(rspReceived, rspReceived.Length, 0);
                    result = Encoding.ASCII.GetString(rspReceived, 0, rspLen);
                }
                catch (InvalidCastException invalidCastExp)
                {
                    _isConnected = false;
                    throw invalidCastExp;
                }
                catch (Exception exp)
                {
                    _isConnected = false;
                    throw exp;
                }
                finally
                {

                }
            }

            return result;
        }

        public void Send(string cmd)
        {
            byte[] cmdSent = Encoding.ASCII.GetBytes(cmd+"\n");

            if (_isConnected)
            {
                try
                {
                    _client.Send(cmdSent, cmdSent.Length, 0);
                }
                catch (InvalidCastException invalidCastExp)
                {
                    _isConnected = false;
                    throw invalidCastExp;
                }
                catch (Exception exp)
                {
                    _isConnected = false;
                    throw exp;
                }
                finally
                {

                }
            }
        }

        public void Close()
        {
            if (_isConnected)
            {
                try
                {
                    _client.Disconnect(false);
                    _client.Close();
                    _client = null;
                    //_mbSession.Clear();
                    //_mbSession = null;
                    _isConnected = false;
                }
                catch (InvalidCastException invalidCastExp)
                {
                    throw invalidCastExp;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                finally
                {
                    _isConnected = false;
                }
            }
        }

        public string GetModelName()
        {
            string result = null;

            if (_isConnected)
            {
                result = _modelName;
            }

            return result;
        }



    
    
    }
}
