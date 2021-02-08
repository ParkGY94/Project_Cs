using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Simulator
{
    class TDKLamdaGENH
    {
        static bool bConnect;

        private static System.IO.Ports.SerialPort serialPort = null;

        public bool Connect
        {
            get { return bConnect; }
            set { bConnect = value; }
        }
        public TDKLamdaGENH(System.IO.Ports.SerialPort cPort, string strPortName, int BaudRate)
        {
            serialPort = cPort;

            serialPort.PortName = strPortName;
            serialPort.BaudRate = BaudRate;
            serialPort.DataBits = 8;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = System.IO.Ports.StopBits.One;

            Open();
        }

        public TDKLamdaGENH()
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

        public void ADR()
        {
            if (!IsOpen()) return;
            serialPort.Write("ADR 01\r\n");
        }
        public void IDN()
        {
            if (!IsOpen()) return;
            serialPort.Write("IDN\r\n");
        }
        public void RST()
        {
            if (!IsOpen()) return;
            serialPort.Write("RST\r\n");
        }

        public void CLS()
        {
            if (!IsOpen()) return;
            serialPort.Write("CLS\r\n");
        }
        public void OutPut(bool bON)
        {
            if (!IsOpen()) return;
            if (bON) serialPort.Write("OUT 1\r\n");
            else serialPort.Write("OUT 0\r\n");
        }
        public void VoltSet(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "PV " + dData.ToString("0.00") + "\r\n";
            serialPort.Write(strCommand);
        }
        public void CurrentSet(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "PC " + dData.ToString("0.00") + "\r\n";
            serialPort.Write(strCommand);
        }
        public void VoltSetCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("PV?\r\n");
        }
        public void VoltOutCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("MV?\r\n");
        }
        public void CurrentSetCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("PC?\r\n");
        }
        public void CurrentOutCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("MC?\r\n");
        }
        public void CCMode()
        {
            if (!IsOpen()) return;
            byte b = 0x01;
            serialPort.Write("SENA " + b + "\r\n");
        }
        public void CVMode()
        {
            if (!IsOpen()) return;
            byte b = 0x00;
            serialPort.Write("SENA " + b + "\r\n");
        }

        public void ModeCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("MODE?\r\n");
        }

        public void OVL(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = "OVP " + dData.ToString("0.00") + "\r\n";
            serialPort.Write(strCommand);
        }

        public void OVLCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("OVP?\r\n");
        }
    }
}
