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
using PAIX_NMF_DEV;

namespace Pressure_Sensor_EOL
{
    public partial class SelfForm : Form
    {
        private MasterInfo masterinfo;
        private LogFile logfile;
        private IniFiles inifile;
        private IDRead Idread;
        private DAQ DAQ1;
        private DAQ DAQ2;
        private DAQ DAQ3;
        private DAQ DAQ4;
        private DAQ DAQ5;
        private BarcodeRead barcoderead;
        private NMFDIO nmfdio;
        private MLCP mlcp;
        private Binary bin;

        public List<string> list;
        public List<string> Spec;
        public List<string> info;
        public List<bool> info2;

        public string[] strarr;
        public string ReadData;
        public string NIName;
        public string ID;
        public short[] IP;
        public short DevNum;
        public double data;
        public bool IsNICon;
        public bool IsNMFCon;
        public string[] strar;
        public char[] chararr;
        public byte[] bytes;
        public int[] NMFstate;
        public bool isRecv;

        public string Result;
        public int index;
        public SelfForm()
        {
            InitializeComponent();
            masterinfo = new MasterInfo(5);
            masterinfo.LoadInfo();
            //logfile = new LogFile();
            DAQ1 = new DAQ();
            DAQ2 = new DAQ();
            DAQ3 = new DAQ();
            DAQ4 = new DAQ();
            DAQ5 = new DAQ();
            barcoderead = new BarcodeRead();
            mlcp = new MLCP();
            bin = new Binary();

            nmfdio = new NMFDIO();

            inifile = new IniFiles(@"C:\Users\abc\Data\Option.ini");
            Spec = new List<string>();
            //Spec = logfile.LoadSpec(2, 92);
            IP = new short[3];
            NMFstate = new int[3];

            ReadData = "";
            ID = "";
            IsNICon = false;
            IsNMFCon = false;
            bytes = ConvertByteArray("0D");
            list = new List<string>();
            info = new List<string>();
            info2 = new List<bool>();
            //strar = new string[5];
            bin.Load(@"C:\Users\abc\Data\Spec\Spec1", ref info, ref info2);

            NIName = inifile.ReadString("NI", "DevName", "");
            if (NIName == "")
            {
                MessageBox.Show("Option 탭에서 NI DevName을 확인해주세요");
            }
            try
            {
                IP[0] = Convert.ToInt16(inifile.ReadString("NMF", "DevName1", ""));
                IP[1] = Convert.ToInt16(inifile.ReadString("NMF", "DevName2", ""));
                IP[2] = Convert.ToInt16(inifile.ReadString("NMF", "DevName3", ""));
                DevNum = Convert.ToInt16(inifile.ReadString("NMF", "DevName4", ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Option 탭에서 NMF DevName을 확인해주세요");
            }

            //SSC_.Open();
            try
            {
                BarcodeScanner1.PortName = inifile.ReadString("Barcode1", "PortName", "");
                BarcodeScanner2.PortName = inifile.ReadString("Barcode2", "PortName", "");
                MLCP.PortName = inifile.ReadString("Meter", "PortName", "");
                SSC_.PortName = inifile.ReadString("SSC", "PortName", "");
                //Idread = new IDRead(inifile.ReadString("SSC", "PortName", ""), 19200);

                BarcodeScanner1.Open();
                BarcodeScanner2.Open();
                MLCP.Open();
                SSC_.Open();
                //Idread.Connect();
            }
            catch
            {
                MessageBox.Show("장비 연결을 확인해주세요");
            }

            //IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);

            DAQ1.Analog_Connect(NIName, "ai0");
            DAQ2.Analog_Connect(NIName, "ai1");
            DAQ3.Analog_Connect(NIName, "ai2");
            DAQ4.Analog_Connect(NIName, "ai3");
            DAQ5.Analog_Connect(NIName, "ai4");
            DAQ1.Digital_Connect(NIName);
            DAQ2.Digital_Connect(NIName);
            DAQ3.Digital_Connect(NIName);
            DAQ4.Digital_Connect(NIName);
        }

        ~SelfForm()
        {
            short nRet = 0;

            if (NMFstate[0] % 2 == 1)
            {
                NMFstate[0]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
            }

            if (NMFstate[1] % 2 == 1)
            {
                NMFstate[1]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);
            }

            if (NMFstate[2] % 2 == 1)
            {
                NMFstate[2]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
            }
            BarcodeScanner1.Close();
            BarcodeScanner2.Close();
            MLCP.Close();
            SSC_.Close();
        }
        private void SelfForm_Load(object sender, EventArgs e)
        {
            NMFTimer.Enabled = true;
        }

        public byte[] ConvertByteArray(String strHex)
        {
            int iLength = strHex.Length;
            byte[] bytes1 = new byte[iLength / 2];

            for (int i = 0; i < iLength; i += 2)
            {
                bytes1[i / 2] = Convert.ToByte(strHex.Substring(i, 2), 16);
            }
            return bytes1;
        }

        private void BTN_BarcodeScan_Click(object sender, EventArgs e)
        {
            BarcodeScan1();
            Txt_Test.Text = ReadData;
        }

        private void BarcodeScan1()
        {
            ReadData = "";
            BarcodeScanner1.Write(barcoderead.Trigger(), 0, 2);
        }

        private void BarcodeScan2()
        {
            ReadData = "";
            BarcodeScanner2.Write(barcoderead.Trigger(), 0, 2);
            /*while (true)
            {
                Application.DoEvents();
                ReadData = BarcodeScanner2.ReadExisting();
                if (ReadData != "")
                {
                    break;
                }
            }
            ReadData = ReadData.Replace("", "");
            list.Add(ReadData);
            Txt_Test.Text = ReadData;*/
        }

        private void HeightMeas()
        {
            ReadData = "";
            MLCP.Write(mlcp.Start());
            MLCP.Write(bytes, 0, 1);
            while (true)
            {
                Application.DoEvents();
                if (ReadData != "")
                {
                    break;
                }
            }
        }

        private async void IDRead()
        {
            short nRet = 0;
            bool isIDOK;

            NMFstate[0]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);

            await Task.Delay(1000);
            /*Idread.ReadID();
            Txt_ICID.Text = Idread.GetID();*/
            TimeSpan spanTime = TimeSpan.FromMilliseconds(1000);

            isRecv = false;
            DateTime start = DateTime.Now;

            ID = "";

            SSC_.Write("OWT2800372f5a2\r\n");

            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            SSC_.Write("OR_28002\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            //recv = recv.Remove(0, 2);
            //ID = recv;
            ReadData = "";

            isRecv = false;
            start = DateTime.Now;
            SSC_.Write("OW_28003240079\r\n");

            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            SSC_.Write("OR_28003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            if (ReadData.Length > 3)
            {
                ReadData = ReadData.Remove(0, 3);
            }
            ID = ReadData;

            isRecv = false;
            isIDOK = false;
            start = DateTime.Now;

            SSC_.Write("OW_2800324007A\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            isRecv = false;
            start = DateTime.Now;
            SSC_.Write("OR_28003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            if (ReadData.Length > 3)
            {
                ReadData = ReadData.Remove(0, 3);
            }
            ID += ReadData;

            isRecv = false;
            isIDOK = false;
            start = DateTime.Now;

            SSC_.Write("OW_2800324007B\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            SSC_.Write("OR_28003\r\n");

            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            if (ReadData.Length > 3)
            {
                ReadData = ReadData.Remove(0, 3);
            }
            ID += ReadData;

            isRecv = false;
            isIDOK = false;
            start = DateTime.Now;

            SSC_.Write("OW_2800324007C\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }

            isRecv = false;
            start = DateTime.Now;
            SSC_.Write("OR_28003\r\n");
            while (true)
            {
                if (DateTime.Now - start > spanTime)
                {
                    break;
                }
                if (isRecv)
                    break;
            }
            if (ReadData.Length > 3)
            {
                ReadData = ReadData.Remove(0, 3);
            }
            ID += ReadData;
            ID = ID.Replace(@"", "");

            Txt_Test.Text = ID;

            NMFstate[0]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
        }

        /*private void IDRead()
        {
            short nRet = 0;

            NMFstate[0]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
            
            Delay(1000);
            //Idread.ReadErrorCode();
            Idread.ReadID();
            Txt_Test.Text = Idread.GetID();
            //Txt_Test.Text = Idread.GetID();

            NMFstate[0]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
        }*/

        private async void VoutMeas()
        {
            short nRet = 0;
            double sum = 0;
            NMFstate[2]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
            await Task.Delay(500);
            for (int i = 0; i < 100; i++)
            {
                sum += DAQ5.Analog_Read();
            }
            Txt_Test.Text = (sum / 100).ToString();
            Txt_Test.Text = DAQ5.Analog_Read().ToString();
            await Task.Delay(500);
            NMFstate[2]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
        }

        private void GroundMeas()
        {
            // 접지 검사
            short nRet = 0;
            NMFstate[1]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);

            Delay(500);

            string judge = "OK";
            double[] doub = new double[4];
            NITimer.Enabled = false;

            for (int i = 0; i < 4; i++)
            {
                DAQ1.Digital_Write(i, true);
                DAQ2.Digital_Write(i, true);
                DAQ3.Digital_Write(i, true);
                DAQ4.Digital_Write(i, true);
                doub[0] = DAQ1.Analog_Read();
                doub[1] = DAQ2.Analog_Read();
                doub[2] = DAQ3.Analog_Read();
                doub[3] = DAQ4.Analog_Read();
                //Txt_Test.Text = Convert.ToString(DAQ1.Analog_Read());
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        if (doub[j] < Convert.ToDouble(info[7]))
                        {
                            judge = "NG";
                        }
                    }
                    else
                    {
                        if (doub[j] > 0.2)
                        {
                            judge = "NG";
                        }
                    }
                }
                DAQ1.Digital_Write(i, false);
                DAQ2.Digital_Write(i, false);
                DAQ3.Digital_Write(i, false);
                DAQ4.Digital_Write(i, false);
            }
            Txt_Test.Text = judge;
            if (ChannelComboBox.Text != "")
            {
                NITimer.Enabled = true;
            }
            Delay(500);

            NMFstate[1]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);
        }

        private void BTN_Height_Click(object sender, EventArgs e)
        {
            HeightMeas();
        }

        private async void BTN_IDScan_Click(object sender, EventArgs e)
        {
            Txt_Test.Text = ID;
            ID = "";
            //await Task.Delay(300);

            IDRead();
            //Idread.GetSet();
        }

        private void BTN_Vout_Click(object sender, EventArgs e)
        {
            VoutMeas();
        }

        private void BTN_Ground_Click(object sender, EventArgs e)
        {
            GroundMeas();
        }

        private void BarcodeScanner1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                while (true)
                {
                    Application.DoEvents();
                    ReadData += BarcodeScanner1.ReadExisting();
                    if (ReadData.IndexOf('\r') >= 0)
                    {
                        break;
                    }
                }
                ReadData = ReadData.Replace("", "");
                ReadData = ReadData.Trim();

                if (Txt_Test.InvokeRequired)
                {
                    Txt_Test.BeginInvoke(new Action(() =>
                    {
                        Txt_Test.Text = ReadData + "\n";
                    }));
                }
                else
                {
                    Txt_Test.Text = ReadData;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void SelfForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*short nRet = 0;

            if (NMFstate[0] % 2 == 1)
            {
                NMFstate[0]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
            }

            if (NMFstate[1] % 2 == 1)
            {
                NMFstate[1]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);
            }

            if (NMFstate[2] % 2 == 1)
            {
                NMFstate[2]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
            }

            BarcodeScanner1.Close();
            BarcodeScanner2.Close();
            MLCP.Close();
            SSC_.Close();*/
            //Idread.Disconnect();
        }

        private void BTN_Cyl1_Click(object sender, EventArgs e)
        {
            //NMF 제품 고정 실린더 전진
            if (myledbulb4.On)
            {
                if (!myledbulb8.On)
                {
                    MessageBox.Show("배출 실린더를 확인해주세요.");
                }
                else
                {
                    if (!IsNMFCon)
                    {
                        IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                    }

                    short nRet = 0;

                    Button B = (Button)sender;
                    int index = Convert.ToInt32(B.Tag);

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
                }
            }
        }

        private void BTN_BarcodeScan2_Click(object sender, EventArgs e)
        {
            BarcodeScan2();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ChannelComboBox.Text == "ai0:3")
            {
                AnalogInput1.Text = Convert.ToString(DAQ1.Analog_Read());
                chart1.Series[0].Points.AddY(DAQ1.Analog_Read());
                if (chart1.Series[0].Points.Count > 100)
                    chart1.Series[0].Points.RemoveAt(0);

                AnalogInput2.Text = Convert.ToString(DAQ2.Analog_Read());
                chart1.Series[1].Points.AddY(DAQ2.Analog_Read());
                if (chart1.Series[1].Points.Count > 100)
                    chart1.Series[1].Points.RemoveAt(0);

                AnalogInput3.Text = Convert.ToString(DAQ3.Analog_Read());
                chart1.Series[2].Points.AddY(DAQ3.Analog_Read());
                if (chart1.Series[2].Points.Count > 100)
                    chart1.Series[2].Points.RemoveAt(0);

                AnalogInput4.Text = Convert.ToString(DAQ4.Analog_Read());
                chart1.Series[3].Points.AddY(DAQ4.Analog_Read());
                if (chart1.Series[3].Points.Count > 100)
                    chart1.Series[3].Points.RemoveAt(0);
            }
            else
            {
                chart1.Series.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(((CheckBox)sender).Tag);

            DAQ1.Digital_Write(index, ((CheckBox)sender).Checked);
            DAQ2.Digital_Write(index, ((CheckBox)sender).Checked);
            DAQ3.Digital_Write(index, ((CheckBox)sender).Checked);
            DAQ4.Digital_Write(index, ((CheckBox)sender).Checked);
        }

        private void NMFTimer_Tick(object sender, EventArgs e)
        {
            if (!IsNMFCon)
            {
                IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
            }
            short nRet;
            short[] nPinStatus = new short[128];
            bool[] state = new bool[15];

            try
            {
                nRet = NMF.nmf_GetBrdAllStatus(DevNum, out nmfdio.tAllStatus);

                nRet = NMF.nmf_DIGet(DevNum, nPinStatus);
                if (nRet != 0) return;
                for (int i = 0; i < 15; i++)
                {
                    //CheckBox chkBox = (Controls.Find("checkBox_In" + i.ToString(), true)[0] as CheckBox);
                    if (i < nmfdio.tAllStatus.nCntDIBrd * NMF.BRD_VS_DIO_PINS)
                    {
                        /*chkBox.Enabled = true;
                        chkBox.ImageIndex = nPinStatus[i];
                        if (chkBox.ImageIndex == 0)
                            chkBox.CheckState = CheckState.Unchecked;
                        else
                            chkBox.CheckState = CheckState.Checked;*/
                        if (nPinStatus[i] == 1)
                            state[i] = true;
                        else
                            state[i] = false;
                    }
                    else
                    {
                        state[i] = false;
                    }
                }
                myledbulb1.On = state[0];
                myledbulb2.On = state[1];
                myledbulb3.On = state[2];
                myledbulb4.On = state[4];
                myledbulb5.On = state[5];
                myledbulb6.On = state[6];
                myledbulb7.On = state[7];
                myledbulb8.On = state[8];
                myledbulb9.On = state[9];
                myledbulb10.On = state[10];
                myledbulb11.On = state[11];
                myledbulb12.On = state[12];
                //myledbulb13.On = state[13];
                myledbulb14.On = state[14];
            }
            catch
            {
                NMFTimer.Enabled = false;
                MessageBox.Show("NMF연결 상태를 확인해주세요");
            }
        }

        private void BTN_DO1_Click(object sender, EventArgs e)
        {
            if (!IsNMFCon)
            {
                IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
            }

            short nRet = 0;

            Button B = (Button)sender;
            int index = Convert.ToInt32(B.Tag);

            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
        }

        private void ChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NITimer.Enabled = true;

            chart1.Series.Clear();
            chart1.Series.Add("AI0");
            chart1.Series.Add("AI1");
            chart1.Series.Add("AI2");
            chart1.Series.Add("AI3");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            AnalogInput1.Text = "";
            AnalogInput2.Text = "";
            AnalogInput3.Text = "";
            AnalogInput4.Text = "";
        }

