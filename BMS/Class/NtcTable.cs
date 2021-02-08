using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class NtcTable
    {
        public List<Ntc> table;
        public const int TableCount = 135;

        public NtcTable()
        {
            table = new List<Ntc>();
            
            Ntc ntc = new Ntc();
        }

        public void ReadTable(string ntcPath)
        {       
            Ntc[] data = new Ntc[TableCount];
            for (int i = 0; i < TableCount; i++)
            {
                data[i] = new Ntc();
            }

            IniFiles ini = new IniFiles(ntcPath);
            table.Clear();
            string str = "DATA_";

            for (int i=0;i< TableCount;i++)
            {
                data[i].temp = ini.ReadDouble(str + (i + 1).ToString(), "TEMP",0);
                data[i].regi = ini.ReadDouble(str + (i + 1).ToString(), "REGI", 0);
            }

            table.AddRange(data);
            
        }

        public void WriteTable(string ntcPath)
        {
            IniFiles ini = new IniFiles(ntcPath);

            //ini.WriteDouble("DATA_1", "TEMP",);
        }

        //기본 테이블 생성
        public void DefaultTable(string ntcPath)
        {
            //기본값 넣기 ㅜㅠ
            SetDefaultValue();

            IniFiles ini = new IniFiles(ntcPath);
            string str = "DATA_";

            for(int i=0;i<table.Count-1;i++)
            {
                ini.WriteDouble(str + (i + 1).ToString(), "TEMP", table[i].temp);
                ini.WriteDouble(str + (i + 1).ToString(), "REGI", table[i].regi);
            }            
        }

        private void SetDefaultValue()
        {
            Ntc[] data = new Ntc[TableCount];
            for(int i=0;i< TableCount; i++)
            {
                data[i] = new Ntc();
            }

            data[0].temp = -30;
            data[0].regi = 111.300;        

            data[1].temp = -29;
            data[1].regi = 105.767;        

            data[2].temp = -28;
            data[2].regi = 100.539;        

            data[3].temp = -27;
            data[3].regi = 95.597;    

            data[4].temp = -26;
            data[4].regi = 90.926;         

            data[5].temp = -25;
            data[5].regi = 86.509;    

            data[6].temp = -24;
            data[6].regi = 82.331;       

            data[7].temp = -23;
            data[7].regi = 78.377;          

            data[8].temp = -22;
            data[8].regi = 74.636;        

            data[9].temp = -21;
            data[9].regi = 71.094;          

            data[10].temp = -20;
            data[10].regi = 67.740;           

            data[11].temp = -19;
            data[11].regi = 64.563;             

            data[12].temp = -18;
            data[12].regi = 58.700;            

            data[13].temp = -17;
            data[13].regi = 55.996;             

            data[14].temp = -16;
            data[14].regi = 53.432;             

            data[15].temp = -15;
            data[15].regi = 51.000;             

            data[16].temp = -14;
            data[16].regi = 48.692;             

            data[17].temp = -13;
            data[17].regi = 46.503;             

            data[18].temp = -12;
            data[18].regi = 46.503;             

            data[19].temp = -11;
            data[19].regi = 44.424;             

            data[20].temp = -10;
            data[20].regi = 42.450;
             
            data[21].temp = -9;
            data[21].regi = 40.568;
             
            data[22].temp = -8;
            data[22].regi = 38.778;
            
            data[23].temp = -7;
            data[23].regi = 37.078;
             
            data[24].temp = -6;
            data[24].regi = 35.461;
             
            data[25].temp = -5;
            data[25].regi = 33.923;
             
            data[26].temp = -3;
            data[26].regi = 31.068;
             
            data[27].temp = -2;
            data[27].regi = 29.743;
             
            data[28].temp = -1;
            data[28].regi = 28.481;
             
            data[29].temp = 0;
            data[29].regi = 27.280;
             
            data[30].temp = 1;
            data[30].regi = 26.136;
             
            data[31].temp = 2;
            data[31].regi = 25.045;
             
            data[32].temp = 3;
            data[32].regi = 24.006;           

            data[33].temp = 4;
            data[33].regi = 23.015;
             
            data[34].temp = 5;
            data[34].regi = 22.071;
             
            data[35].temp = 6;
            data[35].regi = 21.170;            

            data[36].temp = 7;
            data[36].regi = 20.310;             

            data[37].temp = 8;
            data[37].regi = 19.490;             

            data[38].temp = 9;
            data[38].regi = 18.707;             

            data[39].temp = 10;
            data[39].regi = 17.960;
             
            data[40].temp = 11;
            data[40].regi = 17.246;
             
            data[41].temp = 12;
            data[41].regi = 16.565;
             
            data[42].temp = 13;
            data[42].regi = 15.913;
             
            data[43].temp = 14;
            data[43].regi = 15.291;
             
            data[44].temp = 15;
            data[44].regi = 14.693;
            
            data[45].temp = 16;
            data[45].regi = 14.128;
             
            data[46].temp = 17;
            data[46].regi = 13.584;
             
            data[47].temp = 18;
            data[47].regi = 13.064;
             
            data[48].temp = 19;
            data[48].regi = 12.566;
            
            data[49].temp = 20;
            data[49].regi = 12.090;
             
            data[50].temp = 21;
            data[50].regi = 11.635;
             
            data[51].temp = 22;
            data[51].regi = 11.199;
             
            data[52].temp = 23;
            data[52].regi = 10.782;
             
            data[53].temp = 24;
            data[53].regi = 10.383;
             
            data[54].temp = 25;
            data[54].regi = 10.000;
             
            data[55].temp = 26;
            data[55].regi = 9.633;
             
            data[56].temp = 27;
            data[56].regi = 9.282;
             
            data[57].temp = 28;
            data[57].regi = 8.945;
             
            data[58].temp = 29;
            data[58].regi = 8.623;
             
            data[59].temp = 30;
            data[59].regi = 8.313;             

            data[60].temp = 31;
            data[60].regi = 8.016;
             
            data[61].temp = 32;
            data[61].regi = 7.731;
            
            data[62].temp = 33;
            data[62].regi = 7.458;
             
            data[63].temp = 34;
            data[63].regi = 7.196;
             
            data[64].temp = 35;
            data[64].regi = 6.944;
             
            data[65].temp = 36;
            data[65].regi = 6.702;
             
            data[66].temp = 37;
            data[66].regi = 6.470;
             
            data[67].temp = 38;
            data[67].regi = 6.248;
             
            data[68].temp = 39;
            data[68].regi = 6.034;
             
            data[69].temp = 40;
            data[69].regi = 5.828;
             
            data[70].temp = 41;
            data[70].regi = 5.630;
             
            data[71].temp = 42;
            data[71].regi = 5.440;
             
            data[72].temp = 43;
            data[72].regi = 5.258;
            
            data[73].temp = 44;
            data[73].regi = 5.082;
             
            data[74].temp = 45;
            data[74].regi = 4.914;
             
            data[75].temp = 46;
            data[75].regi = 4.751;
             
            data[76].temp = 47;
            data[76].regi = 4.595;
             
            data[77].temp = 48;
            data[77].regi = 4.445;
             
            data[78].temp = 49;
            data[78].regi = 4.300;
             
            data[79].temp = 50;
            data[79].regi = 4.161;
             
            data[80].temp = 51;
            data[80].regi = 4.027;
             
            data[81].temp = 52;
            data[81].regi = 3.898;
             
            data[82].temp = 53;
            data[82].regi = 3.773;
             
            data[83].temp = 54;
            data[83].regi = 3.653;
             
            data[84].temp = 55;
            data[84].regi = 3.538;
             
            data[85].temp = 56;
            data[85].regi = 3.427;
             
            data[86].temp = 57;
            data[86].regi = 3.320;
             
            data[87].temp = 58;
            data[87].regi = 3.216;
             
            data[88].temp = 59;
            data[88].regi = 3.117;
             
            data[89].temp = 60;
            data[89].regi = 3.021;
             
            data[90].temp = 61;
            data[90].regi = 2.928;
             
            data[91].temp = 62;
            data[91].regi = 2.839;
             
            data[92].temp = 63;
            data[92].regi = 2.753;
             
            data[93].temp = 64;
            data[93].regi = 2.670;         

            data[94].temp = 65;
            data[94].regi = 2.590;
             
            data[95].temp = 66;
            data[95].regi = 2.513;
             
            data[96].temp = 67;
            data[96].regi = 2.438;
             
            data[97].temp = 68;
            data[97].regi = 2.366;
             
            data[98].temp = 69;
            data[98].regi = 2.296;
             
            data[99].temp = 70;
            data[99].regi = 2.229;             

            data[100].temp = 71;
            data[100].regi = 2.164;             

            data[101].temp = 72;
            data[101].regi = 2.101;             

            data[102].temp = 73;
            data[102].regi = 2.041;             

            data[103].temp = 74;
            data[103].regi = 1.982;             

            data[104].temp = 75;
            data[104].regi = 1.925;             

            data[105].temp = 76;
            data[105].regi = 1.871;             

            data[106].temp = 77;
            data[106].regi = 1.818;             

            data[107].temp = 78;
            data[107].regi = 1.766;             

            data[108].temp = 79;
            data[108].regi = 1.717;
             
            data[109].temp = 80;
            data[109].regi = 1.669;             

            data[110].temp = 81;
            data[110].regi = 1.622;
             
            data[111].temp = 82;
            data[111].regi = 1.577;             

            data[112].temp = 83;
            data[112].regi = 1.534;             

            data[113].temp = 84;
            data[113].regi = 1.492;
             
            data[114].temp = 85;
            data[114].regi = 1.451;
             
            data[115].temp = 86;
            data[115].regi = 1.412;
             
            data[116].temp = 87;
            data[116].regi = 1.373;
             
            data[117].temp = 88;
            data[117].regi = 1.336;
             
            data[118].temp = 89;
            data[118].regi = 1.301;
             
            data[119].temp = 90;
            data[119].regi = 1.266;
             
            data[120].temp = 91;
            data[120].regi = 1.232;
             
            data[121].temp = 92;
            data[121].regi = 1.200;
             
            data[122].temp = 93;
            data[122].regi = 1.168;
             
            data[123].temp = 94;
            data[123].regi = 1.138;
             
            data[124].temp = 95;
            data[124].regi = 1.108;
             
            data[125].temp = 96;
            data[125].regi = 1.080;
             
            data[126].temp = 97;
            data[126].regi = 1.052;
             
            data[127].temp = 98;
            data[127].regi = 1.025;
             
            data[128].temp = 99;
            data[128].regi = 0.999;             

            data[129].temp = 100;
            data[129].regi = 0.973;             

            data[130].temp = 101;
            data[130].regi = 0.949;             

            data[131].temp = 102;
            data[131].regi = 0.925;             

            data[132].temp = 103;
            data[132].regi = 0.902;             

            data[133].temp = 104;
            data[133].regi = 0.879;            

            data[134].temp = 105;
            data[134].regi = 0.858;

            table.AddRange(data);
             
        }

    }//class end

    public class Ntc
    {
        public double temp;
        public double regi;
    }
}//namespace end
