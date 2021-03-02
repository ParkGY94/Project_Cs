using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMONS;

namespace Pressure_Sensor_EOL
{
    class MasterInfo
    {
        public int masterCount;
        //public List<string> masterBarcode;
        public List<string> masterIC;
        public List<string> masterResult;
        public List<bool> masterUse;
        public const string MASTER_PATH = @"C:\Users\abc\Data\Option.ini";

        public MasterInfo(int Count)
        {
            masterCount = Count;
            //masterBarcode = new List<string>();
            masterIC = new List<string>();
            masterResult = new List<string>();
            masterUse = new List<bool>();
        }

        public void SaveInfo()
        {
            IniFiles ini = new IniFiles(MASTER_PATH);

            //ini.WriteInteger("COUNT", "VALUE", masterCount);

            for(int i = 0; i < masterCount; i++)
            {
                //ini.WriteString("Barcode", i.ToString(), masterBarcode[i]);
                ini.WriteString("IC", i.ToString(), masterIC[i]);
                //ini.WriteString("RESULT", i.ToString(), masterResult[i]);
                ini.WriteBoolean("USE", i.ToString(), masterUse[i]);
            }
        }

        public void LoadInfo()
        {
            IniFiles ini = new IniFiles(MASTER_PATH);

            //masterCount = ini.ReadInteger("COUNT", "VALUE", 0);
            
            for(int i = 0; i < masterCount; i++)
            {
                masterIC.Add(ini.ReadString("Master ID" + (i + 1).ToString(), "Master", ""));

                masterUse.Add(ini.ReadBoolean("Master" + (i + 1).ToString(), "check1", false));
                masterUse.Add(ini.ReadBoolean("Master" + (i + 1).ToString(), "check2", false));
                masterUse.Add(ini.ReadBoolean("Master" + (i + 1).ToString(), "check3", false));
                masterUse.Add(ini.ReadBoolean("Master" + (i + 1).ToString(), "check4", false));
            }
            /*masterIC.Add(ini.ReadString("Master ID1", "Master", ""));
            masterIC.Add(ini.ReadString("Master ID2", "Master", ""));
            masterIC.Add(ini.ReadString("Master ID3", "Master", ""));
            masterIC.Add(ini.ReadString("Master ID4", "Master", ""));
            masterIC.Add(ini.ReadString("Master ID5", "Master", ""));

            masterUse.Add(ini.ReadBoolean("Master1", "check1", false));
            masterUse.Add(ini.ReadBoolean("Master1", "check2", false));
            masterUse.Add(ini.ReadBoolean("Master1", "check3", false));
            masterUse.Add(ini.ReadBoolean("Master1", "check4", false));

            masterUse.Add(ini.ReadBoolean("Master2", "check1", false));
            masterUse.Add(ini.ReadBoolean("Master2", "check2", false));
            masterUse.Add(ini.ReadBoolean("Master2", "check3", false));
            masterUse.Add(ini.ReadBoolean("Master2", "check4", false));

            masterUse.Add(ini.ReadBoolean("Master3", "check1", false));
            masterUse.Add(ini.ReadBoolean("Master3", "check2", false));
            masterUse.Add(ini.ReadBoolean("Master3", "check3", false));
            masterUse.Add(ini.ReadBoolean("Master3", "check4", false));

            masterUse.Add(ini.ReadBoolean("Master4", "check1", false));
            masterUse.Add(ini.ReadBoolean("Master4", "check2", false));
            masterUse.Add(ini.ReadBoolean("Master4", "check3", false));
            masterUse.Add(ini.ReadBoolean("Master4", "check4", false));

            masterUse.Add(ini.ReadBoolean("Master5", "check1", false));
            masterUse.Add(ini.ReadBoolean("Master5", "check2", false));
            masterUse.Add(ini.ReadBoolean("Master5", "check3", false));
            masterUse.Add(ini.ReadBoolean("Master5", "check4", false));*/
        }
    }
}
