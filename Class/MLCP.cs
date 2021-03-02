using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Pressure_Sensor_EOL
{
    class MLCP
    {
        public string comm;
        public byte[] bytes;
        public byte b;
        public MLCP() 
        {
            comm = "";
            bytes = ConvertByteArray("0D");
            b = 0x0D;
        }
        
        public byte[] ConvertByteArray(String strHex)
        {
            int iLength = strHex.Length;
            byte[] bytes1 = new byte[iLength / 2];

            for(int i = 0; i < iLength; i += 2)
            {
                bytes1[i / 2] = Convert.ToByte(strHex.Substring(i, 2), 16);
            }
            return bytes1;
        }
        public string Start()
        {
            comm = "START";
            return comm;
        }

        public string Recall()
        {
            comm = "RECALL";
            return comm;
        }

        public string Reset()
        {
            comm = "RESET";
            return comm;
        }
        public string MZero()
        {
            comm = "MZERO";
            return comm;
        }
        public string MClear()
        {
            comm = "MCLEAR";
            return comm;
        }
    }
}
