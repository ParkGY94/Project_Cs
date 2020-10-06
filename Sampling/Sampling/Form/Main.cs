using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments;
using NationalInstruments.DAQmx;
using System.IO;

namespace Sampling
{
    public partial class Main : Form
    {
        private AnalogMultiChannelReader Reader;
        private NationalInstruments.DAQmx.Task myTask;
        private NationalInstruments.DAQmx.Task runningTask;
        private AsyncCallback Callback;

        private AnalogWaveform<double>[] data;
        FileStream fs;
        FileStream fs2;
        BinaryWriter wr;
        BinaryWriter wr2;

        public int samples;
        public double freq;
        public double value;
        public bool Iszoomin = false;
        public double T;
        public int high = 0;
        public int low = 0;
        public double N;
        public List<double> list;


        public Main()
        {
            InitializeComponent();
            //fs = File.Open(@"C:\Users\gy157\Documents\data.bin", FileMode.Create);
            //wr = new BinaryWriter(fs);
            //fs2 = File.Open(@"C:\Users\gy157\Documents\data2.bin", FileMode.Create);
            //list = new List<double>();
            chart1.Series[0].IsVisibleInLegend = false;
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            if(runningTask == null)
            {
                try
                {
                    BTN_Reset.Enabled = false;
                    BTN_Start.Enabled = false;
                    BTN_Open.Enabled = false;
                    BTN_Data.Enabled = false;
                    timer1.Interval = (Convert.ToInt32(Text_Time.Text) + 1) * 1000;
                    timer1.Enabled = true;

                    fs = File.Open(@"C:\Users\gy157\Documents\data.bin", FileMode.Create);
                    wr = new BinaryWriter(fs);

                    if (chart1.Series.Count > 0)
                        chart1.Series[0].Points.Clear();
                    chart1.Series.Add("chart1");
                    chart1.Series["chart1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series["chart1"].IsVisibleInLegend = false;

                    myTask = new NationalInstruments.DAQmx.Task();

                    samples = Convert.ToInt32(UpDown_Samples.Value);
                    freq = Convert.ToDouble(UpDown_Freq.Value);
                    myTask.AIChannels.CreateVoltageChannel("Dev1/ai3", "", (AITerminalConfiguration)(-1), -10, 10, AIVoltageUnits.Volts);
                    myTask.Timing.ConfigureSampleClock("", freq, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, samples);
                    myTask.Control(TaskAction.Verify);
                    
                    runningTask = myTask;
                    Reader = new AnalogMultiChannelReader(myTask.Stream);
                    Callback = new AsyncCallback(AnalogCallback);

                    Reader.SynchronizeCallbacks = true;
                    Reader.BeginReadWaveform(samples, Callback, myTask);
                }
                catch(DaqException de)
                {
                    MessageBox.Show(de.Message);
                    runningTask = null;
                    myTask.Dispose();
                    BTN_Reset.Enabled = false;
                    BTN_Start.Enabled = true;
                }
            }
        }

        private void AnalogCallback(IAsyncResult ar)
        {
            try
            {
                if(runningTask != null && runningTask == ar.AsyncState && timer1.Enabled)
                {
                    data = Reader.EndReadWaveform(ar);

                    dataRead(data);

                    Reader.BeginMemoryOptimizedReadWaveform(samples, Callback, myTask, data);
                }
                if (!timer1.Enabled)
                {
                    BTN_Reset.Enabled = true;
                    BTN_Open.Enabled = true;
                    BTN_Data.Enabled = true;
                    runningTask = null;
                    myTask.Dispose();
                }
            }
            catch(DaqException de)
            {
                MessageBox.Show(de.Message);
                runningTask = null;
                myTask.Dispose();
                BTN_Reset.Enabled = false;
                BTN_Start.Enabled = true;
            }
        }

        public void dataRead(AnalogWaveform<double>[] Array)
        {
            foreach (AnalogWaveform<double> waveform in Array)
            {
                for (int i = 0; i < waveform.Samples.Count; ++i)
                {
                    value = waveform.Samples[i].Value;
                    chart1.Series["chart1"].Points.AddY(value);
                    wr.Write(Convert.ToString(value));
                }
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void BTN_Reset_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Text_Vrms.Text = "";
            Text_On_T.Text = "";
            Text_Off_T.Text = "";
            Text_Freq.Text = "";
            Text_Duty.Text = "";
            Text_Time.Text = "5";
            UpDown_Freq.Value = 20000;
            UpDown_Samples.Value = 20000;
            BTN_Start.Enabled = true;
        }

        private void BTN_Open_Click(object sender, EventArgs e)
        {
            wr2.Close();
            using (BinaryReader rdr = new BinaryReader(File.Open(@"C:\Users\gy157\Documents\data2.bin", FileMode.Open)))
            {
                Text_Vrms.Text = rdr.ReadString();
                Text_Freq.Text = rdr.ReadString();
                Text_Duty.Text = rdr.ReadString();
                Text_On_T.Text = rdr.ReadString();
                Text_Off_T.Text = rdr.ReadString();
                UpDown_Freq.Value = rdr.ReadDecimal();
                UpDown_Samples.Value = rdr.ReadDecimal();
                Text_Time.Text = rdr.ReadString();
            }
            wr.Close();
            chart1.Series.Add("Read");
            chart1.Series["Read"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Read"].IsVisibleInLegend = false;
            using (BinaryReader rdr = new BinaryReader(File.Open(@"C:\Users\gy157\Documents\data.bin", FileMode.Open)))
            {
                int i = 0;
                try
                {
                    while (i < Convert.ToInt32(Text_Time.Text) * Convert.ToInt32(UpDown_Freq.Value))//rdr.ReadString().Length > 1)
                    {
                        chart1.Series["Read"].Points.AddY(Convert.ToDouble(rdr.ReadString()));
                        i++;
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            if (!Iszoomin)
            {
                Point CurrentPoint = new Point(e.X, e.Y);
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom((CurrentPoint.X * 100) - 50, (CurrentPoint.X * 100) + 50);
                Iszoomin = true;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                Iszoomin = false;
            }
        }

        private void BTN_Data_Click(object sender, EventArgs e)
        {
            list = new List<double>();
            freq = Convert.ToInt32(UpDown_Freq.Value);          // NI 주파수
            T = 0.002;                                          // Function Generator의 주파수의 역수
            N = T * freq;                                       // 한 주기당 데이터 수
            double Rms = 0;
            high = 0;
            low = 0;
            
            wr.Close();
            using (BinaryReader rdr = new BinaryReader(File.Open(@"C:\Users\gy157\Documents\data.bin", FileMode.Open)))
            {
                for (int i = 0; i < N; i++)
                {
                    list.Add(Convert.ToDouble(rdr.ReadString()));
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (list[i] >= 0.99)                // 한 주기 동안 High 데이터의 수
                {
                    high++;
                }
                else if (list[i] <= -0.99)          // 한 주기 동안 Low 데이터의 수
                {
                    low++;
                }
                Rms += list[i] * list[i];
            }

            Rms = Math.Sqrt(Rms / N);
            Text_Vrms.Text = Convert.ToString(Rms);
            Text_Duty.Text = Convert.ToString(high / N * 100);
            Text_Freq.Text = Convert.ToString(1/T);
            Text_On_T.Text = Convert.ToString(high / freq);
            Text_Off_T.Text = Convert.ToString(low / freq);

            fs2 = File.Open(@"C:\Users\gy157\Documents\data2.bin", FileMode.Create);
            wr2 = new BinaryWriter(fs2);
            wr2.Write(Text_Vrms.Text);
            wr2.Write(Text_Freq.Text);
            wr2.Write(Text_Duty.Text);
            wr2.Write(Text_On_T.Text);
            wr2.Write(Text_Off_T.Text);
            wr2.Write(UpDown_Freq.Value);
            wr2.Write(UpDown_Samples.Value);
            wr2.Write(Text_Time.Text);
        }
    }
}
