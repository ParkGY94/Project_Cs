using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analog_Digit
{
    public class HIOKI3540
    {
        //범위 자동 설정
        public string AutoOn()
        {
            string autoOn;
            autoOn = "AUTO 1" + "\r\n";
            return autoOn;
        }

        //범위 자동 설정 해제
        public string AutoOff()
        {
            string autoOff;
            autoOff = "AUTO 0" + "\r\n";
            return autoOff;
        }

        public string Reset()
        {
            string reset;
            reset = "RESET" + "\r\n";
            return reset;
        }

        //범위 수동 설정
        public string Range()
        {
            string range;
            range = "RNG ";
            return range;
        }

        //측정
        public string Measure()
        {
            string measure;
            measure = "RMES" + "\r\n";
            return measure;
        }
    }
}
