using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public static class Commons
    {
        //debug mode
        public const bool DEBUG_MODE = false;
        public const int BMS_MODULE_COUNT = 2;

        public const double REGISTER_VALUE = 6.8;   //6.8k옴
        public const double INPUT_VOLT = 5.0;

        //Header
        #region emun header
        public enum HEADER : int
        {
            //Divide

            CHECK_DATA = 1, //0x01
            DIVIDE = 170,   //AA
            HEAD10 = 16,
            HEAD11 = 17,

            //menu status bar
            ID_TIMESTAMP = 18,
            ID_BASE_FAULTPIN = 11,
            ID_PACKCTRL_SW = 0,
            ID_PACKCTRL_INTERFACE = 1,
            ID_PACKCTRL_EVB = 2,
            ID_PACKCTRL_NOCLUSTER = 4,
            ID_BASE_BMSSTATUS = 10,

            //id
            ID_CHIPREV = 3,
            ID_GUID = 32,

            //Measurments
            ID_MEAS_VPWR = 300,
            ID_MEAS_VCT1 = 301,
            ID_MEAS_VCT2 = 302,
            ID_MEAS_VCT3 = 303,
            ID_MEAS_VCT4 = 304,
            ID_MEAS_VCT5 = 305,
            ID_MEAS_VCT6 = 306,
            ID_MEAS_VCT7 = 307,
            ID_MEAS_VCT8 = 308,
            ID_MEAS_VCT9 = 309,
            ID_MEAS_VCT10 = 310,
            ID_MEAS_VCT11 = 311,
            ID_MEAS_VCT12 = 312,
            ID_MEAS_VCT13 = 313,
            ID_MEAS_VCT14 = 314,
            ID_MEAS_VCUR = 315,
            ID_MEAS_VAN0 = 316,
            ID_MEAS_VAN1 = 317,
            ID_MEAS_VAN2 = 318,
            ID_MEAS_VAN3 = 319,
            ID_MEAS_VAN4 = 320,
            ID_MEAS_VAN5 = 321,
            ID_MEAS_VAN6 = 322,
            ID_MEAS_ICTEMP = 323,
            ID_MEAS_VBG_DIAG_ADC1A = 324,
            ID_MEAS_VBG_DIAG_ADC1B = 325,
            ID_CC_NV_SAMPLE = 326,
            ID_COULOMB_CNT = 327,
            ID_FAULT_STATUS1 = 110,
            ID_FAULT_STATUS2 = 111,
            ID_FAULT_STATUS3 = 112,
            ID_FAULT_MASK1 = 210,
            ID_FAULT_MASK2 = 211,
            ID_FAULT_MASK3 = 212,
            ID_BASE_EVALS2 = 382,
            ID_BASE_EVALS3 = 383,
            ID_BASE_EVALS4 = 384,
            ID_BCCSTATE = 17,
            ID_CID_SELECTED = 13,

            //Status
            ID_CELL_OV = 100,
            ID_CELL_UV = 101,
            ID_CB_OPEN_FAULT = 102,
            ID_CB_SHORT_FAULT = 103,
            ID_CB_DRV_STATUS = 104,
            ID_GPIO_STATUS = 105,
            ID_AN_OT_UT = 106,
            ID_GPIO_SHORT_OPEN = 107,
            ID_I_STATUS = 108,
            ID_COM_STATUS = 109,
            ID_MEAS_ISENSE2 = 113,

            //thresholds
            ID_TH_ALL_CT_OV = 400,
            ID_TH_ALL_CT_UV = 401,
            ID_TH_CT1_OV = 402,
            ID_TH_CT1_UV = 403,
            ID_TH_CT2_OV = 404,
            ID_TH_CT2_UV = 405,
            ID_TH_CT3_OV = 406,
            ID_TH_CT3_UV = 407,
            ID_TH_CT4_OV = 408,
            ID_TH_CT4_UV = 409,
            ID_TH_CT5_OV = 410,
            ID_TH_CT5_UV = 411,
            ID_TH_CT6_OV = 412,
            ID_TH_CT6_UV = 413,
            ID_TH_CT7_OV = 414,
            ID_TH_CT7_UV = 415,
            ID_TH_CT8_OV = 416,
            ID_TH_CT8_UV = 417,
            ID_TH_CT9_OV = 418,
            ID_TH_CT9_UV = 419,
            ID_TH_CT10_OV = 420,
            ID_TH_CT10_UV = 421,
            ID_TH_CT11_OV = 422,
            ID_TH_CT11_UV = 423,
            ID_TH_CT12_OV = 424,
            ID_TH_CT12_UV = 425,
            ID_TH_CT13_OV = 426,
            ID_TH_CT13_UV = 427,
            ID_TH_CT14_OV = 428,
            ID_TH_CT14_UV = 429,

            ID_TH_AN0_OT = 430,
            ID_TH_AN1_OT = 431,
            ID_TH_AN2_OT = 432,
            ID_TH_AN3_OT = 433,
            ID_TH_AN4_OT = 434,
            ID_TH_AN5_OT = 445,
            ID_TH_AN6_OT = 446,

            ID_TH_AN0_UT = 437,
            ID_TH_AN1_UT = 438,
            ID_TH_AN2_UT = 439,
            ID_TH_AN3_UT = 440,
            ID_TH_AN4_UT = 441,
            ID_TH_AN5_UT = 442,
            ID_TH_AN6_UT = 443,

            ID_TH_ISENSE_OC = 444,
            ID_TH_COULOMB_CNT = 445,

            //Config
            ID_INIT = 200,
            ID_SYS_CFG_GLOBAL = 201,
            ID_SYS_CFG1 = 202,
            ID_SYS_CFG2 = 203,
            ID_SYS_DIAG = 204,
            ID_ADC_CFG = 205,
            ID_OV_UV_EN = 206,
            ID_GPIO_CFG1 = 207,
            ID_GPIO_CFG2 = 208,
            ID_WAKEUP_MASK1 = 213,
            ID_WAKEUP_MASK2 = 214,
            ID_WAKEUP_MASK3 = 215,
            ID_ADC2_OFFSET_COMP = 219,
            ID_CB_CFG_1 = 220,
            ID_CB_CFG_2 = 221,
            ID_CB_CFG_3 = 222,
            ID_CB_CFG_4 = 223,
            ID_CB_CFG_5 = 224,
            ID_CB_CFG_6 = 225,
            ID_CB_CFG_7 = 226,
            ID_CB_CFG_8 = 227,
            ID_CB_CFG_9 = 228,
            ID_CB_CFG_10 = 229,
            ID_CB_CFG_11 = 230,
            ID_CB_CFG_12 = 231,
            ID_CB_CFG_13 = 232,
            ID_CB_CFG_14 = 233,
        }
        #endregion

        //표 빨리그리기
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            /*
            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            refGridView,
            new object[] { true });
            */
            Type dgvType = dgv.GetType();

            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",

                BindingFlags.Instance | BindingFlags.NonPublic);

            pi.SetValue(dgv, setting, null);

        }
    }   
}//namespace end
