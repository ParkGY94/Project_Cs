using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMMONS;

namespace Pressure_Sensor_EOL
{
    class Model
    {
        public IniFiles ini;
        public const string FUNCTION_MODEL_PATH = @"C:\Users\gy157\Documents\FINAL_Model.ini";

        public string lastDate;
        public bool vibUse;
        public int vibValue;
        public bool pressUse;
        public double pressValue;

        public double currentOhm;
        public bool tempUse;
        public double tempMinValue;
        public double tempMaxValue;

        public int tickValue;
        public int risingValue;
        public int fallingValue;
        public double threshMinValue;
        public double threshMaxValue;
        public int syncTickValue;
        public int dataPulseValue;

        public double epInputVoltage;
        public double epInputVoltageMis;
        public double epSentVoltage;
        public double epPressValue;
        public double epPressValueMis;
        public int epPcbCount;

        public double judgeTickMin;
        public double judgeTickMax;
        public double judgeP1Min;
        public double judgeP1Max;
        public double judgeP2Min;
        public double judgeP2Max;
        public double judgeRisingMin;
        public double judgeRisingMax;
        public double judgeFallingMin;
        public double judgeFallingMax;
        public double judgeStatusMin;
        public double judgeStatusMax;

        public double judgeP130BarMin;
        public double judgeP130BarMax;
        public double judgeP230BarMin;
        public double judgeP230BarMax;

        public double judgeCurrentMin;
        public double judgeCurrentMax;

        public Model()
        {
            ini = new IniFiles(FUNCTION_MODEL_PATH);

            lastDate = "";

            vibUse = false;
            vibValue = 0;

            pressUse = false;
            pressValue = 0;

            currentOhm = 0;

            tempUse = false;
            tempMinValue = 0;
            tempMaxValue = 0;

            tickValue = 0;
            risingValue = 0;
            fallingValue = 0;

            threshMinValue = 0;
            threshMaxValue = 0;
            syncTickValue = 0;
            dataPulseValue = 0;

            epInputVoltage = 0;
            epInputVoltageMis = 0;
            epSentVoltage = 0;
            epPressValue = 0;
            epPressValueMis = 0;
            epPcbCount = 0;

            judgeTickMin = 0;
            judgeTickMax = 0;
            judgeP1Min = 0;
            judgeP1Max = 0;
            judgeP2Min = 0;
            judgeP2Max = 0;
            judgeRisingMin = 0;
            judgeRisingMax = 0;
            judgeFallingMin = 0;
            judgeFallingMax = 0;
            judgeStatusMin = 0;
            judgeStatusMax = 0;

            judgeP130BarMin = 0;
            judgeP130BarMax = 0;
            judgeP230BarMin = 0;
            judgeP230BarMax = 0;

            judgeCurrentMin = 0;
            judgeCurrentMax = 0;
        }

