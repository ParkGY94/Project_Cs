using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class DataPool
    {
        public string chipRev;
        public string guid;
        public string[] measVct;
        public string[] van;
        public string[] measVan;
        public string measCurr;
        public string icTemp;
        public string[] diag;
        public string[] faultStatus;
        public string nbSample;
        public string coulomCnt;

        public string thAllCtOv;
        public string thAllCtUv;
        public string[] thCtOv;
        public string[] thCtUv;
        public string[] thAnOt;
        public string[] thAnUt;
        public string thIsenceOc;
        public string thCoulombCnt;

        public string[] Init;
        public string[] SYS_CfgGlobal;
        public string[] SYS_CFG1;
        public string[] SYS_CFG2;
        public string[] SYS_DIAG;
        public string[] ADC_CFG;
        public string[] ADC_OFFSET_COMP;
        public string[] OV_UV_EN;
        public string[] CELL_OV;
        public string[] CELL_UV;
        public string[] CB_CFG1;
        public string[] CB_CFG2;
        public string[] CB_CFG3;
        public string[] CB_CFG4;
        public string[] CB_CFG5;
        public string[] CB_CFG6;
        public string[] CB_CFG7;
        public string[] CB_CFG8;
        public string[] CB_CFG9;
        public string[] CB_CFG10;
        public string[] CB_CFG11;
        public string[] CB_CFG12;
        public string[] CB_CFG13;
        public string[] CB_CFG14;
        public string[] CB_Open_Flt;
        public string[] CB_Short_Flt;
        public string[] CB_DrvStatus;
        public string[] GPIO_CFG1;
        public string[] GPIO_CFG2;
        public string[] GPIO_STS;
        public string[] AN_OT_UT;
        public string[] GPIO_Short_Anx_Open_Sts;
        public string[] I_Status;
        public string[] COM_Status;
        public string[] FaultStatus1;
        public string[] FaultStatus2;
        public string[] FaultStatus3;
        public string[] FAULT_MASK1;
        public string[] FAULT_MASK2;
        public string[] FAULT_MASK3;
        public string[] WAKEUP_MASK1;
        public string[] WAKEUP_MASK2;
        public string[] WAKEUP_MASK3;
        public string[] MeasIsense2;


        //생성자
        public DataPool()
        {
            chipRev = "";
            guid = "";
            measVct = new string[14];
            van = new string[7];
            measVan = new string[7];
            measCurr = "";
            icTemp = "";
            diag = new string[2];
            faultStatus = new string[3];
            nbSample = "";
            coulomCnt = "";

            thAllCtOv = "";
            thAllCtUv = "";

            thCtOv = new string[14];
            thCtUv = new string[14];
            thAnOt = new string[7];
            thAnUt = new string[7];
            thIsenceOc = "";
            thCoulombCnt = "";

            Init = new string[6];
            SYS_CfgGlobal = new string [1];
            SYS_CFG1 = new string[16];
            SYS_CFG2 = new string[16];
            SYS_DIAG = new string[16];
            ADC_CFG = new string[16];
            ADC_OFFSET_COMP = new string[16];
            OV_UV_EN = new string[16];
            CELL_OV = new string[16];
            CELL_UV = new string[16];
            CB_CFG1 = new string[16];
            CB_CFG2 = new string[16];
            CB_CFG3 = new string[16];
            CB_CFG4 = new string[16];
            CB_CFG5 = new string[16];
            CB_CFG6 = new string[16];
            CB_CFG7 = new string[16];
            CB_CFG8 = new string[16];
            CB_CFG9 = new string[16];
            CB_CFG10 = new string[16];
            CB_CFG11 = new string[16];
            CB_CFG12 = new string[16];
            CB_CFG13 = new string[16];
            CB_CFG14 = new string[16];
            CB_Open_Flt = new string[16];
            CB_Short_Flt = new string[16];
            CB_DrvStatus = new string[16];
            GPIO_CFG1 = new string[16];
            GPIO_CFG2 = new string[16];
            GPIO_STS = new string[16];
            AN_OT_UT = new string[16];
            GPIO_Short_Anx_Open_Sts = new string[16];
            I_Status = new string[16];
            COM_Status = new string[16];
            FaultStatus1 = new string[16];
            FaultStatus2 = new string[16];
            FaultStatus3 = new string[16];
            FAULT_MASK1 = new string[16];
            FAULT_MASK2 = new string[16];
            FAULT_MASK3 = new string[16];
            WAKEUP_MASK1 = new string[16];
            WAKEUP_MASK2 = new string[16];
            WAKEUP_MASK3 = new string[16];
            MeasIsense2 = new string[16];
    }

        ~DataPool()
        {

        }       

    }//class end
}//namespace end
