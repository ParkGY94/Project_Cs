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

namespace Pressure_Sensor_EOL
{
    public partial class OptionForm : Form
    {
        private MainForm mainform;
        private MasterInfo masterinfo;
        private IniFiles inifile;

        public List<string> list;
        public string[] strarr;

        public bool heightsave;
        public bool infosave;
        public bool Voutsave;

        public OptionForm(MainForm mainform_)
        {
            InitializeComponent();
            //masterinfo = new MasterInfo(5);
            mainform = mainform_;
            inifile = new IniFiles(@"C:\Users\abc\Data\Option.ini");

            heightsave = false;
            infosave = false;
            Voutsave = false;

            string[] port = { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9" };
            string[] device = { "Dev1", "Dev2", "Dev3", "Dev4", "Dev5", "Dev6", "Dev7", "Dev8", "Dev9" };
            comboBox1.Items.AddRange(port);
            comboBox2.Items.AddRange(port);
            comboBox3.Items.AddRange(port);
            comboBox5.Items.AddRange(device);
            comboBox6.Items.AddRange(port);

            /*inifile.ReadString("Barcode1", "PortName", "");
            inifile.ReadString("Barcode2", "PortName", "");
            inifile.ReadString("Meter", "PortName", "");
            inifile.ReadString("NMF", "DevName", "");
            inifile.ReadString("NI", "DevName", "");
            inifile.ReadString("SSC", "PortName", "");*/
            
        }

        private void BTN_InfoSave_Click(object sender, EventArgs e)
        {
            inifile.WriteInteger("Master Count", "Count", Convert.ToInt32(MasterCount.Value));

            inifile.WriteString("Master ID1", "Master", Txt_MasterID1.Text);
            inifile.WriteString("Master ID2", "Master", Txt_MasterID2.Text);
            inifile.WriteString("Master ID3", "Master", Txt_MasterID3.Text);
            inifile.WriteString("Master ID4", "Master", Txt_MasterID4.Text);
            inifile.WriteString("Master ID5", "Master", Txt_MasterID5.Text);

            inifile.WriteBoolean("Master1", "check1", M1_ch1.Checked);
            inifile.WriteBoolean("Master1", "check2", M1_ch2.Checked);
            inifile.WriteBoolean("Master1", "check3", M1_ch3.Checked);
            inifile.WriteBoolean("Master1", "check4", M1_ch4.Checked);

            inifile.WriteBoolean("Master2", "check1", M2_ch1.Checked);
            inifile.WriteBoolean("Master2", "check2", M2_ch2.Checked);
            inifile.WriteBoolean("Master2", "check3", M2_ch3.Checked);
            inifile.WriteBoolean("Master2", "check4", M2_ch4.Checked);

            inifile.WriteBoolean("Master3", "check1", M3_ch1.Checked);
            inifile.WriteBoolean("Master3", "check2", M3_ch2.Checked);
            inifile.WriteBoolean("Master3", "check3", M3_ch3.Checked);
            inifile.WriteBoolean("Master3", "check4", M3_ch4.Checked);

            inifile.WriteBoolean("Master4", "check1", M4_ch1.Checked);
            inifile.WriteBoolean("Master4", "check2", M4_ch2.Checked);
            inifile.WriteBoolean("Master4", "check3", M4_ch3.Checked);
            inifile.WriteBoolean("Master4", "check4", M4_ch4.Checked);

            inifile.WriteBoolean("Master5", "check1", M5_ch1.Checked);
            inifile.WriteBoolean("Master5", "check2", M5_ch2.Checked);
            inifile.WriteBoolean("Master5", "check3", M5_ch3.Checked);
            inifile.WriteBoolean("Master5", "check4", M5_ch4.Checked);

            mainform.IsMaster = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inifile.WriteString("Barcode1", "PortName", comboBox1.Text);
            inifile.WriteString("Barcode2", "PortName", comboBox2.Text);
            inifile.WriteString("Meter", "PortName", comboBox3.Text);
            inifile.WriteString("SSC", "PortName", comboBox6.Text);
        }

        private void BTN_SaveDev_Click(object sender, EventArgs e)
        {
            inifile.WriteString("NMF", "DevName1", textBoxIP0.Text);
            inifile.WriteString("NMF", "DevName2", textBoxIP1.Text);
            inifile.WriteString("NMF", "DevName3", textBoxIP2.Text);
            inifile.WriteString("NMF", "DevName4", textBoxDevID.Text);
            inifile.WriteString("NI", "DevName", comboBox5.Text);
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            comboBox1.Text = inifile.ReadString("Barcode1", "PortName", "");
            comboBox2.Text = inifile.ReadString("Barcode2", "PortName", "");
            comboBox3.Text = inifile.ReadString("Meter", "PortName", "");
            textBoxIP0.Text = inifile.ReadString("NMF", "DevName1", "");
            textBoxIP1.Text = inifile.ReadString("NMF", "DevName2", "");
            textBoxIP2.Text = inifile.ReadString("NMF", "DevName3", "");
            textBoxDevID.Text = inifile.ReadString("NMF", "DevName4", "");
            comboBox5.Text = inifile.ReadString("NI", "DevName", "");
            comboBox6.Text = inifile.ReadString("SSC", "PortName", "");

            MasterCount.Value = inifile.ReadInteger("Master Count", "Count", 0);

            Txt_MasterID1.Text = inifile.ReadString("Master ID1", "Master", "");
            Txt_MasterID2.Text = inifile.ReadString("Master ID2", "Master", "");
            Txt_MasterID3.Text = inifile.ReadString("Master ID3", "Master", "");
            Txt_MasterID4.Text = inifile.ReadString("Master ID4", "Master", "");
            Txt_MasterID5.Text = inifile.ReadString("Master ID5", "Master", "");

            M1_ch1.Checked = inifile.ReadBoolean("Master1", "check1", false);
            M1_ch2.Checked = inifile.ReadBoolean("Master1", "check2", false);
            M1_ch3.Checked = inifile.ReadBoolean("Master1", "check3", false);
            M1_ch4.Checked = inifile.ReadBoolean("Master1", "check4", false);

            M2_ch1.Checked = inifile.ReadBoolean("Master2", "check1", false);
            M2_ch2.Checked = inifile.ReadBoolean("Master2", "check2", false);
            M2_ch3.Checked = inifile.ReadBoolean("Master2", "check3", false);
            M2_ch4.Checked = inifile.ReadBoolean("Master2", "check4", false);

            M3_ch1.Checked = inifile.ReadBoolean("Master3", "check1", false);
            M3_ch2.Checked = inifile.ReadBoolean("Master3", "check2", false);
            M3_ch3.Checked = inifile.ReadBoolean("Master3", "check3", false);
            M3_ch4.Checked = inifile.ReadBoolean("Master3", "check4", false);

            M4_ch1.Checked = inifile.ReadBoolean("Master4", "check1", false);
            M4_ch2.Checked = inifile.ReadBoolean("Master4", "check2", false);
            M4_ch3.Checked = inifile.ReadBoolean("Master4", "check3", false);
            M4_ch4.Checked = inifile.ReadBoolean("Master4", "check4", false);

            M5_ch1.Checked = inifile.ReadBoolean("Master5", "check1", false);
            M5_ch2.Checked = inifile.ReadBoolean("Master5", "check2", false);
            M5_ch3.Checked = inifile.ReadBoolean("Master5", "check3", false);
            M5_ch4.Checked = inifile.ReadBoolean("Master5", "check4", false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Txt_password.Text != "" && Txt_password.Text != "")
            {

                if (Txt_password.Text != Txt_Password2.Text)
                {
                    MessageBox.Show("비밀번호를 확인해주세요", "비밀번호 불일치" , MessageBoxButtons.OK);
                }
                else
                {
                    inifile.WriteString("password", "password", Txt_password.Text);
                    MessageBox.Show("비밀번호가 변경되었습니다.", "비밀번호 변경", MessageBoxButtons.OK);
                }
            }
        }
    }
}
