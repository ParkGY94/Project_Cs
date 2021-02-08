using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Power_Simulator
{
    public partial class TestForm : Form
    {
        MainForm mainform;
        Thread[] thread;
        Task[] task;
        CSV[] csv;
        ODA oda;
        SorensenXG sorenson;
        TDKLamdaGENH lamda;

        DataTable[] datatable;
        DataRow row;
        DateTime[] time;
        DateTime[] present;
        DateTime[] DT2;

        public List<string>[] list;
        public string[] Static;
        public string[] Lim;
        public bool[] timerlock;
        public bool[] timerlock2;
        public double[] RT1;
        public double[] RT2;
        public int[] DelayCount;
        public string[] VoltSetChk;
        public string[] CurrSetChk;

        public bool[] bOpen;
        public bool[] Ch_Status;
        public bool[] Stop;

        public int[] iStep;
        public int[] iCount;
        public int[] presentCount;
        public int[] presentcycle;

        public TestForm(MainForm mainform_)
        {
            InitializeComponent();

            mainform = mainform_;

            task = new Task[3];
            thread = new Thread[3];

            csv = new CSV[3];
            csv[0] = new CSV();
            csv[1] = new CSV();
            csv[2] = new CSV();

            VoltSetChk = new string[3];
            CurrSetChk = new string[3];

            datatable = new DataTable[3];
            present = new DateTime[3];
            DT2 = new DateTime[3];
            DT2[0] = DateTime.Now;
            DT2[1] = DateTime.Now;
            DT2[2] = DateTime.Now;

            time = new DateTime[3];

            list = new List<string>[3];

            DelayCount = new int[3];
            DelayCount[0] = 0;
            DelayCount[1] = 0;
            DelayCount[2] = 0;

            RT1 = new double[3];
            RT1[0] = 0;
            RT1[1] = 0;
            RT1[2] = 0;

            RT2 = new double[3];
            RT2[0] = 0;
            RT2[1] = 0;
            RT2[2] = 0;

            bOpen = new bool[3];
            bOpen[0] = false;
            bOpen[1] = false;
            bOpen[2] = false;

            Static = new string[3];
            Lim = new string[3];

            timerlock = new bool[3];
            timerlock[0] = false;
            timerlock[1] = false;
            timerlock[2] = false;

            timerlock2 = new bool[3];
            timerlock2[0] = false;
            timerlock2[1] = false;
            timerlock2[2] = false;

            Ch_Status = new bool[3];
            Ch_Status[0] = false;
            Ch_Status[1] = false;
            Ch_Status[2] = false;

            Stop = new bool[3];
            /*Stop[0] = false;
            Stop[1] = false;
            Stop[2] = false;*/

            iStep = new int[3];
            iStep[0] = 0;
            iStep[1] = 0;
            iStep[2] = 0;

            iCount = new int[3];
            iCount[0] = 0;
            iCount[1] = 0;
            iCount[2] = 0;

            presentCount = new int[3];
            presentCount[0] = 0;
            presentCount[1] = 0;
            presentCount[2] = 0;

            presentcycle = new int[3];
            presentcycle[0] = 1;
            presentcycle[1] = 1;
            presentcycle[2] = 1;

            row = null;

            DeviceConnect();
            sorenson.IDN();
        }

        private void DeviceConnect()
        {
            oda = new ODA();
            sorenson = new SorensenXG();
            lamda = new TDKLamdaGENH();
        }
        
        public void Delay(int ms)
        {
            DateTime starttime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, ms);
            while (true)
            {
                Application.DoEvents();
                if (DateTime.Now - starttime >= WaitTime)
                {
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Ch_Status[0])
                Ch1_Status.ForeColor = Color.White;
            else
                Ch1_Status.ForeColor = Color.Black;

            if (Ch_Status[1])
                Ch2_Status.ForeColor = Color.White;
            else
                Ch2_Status.ForeColor = Color.Black;

            if (Ch_Status[2])
                Ch3_Status.ForeColor = Color.White;
            else
                Ch3_Status.ForeColor = Color.Black;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (!bOpen[0] || !bOpen[1] || !bOpen[2])
            {
                MessageBox.Show("프로파일을 확인해주세요");
                return;
            }
            double outdata;
            double outdata2;

            if (!Double.TryParse(Txt_Cycle1.Text, out outdata) || !Double.TryParse(Txt_Sampling1.Text, out outdata) ||
                !Double.TryParse(Txt_Min1.Text, out outdata) || !Double.TryParse(Txt_Max1.Text, out outdata2) || outdata2 < outdata)
            {
                MessageBox.Show("설정값을 확인해주세요");
                return;
            }

            if (!Double.TryParse(Txt_Cycle2.Text, out outdata) || !Double.TryParse(Txt_Sampling2.Text, out outdata) ||
                !Double.TryParse(Txt_Min2.Text, out outdata) || !Double.TryParse(Txt_Max2.Text, out outdata2) || outdata2 < outdata)
            {
                MessageBox.Show("설정값을 확인해주세요");
                return;
            }

            if (!Double.TryParse(Txt_Cycle3.Text, out outdata) || !Double.TryParse(Txt_Sampling3.Text, out outdata) ||
                !Double.TryParse(Txt_Min3.Text, out outdata) || !Double.TryParse(Txt_Max3.Text, out outdata2) || outdata2 < outdata)
            {
                MessageBox.Show("설정값을 확인해주세요");
                return;
            }

            if (!Ch_Status[0] && !Ch_Status[1] && !Ch_Status[2])
            {
                //ODA 파워 On 
                Stop[0] = false;
                ch1.Interval = Convert.ToInt32(Txt_Sampling1.Text);
                Ch_Status[0] = true;

                if (!ODA_timer.Enabled)
                {
                    chart2.Series.Clear();
                    chart2.Series.Add("전압");
                    chart2.Series.Add("전류");
                    chart2.Series[0].BorderWidth = 2;
                    chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart2.Series[1].BorderWidth = 2;
                    chart2.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    oda.OutPut(true);
                    Delay(40);
                    oda.CurrentSet(Convert.ToDouble(Lim[0]));
                    Delay(30);

                    Txt_PresentCycle1.Text = presentcycle[0].ToString();
                }
                present[0] = DateTime.Now;

                ODA_timer.Enabled = true;
                //Sorensen 파워 On
                Stop[1] = false;
                ch2.Interval = Convert.ToInt32(Txt_Sampling2.Text);
                Ch_Status[1] = true;

                if (!Sorensen_timer.Enabled)
                {
                    chart4.Series.Clear();
                    chart4.Series.Add("전압");
                    chart4.Series.Add("전류");
                    chart4.Series[0].BorderWidth = 2;
                    chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart4.Series[1].BorderWidth = 2;
                    chart4.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    chart4.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    sorenson.OutPut(true);
                    Delay(40);
                    sorenson.OVL(Convert.ToDouble(Lim[1]));
                    Delay(30);

                    Txt_PresentCycle2.Text = presentcycle[1].ToString();
                }
                present[1] = DateTime.Now;

                Sorensen_timer.Enabled = true;
                //Lamda 파워 On
                Stop[2] = false;
                ch3.Interval = Convert.ToInt32(Txt_Sampling3.Text);
                Ch_Status[2] = true;

                if (!Lamda_Timer.Enabled)
                {
                    chart6.Series.Clear();
                    chart6.Series.Add("전압");
                    chart6.Series.Add("전류");
                    chart6.Series[0].BorderWidth = 2;
                    chart6.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart6.Series[1].BorderWidth = 2;
                    chart6.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    chart6.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    lamda.OutPut(true);
                    Delay(40);
                    lamda.OVL(Convert.ToDouble(Lim[2]));
                    Delay(30);

                    Txt_PresentCycle3.Text = presentcycle[2].ToString();
                }
                present[2] = DateTime.Now;

                Lamda_Timer.Enabled = true;
            }

            else if (Ch_Status[0] && Ch_Status[1] && Ch_Status[2])
            {
                Ch_Status[0] = false;
                Ch_Status[1] = false;
                Ch_Status[2] = false;
            }

            else
            {
                MessageBox.Show("각 채널들을 확인해주세요");
                return;
            }
        }

        private void BTN_OpenCh1_Click(object sender, EventArgs e)
        {
            string[] datalog = new string[5];
            List<string> list = new List<string>();
            List<string> value = new List<string>();
            datatable[0] = new DataTable();
            datatable[0].Columns.Add("number", typeof(string));
            datatable[0].Columns.Add("time", typeof(string));
            datatable[0].Columns.Add("time(s)", typeof(string));
            datatable[0].Columns.Add("value", typeof(string));
            datatable[0].Columns.Add("wave", typeof(string));

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bOpen[0] = true;
                string filename = openFileDialog1.FileName;
                chart1.Series.Clear();
                chart1.Series.Add("전압");
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart1.Series[0].BorderWidth = 2;
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Title = "시간(s)";
                chart1.ChartAreas[0].AxisX.Title = "전압(V)";
                chart1.Series[0].Color = Color.Red;

                if (csv[0].load(filename).Count > 0)
                {
                    value = csv[0].load(filename);
                    Lab_Filename1.Text = Path.GetFileNameWithoutExtension(filename);
                    for (int i = 0; i < value.Count - 2; i++)
                    {
                        row = datatable[0].NewRow();
                        datalog = value[i + 1].Split(',');
                        row["number"] = datalog[0];
                        row["time"] = datalog[1];
                        row["time(s)"] = datalog[2];
                        row["value"] = datalog[3];
                        row["wave"] = datalog[4];
                        datatable[0].Rows.Add(row);
                    }
                    datalog = value[value.Count - 1].Split(',');
                    /*Static[0] = datalog[1];
                    if (datalog[1] == "정전압")
                    {
                        chart1.Series[0].Name = "전압";
                    }
                    else if (datalog[1] == "정전류")
                    {
                        chart1.Series[0].Name = "전류";
                    }*/
                    Lim[0] = datalog[4];
                }

                for (int i = 0; i < datatable[0].Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (datatable[0].Rows[i][j].ToString() == "")
                        {
                            MessageBox.Show("값이 정확하지 않습니다. 다시 시도해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                for (int i = 0; i < datatable[0].Rows.Count; i++)
                {
                    switch (datatable[0].Rows[i][4].ToString())
                    {
                        case "SQUARE":
                            if (i > 0)
                            {
                                double time = Convert.ToDouble(datatable[0].Rows[i - 1][2]);
                                double endtime = Convert.ToDouble(datatable[0].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart1.Series[0].Points.AddXY(time, Convert.ToDouble(datatable[0].Rows[i][3]));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            else
                            {
                                chart1.Series[0].Points.AddY(0);
                                double time = 0;
                                double endtime = Convert.ToDouble(datatable[0].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart1.Series[0].Points.AddXY(time, Convert.ToDouble(datatable[0].Rows[i][3]));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            break;
                        case "RAMP":
                            if (i > 0)
                            {
                                double starttime = Convert.ToDouble(datatable[0].Rows[i - 1][2]);
                                double time = Convert.ToDouble(datatable[0].Rows[i - 1][2]);
                                double endtime = Convert.ToDouble(datatable[0].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart1.Series[0].Points.AddXY(time, (Convert.ToDouble(datatable[0].Rows[i - 1][3])) + (time - starttime)
                                        * ((Convert.ToDouble(datatable[0].Rows[i][3]) - Convert.ToDouble(datatable[0].Rows[i - 1][3]))
                                    / (Convert.ToDouble(datatable[0].Rows[i][2]) - Convert.ToDouble(datatable[0].Rows[i - 1][2]))));

                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            else
                            {
                                double time = 0;
                                double endtime = Convert.ToDouble(datatable[0].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart1.Series[0].Points.AddXY(time, time * (Convert.ToDouble(datatable[0].Rows[i][3]) / Convert.ToDouble(datatable[0].Rows[i][2])));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            break;
                    }
                }
                //chart1.Series[0].Points.AddXY(Convert.ToDouble(datatable[0].Rows[datatable[0].Rows.Count - 1][1]), 0);
            }
        }

        private void ch1_Tick(object sender, EventArgs e)
        {
            if (!timerlock[0])
            {
                timerlock[0] = true;
                if (Ch_Status[0])
                {
                    list[0] = new List<string>();
                    list[0].Add(DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss"));
                    list[0].Add(RT1[0].ToString());
                    list[0].Add(RT2[0].ToString());
                    list[0].Add("1");
                    list[0].Add(Txt_PresentCycle1.Text);
                    list[0].Add(Txt_Cycle1.Text);
                    list[0].Add(Txt_Sampling1.Text);
                    list[0].Add("CV");
                    list[0].Add(VoltSetChk[0]);
                    list[0].Add(CurrSetChk[0]);
                    list[0].Add(Convert.ToDouble(Lim[0]).ToString("0.00"));
                    list[0].Add(Txt_Vout1.Text);
                    list[0].Add(Txt_Iout1.Text);
                    if(Convert.ToDouble(list[0][8]) - Convert.ToDouble(list[0][11]) >= Convert.ToDouble(Txt_faulty1.Text) 
                        || Convert.ToDouble(list[0][11]) - Convert.ToDouble(list[0][8]) >= Convert.ToDouble(Txt_faulty1.Text))
                        csv[0].saveDB(list[0], "Ch1", Lab_Filename1.Text + "_불량");
                    else
                        csv[0].saveDB(list[0], "Ch1", Lab_Filename1.Text);

                    RT1[0] += ch1.Interval / 1000;
                    RT2[0] += ch1.Interval / 1000;
                }
                timerlock[0] = false;
            }
        }

        private void BTN_OnOff1_Click(object sender, EventArgs e)
        {
            if (!bOpen[0])
            {
                MessageBox.Show("프로파일을 불러오세요");
                return;
            }
            double outdata;
            double outdata2;

            if (!Double.TryParse(Txt_Cycle1.Text, out outdata) || !Double.TryParse(Txt_Sampling1.Text, out outdata) ||
                !Double.TryParse(Txt_Min1.Text, out outdata) || !Double.TryParse(Txt_Max1.Text, out outdata2) || outdata2 < outdata)
            {
                MessageBox.Show("설정값을 확인해주세요");
                return;
            }

            if (!Ch_Status[0])
            {
                //StartODA();
                Stop[0] = false;
                ch1.Interval = Convert.ToInt32(Txt_Sampling1.Text);
                Ch_Status[0] = true;

                if (!ODA_timer.Enabled)
                {
                    chart2.Series.Clear();
                    chart2.Series.Add("전압");
                    chart2.Series.Add("전류");
                    chart2.Series[0].BorderWidth = 2;
                    chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart2.Series[1].BorderWidth = 2;
                    chart2.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart2.ChartAreas[0].AxisX.Minimum = 0;
                    chart2.ChartAreas[0].AxisX.Title = "시간(s)";
                    chart2.ChartAreas[0].AxisY.Title = "전압(V)";
                    chart2.ChartAreas[0].AxisY2.Title = "전류(A)";
                    oda.OutPut(true);
                    Delay(40);
                    oda.CurrentSet(Convert.ToDouble(Lim[0]));
                    Delay(30);

                    Txt_PresentCycle1.Text = presentcycle[0].ToString();
                }
                present[0] = DateTime.Now;

                ODA_timer.Enabled = true;
            }
            else
            {
                Ch_Status[0] = false;
            }
        }

        private void BTN_Reset1_Click(object sender, EventArgs e)
        {
            if (Ch_Status[0])
            {
                MessageBox.Show("우선 동작을 정지시키세요", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oda.OutPut(false);
                Stop[0] = true;
                timerlock[0] = false;
                iCount[0] = 0;
                presentCount[0] = 0;
                presentcycle[0] = 1;
                Txt_Cycle1.Text = "";
                Txt_PresentCycle1.Text = "";
                Txt_Sampling1.Text = "";
                Txt_Max1.Text = "";
                Txt_Min1.Text = "";
                Txt_Vout1.Text = "";
                Txt_Iout1.Text = "";
                RT1[0] = 0;
                RT2[0] = 0;
                chart2.Series.Clear();
                chart2.Series.Add("전압");
                chart2.Series.Add("전류");
                chart2.Series[0].BorderWidth = 2;
                chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series[1].BorderWidth = 2;
                chart2.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.ChartAreas[0].AxisX.Minimum = 0;
                chart2.ChartAreas[0].AxisX.Title = "시간(s)";
                chart2.ChartAreas[0].AxisY.Title = "전압(V)";
                chart2.ChartAreas[0].AxisY2.Title = "전류(A)";
            }
        }

        private void BTN_OpenCh2_Click(object sender, EventArgs e)
        {
            string[] datalog = new string[4];
            List<string> list = new List<string>();
            List<string> value = new List<string>();
            datatable[1] = new DataTable();
            datatable[1].Columns.Add("number", typeof(string));
            datatable[1].Columns.Add("time", typeof(string));
            datatable[1].Columns.Add("time(s)", typeof(string));
            datatable[1].Columns.Add("value", typeof(string));
            datatable[1].Columns.Add("wave", typeof(string));

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                bOpen[1] = true;
                string filename = openFileDialog2.FileName;
                chart3.Series.Clear();
                chart3.Series.Add("전압");
                chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series[0].BorderWidth = 2;
                chart3.ChartAreas[0].AxisX.Minimum = 0;
                chart3.ChartAreas[0].AxisX.Title = "시간(s)";
                chart3.ChartAreas[0].AxisX.Title = "전압(V)";
                chart3.Series[0].Color = Color.Red;

                if (csv[1].load(filename).Count > 0)
                {
                    value = csv[1].load(filename);
                    Lab_Filename2.Text = Path.GetFileNameWithoutExtension(filename);
                    for (int i = 0; i < value.Count - 2; i++)
                    {
                        row = datatable[1].NewRow();
                        datalog = value[i + 1].Split(',');
                        row["number"] = datalog[0];
                        row["time"] = datalog[1];
                        row["time(s)"] = datalog[2];
                        row["value"] = datalog[3];
                        row["wave"] = datalog[4];
                        datatable[1].Rows.Add(row);
                    }
                    datalog = value[value.Count - 1].Split(',');
                    /*Static[1] = datalog[1];
                    if (datalog[1] == "정전압")
                    {
                        chart3.Series[0].Name = "전압";
                    }
                    else if (datalog[1] == "정전류")
                    {
                        chart3.Series[0].Name = "전류";
                    }*/
                    Lim[1] = datalog[4];
                }

                for (int i = 0; i < datatable[1].Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (datatable[1].Rows[i][j].ToString() == "")
                        {
                            MessageBox.Show("값이 정확하지 않습니다. 다시 시도해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                for (int i = 0; i < datatable[1].Rows.Count; i++)
                {
                    switch (datatable[1].Rows[i][4].ToString())
                    {
                        case "SQUARE":
                            if (i > 0)
                            {
                                double time = Convert.ToDouble(datatable[1].Rows[i - 1][2]);
                                double endtime = Convert.ToDouble(datatable[1].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart3.Series[0].Points.AddXY(time, Convert.ToDouble(datatable[1].Rows[i][3]));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            else
                            {
                                chart3.Series[0].Points.AddY(0);
                                double time = 0;
                                double endtime = Convert.ToDouble(datatable[1].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart3.Series[0].Points.AddXY(time, Convert.ToDouble(datatable[1].Rows[i][3]));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            break;
                        case "RAMP":
                            if (i > 0)
                            {
                                double starttime = Convert.ToDouble(datatable[1].Rows[i - 1][2]);
                                double time = Convert.ToDouble(datatable[1].Rows[i - 1][2]);
                                double endtime = Convert.ToDouble(datatable[1].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart3.Series[0].Points.AddXY(time, (Convert.ToDouble(datatable[1].Rows[i - 1][3])) + (time - starttime)
                                        * ((Convert.ToDouble(datatable[1].Rows[i][3]) - Convert.ToDouble(datatable[1].Rows[i - 1][3]))
                                    / (Convert.ToDouble(datatable[1].Rows[i][2]) - Convert.ToDouble(datatable[1].Rows[i - 1][2]))));

                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            else
                            {
                                double time = 0;
                                double endtime = Convert.ToDouble(datatable[1].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart3.Series[0].Points.AddXY(time, time * (Convert.ToDouble(datatable[1].Rows[i][3]) / Convert.ToDouble(datatable[1].Rows[i][2])));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            break;
                    }
                }
                //chart3.Series[0].Points.AddXY(Convert.ToDouble(datatable[1].Rows[datatable[1].Rows.Count - 1][1]), 0);
            }
        }

        private void ch2_Tick(object sender, EventArgs e)
        {
            if (!timerlock[1])
            {
                timerlock[1] = true;
                if (Ch_Status[1])
                {
                    list[1] = new List<string>();
                    list[1].Add(DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss"));
                    list[1].Add(RT1[1].ToString());
                    list[1].Add(RT2[1].ToString());
                    list[1].Add("2");
                    list[1].Add(Txt_PresentCycle2.Text);
                    list[1].Add(Txt_Cycle2.Text);
                    list[1].Add(Txt_Sampling2.Text);
                    list[1].Add("CV");
                    list[1].Add(VoltSetChk[1]);
                    list[1].Add(CurrSetChk[1]);
                    list[1].Add(Convert.ToDouble(Lim[1]).ToString("0.00"));
                    list[1].Add(Txt_Vout2.Text);
                    list[1].Add(Txt_Iout2.Text);
                    if (Convert.ToDouble(list[1][8]) - Convert.ToDouble(list[1][11]) >= Convert.ToDouble(Txt_faulty2.Text)
                        || Convert.ToDouble(list[1][11]) - Convert.ToDouble(list[1][8]) >= Convert.ToDouble(Txt_faulty2.Text))
                        csv[1].saveDB(list[1], "Ch2", Lab_Filename2.Text + "_불량");
                    else
                        csv[1].saveDB(list[1], "Ch2", Lab_Filename2.Text);

                    RT1[1] += ch2.Interval / 1000;
                    RT2[1] += ch2.Interval / 1000;
                }
                timerlock[1] = false;
            }
        }

        private void BTN_OnOff2_Click(object sender, EventArgs e)
        {
            if (!bOpen[1])
            {
                MessageBox.Show("프로파일을 불러오세요");
                return;
            }
            double outdata;
            double outdata2;

            if (!Double.TryParse(Txt_Cycle2.Text, out outdata) || !Double.TryParse(Txt_Sampling2.Text, out outdata) ||
                !Double.TryParse(Txt_Min2.Text, out outdata) || !Double.TryParse(Txt_Max2.Text, out outdata2) || outdata2 < outdata)
            {
                MessageBox.Show("설정값을 확인해주세요");
                return;
            }

            if (!Ch_Status[1])
            {
                //StartSorensen();
                Stop[1] = false;
                ch2.Interval = Convert.ToInt32(Txt_Sampling2.Text);
                Ch_Status[1] = true;

                if (!Sorensen_timer.Enabled)
                {
                    chart4.Series.Clear();
                    chart4.Series.Add("전압");
                    chart4.Series.Add("전류");
                    chart4.Series[0].BorderWidth = 2;
                    chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart4.Series[1].BorderWidth = 2;
                    chart4.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    chart4.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart4.ChartAreas[0].AxisX.Minimum = 0;
                    chart4.ChartAreas[0].AxisX.Title = "시간(s)";
                    chart4.ChartAreas[0].AxisY.Title = "전압(V)";
                    chart4.ChartAreas[0].AxisY2.Title = "전류(A)";
                    sorenson.OutPut(true);
                    Delay(40);
                    sorenson.CurrentSet(Convert.ToDouble(Lim[1]));
                    Delay(30);

                    Txt_PresentCycle2.Text = presentcycle[1].ToString();
                }
                present[1] = DateTime.Now;

                Sorensen_timer.Enabled = true;
            }
            else
            {
                //Sorensen_timer.Enabled = false;
                Ch_Status[1] = false;
            }
        }

        private void BTN_Reset2_Click(object sender, EventArgs e)
        {
            if (Ch_Status[1])
            {
                MessageBox.Show("우선 동작을 정지시키세요", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sorenson.OutPut(false);
                Stop[1] = true;
                timerlock[1] = false;
                iCount[1] = 0;
                presentCount[1] = 0;
                presentcycle[1] = 1;
                Txt_Cycle2.Text = "";
                Txt_PresentCycle2.Text = "";
                Txt_Sampling2.Text = "";
                Txt_Max2.Text = "";
                Txt_Min2.Text = "";
                Txt_Vout2.Text = "";
                Txt_Iout2.Text = "";
                RT1[1] = 0;
                RT2[1] = 0;
                chart4.Series.Clear();
                chart4.Series.Add("전압");
                chart4.Series.Add("전류");
                chart4.Series[0].BorderWidth = 2;
                chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart4.Series[1].BorderWidth = 2;
                chart4.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                chart4.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart4.ChartAreas[0].AxisX.Minimum = 0;
                chart4.ChartAreas[0].AxisX.Title = "시간(s)";
                chart4.ChartAreas[0].AxisY.Title = "전압(V)";
                chart4.ChartAreas[0].AxisY2.Title = "전류(A)";
            }
        }

        private void BTN_OpenCh3_Click(object sender, EventArgs e)
        {
            string[] datalog = new string[4];
            List<string> list = new List<string>();
            List<string> value = new List<string>();
            datatable[2] = new DataTable();
            datatable[2].Columns.Add("number", typeof(string));
            datatable[2].Columns.Add("time", typeof(string));
            datatable[2].Columns.Add("time(s)", typeof(string));
            datatable[2].Columns.Add("value", typeof(string));
            datatable[2].Columns.Add("wave", typeof(string));

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                bOpen[2] = true;
                string filename = openFileDialog3.FileName;
                chart5.Series.Clear();
                chart5.Series.Add("전압");
                chart5.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart5.Series[0].BorderWidth = 2;
                chart5.ChartAreas[0].AxisX.Minimum = 0;
                chart5.ChartAreas[0].AxisX.Title = "시간(s)";
                chart5.ChartAreas[0].AxisX.Title = "전압(V)";
                chart5.Series[0].Color = Color.Red;

                if (csv[2].load(filename).Count > 0)
                {
                    value = csv[2].load(filename);
                    Lab_Filename3.Text = Path.GetFileNameWithoutExtension(filename);
                    for (int i = 0; i < value.Count - 2; i++)
                    {
                        row = datatable[2].NewRow();
                        datalog = value[i + 1].Split(',');
                        row["number"] = datalog[0];
                        row["time"] = datalog[1];
                        row["time(s)"] = datalog[2];
                        row["value"] = datalog[3];
                        row["wave"] = datalog[4];
                        datatable[2].Rows.Add(row);
                    }
                    datalog = value[value.Count - 1].Split(',');
                    /*Static[2] = datalog[1];
                    if (datalog[1] == "정전압")
                    {
                        chart5.Series[0].Name = "전압";
                    }
                    else if (datalog[1] == "정전류")
                    {
                        chart5.Series[0].Name = "전류";
                    }*/
                    Lim[2] = datalog[4];
                }

                for (int i = 0; i < datatable[2].Rows.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (datatable[2].Rows[i][j].ToString() == "")
                        {
                            MessageBox.Show("값이 정확하지 않습니다. 다시 시도해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                for (int i = 0; i < datatable[2].Rows.Count; i++)
                {
                    switch (datatable[2].Rows[i][4].ToString())
                    {
                        case "SQUARE":
                            if (i > 0)
                            {
                                double time = Convert.ToDouble(datatable[2].Rows[i - 1][2]);
                                double endtime = Convert.ToDouble(datatable[2].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart5.Series[0].Points.AddXY(time, Convert.ToDouble(datatable[2].Rows[i][3]));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            else
                            {
                                chart5.Series[0].Points.AddY(0);
                                double time = 0;
                                double endtime = Convert.ToDouble(datatable[2].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart5.Series[0].Points.AddXY(time, Convert.ToDouble(datatable[2].Rows[i][3]));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            break;
                        case "RAMP":
                            if (i > 0)
                            {
                                double starttime = Convert.ToDouble(datatable[2].Rows[i - 1][2]);
                                double time = Convert.ToDouble(datatable[2].Rows[i - 1][2]);
                                double endtime = Convert.ToDouble(datatable[2].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart5.Series[0].Points.AddXY(time, (Convert.ToDouble(datatable[2].Rows[i - 1][3])) + (time - starttime)
                                        * ((Convert.ToDouble(datatable[2].Rows[i][3]) - Convert.ToDouble(datatable[2].Rows[i - 1][3]))
                                    / (Convert.ToDouble(datatable[2].Rows[i][2]) - Convert.ToDouble(datatable[2].Rows[i - 1][2]))));

                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            else
                            {
                                double time = 0;
                                double endtime = Convert.ToDouble(datatable[2].Rows[i][2]);
                                while (time <= endtime)
                                {
                                    chart5.Series[0].Points.AddXY(time, time * (Convert.ToDouble(datatable[2].Rows[i][3]) / Convert.ToDouble(datatable[2].Rows[i][2])));
                                    time++;
                                    if (time == endtime + 1)
                                    {
                                        break;
                                    }
                                    else if (time > endtime)
                                        time = endtime;
                                }
                            }
                            break;
                    }
                }
                //chart5.Series[0].Points.AddXY(Convert.ToDouble(datatable[2].Rows[datatable[2].Rows.Count - 1][1]), 0);
            }
        }

        private void ch3_Tick(object sender, EventArgs e)
        {
            if (!timerlock[2])
            {
                timerlock[2] = true;
                if (Ch_Status[2])
                {
                    list[2] = new List<string>();
                    list[2].Add(DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss"));
                    list[2].Add(RT1[2].ToString());
                    list[2].Add(RT2[2].ToString());
                    list[2].Add("3");
                    list[2].Add(Txt_PresentCycle3.Text);
                    list[2].Add(Txt_Cycle3.Text);
                    list[2].Add(Txt_Sampling3.Text);
                    list[2].Add("CV");
                    list[2].Add(VoltSetChk[2]);
                    list[2].Add(CurrSetChk[2]);
                    list[2].Add(Convert.ToDouble(Lim[2]).ToString("0.00"));
                    list[2].Add(Txt_Vout3.Text);
                    list[2].Add(Txt_Iout3.Text);
                    if (Convert.ToDouble(list[2][8]) - Convert.ToDouble(list[2][11]) >= Convert.ToDouble(Txt_faulty3.Text)
                        || Convert.ToDouble(list[2][11]) - Convert.ToDouble(list[2][8]) >= Convert.ToDouble(Txt_faulty3.Text))
                        csv[2].saveDB(list[2], "Ch3", Lab_Filename3.Text + "_불량");
                    else
                        csv[2].saveDB(list[2], "Ch3", Lab_Filename3.Text);

                    RT1[2] += ch3.Interval / 1000;
                    RT2[2] += ch3.Interval / 1000;
                }
                timerlock[2] = false;
            }
        }

        private void BTN_OnOff3_Click(object sender, EventArgs e)
        {
            if (!bOpen[2])
            {
                MessageBox.Show("프로파일을 불러오세요");
                return;
            }
            double outdata;
            double outdata2;

            if (!Double.TryParse(Txt_Cycle3.Text, out outdata) || !Double.TryParse(Txt_Sampling3.Text, out outdata) ||
                !Double.TryParse(Txt_Min3.Text, out outdata) || !Double.TryParse(Txt_Max3.Text, out outdata2) || outdata2 < outdata)
            {
                MessageBox.Show("설정값을 확인해주세요");
                return;
            }

            if (!Ch_Status[2])
            {
                Stop[2] = false;
                ch3.Interval = Convert.ToInt32(Txt_Sampling3.Text);
                Ch_Status[2] = true;

                if (!Lamda_Timer.Enabled)
                {
                    chart6.Series.Clear();
                    chart6.Series.Add("전압");
                    chart6.Series.Add("전류");
                    chart6.Series[0].BorderWidth = 2;
                    chart6.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart6.Series[1].BorderWidth = 2;
                    chart6.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                    chart6.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                    chart6.ChartAreas[0].AxisX.Minimum = 0;
                    chart6.ChartAreas[0].AxisX.Title = "시간(s)";
                    chart6.ChartAreas[0].AxisY.Title = "전압(V)";
                    chart6.ChartAreas[0].AxisY2.Title = "전류(A)";
                    lamda.OutPut(true);
                    Delay(40);
                    lamda.CurrentSet(Convert.ToDouble(Lim[2]));
                    Delay(30);

                    Txt_PresentCycle3.Text = presentcycle[2].ToString();
                }
                present[2] = DateTime.Now;

                Lamda_Timer.Enabled = true;
            }
            else
            {
                Ch_Status[2] = false;
            }
        }

        private void BTN_Reset3_Click(object sender, EventArgs e)
        {
            if (Ch_Status[2])
            {
                MessageBox.Show("우선 동작을 정지시키세요", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lamda.OutPut(false);
                Stop[2] = true;
                timerlock[2] = false;
                /*Delay(50);
                if (task[2] != null)
                {
                    task[2].Dispose();
                    task[2] = null;
                }*/
                iCount[2] = 0;
                presentCount[2] = 0;
                presentcycle[2] = 1;
                Txt_Cycle3.Text = "";
                Txt_PresentCycle3.Text = "";
                Txt_Sampling3.Text = "";
                Txt_Max3.Text = "";
                Txt_Min3.Text = "";
                Txt_Vout3.Text = "";
                Txt_Iout3.Text = "";
                RT1[2] = 0;
                RT2[2] = 0;
                chart6.Series.Clear();
                chart6.Series.Add("전압");
                chart6.Series.Add("전류");
                chart6.Series[0].BorderWidth = 2;
                chart6.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart6.Series[1].BorderWidth = 2;
                chart6.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                chart6.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart6.ChartAreas[0].AxisX.Minimum = 0;
                chart6.ChartAreas[0].AxisX.Title = "시간(s)";
                chart6.ChartAreas[0].AxisY.Title = "전압(V)";
                chart6.ChartAreas[0].AxisY2.Title = "전류(A)";
            }
        }

        public double VoltSetting(string mode, double starttime, double endtime, double presenttime, double startvol, double endvol)
        {
            double Setvol = 0;
            if(mode == "SQUARE")
            {
                Setvol = endvol;
            }
            else
            {
                Setvol = startvol + ((presenttime - starttime) * 
                    ((endvol - startvol) / (endtime - starttime)));
            }
            return Setvol;
        }

        private void Timer_Sorensen_Tick(object sender, EventArgs e)
        {
            if (!timerlock2[1])
            {
                timerlock2[1] = true;
                if (!Ch_Status[1])
                {
                    timerlock2[1] = false;
                    return;
                }

                TimeSpan WT = new TimeSpan(0, 0, 0, 0, 305);
                TimeSpan WT2 = new TimeSpan(0, 0, 0, 0, 30);
                string mode = datatable[1].Rows[iCount[1]][4].ToString();
                double starttime;
                if (iCount[1] == 0)
                    starttime = 0;
                else
                    starttime = Convert.ToDouble(datatable[1].Rows[iCount[1] - 1][2]);
                double endtime = Convert.ToDouble(datatable[1].Rows[iCount[1]][2]);
                double presenttime = starttime + (presentCount[1] * 0.305);

                double startvol;
                if (iCount[1] == 0)
                    startvol = 0;
                else
                    startvol = Convert.ToDouble(datatable[1].Rows[iCount[1] - 1][3]);
                double endvol = Convert.ToDouble(datatable[1].Rows[iCount[1]][3]);

                switch (iStep[1])
                {
                    case 0:
                        sorenson.VoltSet(VoltSetting(mode, starttime, endtime, presenttime, startvol, endvol));
                        time[1] = DateTime.Now;
                        iStep[1]++;
                        break;

                    case 1:
                        Delay(50);
                        if (DateTime.Now - time[1] >= WT2)
                            iStep[1]++;
                        break;

                    case 2:
                        mainform.strReadPower[1] = "";
                        sorenson.VoltSetCheck();
                        iStep[1]++;
                        time[1] = DateTime.Now;
                        break;
                        
                    case 3:
                        if (mainform.strReadPower[1] != "")
                        {
                            try
                            {
                                VoltSetChk[1] = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                            }
                            catch
                            {
                                VoltSetChk[1] = "-1";
                            }
                            iStep[1]++;
                        }
                        else if (DateTime.Now - time[1] > WT)
                            iStep[1]--;
                        break;

                    case 4:
                        mainform.strReadPower[1] = "";
                        sorenson.VoltOutCheck();
                        iStep[1]++;
                        time[1] = DateTime.Now;
                        break;

                    case 5:
                        if (mainform.strReadPower[1] != "")
                        {
                            try
                            {
                                Txt_Vout2.Text = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                            }
                            catch
                            {
                                Txt_Vout2.Text = "-1";
                            }
                            chart4.Series[0].Points.AddXY(presenttime, mainform.strReadPower[1]);
                            iStep[1]++;
                        }
                        else if (DateTime.Now - time[1] > WT)
                            iStep[1]--;
                        break;

                    case 6:
                        mainform.strReadPower[1] = "";
                        sorenson.CurrentSetCheck();
                        iStep[1]++;
                        time[1] = DateTime.Now;
                        break;

                    case 7:
                        if (mainform.strReadPower[1] != "")
                        {
                            try
                            {
                                CurrSetChk[1] = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                            }
                            catch
                            {
                                CurrSetChk[1] = "-1";
                            }
                            iStep[1]++;
                        }
                        else if (DateTime.Now - time[1] > WT)
                            iStep[1]--;
                        break;

                    case 8:
                        mainform.strReadPower[1] = "";
                        sorenson.CurrentOutCheck();
                        iStep[1]++;
                        time[1] = DateTime.Now;
                        break;

                    case 9:
                        if (mainform.strReadPower[1] != "")
                        {
                            try
                            {
                                Txt_Iout2.Text = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                            }
                            catch
                            {
                                Txt_Iout2.Text = "-1";
                            }
                            chart4.Series[1].Points.AddXY(presenttime, mainform.strReadPower[1]);
                            iStep[1]++;
                            time[1] = DateTime.Now;
                        }
                        else if (DateTime.Now - time[1] > WT)
                            iStep[1]--;
                        break;

                    case 10:
                        if (DateTime.Now - present[1] >= WT)
                        {
                            iStep[1] = 0;
                            presentCount[1]++;
                            if (starttime + (presentCount[1] * 0.305) > endtime)
                            {
                                presentCount[1] = 1;
                                iCount[1]++;
                                if (iCount[1] >= datatable[1].Rows.Count)
                                {
                                    if (presentcycle[1] >= Convert.ToInt32(Txt_Min2.Text) && presentcycle[1] <= Convert.ToInt32(Txt_Max2.Text))
                                    {
                                        string now = DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
                                        chart4.SaveImage(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\Data\Graph\"
                                            + Lab_Filename2.Text + "_" + presentcycle[1].ToString() + "_" + now
                                            + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                                    }
                                    presentCount[1] = 0;
                                    presentcycle[1]++;
                                    iCount[1] = 0;

                                    RT1[1] = 0;
                                    present[1] = DateTime.Now;
                                    if (presentcycle[1] > Convert.ToInt32(Txt_Cycle2.Text))
                                    {
                                        sorenson.OutPut(false);
                                        presentcycle[1] = 1;
                                        RT2[1] = 0;
                                        Ch_Status[1] = false;
                                        Sorensen_timer.Enabled = false;
                                    }
                                    else
                                    {
                                        Txt_PresentCycle2.Text = presentcycle[1].ToString();
                                        chart4.Series.Clear();
                                        chart4.Series.Add("전압");
                                        chart4.Series.Add("전류");
                                        chart4.Series[0].BorderWidth = 2;
                                        chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                        chart4.Series[1].BorderWidth = 2;
                                        chart4.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                                        chart4.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                        chart4.ChartAreas[0].AxisX.Minimum = 0;
                                        chart4.ChartAreas[0].AxisX.Title = "시간(s)";
                                        chart4.ChartAreas[0].AxisY.Title = "전압(V)";
                                        chart4.ChartAreas[0].AxisY2.Title = "전류(A)";
                                    }
                                }
                            }
                        }
                        break;
                }
                timerlock2[1] = false;
            }
        }
        
        private void Lamda_Timer_Tick(object sender, EventArgs e)
        {
            if (!timerlock2[2])
            {
                timerlock2[2] = true;
                if (!Ch_Status[2])
                {
                    timerlock2[2] = false;
                    return;
                }

                TimeSpan WT = new TimeSpan(0, 0, 0, 0, 291);
                TimeSpan WT2 = new TimeSpan(0, 0, 0, 0, 30);
                string mode = datatable[2].Rows[iCount[2]][4].ToString();
                double starttime;
                if (iCount[2] == 0)
                    starttime = 0;
                else
                    starttime = Convert.ToDouble(datatable[2].Rows[iCount[2] - 1][2]);
                double endtime = Convert.ToDouble(datatable[2].Rows[iCount[2]][2]);
                double presenttime = starttime + (presentCount[2] * 0.291);

                double startvol;
                if (iCount[2] == 0)
                    startvol = 0;
                else
                    startvol = Convert.ToDouble(datatable[2].Rows[iCount[2] - 1][3]);
                double endvol = Convert.ToDouble(datatable[2].Rows[iCount[2]][3]);

                switch (iStep[2])
                {
                    case 0:
                        lamda.VoltSet(VoltSetting(mode, starttime, endtime, presenttime, startvol, endvol));
                        time[2] = DateTime.Now;
                        iStep[2]++;
                        break;

                    case 1:
                        if (DateTime.Now - time[2] >= WT2)
                            iStep[2]++;
                        break;

                    case 2:
                        mainform.strReadPower[2] = "";
                        lamda.VoltSetCheck();
                        iStep[2]++;
                        time[2] = DateTime.Now;
                        break;

                    case 3:
                        if (mainform.strReadPower[2] != "")
                        {
                            try
                            {
                                VoltSetChk[2] = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                            }
                            catch
                            {
                                VoltSetChk[2] = "-1";
                            }
                            iStep[2]++;
                        }
                        else if (DateTime.Now - time[2] > WT)
                            iStep[2]--;
                        break;

                    case 4:
                        mainform.strReadPower[2] = "";
                        lamda.VoltOutCheck();
                        iStep[2]++;
                        time[2] = DateTime.Now;
                        break;

                    case 5:
                        if (mainform.strReadPower[2] != "")
                        {
                            try
                            {
                                Txt_Vout3.Text = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                            }
                            catch
                            {
                                Txt_Vout3.Text = "-1";
                            }
                            chart6.Series[0].Points.AddXY(presenttime, mainform.strReadPower[2]);
                            iStep[2]++;
                        }
                        else if (DateTime.Now - time[2] > WT)
                            iStep[2]--;
                        break;

                    case 6:
                        mainform.strReadPower[2] = "";
                        lamda.CurrentSetCheck();
                        iStep[2]++;
                        time[2] = DateTime.Now;
                        break;

                    case 7:
                        if (mainform.strReadPower[2] != "")
                        {
                            try
                            {
                                CurrSetChk[2] = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                            }
                            catch
                            {
                                CurrSetChk[2] = "-1";
                            }
                            iStep[2]++;
                        }
                        else if (DateTime.Now - time[2] > WT)
                            iStep[2]--;
                        break;

                    case 8:
                        mainform.strReadPower[2] = "";
                        lamda.CurrentOutCheck();
                        iStep[2]++;
                        time[2] = DateTime.Now;
                        break;

                    case 9:
                        if (mainform.strReadPower[2] != "")
                        {
                            try
                            {
                                Txt_Iout3.Text = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                            }
                            catch
                            {
                                Txt_Iout3.Text = "-1";
                            }
                            chart6.Series[1].Points.AddXY(presenttime, mainform.strReadPower[2]);
                            iStep[2]++;
                            time[2] = DateTime.Now;
                        }
                        else if (DateTime.Now - time[2] > WT)
                            iStep[2]--;
                        break;

                    case 10:
                        if (DateTime.Now - present[2] >= WT)
                        {
                            iStep[2] = 0;
                            presentCount[2]++;
                            if (starttime + (presentCount[2] * 0.291) > endtime)
                            {
                                presentCount[2] = 1;
                                iCount[2]++;
                                if (iCount[2] >= datatable[2].Rows.Count)
                                {
                                    if (presentcycle[2] >= Convert.ToInt32(Txt_Min3.Text) && presentcycle[2] <= Convert.ToInt32(Txt_Max3.Text))
                                    {
                                        string now = DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
                                        chart6.SaveImage(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\Data\Graph\"
                                            + Lab_Filename3.Text + "_" + presentcycle[2].ToString() + "_" + now
                                            + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                                    }
                                    presentCount[2] = 0;
                                    presentcycle[2]++;
                                    iCount[2] = 0;

                                    RT1[2] = 0;
                                    present[2] = DateTime.Now;
                                    if (presentcycle[2] > Convert.ToInt32(Txt_Cycle3.Text))
                                    {
                                        lamda.OutPut(false);
                                        presentcycle[2] = 1;
                                        RT2[2] = 0;
                                        Ch_Status[2] = false;
                                        Lamda_Timer.Enabled = false;
                                    }
                                    else
                                    {
                                        Txt_PresentCycle3.Text = presentcycle[2].ToString();
                                        chart6.Series.Clear();
                                        chart6.Series.Add("전압");
                                        chart6.Series.Add("전류");
                                        chart6.Series[0].BorderWidth = 2;
                                        chart6.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                        chart6.Series[1].BorderWidth = 2;
                                        chart6.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                                        chart6.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                        chart6.ChartAreas[0].AxisX.Minimum = 0;
                                        chart6.ChartAreas[0].AxisX.Title = "시간(s)";
                                        chart6.ChartAreas[0].AxisY.Title = "전압(V)";
                                        chart6.ChartAreas[0].AxisY2.Title = "전류(A)";
                                    }
                                }
                            }
                        }
                        break;
                }
                timerlock2[2] = false;
            }
        }

        private void ODA_timer_Tick(object sender, EventArgs e)
        {
            if (!timerlock2[0])
            {
                timerlock2[0] = true;
                if (!Ch_Status[0])
                {
                    timerlock2[0] = false;
                    return;
                }

                TimeSpan WT = new TimeSpan(0, 0, 0, 0, 252);
                TimeSpan WT2 = new TimeSpan(0, 0, 0, 0, 30);
                string mode = datatable[0].Rows[iCount[0]][4].ToString();
                double starttime;
                if (iCount[0] == 0)
                    starttime = 0;
                else
                    starttime = Convert.ToDouble(datatable[0].Rows[iCount[0] - 1][2]);
                double endtime = Convert.ToDouble(datatable[0].Rows[iCount[0]][2]);
                double presenttime = starttime + (presentCount[0] * 0.252);

                double startvol;
                if (iCount[0] == 0)
                    startvol = 0;
                else
                    startvol = Convert.ToDouble(datatable[0].Rows[iCount[0] - 1][3]);
                double endvol = Convert.ToDouble(datatable[0].Rows[iCount[0]][3]);

                switch (iStep[0])
                {
                    case 0:
                        //if (Static[0] == "정전압")
                        oda.VoltSet(VoltSetting(mode, starttime, endtime, presenttime, startvol, endvol));
                        //else
                            //oda.CurrentSet(VoltSetting(mode, starttime, endtime, presenttime, startvol, endvol));
                        time[0] = DateTime.Now;
                        iStep[0]++;
                        break;

                    case 1:
                        if (DateTime.Now - time[0] >= WT2)
                            iStep[0]++;
                        break;

                    case 2:
                        mainform.strReadPower[0] = "";
                        oda.VoltSetCheck();
                        iStep[0]++;
                        time[0] = DateTime.Now;
                        break;

                    case 3:
                        if (mainform.strReadPower[0] != "")
                        {
                            try
                            {
                                VoltSetChk[0] = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                            }
                            catch
                            {
                                VoltSetChk[0] = "-1";
                            }
                            iStep[0]++;
                        }
                        else if (DateTime.Now - time[0] > WT)
                            iStep[0]--;
                        break;

                    case 4:
                        mainform.strReadPower[0] = "";
                        oda.VoltOutCheck();
                        iStep[0]++;
                        time[0] = DateTime.Now;
                        break;

                    case 5:
                        if (mainform.strReadPower[0] != "")
                        {
                            try
                            {
                                Txt_Vout1.Text = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                            }
                            catch
                            {
                                Txt_Vout1.Text = "-1";
                            }
                            chart2.Series[0].Points.AddXY(presenttime, mainform.strReadPower[0]);
                            iStep[0]++;
                        }
                        else if (DateTime.Now - time[0] > WT)
                            iStep[0]--;
                        break;

                    case 6:
                        mainform.strReadPower[0] = "";
                        oda.CurrentSetCheck();
                        iStep[0]++;
                        time[0] = DateTime.Now;
                        break;

                    case 7:
                        if (mainform.strReadPower[0] != "")
                        {
                            try
                            {
                                CurrSetChk[0] = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                            }
                            catch
                            {
                                CurrSetChk[0] = "-1";
                            }
                            iStep[0]++;
                        }
                        else if (DateTime.Now - time[0] > WT)
                            iStep[0]--;
                        break;

                    case 8:
                        mainform.strReadPower[0] = "";
                        oda.CurrentOutCheck();
                        iStep[0]++;
                        time[0] = DateTime.Now;
                        break;

                    case 9:
                        if (mainform.strReadPower[0] != "")
                        {
                            try
                            {
                                Txt_Iout1.Text = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                            }
                            catch
                            {
                                Txt_Iout1.Text = "-1";
                            }
                            chart2.Series[1].Points.AddXY(presenttime, mainform.strReadPower[0]);
                            iStep[0]++;
                            time[0] = DateTime.Now;
                        }
                        else if (DateTime.Now - time[0] > WT)
                            iStep[0]--;
                        break;

                    case 10:
                        if (DateTime.Now - present[0] >= WT)
                        {
                            iStep[0] = 0;
                            presentCount[0]++;
                            if (starttime + (presentCount[0] * 0.252) > endtime)
                            {
                                presentCount[0] = 1;
                                iCount[0]++;
                                if (iCount[0] >= datatable[0].Rows.Count)
                                {
                                    if (presentcycle[0] >= Convert.ToInt32(Txt_Min1.Text) && presentcycle[0] <= Convert.ToInt32(Txt_Max1.Text))
                                    {
                                        string now = DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
                                        chart2.SaveImage(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\Data\Graph\"
                                            + Lab_Filename1.Text + "_" + presentcycle[0].ToString() + "_" + now
                                            + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                                    }
                                    presentCount[0] = 0;
                                    presentcycle[0]++;
                                    iCount[0] = 0;

                                    RT1[0] = 0;
                                    present[0] = DateTime.Now;
                                    if (presentcycle[0] > Convert.ToInt32(Txt_Cycle1.Text))
                                    {
                                        oda.OutPut(false);
                                        presentcycle[0] = 1;
                                        RT2[0] = 0;
                                        Ch_Status[0] = false;
                                        ODA_timer.Enabled = false;
                                    }
                                    else
                                    {
                                        Txt_PresentCycle1.Text = presentcycle[0].ToString();
                                        chart2.Series.Clear();
                                        chart2.Series.Add("전압");
                                        chart2.Series.Add("전류");
                                        chart2.Series[0].BorderWidth = 2;
                                        chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                        chart2.Series[1].BorderWidth = 2;
                                        chart2.Series[1].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                                        chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                                        chart2.ChartAreas[0].AxisX.Minimum = 0;
                                        chart2.ChartAreas[0].AxisX.Title = "시간(s)";
                                        chart2.ChartAreas[0].AxisY.Title = "전압(V)";
                                        chart2.ChartAreas[0].AxisY2.Title = "전류(A)";
                                    }
                                }
                            }
                        }
                        break;
                }
                timerlock2[0] = false;
                //ODA_timer.Enabled = true;
            }
        }

        private void Txt_Cycle1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
    
