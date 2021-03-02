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
using System.Threading;
using System.IO;

namespace Pressure_Sensor_EOL
{
    public partial class TestForm : Form
    {
        private MainForm mainform;
        private BarcodeRead barcoderead;
        private MasterInfo masterinfo;
        private Binary bin;
        private IDRead Idread;
        private LogFile logfile;
        private MLCP mlcp;
        private CSV csv;
        private IniFiles inifile;
        private IniFiles inifile2;
        private NMFDIO nmfdio;
        private DAQ DAQ1;
        private DAQ DAQ2;
        private DAQ DAQ3;
        private DAQ DAQ4;
        private DAQ DAQ5;

        public List<string> list;
        public List<string> Spec;
        public List<string> info;
        public List<bool> info2;
        public List<string> list2;
        public bool Ismastersample;
        public bool Isswitchon;
        public bool[] masterResult;
        public bool[] ActionCon;
        bool[] state;
        public string[] strarr;
        public int OK;
        public int NG;
        public int Error;
        public byte[] bytes;
        public string judge;
        public bool IsReturn;
        public int[] NMFstate;

        public string ReadData;
        public string NIName;
        public short[] IP;
        public short DevNum;
        public bool IsNICon;
        public bool IsNMFCon;
        public string Result;
        public bool IsOK;
        public bool Voutfaulty;
        public bool Groundingfaulty;
        public bool HeightMaxfaulty;
        public bool HeightMinfaulty;
        public int Count;
        public int index;
        public bool IsError;
        public double Height;
        public double VoutMax;
        public double VoutMin;
        public double VoutVal;
        public double offset;
        public double VoutP;
        public double VoutM;
        public double HeightVal;
        public double Height2;
        public double Vout;
        public bool isRecv;
        public string ID;
        public double data;

        public bool taskProcessLock;

        public TestForm(MainForm mainform_)
        {
            InitializeComponent();
            bin = new Binary();
            nmfdio = new NMFDIO();
            csv = new CSV();

            NMFstate = new int[3];
            NMFstate[0] = 0;
            NMFstate[1] = 0;
            NMFstate[2] = 0;

            DAQ1 = new DAQ();
            DAQ2 = new DAQ();
            DAQ3 = new DAQ();
            DAQ4 = new DAQ();
            DAQ5 = new DAQ();
            inifile = new IniFiles(@"C:\Users\abc\Data\Option.ini");
            inifile2 = new IniFiles(@"C:\Users\abc\Data\Excelpath.ini");
            list = new List<string>();
            Spec = new List<string>();
            list2 = new List<string>();
            barcoderead = new BarcodeRead();
            mlcp = new MLCP();
            mainform = mainform_;

            masterinfo = new MasterInfo(inifile.ReadInteger("Master Count", "Count", 0));
            //masterinfo = new MasterInfo(5);
            masterinfo.LoadInfo();
            
            IP = new short[3];
            Ismastersample = false;
            Isswitchon = false;
            info = new List<string>();
            info2 = new List<bool>();
            state = new bool[15];
            bytes = ConvertByteArray("0D");

            IsReturn = true;
            Voutfaulty = false;
            IsOK = true;
            Groundingfaulty = false;
            HeightMaxfaulty = false;
            HeightMinfaulty = false;
            Count = 0;
            OK = 0;
            NG = 0;
            Error = 0;
            IsNMFCon = false;
            IsError = false;
            VoutMax = 0;
            VoutMin = 0;
            WarningPannel.SendToBack();
            

            NIName = inifile.ReadString("NI", "DevName", "");
            if (NIName == "")
            {
                MessageBox.Show("Option 탭에서 NI DevName을 확인해주세요");
            }
            
                IP[0] = Convert.ToInt16(inifile.ReadString("NMF", "DevName1", ""));
                IP[1] = Convert.ToInt16(inifile.ReadString("NMF", "DevName2", ""));
                IP[2] = Convert.ToInt16(inifile.ReadString("NMF", "DevName3", ""));
                DevNum = Convert.ToInt16(inifile.ReadString("NMF", "DevName4", ""));
            

            //SSC_.Open();
            BarcodeScanner1.PortName = inifile.ReadString("Barcode1", "PortName", "");
            BarcodeScanner2.PortName = inifile.ReadString("Barcode2", "PortName", "");
            MLCP_.PortName = inifile.ReadString("Meter", "PortName", "");
            SSC.PortName = inifile.ReadString("SSC", "PortName", "");
            //Idread = new IDRead(inifile.ReadString("SSC", "PortName", ""), 19200);
            
                BarcodeScanner1.Open();
                BarcodeScanner2.Open();
                MLCP_.Open();
                SSC.Open();
            
            //Idread.Connect();
            /*if (mainform.count <= 1)
                {
                    ReadData = "";
                    MLCP_.Write(mlcp.Start());                                    //높이 측정
                    MLCP_.Write(bytes, 0, 1);
                }*/
            
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

            if (!File.Exists(inifile2.ReadString("path", "path", "")))
            {
                MessageBox.Show("데이터를 취합할 엑셀 파일을 확인해주세요.");
                logfile = new LogFile(@"C:\Users\abc\Data\2020-09-22 Result - EOL");
            }
            else
            {
                logfile = new LogFile(inifile2.ReadString("path", "path", ""));
            }

            if (mainform.count > 1 && mainform.IsSpec)
            {
                bin.Load(inifile2.ReadString("Spec", "path1", ""), ref info, ref info2);
                
                Txt_HeightMin.Text = info[0];
                Txt_HeightMax.Text = info[1];

                Txt_ACCP.Text = info[4];
                Txt_ACCM.Text = info[5];

                Txt_path.Text = inifile2.ReadString("Spec", "path1", "");
                Txt_Excelpath.Text = inifile2.ReadString("path", "path", "");

                HeightVal = Convert.ToDouble(info[2]);
                VoutVal = Convert.ToDouble(info[3]);
                VoutP = Convert.ToDouble(info[4]);
                VoutM = Convert.ToDouble(info[5]);
                offset = Convert.ToDouble(info[6]);

                VoutMax = VoutVal + (VoutP/25);
                VoutMin = VoutVal - (VoutM/25);

                Txt_VoutMax.Text = VoutMax.ToString();
                Txt_VoutMin.Text = VoutMin.ToString();

                ID_Con.Checked = info2[0];
                Barcode1_Con.Checked = info2[1];
                Barcode2_Con.Checked = info2[2];
                Height_Con.Checked = info2[3];
                Vout_Con.Checked = info2[4];
                Ground_Con.Checked = info2[5];

                List<string> list2 = new List<string>();
                list2.Add(info[1]);
                list2.Add(info[0]);
                logfile.SaveSpec(list2, 2, 92);
                list2.Clear();
                list2.Add(VoutMax.ToString());
                list2.Add(VoutMin.ToString());
                logfile.SaveSpec(list2, 2, 94);
                StateMsg.Text = "제품을 올리고 양수 버튼을 눌러주세요";
                groupBox6.BackColor = Color.PaleGreen;
            }
            
            taskProcessLock = false;
        }

