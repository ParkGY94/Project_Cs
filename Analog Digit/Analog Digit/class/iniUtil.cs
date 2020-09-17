using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace COMMONS
{
    public class iniUtil
    {
        private string iniPath;

        public iniUtil(string path)
        {
            this.iniPath = path;  //INI 파일 위치를 생성할때 인자
        }
        //
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(    // GetIniValue String
           String section,
            String key,
            String def,
            StringBuilder retVal,
            int size,
            String filePath);
        //
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // SetIniValue String
            String section,
             String key,
             String val,
             String filePath);

        // INI 값을 읽어 온다. 
        public string GetIniValue(String Section, String Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);

            if (temp.Length > 0)
                return temp.ToString();
            else
                return "";
        }
        //
        // INI 값을 셋팅
        public void SetIniValue(String Section, String Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }
        //
        /*
        FileInfo exefileinfo = new FileInfo(Application.ExecutablePath);   
        string path = exefileinfo.Directory.FullName.ToString()  //프로그램 실행되고 있는데 path 가져오기
        string fileName = @"\config.ini";  //파일명
        */
    }
}
