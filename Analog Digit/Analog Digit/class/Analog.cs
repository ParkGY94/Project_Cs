using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using COMMONS;

namespace Analog_Digit
{
    public class Analog
    {
        private NationalInstruments.DAQmx.Task Readtask;
        private NationalInstruments.DAQmx.Task Writetask;
        public iniUtil ini = new iniUtil(@"C:\Users\gy157\Documents\Info.ini");
        AnalogSingleChannelWriter writer;
        AnalogMultiChannelReader reader;

        //생성자 
        public Analog()
        {
            Readtask = new NationalInstruments.DAQmx.Task();
            Writetask = new NationalInstruments.DAQmx.Task();
        }

        //아날로그 입력 연결
        public bool Connect(ref string ErrorMsg)
        {
            bool flag = false;

            try
            {
                flag = true;

                Readtask.AIChannels.CreateVoltageChannel(ini.GetIniValue("NI", "Name") + "/ai0:7", "Analog Input", (AITerminalConfiguration.Rse), -10, 10, AIVoltageUnits.Volts);
                reader = new AnalogMultiChannelReader(Readtask.Stream);
                Readtask.Control(TaskAction.Verify);
            }
            catch (DaqException de)
            {
                ErrorMsg = de.Message;
                flag = false;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                flag = false;
            }
            return flag;
        }

        //아날로그 출력 연결
        public void Connect_Output(ref string ErrorMsg)
        {
            try
            {
                Writetask.AOChannels.CreateVoltageChannel(ini.GetIniValue("NI", "Name") + "/ao0", "Analog Output", -10, 10, AOVoltageUnits.Volts);
                writer = new AnalogSingleChannelWriter(Writetask.Stream);
                Writetask.Control(TaskAction.Verify);
            }
            catch(DaqException de)
            {
                ErrorMsg = de.Message;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }

        }

        //아날로그 입력
        public double Read(ref string ErrorMsg)
        {
            if (reader != null)
            {
                try
                {
                    double[,] data = reader.ReadMultiSample(1);
                    double Value = Math.Truncate(data[0, 0] * 100) / 100;
                    return Value;
                }
                catch(DaqException de)
                {
                    ErrorMsg = de.Message;
                    return 0;
                }
                catch (Exception e)
                {
                    ErrorMsg = e.Message;
                    return 0;
                }
            }
            else
                return 0;
        }

        //아날로그 출력
        public void Output(double data, ref string ErrorMsg)
        {
            try
            {
                writer.WriteSingleSample(true, data);
            }
            catch (DaqException de)
            {
                ErrorMsg = de.Message;
            }
            catch(Exception e)
            {
                ErrorMsg = e.Message;
            }
        }
    }
}
