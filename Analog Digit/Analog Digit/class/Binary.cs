using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Analog_Digit
{
    public class Binary
    {
        //이진파일 저장
        public void Save(List<string> voltage)
        {
            string FileName = voltage[0];
            FileStream fs = File.Open(FileName, FileMode.Create);

            using(BinaryWriter wr = new BinaryWriter(fs))
            {
                for(int i = 1; i < voltage.Count; i++)
                {
                    wr.Write(voltage[i]);
                }
                wr.Close();
            }
            fs.Close();
        }

        //이진파일 로드
        public List<String> Load(string FileName)
        {
            using (BinaryReader rdr = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                List<string> list = new List<string>();
                string voltageMin = "";
                string voltageMax = "";
                string resistMin = "";
                string resistMax = "";
                
                voltageMin = rdr.ReadString();
                list.Add(voltageMin);
                voltageMax = rdr.ReadString();
                list.Add(voltageMax);
                resistMin = rdr.ReadString();
                list.Add(resistMin);
                resistMax = rdr.ReadString();
                list.Add(resistMax);

                rdr.Close();

                return list;
            }
        }
    }
}
