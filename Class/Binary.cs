using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pressure_Sensor_EOL
{
    class Binary
    {
        public void Save(List<string> voltage, List<bool> Action)
        {
            string FileName = voltage[0];
            
            FileStream fs = File.Open(FileName, FileMode.Create);

            using (BinaryWriter wr = new BinaryWriter(fs))
            {
                for (int i = 1; i < voltage.Count; i++)
                {
                    wr.Write(voltage[i]);
                }
                for(int i = 0; i < Action.Count; i++)
                {
                    wr.Write(Action[i]);
                }
                wr.Close();
            }
            fs.Close();
        }

        //이진파일 로드
        public void Load(string FileName, ref List<string> voltage, ref List<bool> Action)
        {
            try
            {
                using (BinaryReader rdr = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());
                    voltage.Add(rdr.ReadString());

                    Action.Add(rdr.ReadBoolean());
                    Action.Add(rdr.ReadBoolean());
                    Action.Add(rdr.ReadBoolean());
                    Action.Add(rdr.ReadBoolean());
                    Action.Add(rdr.ReadBoolean());
                    Action.Add(rdr.ReadBoolean());

                    rdr.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
