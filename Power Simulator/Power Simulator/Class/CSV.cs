using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Power_Simulator
{
    class CSV
    {
        public bool bVoltage = true;
        public string str = "";
        public void saveDB(List<string> data, string channel, string program)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                if (!File.Exists(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\RawData\" + today + "_" + channel + "_" + program + ".csv"))
                {
                    using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\RawData\" + today + "_" + channel + "_" + program + ".csv", true, Encoding.UTF8))
                    {
                        wr.WriteLine("DateTime, RelativeTime For Cycle, RelativeTime, Ch., PresentCycle, TotalCycle, Sampling, Type, Set_V,  Set_C, Lim_C, Meas_V, Meas_C");
                    }
                }
                using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\RawData\" + today + "_" + channel + "_" + program + ".csv", true, Encoding.UTF8))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].IndexOf("\r\n") >= 0)
                        {
                            data[i] = data[i].Replace("\r\n", "");
                        }
                        else if (data[i].IndexOf('\n') >= 0)
                        {
                            data[i] = data[i].Replace("\n", "");
                        }
                    }
                    wr.WriteLine(data[0] + "," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "," + data[6]
                                    + "," + data[7] + "," + data[8] + "," + data[9] + "," + data[10] + "," + data[11] + "," + data[12]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        //불러오기
        public List<string> load(string Filename)
        {
            List<string> list = new List<string>();

            string value = "";

            try
            {
                using (StreamReader rdr = new StreamReader(Filename))
                {
                    while (true)
                    {
                        value = rdr.ReadLine();
                        if (value != null)
                            list.Add(value);
                        else
                            break;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public void saveProfile(List<string> data, string filename)
        {
            try
            {
                if(!File.Exists(filename + ".csv"))
                {
                    using (StreamWriter wr = new StreamWriter(filename + ".csv", true, Encoding.UTF8))
                    {
                        if (bVoltage)
                        {
                            str = "전압(V)";
                        }
                        else
                        {
                            str = "전류(A)";
                        }
                        wr.WriteLine(",시간(ms), 시간(s), " + str + ", 파형유형");
                    }
                }
               
                using (StreamWriter wr = new StreamWriter(filename + ".csv", true, Encoding.UTF8))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].IndexOf("\r\n") >= 0)
                        {
                            data[i] = data[i].Replace("\r\n", "");
                        }
                        else if (data[i].IndexOf('\n') >= 0)
                        {
                            data[i] = data[i].Replace("\n", "");
                        }
                    }
                    wr.WriteLine(data[0] + "," + data[1] + "," + data[2] + "," + data[3] + "," + data[4]);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
