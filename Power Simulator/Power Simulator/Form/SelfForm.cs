using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Power_Simulator
{
    public partial class SelfForm : Form
    {
        MainForm mainform;

        ODA oda;
        SorensenXG sorenson;
        TDKLamdaGENH lamda;

        public string strReadODA;
        public string strReadSorensen;
        public string strReadLamda;
        public SelfForm(MainForm mainform_)
        {
            InitializeComponent();
            mainform = mainform_;
            DeviceConnect();
            sorenson.IDN();
        }

        private void DeviceConnect()
        {
            oda = new ODA();
            sorenson = new SorensenXG();
            lamda = new TDKLamdaGENH();
        }
        
        private void BTN_IDN1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.IDN();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = mainform.strReadPower[0];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_RST1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.RST();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = mainform.strReadPower[0];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_Output1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;
            
            oda.OutPut(true);
        }

        private void BTN_OutOff1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;
            
            oda.OutPut(false);
        }

        private void BTN_VoltSet1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;
            double dData = 0;
            if (!double.TryParse(Txt_Volt1.Text, out dData) || dData < 0)
            {
                MessageBox.Show("전압 설정값이 유효하지 않습니다.", "SELF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oda.VoltSet(Convert.ToDouble(Txt_Volt1.Text));
        }

        private void BTN_CurrentSet1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;
            double dData = 0;
            if (!double.TryParse(Txt_Volt1.Text, out dData) || dData < 0)
            {
                MessageBox.Show("전류 설정값이 유효하지 않습니다.", "SELF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oda.CurrentSet(Convert.ToDouble(Txt_Volt1.Text));
        }

        private void BTN_VoltCheck1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.VoltOutCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CurrentCheck1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.CurrentOutCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_IDN2_Click(object sender, EventArgs e)
        {
            //if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.IDN();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    mainform.strReadPower[1] = mainform.strReadPower[1].Replace("?", "");
                    Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_RST2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.RST();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_Output2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            sorenson.OutPut(true);
        }

        private void BTN_OutOff2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            sorenson.OutPut(false);
        }

        private void BTN_ADR3_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            sorenson.ADR();
        }

        private void BTN_VoltSet2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;
            double dData = 0;
            if (!double.TryParse(Txt_Volt2.Text, out dData) || dData < 0)
            {
                MessageBox.Show("전압 설정값이 유효하지 않습니다.", "SELF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sorenson.VoltSet(Convert.ToDouble(Txt_Volt2.Text));
        }

        private void BTN_CurrentSet2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;
            double dData = 0;
            if (!double.TryParse(Txt_Volt2.Text, out dData) || dData < 0)
            {
                MessageBox.Show("전압 설정값이 유효하지 않습니다.", "SELF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sorenson.CurrentSet(Convert.ToDouble(Txt_Volt2.Text));
        }

        private void BTN_VoltCheck2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.VoltOutCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    /*mainform.strReadPower[1] = mainform.strReadPower[1].Replace("?", "");
                    while (mainform.strReadPower[1].IndexOf(">") >= 0)
                    {
                        mainform.strReadPower[1] = mainform.strReadPower[1].Replace(">", "0");
                    }
                    while (mainform.strReadPower[1].IndexOf("<") >= 0)
                    {
                        mainform.strReadPower[1] = mainform.strReadPower[1].Replace("<", "0");
                    }*/
                    mainform.strReadPower[1] = mainform.strReadPower[1].Replace("?", "");
                    Txt_Sorensen.Text = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                    //Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CurrentCheck2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.CurrentOutCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    mainform.strReadPower[1] = mainform.strReadPower[1].Replace("?", "");
                    Txt_Sorensen.Text = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                    //Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_IDN3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.IDN();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = mainform.strReadPower[2];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_RST3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.RST();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = mainform.strReadPower[2];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_Output3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            lamda.OutPut(true);
        }

        private void BTN_OutOff3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            lamda.OutPut(false);
        }

        private void BTN_ADR2_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            lamda.ADR();
        }

        private void BTN_VoltSet3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;
            double dData = 0;
            if (!double.TryParse(Txt_Volt3.Text, out dData) || dData < 0)
            {
                MessageBox.Show("전압 설정값이 유효하지 않습니다.", "SELF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lamda.VoltSet(Convert.ToDouble(Txt_Volt3.Text));
        }

        private void BTN_CurrentSet3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;
            double dData = 0;
            if (!double.TryParse(Txt_Volt3.Text, out dData) || dData < 0)
            {
                MessageBox.Show("전압 설정값이 유효하지 않습니다.", "SELF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lamda.CurrentSet(Convert.ToDouble(Txt_Volt3.Text));
        }

        private void BTN_VoltCheck3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.VoltOutCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CurrentCheck3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.CurrentOutCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lamda.CCMode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;
            lamda.CVMode();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sorenson.CCMode();
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
        

        private void BTN_ModeCheck_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.ModeCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = mainform.strReadPower[2];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_VoltSetCheck1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.VoltSetCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CurrentSetCheck1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.CurrentSetCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = Convert.ToDouble(mainform.strReadPower[0]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_VoltSetCheck2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.VoltSetCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    mainform.strReadPower[1] = mainform.strReadPower[1].Replace("?", "");
                    Txt_Sorensen.Text = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                    //Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CurrentSetCheck2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.CurrentSetCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    mainform.strReadPower[1] = mainform.strReadPower[1].Replace("?", "");
                    Txt_Sorensen.Text = Convert.ToDouble(mainform.strReadPower[1]).ToString("0.00");
                    //Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_VoltSetCheck3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.VoltSetCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CurrentSetCheck3_Click(object sender, EventArgs e)
        {
            if (!lamda.Connect) return;

            Txt_Lamda.Text = "";
            mainform.strReadPower[2] = "";
            strReadLamda = "";

            lamda.CurrentSetCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[2] != "")
                {
                    Txt_Lamda.Text = Convert.ToDouble(mainform.strReadPower[2]).ToString("0.00");
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_ModeCheck1_Click(object sender, EventArgs e)
        {
            if (!oda.Connect) return;

            Txt_ODA.Text = "";
            mainform.strReadPower[0] = "";
            strReadODA = "";

            oda.ModeCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[0] != "")
                {
                    Txt_ODA.Text = mainform.strReadPower[0];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void BTN_CV2_Click(object sender, EventArgs e)
        {
            sorenson.CVMode();
        }

        private void BTN_NONE2_Click(object sender, EventArgs e)
        {
            sorenson.NONEMode();
        }

        private void BTN_ModeCheck2_Click(object sender, EventArgs e)
        {
            if (!sorenson.Connect) return;

            Txt_Sorensen.Text = "";
            mainform.strReadPower[1] = "";
            strReadSorensen = "";

            sorenson.ModeCheck();

            DateTime NowTime = DateTime.Now;
            TimeSpan WaitTime = new TimeSpan(0, 0, 0, 0, 500);
            DateTime EndTime = NowTime.Add(WaitTime);
            while (NowTime <= EndTime)
            {
                Application.DoEvents();

                if (mainform.strReadPower[1] != "")
                {
                    Txt_Sorensen.Text = mainform.strReadPower[1];
                    break;
                }
                NowTime = DateTime.Now;
            }
        }

        private void Txt_Volt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
