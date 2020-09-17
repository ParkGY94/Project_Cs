using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMMONS;
//using NationalInstruments.DAQmx;

namespace Analog_Digit
{
    public partial class AutoForm : Form
    {
        public Analog anal;
        public Binary binary;
        public Digit digit;
        public HIOKI3540 hioki;
        public iniUtil ini;
        public logFile logfile;

        public string ErrorMsg = null;
        System.Threading.Tasks.Task t1;
        public List<string> list;
        public int Corcnt = 0;
        public int Inccnt = 0;
        public bool[] state;
        public bool Iscon = false;
        public int Mea_Res = 0;
        public bool Start = false;
        public bool Lock = false;
        public bool Conn_AO = false;

        public AutoForm(Analog analog)
        {
            InitializeComponent();

            anal = analog;
            binary = new Binary();
            digit = new Digit();
            hioki = new HIOKI3540();
            ini = new iniUtil(@"C:\Users\gy157\Documents\Info.ini");
            logfile = new logFile();

            list = new List<string>();
            state = new bool[8];
            Hioki3540.PortName = ini.GetIniValue("HIOKI", "PortName");
            //Hioki3540.Open();
        }

        private void BTN_FileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            file_path.Text = openFileDialog1.FileName;
            
            list = binary.Load(openFileDialog1.FileName);
            VolMin.Text = list[0];
            VolMax.Text = list[1];
            ResMin.Text = list[2];
            ResMax.Text = list[3];

            Corcnt = 0;
            Inccnt = 0;

            CorCnt.Text = Convert.ToString(Corcnt);
            IncCnt.Text = Convert.ToString(Inccnt);
            TotalCnt.Text = Convert.ToString(Corcnt + Inccnt);

            BTN_Measue.Enabled = true;
        }

        private void BTN_Set_Click(object sender, EventArgs e)
        {
            if (!Conn_AO)
            {
                anal.Connect_Output(ref ErrorMsg);
                Conn_AO = true;
            }
            anal.Output(Convert.ToDouble(voltagevalue.Value), ref ErrorMsg);
        }
        
        private void Hioki3540_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string str = Hioki3540.ReadLine();