        public void Save()
        {
            ini.WriteBoolean("VIBRATE", "USE", vibUse);
            ini.WriteInteger("VIBRATE", "VALUE", vibValue);

            ini.WriteBoolean("PRESS", "USE", pressUse);
            ini.WriteDouble("PRESS", "VALUE", pressValue);

            ini.WriteDouble("CURRENT_OHM", "VALUE", currentOhm);

            ini.WriteBoolean("TEMP", "USE", tempUse);
            ini.WriteDouble("TEMP", "MIN", tempMinValue);
            ini.WriteDouble("TEMP", "MAX", tempMaxValue);

            ini.WriteInteger("TICK", "VALUE", tickValue);
            ini.WriteInteger("TICK", "RISING", risingValue);
            ini.WriteInteger("TICK", "FALLING", fallingValue);

            ini.WriteDouble("THRESH", "MIN", threshMinValue);
            ini.WriteDouble("THRESH", "MAX", threshMaxValue);
            ini.WriteInteger("SYNC", "VALUE", syncTickValue);
            ini.WriteInteger("SYNC", "DATA_PULSE", dataPulseValue);

            ini.WriteDouble("ERROR_PROOF", "VOLTAGE", epInputVoltage);
            ini.WriteDouble("ERROR_PROOF", "VOLTAGE_MIS", epInputVoltageMis);
            ini.WriteDouble("ERROR_PROOF", "SENT_VOLTAGE", epSentVoltage);
            ini.WriteDouble("ERROR_PROOF", "PRESS_VALUE", epPressValue);
            ini.WriteDouble("ERROR_PROOF", "PRESS_VALUE_MIS", epPressValueMis);
            ini.WriteInteger("ERROR_PROOF", "PCB_COUNT", epPcbCount);

            ini.WriteDouble("JUDGE", "TICK_MIN", judgeTickMin);
            ini.WriteDouble("JUDGE", "TICK_MAX", judgeTickMax);
            ini.WriteDouble("JUDGE", "P1_MIN", judgeP1Min);
            ini.WriteDouble("JUDGE", "P1_MAX", judgeP1Max);
            ini.WriteDouble("JUDGE", "P2_MIN", judgeP2Min);
            ini.WriteDouble("JUDGE", "P2_MAX", judgeP2Max);
            ini.WriteDouble("JUDGE", "RISING_MIN", judgeRisingMin);
            ini.WriteDouble("JUDGE", "RISING_MAX", judgeRisingMax);
            ini.WriteDouble("JUDGE", "FALLING_MIN", judgeFallingMin);
            ini.WriteDouble("JUDGE", "FALLING_MAX", judgeFallingMax);
            ini.WriteDouble("JUDGE", "STATUS_MIN", judgeStatusMin);
            ini.WriteDouble("JUDGE", "STATUS_MAX", judgeStatusMax);

            ini.WriteDouble("JUDGE", "P1_30BAR_MIN", judgeP130BarMin);
            ini.WriteDouble("JUDGE", "P1_30BAR_MAX", judgeP130BarMax);
            ini.WriteDouble("JUDGE", "P2_30BAR_MIN", judgeP230BarMin);
            ini.WriteDouble("JUDGE", "P2_30BAR_MAX", judgeP230BarMax);

            ini.WriteDouble("JUDGE", "CURRENT_MIN", judgeCurrentMin);
            ini.WriteDouble("JUDGE", "CURRENT_MAX", judgeCurrentMax);
        }
        public void Load()
        {
            vibUse = ini.ReadBoolean("VIBRATE", "USE", false);
            vibValue = ini.ReadInteger("VIBRATE", "VALUE", 0);

            pressUse = ini.ReadBoolean("PRESS", "USE", false);
            pressValue = ini.ReadDouble("PRESS", "VALUE", 0);

            currentOhm = ini.ReadDouble("CURRENT_OHM", "VALUE", 0);

            tempUse = ini.ReadBoolean("TEMP", "USE", false);
            tempMinValue = ini.ReadDouble("TEMP", "MIN", 0);
            tempMaxValue = ini.ReadDouble("TEMP", "MAX", 0);

            tickValue = ini.ReadInteger("TICK", "VALUE", 0);
            risingValue = ini.ReadInteger("TICK", "RISING", 0);
            fallingValue = ini.ReadInteger("TICK", "FALLING", 0);

            threshMinValue = ini.ReadDouble("THRESH", "MIN", 0);
            threshMaxValue = ini.ReadDouble("THRESH", "MAX", 0);
            syncTickValue = ini.ReadInteger("SYNC", "VALUE", 0);
            dataPulseValue = ini.ReadInteger("SYNC", "DATA_PULSE", 0);

            epInputVoltage = ini.ReadDouble("ERROR_PROOF", "VOLTAGE", 0);
            epInputVoltageMis = ini.ReadDouble("ERROR_PROOF", "VOLTAGE_MIS", 0);
            epSentVoltage = ini.ReadDouble("ERROR_PROOF", "SENT_VOLTAGE", 0);
            epPressValue = ini.ReadDouble("ERROR_PROOF", "PREESS_VALUE", 0);
            epPressValueMis = ini.ReadDouble("ERROR_PROOF", "PRESS_VALUE_MIN", 0);
            epPcbCount = ini.ReadInteger("ERROR_PROOF", "PCB_COUNT", 0);

            judgeTickMin = ini.ReadDouble("JUDGE", "TICK_MIN", 0);
            judgeTickMax = ini.ReadDouble("JUDGE", "TICK_MAX", 0);
            judgeP1Min = ini.ReadDouble("JUDGE", "P1_MIN", 0);
            judgeP1Max = ini.ReadDouble("JUDGE", "P1_MAX", 0);
            judgeP2Min = ini.ReadDouble("JUDGE", "P2_MIN", 0);
            judgeP2Max = ini.ReadDouble("JUDGE", "P2_MAX", 0);
            judgeRisingMin = ini.ReadDouble("JUDGE", "RISING_MIN", 0);
            judgeRisingMax = ini.ReadDouble("JUDGE", "RISING_MAX", 0);
            judgeFallingMin = ini.ReadDouble("JUDGE", "FALLING_MIN", 0);
            judgeFallingMax = ini.ReadDouble("JUDGE", "FALLING_MAX", 0);
            judgeStatusMin = ini.ReadDouble("JUDGE", "STATUS_MIN", 0);
            judgeStatusMax = ini.ReadDouble("JUDGE", "STATUS_MAX", 0);

            judgeP130BarMin = ini.ReadDouble("JUDGE", "P1_30BAR_MIN", 0);
            judgeP130BarMax = ini.ReadDouble("JUDGE", "P1_30BAR_MAX", 0);
            judgeP230BarMin = ini.ReadDouble("JUDGE", "P2_30BAR_MIN", 0);
            judgeP230BarMax = ini.ReadDouble("JUDGE", "P2_30BAR_MAX", 0);

            judgeCurrentMin = ini.ReadDouble("JUDGE", "CURRENT_MIN", 0);
            judgeCurrentMax = ini.ReadDouble("JUDGE", "CURRENT_MAX", 0);
        }
    }
    class Setting
    {
        private IniFiles ini;
        public const string FUNCTION_MODEL_PATH = @"C:\Users\gy157\Documents\FINAL_Model.ini";

