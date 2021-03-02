using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMONS;

namespace Pressure_Sensor_EOL
{
    class PinCount
    {
        private int pinCount;
        public const string PINCOUNT_PATH = @"C:\Users\gy157\Documents\\PINCOUNT.ini";

        public PinCount()
        {
            pinCount = 0;
        }

        public void Load()
        {
            IniFiles ini = new IniFiles(PINCOUNT_PATH);
            pinCount = ini.ReadInteger("PIN", "COUNT", 0);
        }

        public void Save()
        {
            IniFiles ini = new IniFiles(PINCOUNT_PATH);
            ini.WriteInteger("PIN", "COUNT", pinCount);
        }

        public int GetPinCount()
        {
            return pinCount;
        }

        public void IncresePinCount()
        {
            pinCount++;
            Save();
        }

        public void Reset()
        {
            pinCount = 0;
            Save();
        }
    }
}
