using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using NationalInstruments;
using System.Windows.Forms;

namespace Pressure_Sensor_EOL
{
    class DAQ
    {
        private NationalInstruments.DAQmx.Task task;
        private NationalInstruments.DAQmx.Task Writetask;

        private AnalogMultiChannelReader Reader;
        private DigitalSingleChannelWriter Writer;

        
        private bool IsConnect;
        private bool IsDataGetCom;
        private bool IsDataReadEnd;

        private int iChPerSampleNum;
        private int m_iSetDataDirection;

        public bool[] LED;
        public bool[] Input;
        public bool[] P1LED;

        public event EventHandler DAQ_Recv_Event;
        public const int SampleRate = 1000000;
        public bool CONNECT
        {
            get { return IsConnect; }
        }
        public bool DATA_GET_COMPLETE
        {
            get { return IsDataGetCom; }
            set { IsDataGetCom = value; }
        }
        public bool DATA_READ_END
        {
            get { return IsDataReadEnd; }
            set { IsDataReadEnd = value; }
        }
        public int DIRECTION
        {
            get { return m_iSetDataDirection; }
            set { m_iSetDataDirection = value; }
        }
        public int CH_PER_SAMPLE_COUNT
        {
            get { return iChPerSampleNum; }
            set { iChPerSampleNum = value; }
        }
        public DAQ()
        {
            task = null;
            IsConnect = false;

            LED = new bool[8];
            Input = new bool[8];
            P1LED = new bool[4];
        }

        public bool Analog_Connect(string DAQName, string channel)
        {
            IsConnect = false;
            
            try
            {
                IsDataGetCom = false;
                IsDataReadEnd = false;

                if (task != null)
                {
                    task.Dispose();
                    task = null;
                }

                task = new NationalInstruments.DAQmx.Task();

                task.AIChannels.CreateVoltageChannel(DAQName + "/" + channel, "", AITerminalConfiguration.Rse,
                    0, 5.0, AIVoltageUnits.Volts);

                Reader = new AnalogMultiChannelReader(task.Stream);

                //task.Timing.ConfigureSampleClock("", SampleRate, SampleClockActiveEdge.Rising,
                //SampleQuantityMode.FiniteSamples, iChPerSampleNum);

                task.Control(TaskAction.Verify);

                IsConnect = true;
                return IsConnect;
            }
            catch(DaqException Exception)
            {
                if (task != null)
                {
                    task.Dispose();
                    task = null;
                    MessageBox.Show(Exception.Message);
                }
                return IsConnect;
            }
            catch(Exception ex)
            {
                if (task != null)
                {
                    task.Dispose();
                    task = null;
                }
                return IsConnect;
            }
        }
        public double Analog_Read()
        {
            //Reader = new AnalogMultiChannelReader(task.Stream);
            if (Reader != null)
            {
                try
                {
                    double[,] data = Reader.ReadMultiSample(1);
                    double Value = Math.Truncate(data[0, 0] * 1000) / 1000;
                    return Value;
                }
                catch (DaqException de)
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        
        public bool Digital_Connect(string DAQName)
        {
            bool flag = false;

            try
            {
                flag = true;
                Writetask = new NationalInstruments.DAQmx.Task();
                Writetask.DOChannels.CreateChannel(DAQName + "/port0/line0:7", "", ChannelLineGrouping.OneChannelForAllLines);
                Writer = new DigitalSingleChannelWriter(Writetask.Stream);

                for (int i = 0; i < 8; i++)
                {
                    LED[i] = false;
                }
                if (Writer != null)
                {
                    Writer.WriteSingleSampleMultiLine(true, LED);
                }
            }
            catch(DaqException Exception)
            {
                flag = false;
                MessageBox.Show(Exception.Message);
            }
            return flag;
        }
        public void Digital_Write(int index, bool value)
        {
            LED[index] = value;
            if (Writer != null)
            {
                try
                {
                    Writer.WriteSingleSampleMultiLine(true, LED);
                }
                catch (DaqException de)
                {
                    if (Writetask != null)
                    {
                        Writetask.Dispose();
                        Writetask = null;
                    }
                    IsConnect = false;
                    //return IsConnect;
                }
            }
        }
        public void Analog_Disconnect()
        {
            if(task != null)
            {
                task.Dispose();
                task = null;
                if(Reader != null)
                {
                    Reader = null;
                }
            }
        }
    }
}
