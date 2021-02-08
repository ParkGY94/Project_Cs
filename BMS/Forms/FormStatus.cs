using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form1 Mainform;
        public Factory factory;
        public int selectCid;
        public bool timerDataShowLock;
        
        public Form2(Form1 mainform)
        {
            InitializeComponent();
            //Mainform = mainform;
            timerDataShowLock = false;
            timer1.Tick += new EventHandler((sender, e) => timer(sender, e, mainform));

            string[] gridBit =
                {
                    "INIT","SYS_CfgGlobal","SYS_CFG1","SYS_CFG2","SYS_DIAG","ADC_CFG","ADC2_OFFSET_COMP","OV_UV_EN"
                    ,"CELL_OV","CELL_UV","CB_CFG1","CB_CFG2","CB_CFG3","CB_CFG4","CB_CFG5","CB_CFG6","CB_CFG7"
                    ,"CB_CFG8","CB_CFG9","CB_CFG10","CB_CFG11","CB_CFG12","CB_CFG13","CB_CFG14","CB_Open_Flt"
                    ,"CB_Short_Flt","CB_DrvStatus","GPIO_CFG1","GPIO_CFG2","GPIO_STS","AN_OT_UT","GPIO_Short_Open"
                    ,"I_Status","COM_Status","FaultStatus1","FaultStatus2","FaultStatus3","FaultMask1 (disable)"
                    ,"FaultMask2 (disable)","FaultMask3 (disable)","WakeupMask1 (disable)","WakeupMask2 (disable)"
                    ,"WakeupMask2 (disable)","MeasIsense2"
                };

            gridClusterBit.RowCount = gridBit.Length;
            for (int i = 0; i < gridBit.Length; i++)
            {
                gridClusterBit.Rows[i].Cells[0].Value = gridBit[i];
            }
        }


        private void timer(object sender, EventArgs e, Form1 mainform)
        {
            //System.Timers.Timer timer1 = (System.Timers.Timer)sender;
            
            Mainform = mainform;
            factory = Mainform.factory;
            selectCid = Mainform.selectCid;
            if (!timerDataShowLock)
            {
                timerDataShowLock = true;

                try
                {
                    gridClusterBit.Rows[0].Cells[11].Value = "RTERM";
                    if (factory.dataPool[selectCid].Init[5] == "0")
                        gridClusterBit.Rows[0].Cells[11].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[0].Cells[11].Style.BackColor = Color.LimeGreen;
                    //gridClusterBit.Rows[0].Cells[11].Value = factory.dataPool[selectCid].Init[5];

                    gridClusterBit.Rows[0].Cells[12].Value = "BUSSW";
                    if (factory.dataPool[selectCid].Init[4] == "0")
                        gridClusterBit.Rows[0].Cells[12].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[0].Cells[12].Style.BackColor = Color.LimeGreen;
                    //gridClusterBit.Rows[0].Cells[12].Value = factory.dataPool[selectCid].Init[4];

                    for (int i = 0; i < 3; i++)
                    {
                        gridClusterBit.Rows[0].Cells[i + 13].Value = "CID" + (3 - i).ToString();
                        if (factory.dataPool[selectCid].Init[3 - i] == "0")
                            gridClusterBit.Rows[0].Cells[13 + i].Style.BackColor = Color.Yellow;
                        else
                            gridClusterBit.Rows[0].Cells[13 + i].Style.BackColor = Color.Orange;
                    }

                    gridClusterBit.Rows[0].Cells[16].Value = "CID0";
                    if (factory.dataPool[selectCid].Init[0] == "0")
                        gridClusterBit.Rows[0].Cells[16].Style.BackColor = Color.Yellow;
                    else
                        gridClusterBit.Rows[0].Cells[16].Style.BackColor = Color.Orange;

                    gridClusterBit.Rows[1].Cells[16].Value = "GO2SLEEP";
                    gridClusterBit.Rows[1].Cells[16].Style.BackColor = Color.Red;

                    for (int i = 0; i < 3; i++)
                    {
                        gridClusterBit.Rows[2].Cells[i + 1].Value = "CYCLIC_TIMER";
                        //gridClusterBit.Rows[2].Cells[i + 1].Value = factory.dataPool[selectCid].SYS_CFG1[15-i];
                        if (factory.dataPool[selectCid].SYS_CFG1[15 - i] == "0")
                            gridClusterBit.Rows[2].Cells[i + 1].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[2].Cells[i + 1].Style.BackColor = Color.LimeGreen;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        gridClusterBit.Rows[2].Cells[i + 4].Value = "DiagTimeout";
                        //gridClusterBit.Rows[2].Cells[i + 4].Value = factory.dataPool[selectCid].SYS_CFG1[12 - i];
                        if (factory.dataPool[selectCid].SYS_CFG1[12 - i] == "0")
                            gridClusterBit.Rows[2].Cells[i + 4].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[2].Cells[i + 4].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[2].Cells[7].Value = "IMeasEn";
                    //gridClusterBit.Rows[2].Cells[7].Value = factory.dataPool[selectCid].SYS_CFG1[9];
                    if (factory.dataPool[selectCid].SYS_CFG1[9] == "0")
                        gridClusterBit.Rows[2].Cells[7].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[7].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[8].Value = "CBAutoPause";
                    //gridClusterBit.Rows[2].Cells[8].Value = factory.dataPool[selectCid].SYS_CFG1[8];
                    if (factory.dataPool[selectCid].SYS_CFG1[8] == "0")
                        gridClusterBit.Rows[2].Cells[8].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[8].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[9].Value = "CBDrvEn";
                    //gridClusterBit.Rows[2].Cells[9].Value = factory.dataPool[selectCid].SYS_CFG1[7];
                    if (factory.dataPool[selectCid].SYS_CFG1[7] == "0")
                        gridClusterBit.Rows[2].Cells[9].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[9].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[10].Value = "GO2DIAG/DIAG";
                    //gridClusterBit.Rows[2].Cells[10].Value = factory.dataPool[selectCid].SYS_CFG1[6];
                    if (factory.dataPool[selectCid].SYS_CFG1[6] == "0")
                        gridClusterBit.Rows[2].Cells[10].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[10].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[11].Value = "CBManuPause";
                    //gridClusterBit.Rows[2].Cells[11].Value = factory.dataPool[selectCid].SYS_CFG1[5];
                    if (factory.dataPool[selectCid].SYS_CFG1[5] == "0")
                        gridClusterBit.Rows[2].Cells[11].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[11].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[12].Value = "SOFT_RST";
                    //gridClusterBit.Rows[2].Cells[12].Value = factory.dataPool[selectCid].SYS_CFG1[4];
                    if (factory.dataPool[selectCid].SYS_CFG1[4] == "0")
                        gridClusterBit.Rows[2].Cells[12].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[2].Cells[12].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[2].Cells[13].Value = "FaultWave";
                    //gridClusterBit.Rows[2].Cells[13].Value = factory.dataPool[selectCid].SYS_CFG1[3];
                    if (factory.dataPool[selectCid].SYS_CFG1[3] == "0")
                        gridClusterBit.Rows[2].Cells[13].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[13].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[14].Value = "Wave_DC";
                    //gridClusterBit.Rows[2].Cells[14].Value = factory.dataPool[selectCid].SYS_CFG1[2];
                    if (factory.dataPool[selectCid].SYS_CFG1[2] == "0")
                        gridClusterBit.Rows[2].Cells[14].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[14].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[15].Value = "Wave_DC";
                    //gridClusterBit.Rows[2].Cells[15].Value = factory.dataPool[selectCid].SYS_CFG1[1];
                    if (factory.dataPool[selectCid].SYS_CFG1[1] == "0")
                        gridClusterBit.Rows[2].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[2].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[2].Cells[16].Value = "Reserved_0";

                    for (int i = 0; i < 3; i++)
                    {
                        gridClusterBit.Rows[3].Cells[i + 4].Value = "PreviousState";
                        if (factory.dataPool[selectCid].SYS_CFG2[12 - i] == "0")
                            gridClusterBit.Rows[3].Cells[i + 4].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[3].Cells[i + 4].Style.BackColor = Color.SkyBlue;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        gridClusterBit.Rows[3].Cells[i + 7].Value = "FLT_RST_CFG";
                        if (factory.dataPool[selectCid].SYS_CFG2[9 - i] == "0")
                            gridClusterBit.Rows[3].Cells[i + 7].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[3].Cells[i + 7].Style.BackColor = Color.LimeGreen;
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        gridClusterBit.Rows[3].Cells[i + 11].Value = "TimeoutComm";
                        if (factory.dataPool[selectCid].SYS_CFG2[5 - i] == "0")
                            gridClusterBit.Rows[3].Cells[i + 11].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[3].Cells[i + 11].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[3].Cells[15].Value = "NumbOdd";
                    if (factory.dataPool[selectCid].SYS_CFG2[1] == "0")
                        gridClusterBit.Rows[3].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[3].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[3].Cells[16].Value = "HammEncode";
                    if (factory.dataPool[selectCid].SYS_CFG2[0] == "0")
                        gridClusterBit.Rows[3].Cells[16].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[3].Cells[16].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[4].Cells[1].Value = "FalutDiag";
                    if (factory.dataPool[selectCid].SYS_DIAG[15] == "0")
                        gridClusterBit.Rows[4].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[4].Cells[1].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 2; i++)
                    {
                        gridClusterBit.Rows[4].Cells[i + 4].Value = "IMux";
                        if (factory.dataPool[selectCid].SYS_DIAG[12 - i] == "0")
                            gridClusterBit.Rows[4].Cells[i + 4].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[4].Cells[i + 4].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[4].Cells[6].Value = "ISenseOLDiag";
                    if (factory.dataPool[selectCid].SYS_DIAG[10] == "0")
                        gridClusterBit.Rows[4].Cells[6].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[4].Cells[6].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 4; i++)
                    {
                        gridClusterBit.Rows[5].Cells[i + 1].Value = "TagID";
                        if (factory.dataPool[selectCid].ADC_CFG[15 - i] == "0")
                            gridClusterBit.Rows[5].Cells[i + 1].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[5].Cells[i + 1].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[5].Cells[5].Value = "Soc/nEoc";
                    if (factory.dataPool[selectCid].ADC_CFG[11] == "0")
                        gridClusterBit.Rows[5].Cells[5].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[5].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 3; i++)
                    {
                        gridClusterBit.Rows[5].Cells[i + 6].Value = "PGAGain";
                        if (factory.dataPool[selectCid].ADC_CFG[10 - i] == "0")
                            gridClusterBit.Rows[5].Cells[i + 6].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[5].Cells[i + 6].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[5].Cells[9].Value = "CCRst";
                    if (factory.dataPool[selectCid].ADC_CFG[7] == "0")
                        gridClusterBit.Rows[5].Cells[9].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[5].Cells[9].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[5].Cells[10].Value = "DisChComp";
                    if (factory.dataPool[selectCid].ADC_CFG[6] == "0")
                        gridClusterBit.Rows[5].Cells[10].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[10].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[5].Cells[11].Value = "ADC1ADef";
                    if (factory.dataPool[selectCid].ADC_CFG[5] == "0")
                        gridClusterBit.Rows[5].Cells[11].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[11].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[5].Cells[12].Value = "ADC1ADef";
                    if (factory.dataPool[selectCid].ADC_CFG[4] == "0")
                        gridClusterBit.Rows[5].Cells[12].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[12].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[5].Cells[13].Value = "ADC1BDef";
                    if (factory.dataPool[selectCid].ADC_CFG[3] == "0")
                        gridClusterBit.Rows[5].Cells[13].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[13].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[5].Cells[14].Value = "ADC1BDef";
                    if (factory.dataPool[selectCid].ADC_CFG[2] == "0")
                        gridClusterBit.Rows[5].Cells[14].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[14].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[5].Cells[15].Value = "ADC2Def";
                    if (factory.dataPool[selectCid].ADC_CFG[1] == "0")
                        gridClusterBit.Rows[5].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[5].Cells[16].Value = "ADC2Def";
                    if (factory.dataPool[selectCid].ADC_CFG[0] == "0")
                        gridClusterBit.Rows[5].Cells[16].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[5].Cells[16].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[6].Cells[1].Value = "CCRstCfg";
                    if (factory.dataPool[selectCid].ADC_OFFSET_COMP[15] == "0")
                        gridClusterBit.Rows[6].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[6].Cells[1].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[6].Cells[2].Value = "FreeCnt";
                    if (factory.dataPool[selectCid].ADC_OFFSET_COMP[14] == "0")
                        gridClusterBit.Rows[6].Cells[2].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[6].Cells[2].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[6].Cells[3].Value = "CC_POvl";
                    if (factory.dataPool[selectCid].ADC_OFFSET_COMP[13] == "0")
                        gridClusterBit.Rows[6].Cells[3].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[6].Cells[3].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[6].Cells[4].Value = "CC_NOvl";
                    if (factory.dataPool[selectCid].ADC_OFFSET_COMP[12] == "0")
                        gridClusterBit.Rows[6].Cells[4].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[6].Cells[4].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[6].Cells[5].Value = "SampOvl";
                    if (factory.dataPool[selectCid].ADC_OFFSET_COMP[11] == "0")
                        gridClusterBit.Rows[6].Cells[5].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[6].Cells[5].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[6].Cells[6].Value = "CC_OVT";
                    if (factory.dataPool[selectCid].ADC_OFFSET_COMP[10] == "0")
                        gridClusterBit.Rows[6].Cells[6].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[6].Cells[6].Style.BackColor = Color.SkyBlue;


                    for (int i = 0; i < 8; i++)
                    {
                        gridClusterBit.Rows[6].Cells[i + 9].Value = "ADC2OffsetComp";
                        if (factory.dataPool[selectCid].ADC_OFFSET_COMP[7 - i] == "0")
                            gridClusterBit.Rows[6].Cells[i + 9].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[6].Cells[i + 9].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[7].Cells[1].Value = "CommonOV";
                    if (factory.dataPool[selectCid].OV_UV_EN[15] == "0")
                        gridClusterBit.Rows[7].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[7].Cells[1].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[7].Cells[2].Value = "CommonOV";
                    if (factory.dataPool[selectCid].OV_UV_EN[14] == "0")
                        gridClusterBit.Rows[7].Cells[2].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[7].Cells[2].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[7].Cells[i + 3].Value = "CT" + (14 - i).ToString() + "_OVUV_EN";
                        if (factory.dataPool[selectCid].OV_UV_EN[13 - i] == "0")
                            gridClusterBit.Rows[7].Cells[i + 3].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[7].Cells[i + 3].Style.BackColor = Color.LimeGreen;
                    }

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[8].Cells[i + 3].Value = "CT" + (14 - i).ToString() + "_OV";
                        if (factory.dataPool[selectCid].CELL_OV[13 - i] == "0")
                        {
                            gridClusterBit.Rows[8].Cells[i + 3].Style.BackColor = Color.DarkRed;
                        }
                        else
                        {
                            gridClusterBit.Rows[8].Cells[i + 3].Style.BackColor = Color.Red;
                        }
                    }

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[9].Cells[i + 3].Value = "CT" + (14 - i).ToString() + "_UV";
                        if (factory.dataPool[selectCid].CELL_UV[13 - i] == "0")
                        {
                            gridClusterBit.Rows[9].Cells[i + 3].Style.BackColor = Color.DarkRed;
                        }
                        else
                        {
                            gridClusterBit.Rows[9].Cells[i + 3].Style.BackColor = Color.Red;
                        }
                    }

                    if (selectCid == 0)
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                string temp = factory.dataPool[selectCid].CB_CFG1[8 - j];
                                switch (i)
                                {
                                    case 0:
                                        temp = factory.dataPool[selectCid].CB_CFG1[8 - j];
                                        break;
                                    case 1:
                                        temp = factory.dataPool[selectCid].CB_CFG2[8 - j];
                                        break;
                                    case 2:
                                        temp = factory.dataPool[selectCid].CB_CFG3[8 - j];
                                        break;
                                    case 3:
                                        temp = factory.dataPool[selectCid].CB_CFG4[8 - j];
                                        break;
                                    case 4:
                                        temp = factory.dataPool[selectCid].CB_CFG5[8 - j];
                                        break;
                                    case 5:
                                        temp = factory.dataPool[selectCid].CB_CFG6[8 - j];
                                        break;
                                    case 6:
                                        temp = factory.dataPool[selectCid].CB_CFG7[8 - j];
                                        break;
                                    case 7:
                                        temp = factory.dataPool[selectCid].CB_CFG8[8 - j];
                                        break;
                                    case 8:
                                        temp = factory.dataPool[selectCid].CB_CFG9[8 - j];
                                        break;
                                    case 9:
                                        temp = factory.dataPool[selectCid].CB_CFG10[8 - j];
                                        break;
                                    case 10:
                                        temp = factory.dataPool[selectCid].CB_CFG11[8 - j];
                                        break;
                                    case 11:
                                        temp = factory.dataPool[selectCid].CB_CFG12[8 - j];
                                        break;
                                    case 12:
                                        temp = factory.dataPool[selectCid].CB_CFG13[8 - j];
                                        break;
                                    case 13:
                                        temp = factory.dataPool[selectCid].CB_CFG14[8 - j];
                                        break;
                                }

                                gridClusterBit.Rows[i + 10].Cells[j + 8].Value = "CBTimer";
                                if (temp == "0")
                                    gridClusterBit.Rows[i + 10].Cells[j + 8].Style.BackColor = Color.Green;
                                else
                                    gridClusterBit.Rows[i + 10].Cells[j + 8].Style.BackColor = Color.LimeGreen;
                            }

                            string temp2 = factory.dataPool[selectCid].CB_CFG1[9];
                            switch (i)
                            {
                                case 0:
                                    temp2 = factory.dataPool[selectCid].CB_CFG1[9];
                                    break;
                                case 1:
                                    temp2 = factory.dataPool[selectCid].CB_CFG2[9];
                                    break;
                                case 2:
                                    temp2 = factory.dataPool[selectCid].CB_CFG3[9];
                                    break;
                                case 3:
                                    temp2 = factory.dataPool[selectCid].CB_CFG4[9];
                                    break;
                                case 4:
                                    temp2 = factory.dataPool[selectCid].CB_CFG5[9];
                                    break;
                                case 5:
                                    temp2 = factory.dataPool[selectCid].CB_CFG6[9];
                                    break;
                                case 6:
                                    temp2 = factory.dataPool[selectCid].CB_CFG7[9];
                                    break;
                                case 7:
                                    temp2 = factory.dataPool[selectCid].CB_CFG8[9];
                                    break;
                                case 8:
                                    temp2 = factory.dataPool[selectCid].CB_CFG9[9];
                                    break;
                                case 9:
                                    temp2 = factory.dataPool[selectCid].CB_CFG10[9];
                                    break;
                                case 10:
                                    temp2 = factory.dataPool[selectCid].CB_CFG11[9];
                                    break;
                                case 11:
                                    temp2 = factory.dataPool[selectCid].CB_CFG12[9];
                                    break;
                                case 12:
                                    temp2 = factory.dataPool[selectCid].CB_CFG13[9];
                                    break;
                                case 13:
                                    temp2 = factory.dataPool[selectCid].CB_CFG14[9];
                                    break;
                            }
                            gridClusterBit.Rows[i + 10].Cells[7].Value = "CBEN/STS";
                            if (temp2 == "0")
                            {
                                gridClusterBit.Rows[i + 10].Cells[7].Style.BackColor = Color.Green;
                                //grid.Rows[i + 1].Cells[1].Style.BackColor = Color.White;
                            }
                            else
                            {
                                gridClusterBit.Rows[i + 10].Cells[7].Style.BackColor = Color.LimeGreen;
                                //grid.Rows[i + 1].Cells[1].Style.BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                string temp = factory.dataPool[selectCid].CB_CFG1[8 - j];
                                switch (i)
                                {
                                    case 0:
                                        temp = factory.dataPool[selectCid].CB_CFG1[8 - j];
                                        break;
                                    case 1:
                                        temp = factory.dataPool[selectCid].CB_CFG2[8 - j];
                                        break;
                                    case 2:
                                        temp = factory.dataPool[selectCid].CB_CFG3[8 - j];
                                        break;
                                    case 3:
                                        temp = factory.dataPool[selectCid].CB_CFG4[8 - j];
                                        break;
                                    case 4:
                                        temp = factory.dataPool[selectCid].CB_CFG5[8 - j];
                                        break;
                                    case 5:
                                        temp = factory.dataPool[selectCid].CB_CFG6[8 - j];
                                        break;
                                }

                                gridClusterBit.Rows[i + 10].Cells[j + 8].Value = "CBTimer";
                                if (temp == "0")
                                    gridClusterBit.Rows[i + 10].Cells[j + 8].Style.BackColor = Color.Green;
                                else
                                    gridClusterBit.Rows[i + 10].Cells[j + 8].Style.BackColor = Color.LimeGreen;
                            }

                            string temp2 = factory.dataPool[selectCid].CB_CFG1[9];
                            switch (i)
                            {
                                case 0:
                                    temp2 = factory.dataPool[selectCid].CB_CFG1[9];
                                    break;
                                case 1:
                                    temp2 = factory.dataPool[selectCid].CB_CFG2[9];
                                    break;
                                case 2:
                                    temp2 = factory.dataPool[selectCid].CB_CFG3[9];
                                    break;
                                case 3:
                                    temp2 = factory.dataPool[selectCid].CB_CFG4[9];
                                    break;
                                case 4:
                                    temp2 = factory.dataPool[selectCid].CB_CFG5[9];
                                    break;
                                case 5:
                                    temp2 = factory.dataPool[selectCid].CB_CFG6[9];
                                    break;
                            }
                            gridClusterBit.Rows[i + 10].Cells[7].Value = "CBEN/STS";
                            if (temp2 == "0")
                            {
                                gridClusterBit.Rows[i + 10].Cells[7].Style.BackColor = Color.Green;
                                //grid.Rows[i + 1].Cells[1].Style.BackColor = Color.White;
                            }
                            else
                            {
                                gridClusterBit.Rows[i + 10].Cells[7].Style.BackColor = Color.LimeGreen;
                                //grid.Rows[i + 1].Cells[1].Style.BackColor = Color.Red;
                            }
                        }

                        for (int i = 6; i < 14; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                gridClusterBit.Rows[i + 10].Cells[j + 8].Value = "";
                                gridClusterBit.Rows[i + 10].Cells[j + 8].Style.BackColor = Color.White;
                            }

                            gridClusterBit.Rows[i + 10].Cells[7].Value = "";
                            gridClusterBit.Rows[i + 10].Cells[7].Style.BackColor = Color.White;
                        }
                    }
                    // 수정 완료
                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[24].Cells[i + 3].Value = "CB" + (14 - i).ToString() + "_Open";
                        if (factory.dataPool[selectCid].CB_Open_Flt[13 - i] == "0")
                            gridClusterBit.Rows[24].Cells[i + 3].Style.BackColor = Color.DarkRed;
                        else
                            gridClusterBit.Rows[24].Cells[i + 3].Style.BackColor = Color.Red;
                    }

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[25].Cells[i + 3].Value = "CB" + (14 - i).ToString() + "_Short";
                        if (factory.dataPool[selectCid].CB_Short_Flt[13 - i] == "0")
                            gridClusterBit.Rows[25].Cells[i + 3].Style.BackColor = Color.DarkRed;
                        else
                            gridClusterBit.Rows[25].Cells[i + 3].Style.BackColor = Color.Red;
                    }

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[26].Cells[i + 3].Value = "CB" + (14 - i).ToString() + "_STS";
                        if (factory.dataPool[selectCid].CB_DrvStatus[13 - i] == "0")
                            gridClusterBit.Rows[26].Cells[i + 3].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[26].Cells[i + 3].Style.BackColor = Color.SkyBlue;
                    }

                    for (int i = 0; i < 13; i += 2)
                    {
                        gridClusterBit.Rows[27].Cells[i + 3].Value = "GPIO" + (6 - (i / 2)).ToString() + "_Cfg";
                        if (factory.dataPool[selectCid].GPIO_CFG1[13 - i] == "0")
                            gridClusterBit.Rows[27].Cells[i + 3].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[27].Cells[i + 3].Style.BackColor = Color.LimeGreen;
                        gridClusterBit.Rows[27].Cells[i + 4].Value = "GPIO" + (6 - (i / 2)).ToString() + "_Cfg";
                        if (factory.dataPool[selectCid].GPIO_CFG1[12 - i] == "0")
                            gridClusterBit.Rows[27].Cells[i + 4].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[27].Cells[i + 4].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[28].Cells[7].Value = "GPIO2_SOC";
                    if (factory.dataPool[selectCid].GPIO_CFG2[9] == "0")
                        gridClusterBit.Rows[28].Cells[7].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[28].Cells[7].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[28].Cells[8].Value = "GPIO0_WU";
                    if (factory.dataPool[selectCid].GPIO_CFG2[8] == "0")
                        gridClusterBit.Rows[28].Cells[8].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[28].Cells[8].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[28].Cells[9].Value = "GPIO0_FLT_ACT";
                    if (factory.dataPool[selectCid].GPIO_CFG2[7] == "0")
                        gridClusterBit.Rows[28].Cells[9].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[28].Cells[9].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[28].Cells[i + 10].Value = "GPIO" + (6 - i).ToString() + "_DR";
                        if (factory.dataPool[selectCid].GPIO_CFG2[6 - i] == "0")
                            gridClusterBit.Rows[28].Cells[i + 10].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[28].Cells[i + 10].Style.BackColor = Color.LimeGreen;
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[29].Cells[i + 2].Value = "GPIO" + (6 - i).ToString() + "_H";
                        if (factory.dataPool[selectCid].GPIO_STS[14 - i] == "0")
                            gridClusterBit.Rows[29].Cells[i + 2].Style.BackColor = Color.DarkRed;
                        else
                            gridClusterBit.Rows[29].Cells[i + 2].Style.BackColor = Color.Red;
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[29].Cells[i + 10].Value = "GPIO" + (6 - i).ToString() + "_ST";
                        if (factory.dataPool[selectCid].GPIO_STS[6 - i] == "0")
                            gridClusterBit.Rows[29].Cells[i + 10].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[29].Cells[i + 10].Style.BackColor = Color.SkyBlue;
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[30].Cells[i + 2].Value = "AN" + (6 - i).ToString() + "_OT";
                        if (factory.dataPool[selectCid].AN_OT_UT[14 - i] == "0")
                        {
                            gridClusterBit.Rows[30].Cells[i + 2].Style.BackColor = Color.DarkRed;
                        }

                        else
                        {
                            gridClusterBit.Rows[30].Cells[i + 2].Style.BackColor = Color.Red;
                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[30].Cells[i + 10].Value = "AN" + (6 - i).ToString() + "_UT";
                        if (factory.dataPool[selectCid].AN_OT_UT[6 - i] == "0")
                        {
                            gridClusterBit.Rows[30].Cells[i + 10].Style.BackColor = Color.DarkRed;
                        }

                        else
                        {
                            gridClusterBit.Rows[30].Cells[i + 10].Style.BackColor = Color.Red;
                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[31].Cells[i + 2].Value = "GPIO" + (6 - i).ToString() + "_SH";
                        if (factory.dataPool[selectCid].GPIO_Short_Anx_Open_Sts[14 - i] == "0")
                            gridClusterBit.Rows[31].Cells[i + 2].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[31].Cells[i + 2].Style.BackColor = Color.SkyBlue;
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        gridClusterBit.Rows[31].Cells[i + 10].Value = "AN" + (6 - i).ToString() + "Open";
                        if (factory.dataPool[selectCid].GPIO_Short_Anx_Open_Sts[6 - i] == "0")
                            gridClusterBit.Rows[31].Cells[i + 10].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[31].Cells[i + 10].Style.BackColor = Color.SkyBlue;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        gridClusterBit.Rows[32].Cells[i + 1].Value = "PGA_DAC";
                        if (factory.dataPool[selectCid].I_Status[15 - i] == "0")
                            gridClusterBit.Rows[32].Cells[i + 1].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[32].Cells[i + 1].Style.BackColor = Color.SkyBlue;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        gridClusterBit.Rows[33].Cells[i + 1].Value = "COM_ERR_COUNT";
                        if (factory.dataPool[selectCid].COM_Status[15 - i] == "0")
                            gridClusterBit.Rows[33].Cells[i + 1].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[33].Cells[i + 1].Style.BackColor = Color.SkyBlue;
                    }

                    gridClusterBit.Rows[34].Cells[1].Value = "POR";
                    if (factory.dataPool[selectCid].FaultStatus1[15] == "0")
                        gridClusterBit.Rows[34].Cells[1].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[1].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[2].Value = "RESET";
                    if (factory.dataPool[selectCid].FaultStatus1[14] == "0")
                        gridClusterBit.Rows[34].Cells[2].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[2].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[3].Value = "COM_ERR_OVR";
                    if (factory.dataPool[selectCid].FaultStatus1[13] == "0")
                        gridClusterBit.Rows[34].Cells[3].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[3].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[4].Value = "VPWR_OV";
                    if (factory.dataPool[selectCid].FaultStatus1[12] == "0")
                        gridClusterBit.Rows[34].Cells[4].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[4].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[5].Value = "VPWR_LV";
                    if (factory.dataPool[selectCid].FaultStatus1[11] == "0")
                        gridClusterBit.Rows[34].Cells[5].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[5].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[6].Value = "COM_LOSS";
                    if (factory.dataPool[selectCid].FaultStatus1[10] == "0")
                        gridClusterBit.Rows[34].Cells[6].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[6].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[7].Value = "COM_ERR";
                    if (factory.dataPool[selectCid].FaultStatus1[9] == "0")
                        gridClusterBit.Rows[34].Cells[7].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[7].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[8].Value = "CSB_WUP";
                    if (factory.dataPool[selectCid].FaultStatus1[8] == "0")
                        gridClusterBit.Rows[34].Cells[8].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[8].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[9].Value = "GPIO0_WUP";
                    if (factory.dataPool[selectCid].FaultStatus1[7] == "0")
                        gridClusterBit.Rows[34].Cells[9].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[9].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[10].Value = "I2C_ERR";
                    if (factory.dataPool[selectCid].FaultStatus1[6] == "0")
                        gridClusterBit.Rows[34].Cells[10].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[10].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[11].Value = "ISENSE_OL";
                    if (factory.dataPool[selectCid].FaultStatus1[5] == "0")
                        gridClusterBit.Rows[34].Cells[11].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[11].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[12].Value = "ISENSE_OC";
                    if (factory.dataPool[selectCid].FaultStatus1[4] == "0")
                        gridClusterBit.Rows[34].Cells[12].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[34].Cells[12].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[34].Cells[13].Value = "AN_OT";
                    if (factory.dataPool[selectCid].FaultStatus1[3] == "0")
                        gridClusterBit.Rows[34].Cells[13].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[34].Cells[13].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[34].Cells[14].Value = "AN_UT";
                    if (factory.dataPool[selectCid].FaultStatus1[2] == "0")
                        gridClusterBit.Rows[34].Cells[14].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[34].Cells[14].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[34].Cells[15].Value = "CT_OT";
                    if (factory.dataPool[selectCid].FaultStatus1[1] == "0")
                        gridClusterBit.Rows[34].Cells[15].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[34].Cells[15].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[34].Cells[16].Value = "CT_UT";
                    if (factory.dataPool[selectCid].FaultStatus1[0] == "0")
                        gridClusterBit.Rows[34].Cells[16].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[34].Cells[16].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[35].Cells[1].Value = "VCOM_OV";
                    if (factory.dataPool[selectCid].FaultStatus2[15] == "0")
                        gridClusterBit.Rows[35].Cells[1].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[1].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[2].Value = "VCOM_UV";
                    if (factory.dataPool[selectCid].FaultStatus2[14] == "0")
                        gridClusterBit.Rows[35].Cells[2].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[2].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[3].Value = "VANA_OV";
                    if (factory.dataPool[selectCid].FaultStatus2[13] == "0")
                        gridClusterBit.Rows[35].Cells[3].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[3].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[4].Value = "VANA_UV";
                    if (factory.dataPool[selectCid].FaultStatus2[12] == "0")
                        gridClusterBit.Rows[35].Cells[4].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[4].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[5].Value = "ADC1_B";
                    if (factory.dataPool[selectCid].FaultStatus2[11] == "0")
                        gridClusterBit.Rows[35].Cells[5].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[5].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[6].Value = "ADC1_A";
                    if (factory.dataPool[selectCid].FaultStatus2[10] == "0")
                        gridClusterBit.Rows[35].Cells[6].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[6].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[7].Value = "GND_LOSS";
                    if (factory.dataPool[selectCid].FaultStatus2[9] == "0")
                        gridClusterBit.Rows[35].Cells[7].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[7].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[8].Value = "IC_TSD";
                    if (factory.dataPool[selectCid].FaultStatus2[8] == "0")
                        gridClusterBit.Rows[35].Cells[8].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[8].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[9].Value = "IDLE_MODE";
                    if (factory.dataPool[selectCid].FaultStatus2[7] == "0")
                        gridClusterBit.Rows[35].Cells[9].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[9].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[10].Value = "AN_OPEN";
                    if (factory.dataPool[selectCid].FaultStatus2[6] == "0")
                        gridClusterBit.Rows[35].Cells[10].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[10].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[11].Value = "GPIO_SHORT";
                    if (factory.dataPool[selectCid].FaultStatus2[5] == "0")
                        gridClusterBit.Rows[35].Cells[11].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[11].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[12].Value = "CB_SHORT";
                    if (factory.dataPool[selectCid].FaultStatus2[4] == "0")
                        gridClusterBit.Rows[35].Cells[12].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[12].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[13].Value = "CB_OPEN";
                    if (factory.dataPool[selectCid].FaultStatus2[3] == "0")
                        gridClusterBit.Rows[35].Cells[13].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[13].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[14].Value = "OSC_ERR";
                    if (factory.dataPool[selectCid].FaultStatus2[12] == "0")
                        gridClusterBit.Rows[35].Cells[14].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[14].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[15].Value = "DED_ERR";
                    if (factory.dataPool[selectCid].FaultStatus2[1] == "0")
                        gridClusterBit.Rows[35].Cells[15].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[15].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[35].Cells[16].Value = "FUSE_ERR";
                    if (factory.dataPool[selectCid].FaultStatus2[0] == "0")
                        gridClusterBit.Rows[35].Cells[16].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[35].Cells[16].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[36].Cells[1].Value = "CC_OVR";
                    if (factory.dataPool[selectCid].FaultStatus3[15] == "0")
                        gridClusterBit.Rows[36].Cells[1].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[36].Cells[1].Style.BackColor = Color.Red;

                    gridClusterBit.Rows[36].Cells[2].Value = "DIAG_TO";
                    if (factory.dataPool[selectCid].FaultStatus3[14] == "0")
                        gridClusterBit.Rows[36].Cells[2].Style.BackColor = Color.DarkRed;
                    else
                        gridClusterBit.Rows[36].Cells[2].Style.BackColor = Color.Red;

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[36].Cells[i + 3].Value = "EOT_CB" + (14 - i).ToString();
                        if (factory.dataPool[selectCid].FaultStatus3[13 - i] == "0")
                            gridClusterBit.Rows[36].Cells[i + 3].Style.BackColor = Color.DarkRed;
                        else
                            gridClusterBit.Rows[36].Cells[i + 3].Style.BackColor = Color.Red;
                    }

                    gridClusterBit.Rows[37].Cells[4].Value = "VPWR_OV";
                    if (factory.dataPool[selectCid].FAULT_MASK1[12] == "0")
                        gridClusterBit.Rows[37].Cells[4].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[4].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[5].Value = "VPWR_LV";
                    if (factory.dataPool[selectCid].FAULT_MASK1[11] == "0")
                        gridClusterBit.Rows[37].Cells[5].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[5].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[6].Value = "COM_LOSS";
                    if (factory.dataPool[selectCid].FAULT_MASK1[10] == "0")
                        gridClusterBit.Rows[37].Cells[6].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[6].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[7].Value = "COM_ERR";
                    if (factory.dataPool[selectCid].FAULT_MASK1[9] == "0")
                        gridClusterBit.Rows[37].Cells[7].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[7].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[8].Value = "CSB_WUP";
                    if (factory.dataPool[selectCid].FAULT_MASK1[8] == "0")
                        gridClusterBit.Rows[37].Cells[8].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[8].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[35].Cells[9].Value = "GPIO0_WUP";
                    if (factory.dataPool[selectCid].FAULT_MASK1[12] == "0")
                        gridClusterBit.Rows[37].Cells[4].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[4].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[10].Value = "I2C_ERR";
                    if (factory.dataPool[selectCid].FAULT_MASK1[6] == "0")
                        gridClusterBit.Rows[37].Cells[10].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[10].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[11].Value = "ISENSE_OL";
                    if (factory.dataPool[selectCid].FAULT_MASK1[5] == "0")
                        gridClusterBit.Rows[37].Cells[11].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[11].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[12].Value = "ISENSE_OC";
                    if (factory.dataPool[selectCid].FAULT_MASK1[4] == "0")
                        gridClusterBit.Rows[37].Cells[12].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[12].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[13].Value = "AN_OT";
                    if (factory.dataPool[selectCid].FAULT_MASK1[3] == "0")
                        gridClusterBit.Rows[37].Cells[13].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[13].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[14].Value = "AN_UT";
                    if (factory.dataPool[selectCid].FAULT_MASK1[2] == "0")
                        gridClusterBit.Rows[37].Cells[14].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[14].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[15].Value = "CT_OT";
                    if (factory.dataPool[selectCid].FAULT_MASK1[1] == "0")
                        gridClusterBit.Rows[37].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[37].Cells[16].Value = "CT_UT";
                    if (factory.dataPool[selectCid].FAULT_MASK1[0] == "0")
                        gridClusterBit.Rows[37].Cells[16].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[37].Cells[16].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[1].Value = "VCOM_OV";
                    if (factory.dataPool[selectCid].FAULT_MASK2[15] == "0")
                        gridClusterBit.Rows[38].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[1].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[2].Value = "VCOM_UV";
                    if (factory.dataPool[selectCid].FAULT_MASK2[14] == "0")
                        gridClusterBit.Rows[38].Cells[2].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[2].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[3].Value = "VANA_OV";
                    if (factory.dataPool[selectCid].FAULT_MASK2[13] == "0")
                        gridClusterBit.Rows[38].Cells[3].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[3].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[4].Value = "VANA_UV";
                    if (factory.dataPool[selectCid].FAULT_MASK2[12] == "0")
                        gridClusterBit.Rows[38].Cells[4].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[4].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[5].Value = "ADC1_B";
                    if (factory.dataPool[selectCid].FAULT_MASK2[11] == "0")
                        gridClusterBit.Rows[38].Cells[5].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[5].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[6].Value = "ADC1_A";
                    if (factory.dataPool[selectCid].FAULT_MASK2[10] == "0")
                        gridClusterBit.Rows[38].Cells[6].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[6].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[7].Value = "GND_LOSS";
                    if (factory.dataPool[selectCid].FAULT_MASK2[9] == "0")
                        gridClusterBit.Rows[38].Cells[7].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[7].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[10].Value = "AN_OPEN";
                    if (factory.dataPool[selectCid].FAULT_MASK2[6] == "0")
                        gridClusterBit.Rows[38].Cells[10].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[10].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[11].Value = "GPIO_SHORT";
                    if (factory.dataPool[selectCid].FAULT_MASK2[5] == "0")
                        gridClusterBit.Rows[38].Cells[11].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[11].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[12].Value = "CB_SHORT";
                    if (factory.dataPool[selectCid].FAULT_MASK2[4] == "0")
                        gridClusterBit.Rows[38].Cells[12].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[12].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[13].Value = "CB_OPEN";
                    if (factory.dataPool[selectCid].FAULT_MASK2[3] == "0")
                        gridClusterBit.Rows[38].Cells[13].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[13].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[14].Value = "OSC_ERR";
                    if (factory.dataPool[selectCid].FAULT_MASK2[2] == "0")
                        gridClusterBit.Rows[38].Cells[14].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[14].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[15].Value = "DED_ERR";
                    if (factory.dataPool[selectCid].FAULT_MASK2[1] == "0")
                        gridClusterBit.Rows[38].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[38].Cells[16].Value = "FUSE_ERR";
                    if (factory.dataPool[selectCid].FAULT_MASK2[0] == "0")
                        gridClusterBit.Rows[38].Cells[16].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[38].Cells[16].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[39].Cells[1].Value = "CC_OVR";
                    if (factory.dataPool[selectCid].FAULT_MASK3[15] == "0")
                        gridClusterBit.Rows[39].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[39].Cells[1].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[39].Cells[2].Value = "DIAG_TO";
                    if (factory.dataPool[selectCid].FAULT_MASK3[14] == "0")
                        gridClusterBit.Rows[39].Cells[2].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[39].Cells[2].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[39].Cells[i + 3].Value = "EOT_CB" + (14 - i).ToString();
                        if (factory.dataPool[selectCid].FAULT_MASK3[13 - i] == "0")
                            gridClusterBit.Rows[39].Cells[i + 3].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[39].Cells[i + 3].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[40].Cells[4].Value = "VPWR_OV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[12] == "0")
                        gridClusterBit.Rows[40].Cells[4].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[4].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[5].Value = "VPWR_LV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[11] == "0")
                        gridClusterBit.Rows[40].Cells[5].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[5].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[8].Value = "CSB_WUP";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[8] == "0")
                        gridClusterBit.Rows[40].Cells[8].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[8].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[9].Value = "GPIO0_WUP";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[7] == "0")
                        gridClusterBit.Rows[40].Cells[9].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[9].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[12].Value = "ISENSE_OC";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[4] == "0")
                        gridClusterBit.Rows[40].Cells[12].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[12].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[13].Value = "AN_OT";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[3] == "0")
                        gridClusterBit.Rows[40].Cells[13].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[13].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[14].Value = "AN_UT";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[2] == "0")
                        gridClusterBit.Rows[40].Cells[14].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[14].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[15].Value = "CT_OV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[1] == "0")
                        gridClusterBit.Rows[40].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[40].Cells[16].Value = "CT_UV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK1[0] == "0")
                        gridClusterBit.Rows[40].Cells[16].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[40].Cells[16].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[1].Value = "VCOM_OV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[15] == "0")
                        gridClusterBit.Rows[41].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[1].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[2].Value = "VCOM_UV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[14] == "0")
                        gridClusterBit.Rows[41].Cells[2].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[2].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[3].Value = "VANA_OV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[13] == "0")
                        gridClusterBit.Rows[41].Cells[3].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[3].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[4].Value = "VANA_UV";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[12] == "0")
                        gridClusterBit.Rows[41].Cells[4].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[4].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[5].Value = "ADC1_B";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[11] == "0")
                        gridClusterBit.Rows[41].Cells[5].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[5].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[6].Value = "ADC1_A";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[10] == "0")
                        gridClusterBit.Rows[41].Cells[6].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[6].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[7].Value = "GND_LOSS";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[9] == "0")
                        gridClusterBit.Rows[41].Cells[7].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[7].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[8].Value = "IC_TSD";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[8] == "0")
                        gridClusterBit.Rows[41].Cells[8].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[8].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[11].Value = "GPIO_SHORT";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[5] == "0")
                        gridClusterBit.Rows[41].Cells[11].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[11].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[12].Value = "CB_SHORT";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[4] == "0")
                        gridClusterBit.Rows[41].Cells[12].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[12].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[14].Value = "OSC_ERR";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[2] == "0")
                        gridClusterBit.Rows[41].Cells[14].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[14].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[41].Cells[15].Value = "DED_ERR";
                    if (factory.dataPool[selectCid].WAKEUP_MASK2[1] == "0")
                        gridClusterBit.Rows[41].Cells[15].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[41].Cells[15].Style.BackColor = Color.LimeGreen;

                    gridClusterBit.Rows[42].Cells[1].Value = "CC_OVR";
                    if (factory.dataPool[selectCid].WAKEUP_MASK3[15] == "0")
                        gridClusterBit.Rows[42].Cells[1].Style.BackColor = Color.Green;
                    else
                        gridClusterBit.Rows[42].Cells[1].Style.BackColor = Color.LimeGreen;

                    for (int i = 0; i < 14; i++)
                    {
                        gridClusterBit.Rows[42].Cells[i + 3].Value = "EOT_CB" + (14 - i).ToString();
                        if (factory.dataPool[selectCid].WAKEUP_MASK3[13 - i] == "0")
                            gridClusterBit.Rows[42].Cells[i + 3].Style.BackColor = Color.Green;
                        else
                            gridClusterBit.Rows[42].Cells[i + 3].Style.BackColor = Color.LimeGreen;
                    }

                    gridClusterBit.Rows[43].Cells[1].Value = "DataRdy";
                    if (factory.dataPool[selectCid].MeasIsense2[15] == "0")
                        gridClusterBit.Rows[43].Cells[1].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[43].Cells[1].Style.BackColor = Color.SkyBlue;

                    for (int i = 0; i < 2; i++)
                    {
                        gridClusterBit.Rows[43].Cells[i + 7].Value = "PGAGain";
                        if (factory.dataPool[selectCid].MeasIsense2[9 - i] == "0")
                            gridClusterBit.Rows[43].Cells[i + 7].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[43].Cells[i + 7].Style.BackColor = Color.SkyBlue;
                    }

                    gridClusterBit.Rows[43].Cells[9].Value = "ADC2_SAT";
                    if (factory.dataPool[selectCid].MeasIsense2[7] == "0")
                        gridClusterBit.Rows[43].Cells[9].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[43].Cells[9].Style.BackColor = Color.SkyBlue;

                    gridClusterBit.Rows[43].Cells[10].Value = "PGAChange";
                    if (factory.dataPool[selectCid].MeasIsense2[6] == "0")
                        gridClusterBit.Rows[43].Cells[10].Style.BackColor = Color.Blue;
                    else
                        gridClusterBit.Rows[43].Cells[10].Style.BackColor = Color.SkyBlue;

                    for (int i = 0; i < 4; i++)
                    {
                        gridClusterBit.Rows[43].Cells[i + 13].Value = "Measl" + (3 - i).ToString();
                        if (factory.dataPool[selectCid].MeasIsense2[3 - i] == "0")
                            gridClusterBit.Rows[43].Cells[i + 13].Style.BackColor = Color.Blue;
                        else
                            gridClusterBit.Rows[43].Cells[i + 13].Style.BackColor = Color.SkyBlue;
                    }

                }
                catch (Exception ex)
                {

                }
            }
            timerDataShowLock = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }   
}