        ~TestForm()
        {
            BarcodeScanner1.Close();
            BarcodeScanner2.Close();
            MLCP_.Close();
            SSC.Close();
        }
        private void Process()
        {
            if (masterinfo.masterCount == 0)
            {
                MessageBox.Show("마스터 샘플을 확인해 주세요.", "Error", MessageBoxButtons.OK);
            }
            short nRet = 0;
            if (!taskProcessLock)
            {
                taskProcessLock = true;
                groupBox6.BackColor = Color.Orange;
                Txt_Barcode1.BackColor = Color.White;
                Txt_Barcode2.BackColor = Color.White;
                Txt_Case.BackColor = Color.White;
                Txt_Height.BackColor = Color.White;
                Txt_ACC.BackColor = Color.White;
                Txt_ICID.BackColor = Color.White;
                Txt_Vout.BackColor = Color.White;
                Txt_Judge.BackColor = Color.White;

                Txt_Barcode1.Clear();
                Txt_Barcode2.Clear();
                Txt_Case.Clear();
                Txt_Height.Clear();
                Txt_ACC.Clear();
                Txt_ICID.Clear();
                Txt_Vout.Clear();
                Txt_Judge.Clear();

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

                if (mainform.IsMaster)
                {
                    StateMsg.Text = "마스터 모드를 실행합니다.";
                    label_Mode.Text = "마스터 모드";

                    HeightMaxfaulty = false;
                    HeightMinfaulty = false;
                    Voutfaulty = false;
                    Groundingfaulty = false;

                    Delay(1000);

                    if (!timer1.Enabled)
                    {
                    StateMsg.Text = "정지합니다";
                    Stop();
                        return;
                    }

                    if (!IsNMFCon)
                    {
                        IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                    }
                    StateMsg.Text = "상하실린더를 전진합니다.";

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)3);                //상하 실린더 전진

                    DelayTime(5,4);

                    if (!timer1.Enabled)
                    {
                    StateMsg.Text = "정지합니다";
                    Stop();
                        return;
                    }
                    
                    StateMsg.Text = "지그실린더를 전진합니다.";

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)4);                //지그 실린더 전진

                    DelayTime(7,6);

