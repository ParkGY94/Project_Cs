using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pressure_Sensor_EOL
{
    class SerialDeserial
    {
        public void Serialize(string filename, string password)
        {
            Stream stre = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter BF = new BinaryFormatter();

            BF.Serialize(stre, password);
            stre.Close();
        }

        public string Deserialize(string fileName)
        {
            string password = "";
            try
            {
                BinaryFormatter BF = new BinaryFormatter();
                using(BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
                {
                    password = (string)BF.Deserialize(br.BaseStream, headersHandler =>
                    {
                        return new object();
                    });
                }
            }
            catch(SerializationException SE)
            {
                SE.ToString();
            }
            return password;
        }
    }
}
