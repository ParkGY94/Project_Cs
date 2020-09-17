using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analog_Digit
{
    public partial class SettingForm : Form
    {
        public Binary bin;
        public SettingForm()
        {
            InitializeComponent();
            bin = new Binary();
        }

        private void BTN_FileOpen_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            openFileDialog.ShowDialog();
            path.Text = openFileDialog.FileName;

            list = bin.Load(openFileDialog.FileName);
            
            VolMax.Text = list[0];
            VolMin.Text = list[1];
            ResMax.Text = list[2];
            ResMin.Text = list[3];
        }

        private void BTN_FileSave_Click(object sender, EventArgs e)
        {
            double dtm1, dtm2, dtm3, dtm4;
            bool boolText1 = Double.TryParse(VolMax.Text, out dtm1);
            bool boolText2 = Double.TryParse(VolMin.Text, out dtm2);
            bool boolText3 = Double.TryParse(ResMax.Text, out dtm3);
            bool boolText4 = Double.TryParse(ResMin.Text, out dtm4);

            if (boolText1 && boolText2 && boolText3 && boolText4)
            {
                List<string> list = new List<string>();
                
                saveFileDialog.ShowDialog();

                list.Add(saveFileDialog.FileName);
                list.Add(VolMax.Text);
                list.Add(VolMin.Text);
                list.Add(ResMax.Text);
                list.Add(ResMin.Text);

                bin.Save(list);
            }
            else
                MessageBox.Show("잘못 입력 하였습니다. 다시 입력해주세요");
        }
    }
}
