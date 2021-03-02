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
    public partial class SpecForm : Form
    {
        private MasterInfo masterinfo;
        private Binary bin;
        private IniFiles ini;

        public List<string> info;
        public List<bool> info2;
        public string[] strarr;

        public bool heightsave;
        public bool infosave;
        public bool Voutsave;

        public SpecForm()
        {
            InitializeComponent();
            masterinfo = new MasterInfo(5);
            bin = new Binary();
            ini = new IniFiles(@"C:\Users\abc\Data\Excelpath.ini");

            info = new List<string>();
            info2 = new List<bool>();

            heightsave = false;
            infosave = false;
            Voutsave = false;

        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<bool> list2 = new List<bool>();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                list.Add(saveFileDialog.FileName);
                list.Add(HeightMin.Value.ToString());
                list.Add(HeightMax.Value.ToString());
                list.Add(HeightVal.Value.ToString());
                list.Add(Vout_Value.Value.ToString());
                list.Add(VoutP.Value.ToString());
                list.Add(VoutM.Value.ToString());
                list.Add(Offset.Value.ToString());
                list.Add(Standard.Value.ToString());
                list.Add(Txt_Path.Text);

                list2.Add(ID_Con.Checked);
                list2.Add(Barcode1_Con.Checked);
                list2.Add(Barcode2_Con.Checked);
                list2.Add(Height_Con.Checked);
                list2.Add(Vout_Con.Checked);
                list2.Add(Ground_Con.Checked);

                bin.Save(list, list2);
            }
        }

        private void BTN_Open_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog.FileName;

                bin.Load(openFileDialog.FileName, ref info, ref info2);

                HeightMin.Value = Convert.ToDecimal(info[0]);
                HeightMax.Value = Convert.ToDecimal(info[1]);
                HeightVal.Value = Convert.ToDecimal(info[2]);
                Vout_Value.Value = Convert.ToDecimal(info[3]);
                VoutP.Value = Convert.ToDecimal(info[4]);
                VoutM.Value = Convert.ToDecimal(info[5]);
                Offset.Value = Convert.ToDecimal(info[6]);
                Standard.Value = Convert.ToDecimal(info[7]);
                Txt_Path.Text = info[8];

                ID_Con.Checked = info2[0];
                Barcode1_Con.Checked = info2[1];
                Barcode2_Con.Checked = info2[2];
                Height_Con.Checked = info2[3];
                Vout_Con.Checked = info2[4];
                Ground_Con.Checked = info2[5];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            Txt_Path.Text = openFileDialog2.FileName;
            ini.WriteString("path", "path", openFileDialog2.FileName);
        }
    }
}
