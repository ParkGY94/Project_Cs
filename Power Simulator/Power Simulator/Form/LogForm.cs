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
    public partial class LogForm : Form
    {
        CSV csv;
        public LogForm()
        {
            InitializeComponent();
            csv = new CSV();
        }

        private void BTN_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                Txt_filepath.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName); ;

                string[] datalog = new string[7];
                List<string> value = new List<string>();

                if (csv.load(openFileDialog.FileName).Count > 0)
                {
                    try
                    {
                        value = csv.load(openFileDialog.FileName);
                        dataGridView1.RowCount = value.Count;

                        for (int i = 0; i < value.Count - 1; i++)
                        {
                            datalog = value[i + 1].Split(',');
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                dataGridView1.Rows[i].Cells[j].Value = datalog[j];
                        }
                    }
                    catch
                    {
                        MessageBox.Show("잘못된 파일입니다. 로그파일을 불러오세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
