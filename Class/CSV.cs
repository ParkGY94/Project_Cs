using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pressure_Sensor_EOL
{
    class CSV
    {
        /*public void save(string data)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            if (!File.Exists(@"C:\Users\abc\Data\DataFile" + today + ".csv"))
            {
                using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Data\DataFile" + today + ".csv", true, Encoding.UTF8))
                {
                    wr.WriteLine("ID, Barcode#1, Barcode#2, Height, Vout, Case, 판정");
                }
            }
            using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Data\DataFile" + today + ".csv", true, Encoding.UTF8))
            {
                if (data.IndexOf('\n') >= 0)
                    wr.Write(data);
                else
                    wr.Write(data + ",");
            }
        }*/
        public void save(List<string> data)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                if (!File.Exists(@"C:\Users\abc\Data\Logfile\DataFile" + today + ".csv"))
                {
                    using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Data\Logfile\DataFile" + today + ".csv", true, Encoding.UTF8))
                    {
                        wr.WriteLine("ID, Barcode#1, Barcode#2, Height, Vout, Case, 판정");
                    }
                }
                using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Data\Logfile\DataFile" + today + ".csv", true, Encoding.UTF8))
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
                    wr.WriteLine(data[0] + "," + data[1] + "," + data[2] + "," + data[3]
                        + "," + data[4] + "," + data[5] + "," + data[6]);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void masterSave(List<string> data)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                if (!File.Exists(@"C:\Users\abc\Data\Logfile\MasterLog" + today + ".csv"))
                {
                    using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Data\Logfile\MasterLog" + today + ".csv", true, Encoding.UTF8))
                    {
                        wr.WriteLine("ID, Barcode#1, Barcode#2, Height, Vout, Case, 판정");
                    }
                }
                using (StreamWriter wr = new StreamWriter(@"C:\Users\abc\Data\Logfile\MasterLog" + today + ".csv", true, Encoding.UTF8))
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
                    wr.WriteLine(data[0] + "," + data[1] + "," + data[2] + "," + data[3]
                        + "," + data[4] + "," + data[5] + "," + data[6]);
                }
            }
            catch(Exception ex)
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
    }
}
