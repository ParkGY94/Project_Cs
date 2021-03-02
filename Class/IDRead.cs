using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Pressure_Sensor_EOL
{
    public class IDRead : Serial
    {
        private string recv;
        private string errorCode;
        private string ID;

        private bool isRecv;
        private bool isIDOK;
        private bool isErrorcodeOK;

        private string fullString;

        public IDRead(string portName, int baudRate) : base(portName, baudRate)
        {
            ID = "";
            recv = "";
            errorCode = "";
        }
        protected override void SerialRecv(object sender, EventArgs e)
        {
            recv = serial.ReadLine();
            isRecv = true;
            //throw new NotImplementedException();
        }

        /*public void ReadID()
        {
            TimeSpan spanTime = TimeSpan.FromMilliseconds(500);

            isRecv = false;
            isIDOK = false;
            DateTime start = DateTime.Now;
            serial.Write("owt28003727ea9\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isIDOK = false;
                return;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("ow_280052603F80003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }

                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isIDOK = false;
                return;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("or_28007\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }

                if (isRecv)
                {
                    break;
                }
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isIDOK = false;
                return;
            }

            recv = recv.Substring(recv.IndexOf("26") + 2);
            recv = recv.Trim();
            if (recv.Length != 12)
            {
                isIDOK = false;
                return;
            }

            isIDOK = true;
        }*/

        public void ReadID()
        {
            TimeSpan spanTime = TimeSpan.FromMilliseconds(1000);

            isRecv = false;
            DateTime start = DateTime.Now;

            ID = "";

            serial.Write("OWT2800372f5a2\r\n");

            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("OR_28002\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            //recv = recv.Remove(0, 2);
            //ID = recv;
            recv = "";

            isRecv = false;
            start = DateTime.Now;
            serial.Write("OW_28003240079\r\n");

            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("OR_28003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            if (recv.Length > 3)
            {
                recv = recv.Remove(0, 3);
            }
            ID = recv;

            isRecv = false;
            isIDOK = false;
            start = DateTime.Now;

            serial.Write("OW_2800324007A\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            isRecv = false;
            start = DateTime.Now;
            serial.Write("OR_28003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            if (recv.Length > 3)
            {
                recv = recv.Remove(0, 3);
            }
            ID += recv;

            isRecv = false;
            isIDOK = false;
            start = DateTime.Now;

            serial.Write("OW_2800324007B\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("OR_28003\r\n");

            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            if (recv.Length > 3)
            {
                recv = recv.Remove(0, 3);
            }
            ID += recv;

            isRecv = false;
            isIDOK = false;
            start = DateTime.Now;

            serial.Write("OW_2800324007C\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("OR_28003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            if (recv.Length > 3)
            {
                recv = recv.Remove(0, 3);
            }
            ID += recv;
            ID = ID.Replace(@"", "");
        }

        public void ReadErrorCode()
        {
            TimeSpan spanTime = TimeSpan.FromMilliseconds(1000);
            fullString = "";
            isRecv = false;
            isErrorcodeOK = false;
            DateTime start = DateTime.Now;

            serial.Write("eos_\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                    break;

                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isErrorcodeOK = false;
                return;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("eotxxxx00\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                    break;

                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isErrorcodeOK = false;
                return;
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("et_1\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                    break;

                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isErrorcodeOK = false;
                return;
            }
            else
            {
                fullString += recv.Trim() + "/";
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("er_004\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                    break;

                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isErrorcodeOK = false;
                return;
            }
            else
            {
                fullString += recv.Trim() + "/";
            }

            isRecv = false;
            start = DateTime.Now;
            serial.Write("es_004\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                    break;

                if (isRecv)
                    break;
            }
            if (recv.IndexOf("\u0006") < 0)
            {
                isErrorcodeOK = false;
                return;
            }
            else
            {
                fullString += recv.Trim() + "/";
            }
            recv = recv.Remove(0, 1);
            recv = recv.Trim();

            //string[] recvList = recv.Split('_');
            /*try
            {
                for(int i = 0; i < 4; i++)
                {
                    if(recvList[i].IndexOf("01:") >= 0)
                    {
                        errorCode = recvList[i];
                        break;
                    }
                }

                errorCode = errorCode.Remove(0, 3);
                errorCode = errorCode.Remove(4, 3);

                for(int i = 0; i < 4; i++)
                {
                    if(recvList[i].IndexOf("10:") >= 0)
                    {
                        temperature = recvList[i];
                        break;
                    }
                }
                temperature = temperature.Remove(0, 3);
                temperature = temperature.Remove(4, 3);

                temperature = Int32.Parse(temperature, System.Globalization.NumberStyles.HexNumber).ToString();
                temperature = (Convert.ToDouble(temperature) * 510.875 / 4087 - 73.025).ToString();
            }
            catch(Exception Exception)
            {

            }*/
        }

        public string GetID()
        {
            /*string result = "";
            if (isIDOK)
                result = recv;
            else
                result = "ERROR";*/
            return ID;
        }
        public string GetErrorCode()
        {
            /*string result = "";
            if (isErrorcodeOK)
            {
                result = errorCode;
            }
            else
            {
                result = "ERROR";
            }*/
            return errorCode;
        }
        public string GetFullString()
        {
            return fullString;
        }

        public void Set()
        {
            TimeSpan spanTime = TimeSpan.FromMilliseconds(1000);

            isRecv = false;
            isIDOK = false;
            DateTime start = DateTime.Now;

            serial.Write("V\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            serial.Write("T11020\r\n");
            serial.Write("TSO31150\r\n");
            serial.Write("IS_07\r\n");
            serial.Write("OS_10\r\n");
            /*serial.Write("TSO31150\r\n");
            serial.Write("OS_14\r\n");
            serial.Write("T11030\r\n");*/
            isRecv = false;
        }
        public string GetSet()
        {
            return recv;
        }
    }
}
