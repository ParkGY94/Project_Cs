using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Pressure_Sensor_EOL
{
    class BarcodeRead
    {
        private string readData;

        public BarcodeRead()
        {
        }

        public byte[] Trigger()
        {
            byte[] arr;
            arr = new byte[2];
            arr[0] = 0x1B;
            arr[1] = 0x31;
            return arr;
        }
        
    }
}
