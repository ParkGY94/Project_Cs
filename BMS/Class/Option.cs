using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Option
    {
        public double logSaveInterval; //로그 저장 인터벌
        public int logEndCount;            //자동 정지 개수
        public string logSavePath;     //로그 저장 경로

        //생성자
        public Option()
        {
            logSaveInterval = 0;
            logEndCount = 0;
            logSavePath = "";
        } 
        
        //저장
        public bool Save(string path)
        {            
            bool result = false;

            try
            {
                IniFiles ini = new IniFiles(path);

                ini.WriteDouble("LOGGING", "SAVE_INTERVAL", logSaveInterval);
                ini.WriteInteger("LOGGING", "END_COUNT", logEndCount);
                ini.WriteString("LOGGING", "SAVE_PATH", logSavePath);

                result = true;
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        //로드 
        public void Load(string path)
        {
            IniFiles ini = new IniFiles(path);

            logSaveInterval =  ini.ReadDouble("LOGGING", "SAVE_INTERVAL", 0);
            logEndCount = ini.ReadInteger("LOGGING", "END_COUNT", 0);
            logSavePath = ini.ReadString("LOGGING", "SAVE_PATH", "");
        }

    }//class end
}//namespace end