        public string DAQName;
        public string comVibe;
        public string comPressMeta;
        public string comPressTester;
        public string comIC1;
        public string comIC2;
        public string comIC3;
        public string comTempMeta;

        public string DBIp;
        public int DBPort;
        public int PLCnum;

        public string pdfPath;

        public Setting()
        {
            ini = new IniFiles(FUNCTION_MODEL_PATH);

            DAQName = "";
            comVibe = "";
            comPressTester = "";
            comPressMeta = "";
            comIC1 = "";
            comIC2 = "";
            comIC3 = "";
            comTempMeta = "";

            DBIp = "";
            DBPort = 0;
            PLCnum = 0;
            pdfPath = "";
        }
        public void Load()
        {
            PLCnum = ini.ReadInteger("PLC", "NUM", 0);
            comVibe = ini.ReadString("COM", "VIBRATION", "");
            comPressMeta = ini.ReadString("COM", "PRESS_META", "");
            comPressTester = ini.ReadString("COM", "PRESS_CONTROL", "");
            comTempMeta = ini.ReadString("COM", "TEMP_META", "");
            comIC1 = ini.ReadString("COM", "IC_BOARD_1", "");
            comIC2 = ini.ReadString("COM", "IC_BOARD_2", "");
            comIC3 = ini.ReadString("COM", "IC_BOARD_3", "");

            DBIp = ini.ReadString("DB", "IP", "");
            DBPort = ini.ReadInteger("DB", "PORT", 0);
            DAQName = ini.ReadString("DAQ", "NAME", "");

            pdfPath = ini.ReadString("PDF", "PATH", "");

        }
    }

    class Password
    {
        private SerialDeserial sd;
        private string password;
        public const string PASSWD_PATH = @"C:\Users\gy157\Documents\Passwd.ps";

        public Password()
        {
            sd = new SerialDeserial();
        }
        public string PASSWORD
        {
            get { return password; }
            set { password = PASSWORD; }
        }
        public void Save(string password)
        {
            this.password = password;
            sd.Serialize(PASSWD_PATH, "1234");
        }
        public string Load()
        {
            password = sd.Deserialize(PASSWD_PATH);
            return password;
        }
    }
}
