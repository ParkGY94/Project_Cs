using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Power_Simulator
{
    public partial class OptionForm : Form
    {
        private INIFILE ini;
        private string strPath;
        public OptionForm()
        {
            InitializeComponent();
            strPath = @"C:\Users\abc\Desktop\Power Simulator\Power Simulator\sys\option.ini";
            ini = new INIFILE(strPath);

            string[] port = { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6"};
            comboBox1.Items.AddRange(port);
            comboBox2.Items.AddRange(port);
            comboBox3.Items.AddRange(port);

            string[] baudrate1 = { "9600", "19200", "38400", "57600", "115200", "230400" };
            comboBox4.Items.AddRange(baudrate1);
            string[] baudrate2 = { "1200", "2400", "4800", "9600", "19200", "38400", "57600"};
            comboBox5.Items.AddRange(baudrate2);
            string[] baudrate3 = { "1200", "2400", "4800", "9600", "19200" };
            comboBox6.Items.AddRange(baudrate3);

            if (Directory.Exists(@"C:\Users\abc\Desktop\Power Simulator\Power Simulator\sys"))
            {
                comboBox1.Text = ini.Read("POWER1", "PortName", "");
                comboBox2.Text = ini.Read("POWER2", "PortName", "");
                comboBox3.Text = ini.Read("POWER3", "PortName", "");
                comboBox4.Text = ini.Read("POWER1", "BaudRate", "");
                comboBox5.Text = ini.Read("POWER2", "BaudRate", "");
                comboBox6.Text = ini.Read("POWER3", "BaudRate", "");
            }
        }

        private void BTN_SavePort_Click(object sender, EventArgs e)
        {
            ini.Write("POWER1", "PortName", comboBox1.Text);
            ini.Write("POWER2", "PortName", comboBox2.Text);
            ini.Write("POWER3", "PortName", comboBox3.Text);

            ini.Write("POWER1", "BaudRate", comboBox4.Text);
            ini.Write("POWER2", "BaudRate", comboBox5.Text);
            ini.Write("POWER3", "BaudRate", comboBox6.Text);
            MessageBox.Show("저장되었습니다.", "포트 설정", MessageBoxButtons.OK);
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
