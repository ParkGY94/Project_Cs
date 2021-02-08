using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Simulator
{
    class SorensenXG
    {
        static bool bConnect;

        private static System.IO.Ports.SerialPort serialPort = null;

        public bool Connect
        {
            get { return bConnect; }
            set { bConnect = value; }
        }
        public SorensenXG(System.IO.Ports.SerialPort cPort, string strPortName, int BaudRate)
        {
            serialPort = cPort;

            serialPort.PortName = strPortName;
            serialPort.BaudRate = BaudRate;
            serialPort.DataBits = 8;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = System.IO.Ports.StopBits.One;

            Open();
        }

        public SorensenXG()
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
            serialPort.Write("*IDN?\r\n");
        }
        public void RST()
        {
            if (!IsOpen()) return;
            serialPort.Write("*RST\r\n");
        }
        public void OutPut(bool bON)
        {
            if (!IsOpen()) return;
            if (bON) serialPort.Write("OUTP ON\r\n");
            else serialPort.Write("OUTP OFF\r\n");
        }
        public void VoltSet(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = ":VOLT " + dData.ToString("0.00") + "\r\n";
            serialPort.Write(strCommand);
        }
        public void CurrentSet(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = ":CURR " + dData.ToString("0.00") + "\r\n";
            serialPort.Write(strCommand);
        }
        public void VoltSetCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write(":VOLT?\r\n");
        }
        public void VoltOutCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("Meas:VOLT?\r\n");
        }
        public void CurrentSetCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write(":CURR?\r\n");
        }
        public void CurrentOutCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write("Meas:CURR?\r\n");
        }

        public void ADR()
        {
            if (!IsOpen()) return;
            serialPort.Write("*ADR 10\r\n");
        }

        public void CCMode()
        {
            if (!IsOpen()) return;
            serialPort.Write(":OUTP:PROT:FOLD CC\r\n");
        }

        public void CVMode()
        {
            if (!IsOpen()) return;
            serialPort.Write(":OUTP:PROT:FOLD CV\r\n");
        }

        public void NONEMode()
        {
            if (!IsOpen()) return;
            serialPort.Write(":OUTP:PROT:FOLD NONE\r\n");
        }

        public void ModeCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write(":OUTP:PROT:FOLD?\r\n");
        }

        public void OVL(double dData)
        {
            if (!IsOpen()) return;
            string strCommand = ":SOUR:VOLT:PROT:OVER:LEV "+ dData.ToString("0.00") + "\r\n";
            serialPort.Write(strCommand);
        }

        public void OVLCheck()
        {
            if (!IsOpen()) return;
            serialPort.Write(":SOUR:VOLT:PROT:OVER\r\n");
            //serialPort.Write(":CAL:VOLT:PROT:OVER?\r\n");
        }
    }
}
