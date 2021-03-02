using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace COMMONS
{
    class IniFiles
    {
        string path;

        //====================================================================================================================================
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //===================================================================================================================================       

        public IniFiles(string path)   
        {
            this.path = path;
        }
        //===============================================================================================================
        //=============================문자열===========================
        public void WriteString(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        public string ReadString(string section, string key, string def)
        {
            StringBuilder result = new StringBuilder(255);

            GetPrivateProfileString(section, key, def, result, result.Capacity, path);

            return Convert.ToString(result);
        }

        public void WriteInteger(string section, string key, int value)
        {
            string tmp = "";

            try
            {
                tmp = Convert.ToString(value);
                WritePrivateProfileString(section, key, tmp, path);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //=============================정수================================
        public int ReadInteger(string section, string key, int def)
        {
            StringBuilder result = new StringBuilder(255);
            string tmp = "";

            try
            {
                tmp = Convert.ToString(def);
                GetPrivateProfileString(section, key, tmp, result, result.Capacity, path);
                tmp = result.ToString();
                return Convert.ToInt32(tmp);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return def;
            }
        }
        public void WriteDouble(string section, string key, double value)
        {
            string tmp = "";

            try
            {
                tmp = Convert.ToString(value);
                WritePrivateProfileString(section, key, tmp, path);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //====================================실수==================================
        public double ReadDouble(string section, string key, double def)
        {
            StringBuilder result = new StringBuilder(255);
            string tmp = "";

            try
            {
                tmp = Convert.ToString(def);
                GetPrivateProfileString(section, key, tmp, result, result.Capacity, path);
                tmp = result.ToString();
                return Convert.ToDouble(tmp);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return def;
            }
        }

        public void WriteBoolean(string section, string key, bool value)
        {
            string tmp = "";

            try
            {
                tmp = Convert.ToString(value);
                WritePrivateProfileString(section, key, tmp, path);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //=======================================Boolean=======================================
        public bool ReadBoolean(string section, string key, bool def)
        {
            StringBuilder result = new StringBuilder(255);
            string tmp;

            try
            {
                tmp = Convert.ToString(def);
                GetPrivateProfileString(section, key, tmp, result, result.Capacity, path);
                tmp = result.ToString();
                return Convert.ToBoolean(tmp);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return def;
            }
        }
    }
}
