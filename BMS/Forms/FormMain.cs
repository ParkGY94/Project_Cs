using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private Form2 form2;
        //timer Lock
        private bool timerDataShowLock;
        private bool timerLogLock;
        private bool timerShortLock;

        //객체
        public Factory factory;
        private FormOption option;

        //Task
        private TaskSerialRead bms;
        private Task logging;
        private Task task;

        //멤버변수
        public int selectCid;
        byte[] buffer;
        private bool isConnected;
        bool isLogging;
        int loggingCount;

        bool bShort;
        bool bOC;
        public Form1()
        {
            InitializeComponent();
            SetGrid();
            SetSerialList();

            factory = new Factory();
            bms = new TaskSerialRead(factory);

            timerDataShowLock = false;
            timerLogLock = false;
            timerShortLock = false;

            selectCid = 0;
            buffer = new byte[512];

            lbOption.ForeColor = Color.Black;
            lbOption.Font = new Font(FontFamily.GenericMonospace, 11, FontStyle.Bold);
            CheckOptionFile();

            bShort = false;
            bOC = false;

            isLogging = false;
        }

        //grid 셋팅
        private void SetGrid()
        {
            grid.Visible = false;
            grid.SuspendLayout();
            gridCluster.Visible = false;
            gridCluster.SuspendLayout();
            gridThresholds.Visible = false;
            gridThresholds.SuspendLayout();

            grid.DoubleBuffered(true);
            gridCluster.DoubleBuffered(true);
            gridThresholds.DoubleBuffered(true);

            //헤더 생성

            string[] gridRowHeader =
                {"Stack [V]","Cell-1 [V]","Cell-2 [V]","Cell-3 [V]","Cell-4 [V]","Cell-5 [V]","Cell-6 [V]"
                ,"Cell-7 [V]","Cell-8 [V]","Cell-9 [V]","Cell-10 [V]","Cell-11 [V]","Cell-12 [V]"
                ,"Cell-13 [V]","Cell-14 [V]","Current [mV]","T chip [C]","AN0 [C]","AN1 [C]"
                ,"AN2 [C]","AN3 [C]","AN4 [C]","AN5 [C]","AN6 [C]","Vbg Diag 1A [V]","Vbg Diag 1B [V]"
                ,"Fault Status 1 [1]","Fault Status 2 [1]","Fault Status 3 [1]"
            };

            //헤더 표시
            grid.RowCount = gridRowHeader.Length;
            for (int i = 0; i < gridRowHeader.Length; i++)
            {
                grid.Rows[i].Cells[0].Value = gridRowHeader[i];
            }

            //cluster 헤더 생성
            string[] gridClusterHeader =
                {"MEAS_ISENSE","MEAS_STACK","MEAS_CELL1","MEAS_CELL2","MEAS_CELL3","MEAS_CELL4"
                ,"MEAS_CELL5","MEAS_CELL6","MEAS_CELL7","MEAS_CELL8","MEAS_CELL9","MEAS_CELL10"
                ,"MEAS_CELL11","MEAS_CELL12","MEAS_CELL13","MEAS_CELL14","MEAS_AN0","MEAS_AN1"
                ,"MEAS_AN2","MEAS_AN3","MEAS_AN4","MEAS_AN5","MEAS_AN6","MEAS_IC_TEMP","MEAS_VBG_DIAG_ADC1A",
                "MEAS_VBG_DIAG_ADC1B","CC_NB_SAMPLES","COULOMB_CNT"
            };

            //cluster 헤더 표시
            gridCluster.RowCount = gridClusterHeader.Length;
            for (int i = 0; i < gridClusterHeader.Length; i++)
            {
                gridCluster.Rows[i].Cells[0].Value = gridClusterHeader[i];

                if (i == 0)
                {
                    gridCluster.Rows[i].Cells[2].Value = "mV";
                }
                else if (16 <= i && i <= 23)
                {
                    gridCluster.Rows[i].Cells[2].Value = "degC";
                }
                else if (i == 26 || i == 27)
                {
                    gridCluster.Rows[i].Cells[2].Value = "-";
                }
                else
                {
                    gridCluster.Rows[i].Cells[2].Value = "V";
                }
            }

            //thresholds
            string[] gridThresholdsHeader =
                {"TH_ALL_CT_OV","TH_ALL_CT_UV",
                "TH_CT01_OV","TH_CT01_UV","TH_CT02_OV","TH_CT02_UV","TH_CT03_OV","TH_CT03_UV",
                "TH_CT04_OV","TH_CT04_UV","TH_CT05_OV","TH_CT05_UV","TH_CT06_OV","TH_CT06_UV",
                "TH_CT07_OV","TH_CT07_UV","TH_CT08_OV","TH_CT08_UV","TH_CT09_OV","TH_CT09_UV",
                "TH_CT10_OV","TH_CT10_UV","TH_CT11_OV","TH_CT11_UV","TH_CT12_OV","TH_CT12_UV",
                "TH_CT13_OV","TH_CT13_UV","TH_CT14_OV","TH_CT14_UV",
                "TH_AN0_OT","TH_AN1_OT","TH_AN2_OT","TH_AN3_OT","TH_AN4_OT","TH_AN5_OT","TH_AN6_OT",
                "TH_AN0_UT","TH_AN1_UT","TH_AN2_UT","TH_AN3_UT","TH_AN4_UT","TH_AN5_UT","TH_AN6_UT",
                "TH_ISENSE_OC","TH_COLOMB_CNT"
            };

            gridThresholds.RowCount = gridThresholdsHeader.Length;

            for (int i = 0; i < gridThresholdsHeader.Length; i++)
            {
                gridThresholds.Rows[i].Cells[0].Value = gridThresholdsHeader[i];

                if (i < 30)
                {
                    gridThresholds.Rows[i].Cells[2].Value = "V";
                }
                else if (i < 44)
                {
                    gridThresholds.Rows[i].Cells[2].Value = "degC";
                }
                else
                {
                    gridThresholds.Rows[i].Cells[2].Value = "-";
                }
            }

            lbCid1.Enabled = false;

            grid.Visible = true;
            grid.ResumeLayout();
            gridCluster.Visible = true;
            gridCluster.ResumeLayout();
            gridThresholds.Visible = true;
            gridThresholds.ResumeLayout();
        }

        private void SetSerialList()
        {
            string[] serialList = SerialPort.GetPortNames();    //serial 목록 불러오기
            cbSerialList.Items.AddRange(serialList);            //추가
        }

        private void timerShowData_Tick(object sender, EventArgs e)
        {
            if (!timerDataShowLock)
            {
                timerDataShowLock = true;
                int progressValue = Convert.ToInt32((float)(loggingCount / (float)factory.option.logEndCount) * 100);
                progressLog.Value = progressValue;
                lbProgress.Text = progressValue.ToString() + "%";

                if (bms != null && isConnected)
                {
                    bms.GetReadData(ref buffer);

                    double stackCid0 = 0;
                    double stackCid1 = 0;

                    lbCid0.Text = "CHIPREV-" + factory.dataPool[0].chipRev + "\n" + "GUID-" + factory.dataPool[0].guid;

                    if (radioCluster2.Checked)
                        lbCid1.Text = "CHIPREV-" + factory.dataPool[1].chipRev + "\n" + "GUID-" + factory.dataPool[1].guid;
                    else
                        lbCid1.Text = "CID-02";
                    //vct
                    for (int i = 0; i < 14; i++)
                    {
                        grid.Rows[i + 1].Cells[1].Value = factory.dataPool[0].measVct[i];   //cid0
                        if (radioCluster2.Checked)
                            grid.Rows[i + 1].Cells[3].Value = factory.dataPool[1].measVct[i];   //cid1
                        else
                            grid.Rows[i + 1].Cells[3].Value = "";

                        gridCluster.Rows[i + 2].Cells[1].Value = factory.dataPool[selectCid].measVct[i];

                        stackCid0 += Convert.ToDouble(factory.dataPool[0].measVct[i]);
                        stackCid1 += Convert.ToDouble(factory.dataPool[1].measVct[i]);
                    }
                    grid.Rows[0].Cells[1].Value = "CID-1:" + stackCid0.ToString("F3");
                    if (radioCluster2.Checked)
                    {
                        grid.Rows[0].Cells[2].Value = "CID-2:" + stackCid1.ToString("F3");
                        grid.Rows[0].Cells[2].Style.ForeColor = Color.Black;
                    }
                    else
                        grid.Rows[0].Cells[2].Value = "";

                    if (selectCid == 0)
                        gridCluster.Rows[1].Cells[1].Value = stackCid0.ToString("F3");
                    else
                        gridCluster.Rows[1].Cells[1].Value = stackCid1.ToString("F3");

                    //vcur                
                    grid.Rows[15].Cells[1].Value = factory.dataPool[0].measCurr;
                    gridCluster.Rows[0].Cells[1].Value = factory.dataPool[selectCid].measCurr;

                    if (radioCluster2.Checked)
                        grid.Rows[15].Cells[3].Value = factory.dataPool[1].measCurr;
                    else
                        grid.Rows[15].Cells[3].Value = "";

                    //temp
                    grid.Rows[16].Cells[1].Value = factory.dataPool[0].icTemp;
                    gridCluster.Rows[23].Cells[1].Value = factory.dataPool[selectCid].icTemp;
                    if (radioCluster2.Checked)
                        grid.Rows[16].Cells[3].Value = factory.dataPool[1].icTemp;
                    else
                        grid.Rows[16].Cells[3].Value = "";

                    //
                    //van              
                    for (int i = 0; i < 7; i++)
                    {
                        //grid.Rows[i + 17].Cells[1].Value = factory.dataPool[0].van[i];
                        grid.Rows[i + 17].Cells[1].Value = factory.dataPool[0].measVan[i];
                        gridCluster.Rows[i + 16].Cells[1].Value = factory.dataPool[selectCid].measVan[i];

                        if (radioCluster2.Checked)
                            //grid.Rows[i + 17].Cells[3].Value = factory.dataPool[1].van[i];
                            grid.Rows[i + 17].Cells[3].Value = factory.dataPool[1].measVan[i];
                        else
                            grid.Rows[i + 17].Cells[3].Value = "";
                    }

                    //diag
                    for (int i = 0; i < 2; i++)
                    {
                        grid.Rows[i + 24].Cells[1].Value = factory.dataPool[0].diag[i];
                        gridCluster.Rows[i + 24].Cells[1].Value = factory.dataPool[selectCid].diag[i];
                        if (radioCluster2.Checked)
                            grid.Rows[i + 24].Cells[3].Value = factory.dataPool[1].diag[i];
                        else
                            grid.Rows[i + 24].Cells[3].Value = "";
                    }

                    //faultStatus                
                    for (int i = 0; i < 3; i++)
                    {
                        grid.Rows[i + 26].Cells[1].Value = "0x" + factory.dataPool[0].faultStatus[i];
                        if (radioCluster2.Checked)
                            grid.Rows[i + 26].Cells[3].Value = "0x" + factory.dataPool[1].faultStatus[i];
                        else
                            grid.Rows[i + 26].Cells[3].Value = "";
                    }

                    //nb sample
                    gridCluster.Rows[26].Cells[1].Value = "0x" + factory.dataPool[selectCid].nbSample;

                    //coulomb cnt
                    gridCluster.Rows[27].Cells[1].Value = "0x" + factory.dataPool[selectCid].coulomCnt;

                    //Stack OV
                    double Stack = 0;

                    DateTime starttime = DateTime.Now;
                    TimeSpan ts = TimeSpan.FromMilliseconds(1000);
                    TimeSpan ts2 = TimeSpan.FromMilliseconds(500);

                    while (true)
                    {
                        Application.DoEvents();
                        if (DateTime.Now - starttime <= ts)
                        {
                            try
                            {
                                Stack = stackCid0;
                                if (radioCluster2.Checked)
                                    Stack += stackCid1;

                                grid.Rows[0].Cells[3].Value = "Sum: " + Stack;

                                if (Stack <= 84 && Stack >= 50)
                                {
                                    grid.Rows[0].Cells[4].Value = "";
                                    break;
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                if (Stack >= 84)
                                    grid.Rows[0].Cells[4].Value = "Stack OV";
                                else if (Stack <= 50)
                                    grid.Rows[0].Cells[4].Value = "Stack UV";
                                break;
                            }
                            catch
                            {
                            }
                        }
                    }

                    //Current Short
                    DateTime starttime2 = DateTime.Now;
                    try
                    {
                        if (grid.Rows[15].Cells[1].Value != "")
                        {
                            double current = Convert.ToDouble(grid.Rows[15].Cells[1].Value);
                            if (!bShort && !bOC)
                            {
                                while (true)
                                {
                                    Application.DoEvents();
                                    if (DateTime.Now - starttime2 <= ts)
                                    {
                                        if (current >= 100)
                                        {
                                            DateTime starttime3 = DateTime.Now;

                                            while (true)
                                            {
                                                Application.DoEvents();
                                                if (DateTime.Now - starttime2 <= ts2)
                                                {
                                                    grid.Rows[15].Cells[2].Value = "";
                                                    break;
                                                }
                                                else
                                                {
                                                    grid.Rows[15].Cells[2].Value = "Short";
                                                    bShort = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (current < 50)
                                        {
                                            grid.Rows[15].Cells[2].Value = "";
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (!bShort)
                                        {
                                            grid.Rows[15].Cells[2].Value = "OC";
                                            bOC = true;
                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (!timerShortLock)
                                {
                                    task = new Task(ShortOC_Check);
                                    task.Start();
                                }
                            }
                        }
                    }
                    catch
                    {

                    }

                    //thresholds============================================================================================
                    try
                    {
                        gridThresholds.Rows[0].Cells[1].Value = (Convert.ToDouble(factory.dataPool[selectCid].thAllCtOv) * 5 / 256).ToString("F3");
                        gridThresholds.Rows[1].Cells[1].Value = (Convert.ToDouble(factory.dataPool[selectCid].thAllCtUv) * 5 / 256).ToString("F3");

                        for (int i = 0; i < 14; i++)
                        {
                            gridThresholds.Rows[(i * 2) + 2].Cells[1].Value = (Convert.ToDouble(factory.dataPool[selectCid].thCtOv[i]) * 5 / 256).ToString("F3");
                            gridThresholds.Rows[(i * 2) + 3].Cells[1].Value = (Convert.ToDouble(factory.dataPool[selectCid].thCtUv[i]) * 5 / 256).ToString("F3");
                        }

                        for (int i = 0; i < 7; i++)
                        {
                            gridThresholds.Rows[i + 30].Cells[1].Value = (Convert.ToDouble(factory.dataPool[selectCid].thAnOt[i])).ToString("F3");
                            gridThresholds.Rows[i + 37].Cells[1].Value = (Convert.ToDouble(factory.dataPool[selectCid].thAnUt[i])).ToString("F3");
                        }

                        gridThresholds.Rows[44].Cells[1].Value = "0x" + factory.dataPool[selectCid].thIsenceOc;
                        gridThresholds.Rows[45].Cells[1].Value = "0x" + factory.dataPool[selectCid].thCoulombCnt;
                    }
                    catch (Exception ex)
                    {

                    }
                    //Bits
                    try
                    {
                        // 210107
                        for (int i = 0; i < 14; i++)
                        {
                            if (factory.dataPool[0].CELL_OV[13 - i] == "1" && factory.dataPool[0].CELL_UV[13 - i] == "0")
                            {
                                grid.Rows[14 - i].Cells[2].Value = "Cell OV";
                            }
                            else if (factory.dataPool[0].CELL_OV[13 - i] == "0" && factory.dataPool[0].CELL_UV[13 - i] == "1")
                            {
                                grid.Rows[14 - i].Cells[2].Value = "Cell UV";
                            }
                            else
                            {
                                grid.Rows[14 - i].Cells[2].Value = "";
                            }

                            if (factory.dataPool[1].CELL_OV[13 - i] == "1" && factory.dataPool[1].CELL_UV[13 - i] == "0")
                            {
                                grid.Rows[14 - i].Cells[4].Value = "Cell OV";
                            }
                            else if (factory.dataPool[1].CELL_OV[13 - i] == "0" && factory.dataPool[1].CELL_UV[13 - i] == "1")
                            {
                                grid.Rows[14 - i].Cells[4].Value = "Cell UV";
                            }
                            else
                            {
                                grid.Rows[14 - i].Cells[4].Value = "";
                            }
                        }

                        /*for (int i = 0; i < 14; i++)
                        {
                            if (factory.dataPool[0].CELL_UV[13 - i] == "0")
                            {
                                grid.Rows[14-i].Cells[2].Value = "";
                            }
                            else
                            {
                                grid.Rows[14-i].Cells[2].Value = "Cell UV";
                            }

                            if (factory.dataPool[1].CELL_UV[13 - i] == "0")
                            {
                                grid.Rows[14-i].Cells[4].Value = "";
                            }
                            else
                            {
                                grid.Rows[14-i].Cells[4].Value = "Cell UV";
                            }
                        }*/

                        for (int i = 0; i < 14; i++)
                        {
                            string temp2 = factory.dataPool[0].CB_CFG1[9];
                            switch (i)
                            {
                                case 0:
                                    temp2 = factory.dataPool[0].CB_CFG1[9];
                                    break;
                                case 1:
                                    temp2 = factory.dataPool[0].CB_CFG2[9];
                                    break;
                                case 2:
                                    temp2 = factory.dataPool[0].CB_CFG3[9];
                                    break;
                                case 3:
                                    temp2 = factory.dataPool[0].CB_CFG4[9];
                                    break;
                                case 4:
                                    temp2 = factory.dataPool[0].CB_CFG5[9];
                                    break;
                                case 5:
                                    temp2 = factory.dataPool[0].CB_CFG6[9];
                                    break;
                                case 6:
                                    temp2 = factory.dataPool[0].CB_CFG7[9];
                                    break;
                                case 7:
                                    temp2 = factory.dataPool[0].CB_CFG8[9];
                                    break;
                                case 8:
                                    temp2 = factory.dataPool[0].CB_CFG9[9];
                                    break;
                                case 9:
                                    temp2 = factory.dataPool[0].CB_CFG10[9];
                                    break;
                                case 10:
                                    temp2 = factory.dataPool[0].CB_CFG11[9];
                                    break;
                                case 11:
                                    temp2 = factory.dataPool[0].CB_CFG12[9];
                                    break;
                                case 12:
                                    temp2 = factory.dataPool[0].CB_CFG13[9];
                                    break;
                                case 13:
                                    temp2 = factory.dataPool[0].CB_CFG14[9];
                                    break;
                            }
                            if (temp2 == "0")
                            {
                                grid.Rows[i + 1].Cells[1].Style.BackColor = Color.White;
                            }
                            else
                            {
                                grid.Rows[i + 1].Cells[1].Style.BackColor = Color.Red;
                            }
                        }

                        if (selectCid == 1)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                string temp2 = factory.dataPool[1].CB_CFG1[9];
                                switch (i)
                                {
                                    case 0:
                                        temp2 = factory.dataPool[1].CB_CFG1[9];
                                        break;
                                    case 1:
                                        temp2 = factory.dataPool[1].CB_CFG2[9];
                                        break;
                                    case 2:
                                        temp2 = factory.dataPool[1].CB_CFG3[9];
                                        break;
                                    case 3:
                                        temp2 = factory.dataPool[1].CB_CFG4[9];
                                        break;
                                    case 4:
                                        temp2 = factory.dataPool[1].CB_CFG5[9];
                                        break;
                                    case 5:
                                        temp2 = factory.dataPool[1].CB_CFG6[9];
                                        break;
                                }
                                if (temp2 == "0")
                                {
                                    grid.Rows[i + 1].Cells[3].Style.BackColor = Color.White;
                                }
                                else
                                {
                                    grid.Rows[i + 1].Cells[3].Style.BackColor = Color.Red;
                                }
                            }
                        }

                        for (int i = 0; i < 7; i++)
                        {
                            if (factory.dataPool[0].AN_OT_UT[14 - i] == "0" && factory.dataPool[0].AN_OT_UT[6 - i] == "0")
                            {
                                grid.Rows[23 - i].Cells[2].Value = "";
                            }
                            else if (factory.dataPool[0].AN_OT_UT[14 - i] == "1")
                            {
                                grid.Rows[23 - i].Cells[2].Value = "OT";
                            }
                            else if (factory.dataPool[0].AN_OT_UT[6 - i] == "1")
                            {
                                grid.Rows[23 - i].Cells[2].Value = "UT";
                            }
                            
                            if (factory.dataPool[1].AN_OT_UT[14 - i] == "0" && factory.dataPool[0].AN_OT_UT[6 - i] == "0")
                            {
                                grid.Rows[23 - i].Cells[4].Value = "";
                            }
                            else if (factory.dataPool[1].AN_OT_UT[14 - i] == "1")
                            {
                                grid.Rows[23 - i].Cells[4].Value = "OT";
                            }
                            else if (factory.dataPool[1].AN_OT_UT[6 - i] == "1")
                            {
                                grid.Rows[23 - i].Cells[4].Value = "UT";
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                //this.gridClusterBit.FirstDisplayedScrollingRowIndex = gridClusterBit.Rows.Count - 1;

                timerDataShowLock = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnCon.Text == "Connect")
            {
                factory.serial.Connect(cbSerialList.Text, 115200);
                btnCon.Text = "Disconnect";

                if(Commons.BMS_MODULE_COUNT == 2)
                    radioCluster2.Checked = true;
                else 
                    radioCluster1.Checked = true;

                lbCid0.ForeColor = Color.Blue;

                byte[] data = new byte[2];
                data[0] = 0x72;
                data[1] = 0x0A;

                isConnected = true;
                factory.serial.Write(data);

                btnLogging.Enabled = true;
            }
            else
            {
                factory.serial.Disconnect();
                btnCon.Text = "Connect";

                isConnected = false;

                btnLogging.Enabled = false;
            }
        }

        private void radioCluster2_CheckedChanged(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(((RadioButton)sender).Tag);

            byte[] data = new byte[7];
            data[0] = 0x63;
            data[1] = 0x33;
            data[2] = 0x30;
            data[3] = 0x30;
            data[4] = 0x30;
            data[5] = 0x31;
            data[6] = 0x0A;

            //cluster1
            if (tag == 1)
            {
                data[5] = 0x31;     //클러스터 1개일때
                lbCid1.Enabled = false;
            }
            else //cluster2
            {
                data[5] = 0x32;     //클러스터 2개일때
                lbCid1.Enabled = true;
            }
            factory.serial.Write(data);
        }

        private void lbCid0_Click(object sender, EventArgs e)
        {
            lbCid0.ForeColor = Color.White;
            lbCid1.ForeColor = Color.White;

            ((Label)sender).ForeColor = Color.Blue;

            selectCid = Convert.ToInt32(((Label)sender).Tag);
            byte[] data = new byte[3];
            data[0] = 0x67;
            data[1] = 0x31;
            data[2] = 0x0A;

            if (selectCid == 0)
            {
                data[1] = 0x31;
                radioCluster1.Enabled = true;
            }
            else
            {
                data[1] = 0x32;
                radioCluster1.Enabled = false;
            }

            factory.serial.Write(data);
        }

        private void lbCid0_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Maroon;
        }

        private void lbCid0_MouseLeave(object sender, EventArgs e)
        {
            if (selectCid == Convert.ToInt32(((Label)sender).Tag))
                ((Label)sender).ForeColor = Color.Blue;
            else
                ((Label)sender).ForeColor = Color.White;
        }

        private void timerTask_Tick(object sender, EventArgs e)
        {
            if (!timerLogLock)
            {
                timerLogLock = true;

                if (isLogging)
                {
                    btnLogging.Text = "Logging Stop";
                }
                else
                {
                    btnLogging.Text = "Logging Start";
                }

                timerLogLock = false;
            }
        }

        private void lbOption_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Maroon;
            ((Label)sender).Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
        }

        private void lbOption_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
            ((Label)sender).Font = new Font(FontFamily.GenericMonospace, 11, FontStyle.Bold);
        }

        private void lbOption_Click(object sender, EventArgs e)
        {
            if (option == null)
            {
                option = new FormOption(factory);
                option.ShowDialog();

                if (option != null)
                {
                    option.Dispose();
                    option = null;
                }
            }
        }

        private void CheckOptionFile()
        {
            string optionPath = Application.StartupPath + @"\system";
            string ntcPath = "";
            if (!Directory.Exists(optionPath))
            {
                Directory.CreateDirectory(optionPath);
            }
            ntcPath = optionPath + @"\ntcTable.ini";
            optionPath += @"\option.ini";


            //option file이 없으면 자동으로 생성
            if (!File.Exists(optionPath))
            {
                string logPath = Application.StartupPath + @"\Log";
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                factory.option.logSaveInterval = 1;
                factory.option.logEndCount = 10;

                factory.option.logSavePath = logPath;
                factory.option.Save(optionPath);
            }

            //ntctable 없으면 자동생성
            if (!File.Exists(ntcPath))
            {
                //테이블 자동생성
                factory.ntc.DefaultTable(ntcPath);
            }

            //저장하고 다시불러와서 확인
            factory.option.Load(optionPath);
            factory.ntc.ReadTable(ntcPath);
        }

        private void btnLogging_Click(object sender, EventArgs e)
        {
            loggingCount = 0;

            if (!isLogging)
            {
                logging = new Task(new Action(LoggingProcess));
                logging.Start();
                isLogging = true;
            }
            else
            {
                isLogging = false;
            }
        }


        //로그 기록하는 task
        private async void LoggingProcess()
        {
            loggingCount = 0;

            string path = factory.option.logSavePath + @"\";
            path += DateTime.Now.Year.ToString() + @"\";
            path += DateTime.Now.Month.ToString() + @"\";
            path += DateTime.Now.Day.ToString() + @"\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "Data_" + DateTime.Now.ToString("HHmmss") + ".csv";
            TimeSpan span = TimeSpan.FromMilliseconds(factory.option.logSaveInterval * 1000);

            //헤더 생성 
            string header = "";

            header += "Time,";
            int clusterNum = 1;
            if (radioCluster2.Checked)
                clusterNum = 2;
            for (int k = 0; k < clusterNum; k++)
            {
                for (int i = 0; i < grid.RowCount - 1; i++)
                {
                    header += "CID0" + (k + 1).ToString() + "-" + grid.Rows[i].Cells[0].Value + ",";
                }
            }

            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine("CID-01");
                    sw.WriteLine(lbCid0.Text);
                    if (radioCluster2.Checked)
                    {
                        sw.WriteLine("CID-02");
                        sw.WriteLine(lbCid1.Text);
                    }
                    sw.WriteLine(header);
                    sw.Close();
                }
                fs.Close();
            }

            await Task.Delay(100);
            while (true)
            {
                using (FileStream fs = new FileStream(path, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        await Task.Delay(span); //interval
                        string data = DateTime.Now.ToString("HH:mm:ss") + ",";
                        for (int i = 0; i < grid.RowCount - 1; i++)
                        {
                            data += grid.Rows[i].Cells[1].Value + ",";
                        }
                        for (int i = 0; i < grid.RowCount - 1; i++)
                        {
                            data += grid.Rows[i].Cells[2].Value + ",";
                        }
                        sw.WriteLine(data);

                        sw.Close();
                    }
                    fs.Close();
                }
                loggingCount++;

                if (loggingCount >= factory.option.logEndCount)
                    break;

                //stop 누르면 탈출 
                if (!isLogging)
                {
                    loggingCount = 0;
                    break;
                }
            }

            logging.Dispose();
            logging = null;
            isLogging = false;

        }

        private void gridThresholds_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void WriteCtThresholds(int ch, int address, int value1, int value2)
        {
            byte[] data = new byte[9];
            data[0] = 0x77;                 //w         

            string add = address.ToString("X2");

            data[1] = Convert.ToByte(Convert.ToChar(ch.ToString()));   //ch
            data[2] = Convert.ToByte(add[0]);                 // address
            data[3] = Convert.ToByte(add[1]);                 // address           

            string hex = value1.ToString("X2");
            string hex2 = value2.ToString("X2");

            data[4] = Convert.ToByte(hex[0]);    //value
            data[5] = Convert.ToByte(hex[1]);    //value

            data[6] = Convert.ToByte(hex2[0]);
            data[7] = Convert.ToByte(hex2[1]);

            data[8] = 0x0A;                 //.            

            factory.serial.Write(data);
        }

        private void WriteAnThresholds(int ch, int address, int value1)
        {
            byte[] data = new byte[13];
            data[0] = 0x6D;                 //m         

            string add = address.ToString("X2");

            data[1] = Convert.ToByte(Convert.ToChar(ch.ToString()));   //ch
            data[2] = Convert.ToByte(add[0]);                 // address
            data[3] = Convert.ToByte(add[1]);                 // address  

            data[4] = 0x30;     //mask data
            data[5] = 0x33;     //mask
            data[6] = 0x46;     //mask  
            data[7] = 0x46;     //mask          

            string hex = value1.ToString("X4");

            data[8] = Convert.ToByte(hex[0]);    //value
            data[9] = Convert.ToByte(hex[1]);    //value
            data[10] = Convert.ToByte(hex[2]);    //value
            data[11] = Convert.ToByte(hex[3]);    //value 

            data[12] = 0x0A;

            factory.serial.Write(data);
        }

        private void WriteBit(int ch, int address, int value1, int value2)
        {
            byte[] data = new byte[9];
            data[0] = 0x77;                 //w         

            string add = address.ToString("X2");

            data[1] = Convert.ToByte(Convert.ToChar(ch.ToString()));   //ch
            data[2] = Convert.ToByte(add[0]);                 // address
            data[3] = Convert.ToByte(add[1]);                 // address           

            string hex = value1.ToString("X2");
            string hex2 = value2.ToString("X2");

            data[4] = Convert.ToByte(hex[0]);    //value
            data[5] = Convert.ToByte(hex[1]);    //value

            data[6] = Convert.ToByte(hex2[0]);
            data[7] = Convert.ToByte(hex2[1]);

            data[8] = 0x0A;                 //.            

            factory.serial.Write(data);
        }

        //셀 수정이끝나면
        private void gridThresholds_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = ((DataGridView)sender).CurrentCell.RowIndex;
                string header = ((DataGridView)sender).Rows[rowIndex].Cells[0].Value.ToString();

                //ct
                if (header.IndexOf("CT") >= 0)
                {
                    double writeCtValue = 0;
                    double writeCtValue2 = 0;

                    if (header.IndexOf("OV") >= 0)
                    {
                        writeCtValue = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[1].Value);
                        writeCtValue2 = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex + 1].Cells[1].Value);
                    }
                    else if (header.IndexOf("UV") >= 0)
                    {
                        writeCtValue = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex - 1].Cells[1].Value);
                        writeCtValue2 = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[1].Value);
                    }

                    //수식
                    writeCtValue = (writeCtValue / 5) * 256;
                    writeCtValue2 = (writeCtValue2 / 5) * 256;

                    int address = 0;
                    for (int i = 0; i < 14; i++)
                    {
                        if (header.IndexOf((i + 1).ToString("00")) >= 0)
                        {
                            //byte index = Convert.ToByte(Convert.ToChar((1).ToString()));
                            address = 90 - (i + 1);
                            break;
                        }
                    }

                    int ch = selectCid + 1;

                    WriteCtThresholds(ch, address, Convert.ToInt32(writeCtValue), Convert.ToInt32(writeCtValue2));
                }

                //an
                if (header.IndexOf("AN") >= 0)
                {
                    double inputValue = 0;
                    double writeAnValue = 0;
                    double regiValue = 0;
                    int address = 0;

                    if (header.IndexOf("OT") >= 0)
                    {
                        writeAnValue = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[1].Value);
                        for (int i = 0; i < 7; i++)
                        {
                            string search = (i).ToString("0");
                            if (header.IndexOf(search) >= 0)
                            {
                                // byte index = Convert.ToByte(Convert.ToChar((1).ToString()));
                                address = 96 - i;
                                break;
                            }
                        }
                    }
                    else if (header.IndexOf("UT") >= 0)
                    {
                        writeAnValue = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[1].Value);
                        for (int i = 0; i < 7; i++)
                        {
                            string search = (i).ToString("0");
                            if (header.IndexOf(search) >= 0)
                            {
                                // byte index = Convert.ToByte(Convert.ToChar((1).ToString()));
                                address = 103 - i;
                                break;
                            }
                        }
                    }

                    inputValue = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[1].Value);


                    //수식
                    //저항값찾기 
                    for (int z = 0; z < factory.ntc.table.Count - 2; z++)
                    {
                        if (factory.ntc.table[z].temp == inputValue)
                        {
                            regiValue = factory.ntc.table[z].regi;
                            break;
                        }
                    }

                    writeAnValue = 5 / (regiValue / 6.8 + 1);
                    writeAnValue = 1024 / writeAnValue;

                    int ch = selectCid + 1;

                    WriteAnThresholds(ch, address, Convert.ToInt32(writeAnValue));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void grid_Paint(object sender, PaintEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            string[] strHeaders = { "CID-1", "CID-2" };
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            //Category Painting
            {
                Rectangle r1 = gv.GetCellDisplayRectangle(1, -1, false);
                int width1 = gv.GetCellDisplayRectangle(2, -1, false).Width;

                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + width1 - 2;
                r1.Height = (r1.Height / 2) - 2;

                e.Graphics.DrawRectangle(new Pen(gv.BackgroundColor), r1);
                e.Graphics.FillRectangle(new SolidBrush(gv.ColumnHeadersDefaultCellStyle.BackColor), r1);
                e.Graphics.DrawString(strHeaders[0], gv.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(gv.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
            }

            {
                Rectangle r2 = gv.GetCellDisplayRectangle(3, -1, false);
                int width = gv.GetCellDisplayRectangle(4, -1, false).Width;

                r2.X += 1;
                r2.Y += 1;
                r2.Width = r2.Width + width - 2;
                r2.Height = (r2.Height / 2) - 2;

                e.Graphics.DrawRectangle(new Pen(gv.BackgroundColor), r2);
                e.Graphics.FillRectangle(new SolidBrush(gv.ColumnHeadersDefaultCellStyle.BackColor), r2);
                e.Graphics.DrawString(strHeaders[1], gv.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(gv.ColumnHeadersDefaultCellStyle.ForeColor), r2, format);
            }
        }

        private void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            Rectangle rtHeader = gv.DisplayRectangle;
            rtHeader.Height = gv.ColumnHeadersHeight / 2;
            gv.Invalidate(rtHeader);
        }

        private void grid_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            Rectangle rtHeader = gv.DisplayRectangle;
            rtHeader.Height = gv.ColumnHeadersHeight / 2;
            gv.Invalidate(rtHeader);
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r = e.CellBounds;
                r.Y += e.CellBounds.Height / 2;
                r.Height = e.CellBounds.Height / 2;

                e.PaintBackground(r, true);
                e.PaintContent(r);
                e.Handled = true;
            }
        }

        private void ShortOC_Check()
        {
            timerShortLock = true;
            DateTime starttime = DateTime.Now;
            TimeSpan ts = TimeSpan.FromSeconds(10);
            while (true)
            {
                Application.DoEvents();
                if (DateTime.Now - starttime >= ts)
                {
                    bShort = false;
                    bOC = false;
                    timerShortLock = false;
                    break;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form2 = new Form2(this);
            form2.Show();
        }
    }//class end
}//namespace end