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

namespace Analog_Digit
{
    public partial class OptionForm : Form
    {
        public iniUtil ini;
        public OptionForm()
        {
            InitializeComponent();
            ini = new iniUtil(@"C:\Users\gy157\Documents\Info.ini");

            NIName.Text = ini.GetIniValue("NI", "Name");
            HiokiName.Text = ini.GetIniValue("HIOKI", "PortName");
        }

        private void BTN_SaveName_Click(object sender, EventArgs e)
        {
            ini.SetIniValue("NI", "Name", NIName.Text);
            ini.SetIniValue("HIOKI", "PortName", HiokiName.Text);
        }
    }
}
