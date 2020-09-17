using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMMONS;

namespace Analog_Digit
{
    public partial class SelfForm : Form
    {
        public HIOKI3540 Hioki;
        public Digit digit;
        public iniUtil ini;

        public bool[] state;
        public string readMsg;
        public bool Iszoomin;
        public bool Iscon;
        public bool Conn_AO = false;
        public string ErrorMsg = null;

        public Analog anal;
        public SelfForm(Analog analog)
        {
            InitializeComponent();

            anal = analog;
            Hioki = new HIOKI3540();
            digit = new Digit();
            ini = new iniUtil(@"C:\Users\gy157\Documents\Info.ini");

            HIOKI3540.PortName = ini.GetIniValue("HIOKI", "PortName");
            //HIOKI3540.Open();
            
            Iszoomin = false;
            Iscon = false;
            state = new bool[8];
        }

        private void AnalogTimer_Tick(object sender, EventArgs e)
        {
            if (!Iscon)
            {
                digit.Connect_port1_write();
                Iscon = true;
            }
            //anal.Connect(ref ErrorMsg);
            AnalogInput.Text = Convert.ToString(anal.Read(ref ErrorMsg));
            chart1.Series[0].Points.AddY(anal.Read(ref ErrorMsg));

            if (chart1.Series[0].Points.Count > 200)
                chart1.Series[0].Points.RemoveAt(0);
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            state = new bool[8];
            Button b = (Button)sender;
            digit.Segment(Convert.ToInt32(b.Tag),state);
            
            digit.port1_Output(2, true, ref ErrorMsg);
            digit.port1_Output(2, false, ref ErrorMsg);

            checkBox1.Checked = state[0];
            checkBox2.Checked = state[1];
            checkBox3.Checked = state[2];
            checkBox4.Checked = state[3];
            checkBox5.Checked = state[4];
            checkBox6.Checked = state[5];
            checkBox7.Checked = state[6];
            checkBox8.Checked = state[7];
        }

        private void DigitTimer_Tick(object sender, EventArgs e)
        {
            state = digit.port0_Input(ref ErrorMsg);

            if (!checkBox12.Checked)
            {
                Switch0.On = state[0];
                Switch1.On = state[1];
                Switch2.On = state[2];
                Switch3.On = state[3];
                Switch4.On = state[4];
                Switch5.On = state[5];
                Switch6.On = state[6];
                Switch7.On = state[7];
            }
        }

        private void BTN_HiokiCon_Click(object sender, EventArgs e)
        {
            BTN_HiokiCon.Enabled = false;
            BTN_HiokiDis.Enabled = true;
            BTN_SendMsg.Enabled = true;

            HIOKI3540.PortName = ini.GetIniValue("HIOKI", "PortName");
            HIOKI3540.Open();
        }

        private void BTN_HiokiDis_Click(object sender, EventArgs e)
        {
            BTN_HiokiCon.Enabled = true;
            BTN_HiokiDis.Enabled = false;
            BTN_SendMsg.Enabled = false;

            HIOKI3540.Close();
        }

        private void BTN_SendMsg_Click(object sender, EventArgs e)
        {
            HIOKI3540.Write(SendMsg.Text + "\r\n");
            SendMsg.Clear();
        }

        private void BTN_AutoOn_Click(object sender, EventArgs e)
        {
            BTN_AutoOn.Enabled = false;
            BTN_AutoOff.Enabled = true;

            HIOKI3540.Write(Hioki.AutoOn());
        }

        private void BTN_AutoOff_Click(object sender, EventArgs e)
        {
            BTN_AutoOn.Enabled = true;
            BTN_AutoOff.Enabled = false;

            HIOKI3540.Write(Hioki.AutoOff());
        }

        private void BTN_Range_Click(object sender, EventArgs e)
        {
            int RangeValue = Convert.ToInt32(UD_Range.Value);
            HIOKI3540.Write(Hioki.Range() + RangeValue + "\r\n");
        }

        private void HIOKI3540_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            readMsg = HIOKI3540.ReadLine();

            if (ReadMsg.InvokeRequired)
            {
                readMsg = readMsg.Trim();
                double value;

                bool isDouble = double.TryParse(readMsg, out value);
                if (isDouble)
                {
                    ReadMsg.BeginInvoke(new Action(() =>
                    {
                        MeasureMsg.AppendText(readMsg + "\r\n");
                    }));
                }
                ReadMsg.BeginInvoke(new Action(() =>
                {
                    ReadMsg.AppendText(readMsg + "\r\n");
                }));
            }

        }