            if (Resistance.InvokeRequired)
            {
                Resistance.BeginInvoke(new Action(() =>
               {
                   Resistance.Text = str;
               }));
            }
        }

        private void AnalogTImer_Tick(object sender, EventArgs e)
        {
            /*if (!Iscon)
            {
                digit.Connect_port1_write();
                Iscon = true;
            }*/
            //anal.Connect(ref ErrorMsg);
            digit.Connect_port1_write();
            AnalogInput.Text = Convert.ToString(anal.Read(ref ErrorMsg));
        }

        private void DigitalTImer_Tick(object sender, EventArgs e)
        {
            digit.Connect_port0_read(ref ErrorMsg);
            digit.Connect_port1_write();

            if (ErrorMsg != null)
            {
                DigitalTImer.Enabled = false;
            }
            digit.port1_Output(0, true, ref ErrorMsg);
            digit.port1_Output(1, true, ref ErrorMsg);
            digit.port1_Output(2, true, ref ErrorMsg);
            digit.port1_Output(3, false, ref ErrorMsg);

            state = digit.port0_Input(ref ErrorMsg);
            
            myledbulb1.On = state[0];
            myledbulb2.On = state[1];
            myledbulb3.On = state[2];
            myledbulb4.On = state[3];
            myledbulb5.On = state[4];
            myledbulb6.On = state[5];
            myledbulb7.On = state[6];
            myledbulb8.On = state[7];
        }

        public void Delay(int ms)
        {
            DateTime Starttime = DateTime.Now;

            while (true)
            {
                Application.DoEvents();
                if(DateTime.Now - Starttime >= TimeSpan.FromMilliseconds(ms))
                {
                    break;
                }
            }
        }

        public void Measure()
        {
            double val = Convert.ToDouble(AnalogInput.Text);
            double volMax = Convert.ToDouble(VolMax.Text);
            double volMin = Convert.ToDouble(VolMin.Text);
            double resMax = Convert.ToDouble(ResMax.Text);
            double resMin = Convert.ToDouble(ResMin.Text);

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    StateMsg.Text = "측정을 시작합니다.";
                    Delay(500);
                    StateMsg.Text = "전압을 측정합니다.";
                    Delay(500);

                    dataGridView1.Rows[0].Cells[1].Value = val;
                    if (val <= volMax && val >= volMin)
                    {
                        StateMsg.Text = "Correct";
                        dataGridView1.Rows[0].Cells[2].Value = "Correct";
                        Corcnt++;
                    }
                    else
                    {
                        StateMsg.Text = "Incorrect";
                        dataGridView1.Rows[0].Cells[2].Value = "Incorrect";
                        Inccnt++;
                    }

                    CorCnt.Text = Convert.ToString(Corcnt);
                    IncCnt.Text = Convert.ToString(Inccnt);
                    TotalCnt.Text = Convert.ToString(Corcnt + Inccnt);

                    Delay(500);
                    StateMsg.Text = "아무 스위치를 눌러주세요";
                    
                    while (true)
                    {
                        Application.DoEvents();
                        if (state[0] || state[1] || state[2] || state[3] || state[4] || state[5] || state[6] || state[7])
                        {
                            dataGridView1.Rows[1].Cells[1].Value = "Confirmed";
                            dataGridView1.Rows[1].Cells[2].Value = "Switch On";
                            break;
                        }
                    }

                    Delay(500);
                    StateMsg.Text = "한번 더 아무 스위치를 눌러주세요";
                    
                    while (true)
                    {
                        Application.DoEvents();
                        if (state[0] || state[1] || state[2] || state[3] || state[4] || state[5] || state[6] || state[7])
                        {
                            dataGridView1.Rows[2].Cells[1].Value = "Confirmed";
                            dataGridView1.Rows[2].Cells[2].Value = "Switch On";
                            break;
                        }
                    }

                    Delay(500);
                    StateMsg.Text = "저항을 측정 해주세요";
                    
                    int cur = Mea_Res;
                    while (true)
                    {
                        Application.DoEvents();
                        if (Mea_Res > cur)
                        {
                            if (Convert.ToDouble(Resistance.Text) <= resMax && Convert.ToDouble(Resistance.Text) >= resMin)
                            {
                                dataGridView1.Rows[3].Cells[1].Value = Convert.ToDouble(Resistance.Text);
                                dataGridView1.Rows[3].Cells[2].Value = "Correct";
                                Corcnt++;
                                break;
                            }
                            else
                            {
                                dataGridView1.Rows[3].Cells[1].Value = Convert.ToDouble(Resistance.Text);
                                dataGridView1.Rows[3].Cells[2].Value = "Incorrect";
                                Inccnt++;
                                break;
                            }
                        }
                    }

                    CorCnt.Text = Convert.ToString(Corcnt);
                    IncCnt.Text = Convert.ToString(Inccnt);
                    TotalCnt.Text = Convert.ToString(Corcnt + Inccnt);

                    Delay(500);
                    StateMsg.Text = "한번 더 저항을 측정 해주세요";
                    
                    cur = Mea_Res;
                    while (true)
                    {
                        Application.DoEvents();
                        if (Mea_Res > cur)
                        {
                            if (Convert.ToDouble(Resistance.Text) <= resMax && Convert.ToDouble(Resistance.Text) >= resMin)
                            {
                                dataGridView1.Rows[4].Cells[1].Value = Convert.ToDouble(Resistance.Text);
                                dataGridView1.Rows[4].Cells[2].Value = "Correct";
                                Corcnt++;
                                break;
                            }
                            else
                            {
                                dataGridView1.Rows[4].Cells[1].Value = Convert.ToDouble(Resistance.Text);
                                dataGridView1.Rows[4].Cells[2].Value = "Incorrect";
                                Inccnt++;
                                break;
                            }
                        }
                    }
                    Delay(500);
                    StateMsg.Text = "측정이 끝났습니다.";

                    CorCnt.Text = Convert.ToString(Corcnt);
                    IncCnt.Text = Convert.ToString(Inccnt);
                    TotalCnt.Text = Convert.ToString(Corcnt + Inccnt);
                }));
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                logfile.save(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
            }
        }
    
        private void BTN_Measue_Click(object sender, EventArgs e)
        {
            Start = true;
        }

        private void Resistance_TextChanged(object sender, EventArgs e)
        {
            Mea_Res++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Start)
            {
                Start = false;
                BTN_Measue.Enabled = false;

                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = 5;

                dataGridView1.Rows[0].Cells[0].Value = "전압";
                dataGridView1.Rows[1].Cells[0].Value = "Switch1";
                dataGridView1.Rows[2].Cells[0].Value = "Switch2";
                dataGridView1.Rows[3].Cells[0].Value = "저항1";
                dataGridView1.Rows[4].Cells[0].Value = "저항2";

                t1 = new System.Threading.Tasks.Task(new Action(Measure));
                t1.Start();
                t1.Wait();
                BTN_Measue.Enabled = true;
            }
        }

        private void BTN_AutoOn_Click(object sender, EventArgs e)
        {
            Hioki3540.Write(hioki.AutoOn());
        }

        private void BTN_AutoOff_Click(object sender, EventArgs e)
        {
            Hioki3540.Write(hioki.AutoOff());
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show(ex.Message);
        }

        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show(ex.Message);
        }

        private void Error_Tick(object sender, EventArgs e)
        {
            if (ErrorMsg != null)
            {
                Error.Enabled = false;
                MessageBox.Show(ErrorMsg);
                Application.Exit();
            }
            /*if (!Hioki3540.IsOpen)
            {
                Error.Enabled = false;
                MessageBox.Show("HIOKI 연결 상태를 확인해주세요.");
                Application.Exit();
            }*/
        }
    }
}
