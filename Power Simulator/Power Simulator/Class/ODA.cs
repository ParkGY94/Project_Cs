using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Simulator
{
    class ODA
    {
        static bool bConnect;

        private static System.IO.Ports.SerialPort serialPort = null;

        public bool Connect
        {
            get { return bConnect; }
            set { bConnect = value; }
        }
        public ODA(System.IO.Ports.SerialPort cPort, string strPortName, int BaudRate)
        {
            serialPort = cPort;

            serialPort.PortName = strPortName;
            serialPort.BaudRate = BaudRate;
            serialPort.DataBits = 8;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = System.IO.Ports.StopBits.One;

            Open();
        }
        public ODA()
        {
        }

        public bool Open()
        {
            try
            {
                serialPort.Open();
                //RST();
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }
        public void Close()
        {
            serialPort.Close();
            bConnect = false;
        }
        public bool IsOpen()
        {
            if (serialPort.IsOpen) return true;
            else return false;
        }

        public void IDN()
        {
            if (!IsOpen()) return;
            serialPort.Write("*IDN?\n");
        }
        public void RST()
        {
            if (!IsOpen()) return;
            serialPort.Write("*RST\n");
        }
        public void OutPut(bool bON)
        {
            if (!IsOpen()) return;
            if (bON) serialPort.Write("OUTP ON\n");
            else serialPort.Write("OUTP OFF\n");
        }
        public void VoltSet(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "VOLT " + dData.ToString("0.00") + "\n";
            serialPort.Write(strCommand);
        }
        public void CurrentSet(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "CURR " + dData.ToString("0.00") + "\n";

            serialPort.Write(strCommand);
        }
        public void VoltSetCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("VOLT?\n");
        }
        public void VoltOutCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("Meas:VOLT?\n");
        }
        public void CurrentSetCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("CURR?\n");
        }
        public void CurrentOutCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("Meas:CURR?\n");
        }

        public void OVL(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "VOLT:OVL " + dData.ToString("0.00") + "\n";
            serialPort.Write(strCommand);
        }

        public void UVL(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "VOLT:UVL " + dData.ToString("0.00") + "\n";
            serialPort.Write(strCommand);
        }

        public void OCL(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "CURR:OCL " + dData.ToString("0.00") + "\n";
            serialPort.Write(strCommand);
        }

        public void UCL(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "CURR:UCL " + dData.ToString("0.00") + "\n";
            serialPort.Write(strCommand);
        }

        public void OVLCheck()
        {
            if (!IsOpen()) return;
            string strCommand = "VOLT:OVL?\n";
            serialPort.Write(strCommand);
        }

        public void OCLCheck()
        {
            if (!IsOpen()) return;
            string strCommand = "CURR:OCL?\n";
            serialPort.Write(strCommand);
        }

        public void ModeCheck()
        {
            if (!IsOpen()) return;
            string strCommand = "FLOW?\n";
            serialPort.Write(strCommand);
        }
    }
}