                    if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }

                    StateMsg.Text = "ID를 스캔합니다.";

                    Delay(1000);
                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }
                    //Idread.Connect();
                    IDRead();                                          //IDRead

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    Delay(1500);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (Txt_ICID.Text == "1111")
                    {
                        nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
                        Delay(500);
                        IDRead();
                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }
                    }

                    Delay(1500);
                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (!masterinfo.masterIC.Contains(Txt_ICID.Text))
                    {
                        WarningPannel.Visible = true;
                        WarningPannel.BringToFront();
                        Label.Text = "[비상정지] 마스터 샘플 아이디를 확인해 주세요";
                        timer1.Enabled = false;
                        Stop();
                        return;
                    }
                    index = masterinfo.masterIC.IndexOf(Txt_ICID.Text);
                    list.Add(Txt_ICID.Text);

                    Delay(500);

                    if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }

                    StateMsg.Text = "아래 바코드를 스캔합니다.";

                    BarcodeScan1();                                              //바코드 스캔

                    Delay(2000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (Txt_Barcode1.Text == "")
                    {
                        Txt_Barcode1.BackColor = Color.Orange;
                    }
                    else
                        Txt_Barcode1.BackColor = Color.PaleGreen;

                    list.Add(Txt_Barcode1.Text);
                    Delay(1000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    StateMsg.Text = "윗 바코드를 스캔합니다.";

                    BarcodeScan2();                                              //바코드 스캔

                    Delay(2000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }
                    if (Txt_Barcode2.Text == "")
                    {
                        Txt_Barcode2.BackColor = Color.Orange;
                    }
                    else 
                        Txt_Barcode2.BackColor = Color.PaleGreen;

                    list.Add(Txt_Barcode2.Text);
                    Delay(1000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    StateMsg.Text = "높이를 측정합니다.";

                    ReadData = "";
                    MLCP_.Write(mlcp.Start());                                    //높이 측정
                    MLCP_.Write(bytes, 0, 1);

                    /*while (!Double.TryParse(Txt_Height.Text, out Height))
                    {
                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }

                        ReadData = "";
                        MLCP_.Write(mlcp.Start());
                        MLCP_.Write(bytes, 0, 1);
                    }*/
                    
                    Delay(1500);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (Convert.ToDouble(Txt_Height.Text) > Convert.ToDouble(Txt_HeightMax.Text) ||
                        Convert.ToDouble(Txt_Height.Text) < Convert.ToDouble(Txt_HeightMin.Text))
                    {
                        IsOK = false;
                        Txt_Height.BackColor = Color.Orange;
                    }
                    else
                        Txt_Height.BackColor = Color.PaleGreen;
                    

                    list.Add(Txt_Height.Text);

                    StateMsg.Text = "출력 전압을 측정합니다.";

                    VoutMeas();                                                   // 출력 검사
                    
                    Delay(1000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    Txt_Vout.Text = (Vout + offset).ToString();
                    data = Math.Truncate(((Vout + offset - VoutVal) * 25) * 1000) / 1000;
                    Txt_ACC.Text = data.ToString();
                    if ((Convert.ToDouble(Txt_Vout.Text) - VoutVal) * 25 > 1.5 ||
                        (Convert.ToDouble(Txt_Vout.Text) - VoutVal) * 25 < -1.5)
                    {
                        IsOK = false;
                        Txt_Vout.BackColor = Color.Orange;
                        Txt_ACC.BackColor = Color.Orange;
                    }
                    else
                    {
                        Txt_Vout.BackColor = Color.PaleGreen;
                        Txt_ACC.BackColor = Color.PaleGreen;
                    }
                        
                    list.Add(Txt_Vout.Text);

                    Delay(1000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    StateMsg.Text = "접지를 검사합니다.";

                    GroundMeas();                                                 // 접지 검사

                    Delay(500);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }
                    
                    if (Txt_Case.Text == "NG")
                    {
                        IsOK = false;
                        Txt_Case.BackColor = Color.Orange;
                    }
                    else
                        Txt_Case.BackColor = Color.PaleGreen;

                    list.Add(Txt_Case.Text);
                    Delay(1000);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }
                    

                    StateMsg.Text = "지그실린더를 복귀합니다.";

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)4);                 //지그실린더 복귀

                    DelayTime(6,7);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }
                    
                    StateMsg.Text = "상하실린더를 복귀합니다.";

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)3);                 //상하실린더 복귀
                    
                    DelayTime(4,5);

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (!IsOK)
                    {
                        Txt_Judge.BackColor = Color.Orange;
                        MasterCheck(index);                                              //불량체크
                        //MasterResult();

                        StateMsg.Text = "불량 제품을 배출합니다.";
                        Abondon();                                                  //배출

                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }
                        
                    }
                    else
                    {
                        Txt_Judge.Text = "양품";
                        if (!masterinfo.masterUse[index * 4] && !masterinfo.masterUse[index * 4 + 1] &&
                        !masterinfo.masterUse[index * 4 + 2] && !masterinfo.masterUse[index * 4 + 3])
                        {
                            Count++;
                            MastRes1.Visible = true;
                        }
                        Txt_Judge.BackColor = Color.PaleGreen;
                        //MasterResult();
                    }

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    StateMsg.Text = "최종 판정 결과는 " + Txt_Judge.Text + "입니다.";
                    list.Add(Txt_Judge.Text);
                    csv.masterSave(list);
                    Delay(500);

                    //Count++;
                    
                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }
                    
                    if (Count == masterinfo.masterCount)
                    {
                        label_Mode.Text = "양산 모드";
                        mainform.IsMaster = false;
                        Count = 0;
                    }
                }
                else
                {
                StateMsg.Text = "양산 모드를 실행합니다.";
                label_Mode.Text = "양산 모드";
                Delay(500);

                if (!timer1.Enabled)
                {
                    StateMsg.Text = "정지합니다";
                    Stop();
                    return;
                }

                StateMsg.Text = "상하실린더를 전진합니다.";
                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)3);                //상하 실린더 전진
                
                    DelayTime(5, 4);

                if (!timer1.Enabled)
                {
                    StateMsg.Text = "정지합니다";
                    Stop();
                    return;
                }

                StateMsg.Text = "지그실린더를 전진합니다.";

                    nRet = NMF.nmf_DOSetTogPin(DevNum, (short)4);                //지그 실린더 전진

                if (!timer1.Enabled)
                {
                    StateMsg.Text = "정지합니다";
                    Stop();
                    return;
                }

                DelayTime(7, 6);

                if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (info2[0])
                        {
                        StateMsg.Text = "ID를 스캔합니다.";
                        //NMFstate[0]++;
                        //nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
                        Delay(500);
                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }
                        //Idread.Connect();
                        IDRead();                                          //IDRead

                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }

                        Delay(1000);

                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }

                        if (Txt_ICID.Text == "1111")
                        {
                            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
                            Delay(500);
                            IDRead();
                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }
                        }

                        Delay(1500);
                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }
                        //NMFstate[0]++;
                        //nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);

                        list2 = logfile.LoadID(8, 3);
                    if (!list2.Contains(Txt_ICID.Text))
                        {
                            StateMsg.Text = "등록된 제품이 아닙니다.";
                        //불량처리
                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }
                            Return();
                            NG++;
                            IsOK = false;
                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }
                        Delay(500);
                            StateMsg.Text = "제품을 배출합니다.";
                            Abondon();
                        }
                        else
                        {
                            index = list2.IndexOf(Txt_ICID.Text);
                        }

                        Delay(500);

                        if (!timer1.Enabled)
                        {
                            StateMsg.Text = "정지합니다";
                            Stop();
                            return;
                        }
                    }
                    list.Add(Txt_ICID.Text);
                    if (IsOK)
                        {
                        if (logfile.Load("Prev", index) == "NG")
                        {
                            StateMsg.Text = "전 공정에서 불량으로 판정난 제품입니다.";
                            NG++;
                            logfile.SaveData("NG", index + 8, 9);
                            logfile.SaveData("NG", index + 8, 93);
                            Txt_ICID.BackColor = Color.Orange;
                            IsOK = false;

                            Delay(500);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                            StateMsg.Text = "제품을 배출합니다.";
                            Return();
                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }
                            Delay(500);
                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }
                            Abondon();
                        }
                        else if (logfile.Load("Prev", index) == "OK")
                        {
                            if (info2[1])
                            {
                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                StateMsg.Text = "아래 바코드를 스캔합니다.";
                                BarcodeScan1();

                                Delay(2000);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                if (Txt_Barcode1.Text == "")
                                    Txt_Barcode1.BackColor = Color.Orange;
                                else
                                    Txt_Barcode1.BackColor = Color.PaleGreen;

                                Delay(500);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                            logfile.SaveData(Txt_Barcode1.Text, index + 8, 89);
                            }
                            list.Add(Txt_Barcode1.Text);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                            if (info2[2])
                            {
                                StateMsg.Text = "윗 바코드를 스캔합니다.";
                                BarcodeScan2();

                                Delay(2000);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                if (Txt_Barcode2.Text == "")
                                    Txt_Barcode2.BackColor = Color.Orange;
                                else
                                    Txt_Barcode2.BackColor = Color.PaleGreen;

                                Delay(500);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                logfile.SaveData(Txt_Barcode2.Text, index + 8, 2);
                             }
                            list.Add(Txt_Barcode2.Text);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                        if (info2[3])
                            {
                                StateMsg.Text = "높이를 측정합니다.";
                                ReadData = "";
                                MLCP_.Write(mlcp.Start());
                                MLCP_.Write(bytes, 0, 1);

                                Delay(1500);

                                while(!Double.TryParse(Txt_Height.Text,out Height))
                                {
                                    if (!timer1.Enabled)
                                    {
                                        StateMsg.Text = "정지합니다";
                                        Stop();
                                        return;
                                    }
                                    ReadData = "";
                                    MLCP_.Write(mlcp.Start());
                                    MLCP_.Write(bytes, 0, 1);
                                }
                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }
                                
                                logfile.SaveData(Txt_Height.Text, index + 8, 92);

                                Delay(500);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                if (Convert.ToDouble(Txt_Height.Text) > Convert.ToDouble(Txt_HeightMax.Text) ||
                                        Convert.ToDouble(Txt_Height.Text) < Convert.ToDouble(Txt_HeightMin.Text))
                                    {
                                        IsOK = false;
                                        Txt_Height.BackColor = Color.Orange;
                                    }
                                else
                                    Txt_Height.BackColor = Color.PaleGreen;
                                //await Task.Delay(1000);
                            }
                            list.Add(Txt_Height.Text);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                            if (info2[4])
                            {
                                StateMsg.Text = "출력 전압을 측정합니다.";
                                VoutMeas();                                            // 출력 검사
                                
                                Delay(1000);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                            logfile.SaveData(Txt_Vout.Text, index + 8, 90);

                                Txt_Vout.Text = (Vout + offset).ToString();
                                data = Math.Truncate(((Vout + offset - VoutVal) * 25)*1000) / 1000;
                                Txt_ACC.Text = data.ToString();
                                if ((Convert.ToDouble(Txt_Vout.Text) - VoutVal) * 25 > 1.5 ||
                                    (Convert.ToDouble(Txt_Vout.Text) - VoutVal) * 25 < -1.5)
                                {
                                    IsOK = false;
                                    Txt_Vout.BackColor = Color.Orange;
                                    Txt_ACC.BackColor = Color.Orange;
                                }
                                else
                                {
                                    Txt_Vout.BackColor = Color.PaleGreen;
                                    Txt_ACC.BackColor = Color.PaleGreen;
                                }
                                //await Task.Delay(1000);
                            }
                            list.Add(Txt_Vout.Text);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                        if (info2[5])
                            {
                                StateMsg.Text = "접지를 검사합니다.";
                                GroundMeas();
                                
                                if(Txt_Case.Text == "NG")
                                {
                                    IsOK = false;
                                    Txt_Case.BackColor = Color.Orange;
                                }
                                else
                                    Txt_Case.BackColor = Color.PaleGreen;

                                Delay(1000);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                logfile.SaveData(Txt_Case.Text, index + 8, 91);
                            }
                            list.Add(Txt_Case.Text);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                        StateMsg.Text = "지그실린더를 복귀합니다.";

                            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)4);                 //지그실린더 복귀

                            DelayTime(6, 7);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                            StateMsg.Text = "상하실린더를 복귀합니다.";

                            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)3);                 //상하실린더 복귀
                        
                            DelayTime(4, 5);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }

                        if (IsOK)
                            {
                                StateMsg.Text = "최종 검사 결과 양품입니다. 제품을 직접 배출해주세요.";
                                OK++;
                                Txt_Judge.Text = "OK";
                                Txt_Judge.BackColor = Color.PaleGreen;
                                logfile.SaveData("OK", index + 8, 9);
                                logfile.SaveData("OK", index + 8, 93);
                                logfile.SaveData(OK.ToString(), 1, 3);
                            }
                            else
                            {
                                StateMsg.Text = "최종 검사 결과 불량입니다. 제품을 배출합니다.";
                                NG++;
                                Txt_Judge.Text = "NG";
                                Txt_Judge.BackColor = Color.Orange;
                                logfile.SaveData("NG", index + 8, 9);
                                logfile.SaveData("NG", index + 8, 93);
                                logfile.SaveData(NG.ToString(), 2, 3);

                                if (!timer1.Enabled)
                                {
                                    StateMsg.Text = "정지합니다";
                                    Stop();
                                    return;
                                }

                                Abondon();
                            }
                            list.Add(Txt_Judge.Text);
                            mainform.list.Add(Log(list));
                            csv.save(list);

                            if (!timer1.Enabled)
                            {
                                StateMsg.Text = "정지합니다";
                                Stop();
                                return;
                            }
                        }
                    }
                }
                Delay(500);
                StateMsg.Text = "검사가 완료되었습니다.";

                groupBox6.BackColor = Color.PaleGreen;
                
                Return();

                while (true)
                {
                    Application.DoEvents();

                    if (!timer1.Enabled)
                    {
                        StateMsg.Text = "정지합니다";
                        Stop();
                        return;
                    }

                    if (!state[14])
                    {
                        WarningPannel.Visible = false;
                        WarningPannel.SendToBack();
                        break;
                    }
                    else
                    {
                        WarningPannel.Visible = true;
                        WarningPannel.BringToFront();
                        if (IsOK)
                        {
                            Label.Text = "[비상정지] 양품 제품 배출을 확인해 주세요";
                        }
                        else
                        {
                            Label.Text = "불량품을 배출합니다.";
                            Abondon();
                        }
                    }
                }

                IsOK = true;
                list.Clear();
                timer1.Enabled = false;
                taskProcessLock = false;
            }
        }
        
        private void Stop()
        {
            taskProcessLock = false;
            IsOK = true;
            list.Clear();
            groupBox6.BackColor = Color.PaleGreen;
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

        private void GroundMeas()
        {
            short nRet = 0;
            NMFstate[1]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);

            Delay(500);
            judge = "OK";
            double[] doub = new double[4];

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
                        if (doub[j] > 0.3)
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
            Txt_Case.Text = judge;

            Delay(500);
            NMFstate[1]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)1);
        }         //접지검사

        private void Abondon()
        {
            short nRet = 0;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)5);

            if (!timer1.Enabled)
            {
                StateMsg.Text = "정지합니다";
                Stop();
                return;
            }

            DelayTime(9, 8);

            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)6);

            if (!timer1.Enabled)
            {
                StateMsg.Text = "정지합니다";
                Stop();
                return;
            }

            DelayTime(11,10);

            if (!timer1.Enabled)
            {
                StateMsg.Text = "정지합니다";
                Stop();
                return;
            }

            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)7);
            
            Delay(1500);

            if (!timer1.Enabled)
            {
                StateMsg.Text = "정지합니다";
                Stop();
                return;
            }

            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)6);

            DelayTime(10,11);

            if (!timer1.Enabled)
            {
                StateMsg.Text = "정지합니다";
                Stop();
                return;
            }

            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)5);

            DelayTime(8, 9);

            if (!timer1.Enabled)
            {
                StateMsg.Text = "정지합니다";
                Stop();
                return;
            }

            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)7);
            Delay(500);
        }           //배출
        
        private  void VoutMeas()
        { 
            short nRet = 0;
            double sum = 0;
            NMFstate[2]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
            Delay(500);
            for(int i = 0; i < 100; i++)
            {
                sum += DAQ5.Analog_Read();
            }
            Vout = sum / 100;
            Delay(500);
            NMFstate[2]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)2);
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
        }

        private void MasterCheck(int index)
        {
            if (Convert.ToDouble(Txt_Height.Text) > Convert.ToDouble(Txt_HeightMax.Text))
                HeightMaxfaulty = true;
            if (Convert.ToDouble(Txt_Height.Text) < Convert.ToDouble(Txt_HeightMin.Text))
                HeightMinfaulty = true;
            if (Txt_Case.Text == "NG")
                Groundingfaulty = true;
            if (Convert.ToDouble(Txt_Vout.Text) > VoutMax ||
                Convert.ToDouble(Txt_Vout.Text) < VoutMin)
                Voutfaulty = true;

            Txt_Judge.Text = "";
            if (HeightMaxfaulty)
                Txt_Judge.AppendText(" 높이 상한 불량");
            if (HeightMinfaulty)
                Txt_Judge.AppendText(" 높이 하한 불량");
            if (Voutfaulty)
                Txt_Judge.AppendText(" 출력 불량");
            if (Groundingfaulty)
                Txt_Judge.AppendText(" 접지 불량");
            

            if (masterinfo.masterUse[index*4] == HeightMaxfaulty && masterinfo.masterUse[index * 4 + 1] == HeightMinfaulty &&
                masterinfo.masterUse[index * 4 + 2] == Voutfaulty && masterinfo.masterUse[index * 4 + 3] == Groundingfaulty)
            {
                if (HeightMaxfaulty)
                {
                    MastRes2.Visible = true;
                }
                else if (HeightMinfaulty)
                {
                    MastRes3.Visible = true;
                }
                else if (Voutfaulty)
                {
                    MastRes4.Visible = true;
                }
                else if (Groundingfaulty)
                {
                    MastRes5.Visible = true;
                }

                masterinfo.masterIC.RemoveAt(index);
                for(int i = 0; i < 4; i++)
                {
                    masterinfo.masterUse.RemoveAt(index * 4);
                }
                Count++;
            }
        }

        private void MasterResult()
        {
            /*switch (Count)
            {
                case 1:
                    MastRes1.Visible = true;
                    break;
                case 2:
                    MastRes2.Visible = true;
                    break;
                case 3:
                    MastRes3.Visible = true;
                    break;
                case 4:
                    MastRes4.Visible = true;
                    break;
                case 5:
                    MastRes5.Visible = true;
                    break;
            }*/
        }

        private void Return()
        {
            short nRet = 0;

            if (NMFstate[0]%2 == 1)
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

            if (!state[4])
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)3);
                DelayTime(4,5);
            }

            if (!state[6])
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)4);
                DelayTime(6, 7);
            }

            if (!state[12])
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)7);
                Delay(1500);
            }

            if (!state[10])
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)6);
                DelayTime(10, 11);
            }

            if (!state[8])
            {
                nRet = NMF.nmf_DOSetTogPin(DevNum, (short)5);
                DelayTime(8,9);
                Delay(500);
            }
            
            ClynderCheck.Enabled = true;
        }
        
        private void DelayTime(int num1, int num2)
        {
            DateTime starttime = DateTime.Now;

            while (true)
            {
                Application.DoEvents();
                if (state[num1]&& !state[num2])
                {
                    break;
                }
            }
            Delay(500);
        }

        private void Delay(int ms)
        {
            DateTime starttime = DateTime.Now;

            while (true)
            {
                Application.DoEvents();
                if(DateTime.Now - starttime >= TimeSpan.FromMilliseconds(ms))
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

            SSC.Write("OWT2800372f5a2\r\n");

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
            SSC.Write("OR_28002\r\n");
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
            SSC.Write("OW_28003240079\r\n");

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
            SSC.Write("OR_28003\r\n");
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

            SSC.Write("OW_2800324007A\r\n");
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
            SSC.Write("OR_28003\r\n");
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

            SSC.Write("OW_2800324007B\r\n");
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
            SSC.Write("OR_28003\r\n");

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

            SSC.Write("OW_2800324007C\r\n");
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
            SSC.Write("OR_28003\r\n");
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

            Txt_ICID.Text = ID;
            Txt_ICID.BackColor = Color.PaleGreen;

            NMFstate[0]++;
            nRet = NMF.nmf_DOSetTogPin(DevNum, (short)0);
        }

        private string Log(List<string> data)
        {
            string str;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].IndexOf("\r\n") >= 0)
                {
                    data[i] = data[i].Replace("\r\n", "");
                }
                else if (data[i].IndexOf('\n') >= 0)
                {
                    data[i] = data[i].Replace("\n", "");
                }
            }
            str = (data[0] + "," + data[1] + "," + data[2] + "," + data[3]
                + "," + data[4] + "," + data[5] + "," + data[6]);
            return str;
        }
        
        private void Timer_Start_Tick(object sender, EventArgs e)
        {
            if (state[0] && state[1] && !state[2] && Txt_path.Text != "")
            {
                if (!IsReturn)
                {
                    Timer_Start.Enabled = false;
                    MessageBox.Show("실린더 원위치 버튼을 눌러주세요");
                    ClynderCheck.Enabled = false;
                    Timer_Start.Enabled = true;
                }
                else if (!state[14] && !taskProcessLock)
                {
                    Timer_Start.Enabled = false;
                    WarningPannel.Visible = true;
                    WarningPannel.BringToFront();
                    MessageBox.Show("제품을 올려주세요");
                    Timer_Start.Enabled = true;
                }
                else
                {
                    timer1.Enabled = true;
                    WarningPannel.Visible = false;
                    WarningPannel.SendToBack();
                }
                //Thread = new Thread(Process);
                //Thread.Start();
                /*cts = new System.Threading.CancellationTokenSource();
                token = cts.Token;
                taskProcess = new Task(new Action(Process), token);
                taskProcess.Start();*/
                //ProcessTimer.Enabled = true;
                //Process();
            }
            else if (state[2])
            {
                timer1.Enabled = false;
                //Stop();
            }
            else if(state[0] && state[1] && !state[2] && Txt_path.Text == "")
            {
                Timer_Start.Enabled = false;
                MessageBox.Show("스펙 데이터를 확인해주세요");
                Timer_Start.Enabled = true;
            }
        }

        private void BTN_Return_Click(object sender, EventArgs e)
        {
            if(!taskProcessLock)
                Return();
        }

        private void BTN_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mainform.IsSpec = true;
                Txt_path.Text = openFileDialog.FileName;

                info.Clear();
                info2.Clear();
                bin.Load(openFileDialog.FileName, ref info, ref info2);
                
                Txt_HeightMin.Text = info[0];
                Txt_HeightMax.Text = info[1];
                Txt_ACCP.Text = info[4];
                Txt_ACCM.Text = info[5];

                inifile2.WriteString("Spec", "path1", openFileDialog.FileName);
                Txt_Excelpath.Text = inifile2.ReadString("path","path", "");

                HeightVal = Convert.ToDouble(info[2]);
                VoutVal = Convert.ToDouble(info[3]);
                VoutP = Convert.ToDouble(info[4]);
                VoutM = Convert.ToDouble(info[5]);
                offset = Convert.ToDouble(info[6]);

                VoutMax = VoutVal + (VoutP / 25);
                VoutMin = VoutVal - (VoutM / 25);

                Txt_VoutMax.Text = VoutMax.ToString();
                Txt_VoutMin.Text = VoutMin.ToString();

                ID_Con.Checked = info2[0];
                Barcode1_Con.Checked = info2[1];
                Barcode2_Con.Checked = info2[2];
                Height_Con.Checked = info2[3];
                Vout_Con.Checked = info2[4];
                Ground_Con.Checked = info2[5];

                List<string> list2 = new List<string>();
                list2.Add(info[1]);
                list2.Add(info[0]);
                logfile.SaveSpec(list2, 2, 92);
                list2.Clear();
                list2.Add(info[3]);
                list2.Add(info[2]);
                logfile.SaveSpec(list2, 2, 94);
                StateMsg.Text = "제품을 올리고 양수 버튼을 눌러주세요";
                label_Mode.Text = "마스터 모드";
                groupBox6.BackColor = Color.PaleGreen;
            }
        }

        private void NMF_Input_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!IsNMFCon)
                {
                    IsNMFCon = nmfdio.Connect(DevNum, IP[0], IP[1], IP[2], 200);
                }
                short nRet;
                short[] nPinStatus = new short[128];

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
            }
            catch
            {
                NMF_Input.Enabled = false;
                mainform.CloseForm();
                MessageBox.Show("NMF 연결 상태를 확인해주세요");
            }
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //Stop();
        }

        private void MLCP__DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string[] strar;
            char[] chararr;

            ReadData = MLCP_.ReadLine();
            
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
            
            if (Txt_Height.InvokeRequired)
            {
                Txt_Height.BeginInvoke(new Action(() =>
                {
                    Txt_Height.Text = Height2.ToString();
                }));
            }
            else
            {
                Txt_Height.Text = Height2.ToString();
            }
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //Idread.Disconnect();
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            if (!IsReturn)
            {
                MessageBox.Show("실린더 원위치 버튼을 눌러주세요");
                ClynderCheck.Enabled = false;
            }
            else if (!state[14] && !taskProcessLock)
            {
                WarningPannel.Visible = true;
                WarningPannel.BringToFront();
                MessageBox.Show("제품을 올려주세요");
            }
            else
            {
                if (Txt_path.Text != "")
                {
                    WarningPannel.Visible = false;
                    WarningPannel.SendToBack();
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("스펙 데이터를 확인해주세요");
                }
            }
        }

        private void ClynderCheck_Tick(object sender, EventArgs e)
        {
            if(state[4] && state[6] && state[8] && state[10] && state[12])
            {
                IsReturn = true;
            }
            else
            {
                IsReturn = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*label_Mode.Text = "양산 모드";
            mainform.IsMaster = false;
            MastRes1.Visible = true;
            MastRes2.Visible = true;
            MastRes3.Visible = true;
            MastRes4.Visible = true;
            MastRes5.Visible = true;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*masterinfo = new MasterInfo(5);
            masterinfo.LoadInfo();
            mainform.IsMaster = true;
            label_Mode.Text = "마스터 모드";
            MastRes1.Visible = false;
            MastRes2.Visible = false;
            MastRes3.Visible = false;
            MastRes4.Visible = false;
            MastRes5.Visible = false;*/
        }

        private void BTN_DO2_Click(object sender, EventArgs e)
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

        private void TestForm_Load(object sender, EventArgs e)
        {
            if (IsError)
            {
                mainform.CloseForm();
                mainform.modelformOpen();
            }
        }

        private void BarcodeScanner1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                while (true)
                {
                    Application.DoEvents();
                    ReadData += BarcodeScanner1.ReadExisting();
                    //ReadData.Trim();
                    if (ReadData.IndexOf('\r') >= 0)
                    {
                        break;
                    }
                }
                ReadData = ReadData.Replace("", "");
                ReadData = ReadData.Trim();

                if (Txt_Barcode1.InvokeRequired)
                {
                    Txt_Barcode1.BeginInvoke(new Action(() =>
                    {
                        Txt_Barcode1.Text = ReadData;
                    }));
                }
                else
                {
                    Txt_Barcode1.Text = ReadData;
                }
            }
            catch(Exception ex)
            {

            }
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

                if (Txt_Barcode2.InvokeRequired)
                {
                    Txt_Barcode2.BeginInvoke(new Action(() =>
                    {
                        Txt_Barcode2.Text = ReadData;
                    }));
                }
                else
                {
                    Txt_Barcode2.Text = ReadData;
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void SSC_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ReadData = SSC.ReadLine();
            isRecv = true;
        }
    }
}