        private void BTN_Cyl2_Click(object sender, EventArgs e)
        {
            if (!myledbulb4.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl3_Click(object sender, EventArgs e)
        {
            if (myledbulb6.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl4_Click(object sender, EventArgs e)
        {
            if (!myledbulb6.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl5_Click(object sender, EventArgs e)
        {
            if (!myledbulb9.On)
            {
                if (!myledbulb4.On)
                {
                    MessageBox.Show("상하 실린더를 확인해주세요");
                }
                else if (!myledbulb6.On)
                {
                    MessageBox.Show("지그 실린더를 확인해주세요");
                }
                else
                {
                    if (!IsNMFCon)
                    {
                        IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                    }

                    short nRet = 0;

                    Button B = (Button)sender;
                    int index = Convert.ToInt32(B.Tag);

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
                }
            }
        }

        private void BTN_Cyl6_Click(object sender, EventArgs e)
        {
            if (myledbulb9.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl7_Click(object sender, EventArgs e)
        {
            if (myledbulb10.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl8_Click(object sender, EventArgs e)
        {
            if (!myledbulb10.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl9_Click(object sender, EventArgs e)
        {
            if (myledbulb12.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void BTN_Cyl10_Click(object sender, EventArgs e)
        {
            if (!myledbulb12.On)
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }

                short nRet = 0;

                Button B = (Button)sender;
                int index = Convert.ToInt32(B.Tag);

                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)index);
            }
        }

        private void MLCP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            double HeightVal = Convert.ToDouble(info[2]);
            double Height2;

            ReadData = MLCP.ReadLine();

            strar = ReadData.Split(',');
            chararr = strar[2].ToCharArray();
            double value;
            string str2;

            str2 = chararr[0].ToString() + chararr[1].ToString() + chararr[2].ToString() +
                    chararr[3].ToString() + chararr[4].ToString();
            bool isDouble = double.TryParse(str2, out value);

            if (isDouble)
            {
                str2 = chararr[0].ToString() + chararr[1].ToString() + "." + chararr[2].ToString() +
                    chararr[3].ToString() + chararr[4].ToString();
                str2 = str2.Trim();
                Height2 = Convert.ToDouble(str2) + HeightVal;
            }
            else
            {
                str2 = chararr[0].ToString() + "." + chararr[1].ToString() + chararr[2].ToString() +
                    chararr[3].ToString();
                str2 = str2.Trim();
                Height2 = Convert.ToDouble(str2) + HeightVal;
            }

            if (Txt_Test.InvokeRequired)
            {
                Txt_Test.BeginInvoke(new Action(() =>
                {
                    Txt_Test.Text = Height2.ToString();
                }));
            }
            else
            {
                Txt_Test.Text = Height2.ToString();
            }
        }

        private void SSC__DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ReadData = SSC_.ReadLine();
            isRecv = true;
        }

        private void BarcodeScanner2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                while (true)
                {
                    Application.DoEvents();
                    ReadData += BarcodeScanner2.ReadExisting();
                    //ReadData.Trim();
                    if (ReadData.IndexOf('\r') >= 0)
                    {
                        break;
                    }
                }
                ReadData = ReadData.Replace("", "");
                ReadData = ReadData.Trim();

                if (Txt_Test.InvokeRequired)
                {
                    Txt_Test.BeginInvoke(new Action(() =>
                    {
                        Txt_Test.Text = ReadData + "\n";
                    }));
                }
                else
                {
                    Txt_Test.Text = ReadData;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Idread.Set();
            Txt_Test.Text = Idread.GetSet();*/
            /*SSC_.Write(ssc.Set());
            SSC_.Write("TSO31150\r\n");
            SSC_.Write("OS_14\r\n");
            SSC_.Write("T11030\r\n");*/
        }

        private void Delay(int ms)
        {
            DateTime starttime = DateTime.Now;

            while (true)
            {
                Application.DoEvents();
                if (DateTime.Now - starttime >= TimeSpan.FromMilliseconds(ms))
                {
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsNMFCon)
            {
                IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
            }
            short nRet = 0;

            if (NMFstate[0] % 2 == 1)
            {
                NMFstate[0]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
            }

            if (NMFstate[1] % 2 == 1)
            {
                NMFstate[1]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);
            }

            if (NMFstate[2] % 2 == 1)
            {
                NMFstate[2]++;
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
            }

            if (!myledbulb4.On)
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)3);
                Delay(1000);
            }

            if (!myledbulb6.On)
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)4);
                Delay(1000);
            }

            if (!myledbulb8.On)
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)5);
                Delay(2500);
            }

            if (!myledbulb10.On)
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)6);
                Delay(1000);
            }

            if (!myledbulb12.On)
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)7);
                Delay(1500);
            }
        }
        
    }
}
