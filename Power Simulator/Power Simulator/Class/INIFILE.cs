using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Power_Simulator
{
    class INIFILE
    {
        String strPath = null;
        [DllImport("Kernel32.dll")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("Kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public INIFILE(String strPath)
        {
            this.strPath = strPath;
        }
        public void Write(string strSection, string strKey, string strValue)
        {
            WritePrivateProfileString(strSection, strKey, strValue, strPath);
        }

        public void Write(string strSection, string strKey, int iValue)
        {
            WritePrivateProfileString(strSection, strKey, iValue.ToString(), strPath);
        }

        public void Write(string strSection, string strKey, double dValue)
        {
            WritePrivateProfileString(strSection, strKey, dValue.ToString(), strPath);
        }
        public void Write(string strSection, string strKey, bool bValue)
        {
            WritePrivateProfileString(strSection, strKey, bValue.ToString(), strPath);
        }

        public String Read(string strSection, string strKey, string strDefault)
        {
            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(strSection, strKey, "", temp, 255, strPath);
                if (temp.ToString() == "") return strDefault;
                return temp.ToString();
            }
            catch (Exception ee)
            {
                return strDefault;
            }
        }
        public int Read(string strSection, string strKey, int iDefault)
        {
            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(strSection, strKey, "", temp, 255, strPath);
                if (temp.ToString() == "") return iDefault;
                return Convert.ToInt32(temp.ToString());
            }
            catch (Exception ee)
            {
                return iDefault;
            }
        }
        public double Read(string strSection, string strKey, double dDefault)
        {
            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(strSection, strKey, "", temp, 255, strPath);
                if (temp.ToString() == "") return dDefault;
                return Convert.ToDouble(temp.ToString());
            }
            catch (Exception ee)
            {
                return dDefault;
            }
        }
        public bool Read(string strSection, string strKey, bool bDefault)
        {
            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(strSection, strKey, "", temp, 255, strPath);
                if (temp.ToString() == "") return bDefault;
                return Convert.ToBoolean(temp.ToString());
            }
            catch (Exception ee)
            {
                return bDefault;
            }
        }
    }
}
