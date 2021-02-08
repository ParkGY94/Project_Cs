using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Simulator
{
    class Profile
    {
        public bool Static;
        public double LimitCurrent;
        public double LimitVoltage;

        public int count;
        public double[] time = new double[100];
        public double[] value = new double [100];
        public string wave;
    }
}
