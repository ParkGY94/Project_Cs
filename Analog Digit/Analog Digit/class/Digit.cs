using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using COMMONS;

namespace Analog_Digit
{
    public class Digit
    {
        private NationalInstruments.DAQmx.Task Writetask;
        private NationalInstruments.DAQmx.Task Writetask2;
        private NationalInstruments.DAQmx.Task Readtask;
        private DigitalSingleChannelWriter writer;
        private DigitalSingleChannelWriter writer2;
        private DigitalSingleChannelReader reader;

        public iniUtil ini = new iniUtil(@"C:\Users\gy157\Documents\Info.ini");

        public bool[] LED = new bool[8];
        public bool[] Input = new bool[8];
        public bool[] P1LED = new bool[4];
        
        //포트0 연결
        public bool Connect_port0_write()
        {
            bool flag = false;

            try
            {
                flag = true;
                Writetask = new NationalInstruments.DAQmx.Task();
                Writetask.DOChannels.CreateChannel(ini.GetIniValue("NI", "Name") + "/port0/line0:7", "Digital Output Port0", ChannelLineGrouping.OneChannelForAllLines);
                writer = new DigitalSingleChannelWriter(Writetask.Stream);

                for (int i = 0; i < 8; i++)
                {
                    LED[i] = false;
                }
                if(writer != null)
                {
                    writer.WriteSingleSampleMultiLine(true, LED);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        //포트0 연결
        public bool Connect_port0_read(ref string ErrorMsg)
        {
            bool flag = false;

            try
            {
                flag = true;

                Readtask = new NationalInstruments.DAQmx.Task();
                Readtask.DIChannels.CreateChannel(ini.GetIniValue("NI", "Name") + "/port0/line0:7", "Digital Input", ChannelLineGrouping.OneChannelForAllLines);
                reader = new DigitalSingleChannelReader(Readtask.Stream);

                if(reader != null)
                {
                    Input = reader.ReadSingleSampleMultiLine();
                }
            }
            catch(DaqException de)
            {
                flag = false;
                ErrorMsg = de.Message;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
            return flag;
        }
        //포트0 열결 해제
        public void Disconnect_port0()
        {
            if(Writetask != null)
            {
                Writetask.Dispose();
                Writetask = null;
                if(writer != null)
                {
                    writer = null;
                }
            }
            if(Readtask != null)
            {
                Readtask.Dispose();
                Readtask = null;
                if(reader != null)
                {
                    reader = null;
                }
            }
        }
        //포트1 연결
        public bool Connect_port1_write()
        {
            bool flag = false;

            try
            {
                flag = true;

                Writetask2 = new NationalInstruments.DAQmx.Task();
                Writetask2.DOChannels.CreateChannel(ini.GetIniValue("NI", "Name") + "/port1/line0:3", "Digital Output Port1", ChannelLineGrouping.OneChannelForAllLines);
                writer2 = new DigitalSingleChannelWriter(Writetask2.Stream);

                for(int i = 0; i < 4; i++)
                {
                    P1LED[i] = false;
                }
                if(writer2 != null)
                {
                    writer2.WriteSingleSampleMultiLine(true, P1LED);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        //포트0 출력
        public void port0_Output(int index, bool value, ref string ErrorMsg)
        {
            LED[index] = value;
            if(writer != null)
            {
                try
                {
                    writer.WriteSingleSampleMultiLine(true, LED);
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
        }
        //포트1 출력
        public void port1_Output(int index, bool value, ref string ErrorMsg)
        {
            P1LED[index] = value;
            if(writer2 != null)
            {
                try
                {
                    writer2.WriteSingleSampleMultiLine(true, P1LED);
                }
                catch (DaqException de)
                {
                    ErrorMsg = de.Message;
                }
                catch (Exception e)
                {
                    ErrorMsg = e.Message;
                }
            }
        }
        //포트0 입력
        public bool[] port0_Input(ref string ErrorMsg)
        {
            if(reader != null)
            {
                try
                {
                    Input = reader.ReadSingleSampleMultiLine();
                }
                catch (DaqException de)
                {
                    ErrorMsg = de.Message;
                }
                catch (Exception e)
                {
                    ErrorMsg = e.Message;
                }
            }
            else
            {
                Input[0] = false;
                Input[1] = false;
                Input[2] = false;
                Input[3] = false;
                Input[4] = false;
                Input[5] = false;
                Input[6] = false;
                Input[7] = false;
            }
            return Input;
        }
        //시그먼트 출력
        public void Segment(int N, bool[] state)
        {
            switch (N)
            {
                case 0:
                    LED[0] = true;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = true;
                    LED[4] = true;
                    LED[5] = true;
                    LED[6] = false;
                    LED[7] = false;
                    break;
                case 1:
                    LED[0] = false;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = false;
                    LED[4] = false;
                    LED[5] = false;
                    LED[6] = false;
                    LED[7] = false;
                    break;
                case 2:
                    LED[0] = true;
                    LED[1] = true;
                    LED[2] = false;
                    LED[3] = true;
                    LED[4] = true;
                    LED[5] = false;
                    LED[6] = true;
                    LED[7] = false;
                    break;
                case 3:
                    LED[0] = true;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = true;
                    LED[4] = false;
                    LED[5] = false;
                    LED[6] = true;
                    LED[7] = false;
                    break;
                case 4:
                    LED[0] = false;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = false;
                    LED[4] = false;
                    LED[5] = true;
                    LED[6] = true;
                    LED[7] = false;
                    break;
                case 5:
                    LED[0] = true;
                    LED[1] = false;
                    LED[2] = true;
                    LED[3] = true;
                    LED[4] = false;
                    LED[5] = true;
                    LED[6] = true;
                    LED[7] = false;
                    break;
                case 6:
                    LED[0] = false;
                    LED[1] = false;
                    LED[2] = true;
                    LED[3] = true;
                    LED[4] = true;
                    LED[5] = true;
                    LED[6] = true;
                    LED[7] = false;
                    break;
                case 7:
                    LED[0] = true;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = false;
                    LED[4] = false;
                    LED[5] = false;
                    LED[6] = false;
                    LED[7] = false;
                    break;
                case 8:
                    LED[0] = true;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = true;
                    LED[4] = true;
                    LED[5] = true;
                    LED[6] = true;
                    LED[7] = false;
                    break;
                case 9:
                    LED[0] = true;
                    LED[1] = true;
                    LED[2] = true;
                    LED[3] = false;
                    LED[4] = false;
                    LED[5] = true;
                    LED[6] = true;
                    LED[7] = false;
                    break;
            }
            state = LED;
            if(writer != null)
            {
                writer.WriteSingleSampleMultiLine(true, LED);
            }
        }
    }
}
