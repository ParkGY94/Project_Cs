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
    public partial class LogForm : Form
    {
        logFile logfile;
        public LogForm()
        {
            InitializeComponent();
            logfile = new logFile();
        }

        private void BTN_FileOpen_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                filepath.Text = filename;
                dataGridView1.DataSource = logfile.load(filename,true);
                for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    dataGridView1[0, i].Value = i + 1;
                }
            }
            /*List<string> value = new List<string>();
            string[] data = new string[7];

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath.Text = openFileDialog1.FileName;
                value = logfile.load(openFileDialog1.FileName);
                dataGridView1.RowCount = value.Count - 1;

                for(int i = 0; i < value.Count-1; i++)
                {
                    data = value[i + 1].Split(',');
                    for(int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = data[j];
                    }
                }
            }*/
        }
    }
}