        private void BTN_Measure_Click(object sender, EventArgs e)
        {
            HIOKI3540.Write(Hioki.Measure());
        }
        
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            //digit.Connect_port0_write();
            digit.Connect_port0_read(ref ErrorMsg);
            digit.Connect_port1_write();

            BTN_Start.Enabled = false;
            BTN_Stop.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            digit.Disconnect_port0();

            BTN_Start.Enabled = true;
            BTN_Stop.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void BTN_Switch_Click(object sender, EventArgs e)
        {
            digit.Disconnect_port0();
            digit.Connect_port0_read(ref ErrorMsg);

            digit.port1_Output(0, true, ref ErrorMsg);
            digit.port1_Output(1, true, ref ErrorMsg);
            digit.port1_Output(2, true, ref ErrorMsg);
            digit.port1_Output(3, false, ref ErrorMsg);
            
            checkBox9.Checked = true;
            checkBox10.Checked = true;
            checkBox11.Checked = true;
            checkBox12.Checked = false;
        }

        private void BTN_Segment_Click(object sender, EventArgs e)
        {
            digit.Disconnect_port0();
            digit.Connect_port0_write();

            digit.port1_Output(0, false, ref ErrorMsg);
            digit.port1_Output(1, false, ref ErrorMsg);
            digit.port1_Output(2, true, ref ErrorMsg);
            digit.port1_Output(3, true, ref ErrorMsg);

            digit.port0_Output(0, false, ref ErrorMsg);
            digit.port0_Output(1, false, ref ErrorMsg);
            digit.port0_Output(2, false, ref ErrorMsg);
            digit.port0_Output(3, false, ref ErrorMsg);
            digit.port0_Output(4, false, ref ErrorMsg);
            digit.port0_Output(5, false, ref ErrorMsg);
            digit.port0_Output(6, false, ref ErrorMsg);
            digit.port0_Output(7, false, ref ErrorMsg);

            digit.port1_Output(2, false, ref ErrorMsg);
            digit.port1_Output(2, true, ref ErrorMsg);

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = true;
            checkBox12.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((CheckBox)sender).Tag);

            digit.port0_Output(index, ((CheckBox)sender).Checked, ref ErrorMsg);
            digit.port1_Output(2, false, ref ErrorMsg);
            digit.port1_Output(2, true, ref ErrorMsg);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((CheckBox)sender).Tag);

            digit.port1_Output(index, ((CheckBox)sender).Checked, ref ErrorMsg);

            digit.Disconnect_port0();
            if(index == 3)
            {
                if (((CheckBox)sender).Checked)
                {
                    digit.Connect_port0_write();
                }
                else
                {
                    digit.Connect_port0_read(ref ErrorMsg);
                }
            }
        }

        private void BTN_Off_Click(object sender, EventArgs e)
        {
            digit.port0_Output(0, false, ref ErrorMsg);
            digit.port0_Output(1, false, ref ErrorMsg);
            digit.port0_Output(2, false, ref ErrorMsg);
            digit.port0_Output(3, false, ref ErrorMsg);
            digit.port0_Output(4, false, ref ErrorMsg);
            digit.port0_Output(5, false, ref ErrorMsg);
            digit.port0_Output(6, false, ref ErrorMsg);
            digit.port0_Output(7, false, ref ErrorMsg);

            digit.port1_Output(2, true, ref ErrorMsg);
            digit.port1_Output(2, false, ref ErrorMsg);
        }

        private void BTN_HiokiReset_Click(object sender, EventArgs e)
        {
            HIOKI3540.Write(Hioki.Reset());
        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            if (!Iszoomin)
            {
                Point CurrentPoint = new Point(e.X, e.Y);
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom((CurrentPoint.X * 0.5) - 10, (CurrentPoint.X * 0.5) + 10);
                //chart1.ChartAreas[0].AxisY.ScaleView.Zoom((CurrentPoint.Y) - 100, (CurrentPoint.Y) + 100);
                Iszoomin = true;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                //chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                Iszoomin = false;
            }

        }

        private void BTN_Update_Click_1(object sender, EventArgs e)
        {
            if (!Conn_AO)
            {
                anal.Connect_Output(ref ErrorMsg);
                Conn_AO = true;
            }
            anal.Output(Convert.ToDouble(voltagevalue.Value), ref ErrorMsg);
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
