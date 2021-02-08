using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Factory
    {
        public DataPool[] dataPool;           //data pool
        public SerialComClass serial;       //serial classs
        public NtcTable ntc;
        public Option option;          //option;

        //생성자 
        public Factory()
        {
            dataPool = new DataPool[Commons.BMS_MODULE_COUNT];
            for(int i=0;i< Commons.BMS_MODULE_COUNT; i++)
            {
                dataPool[i] = new DataPool();
            }
            serial = new SerialComClass();
            ntc = new NtcTable();
            option = new Option();
        }

        //소멸자
        ~Factory()
        {
            serial.Disconnect();
        }
    }
}
