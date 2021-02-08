using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class SerialComClass
    {
        private SerialPort port;
        private string portName;
        private int baudRate;
        protected string recvMessage;
        private byte[] recvData;    

        private bool isConnect;
        byte[] buffer;

        private bool isReading;

        public bool CONNECTED
        {
            get { return isConnect; }
        }     

        //생성자
        public SerialComClass()
        {          
            isConnect = false;        

            recvData = new byte[512];
            buffer = new byte[512];

            recvMessage = "";
            port = new SerialPort();
            port.DataReceived += SerialDataReceivedEventArgs;

            isReading = false;
        }
        //소멸자
        ~SerialComClass()
        {
            if (port != null)
            {
                isConnect = false;
                port.Close();
                port.Dispose();
                port = null;                
            }
        }

        //연결
        public bool Connect(string portName, int baudRate)
        {
            bool result = false;

            this.portName = portName;
            this.baudRate = baudRate;

            try
            {
                port.PortName = portName;
                port.BaudRate = baudRate;

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.DataBits = 8;

                port.ReceivedBytesThreshold = 512;
                port.ReadBufferSize = 512;
                               
                port.Open();                                

                isConnect = true;
                result = true;
            }
            catch (Exception ex)
            {
                isConnect = false;
                result = false;
            }        
           
            return result;
        }    

        //해제
        public bool Disconnect()
        {
            bool result = false;
            try
            {
                if (isConnect)
                {
                    port.Close();
                    isConnect = false;
                    result = true;
                }
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        //쓰기
        public void Write(byte[] data)
        {
            if(port.IsOpen)
            {
                port.Write(data, 0, data.Length);
            }
        }
        
        //읽기
        public bool ReadData(ref List<byte> data)
        {
            bool result = true;

            try
            {
                data.AddRange(recvData);
                //data = recvData;
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        //recieve 이벤트
        private void SerialDataReceivedEventArgs(object sender, SerialDataReceivedEventArgs e)
        {
            if (!isReading)
            {            
                isReading = true;
                if (port.IsOpen)
                {                    
                    port.Read(buffer, 0, buffer.Length);
                    recvData = buffer;                   
                }
                isReading = false;
            }
        }

        //delay 
        protected void Delay(int ms)
        {
            DateTime start = DateTime.Now;
            while(true)
            {              
                if (DateTime.Now - start > TimeSpan.FromMilliseconds(ms))
                    break;
            }
        }
    }
}
