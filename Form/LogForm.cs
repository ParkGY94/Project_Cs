using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pressure_Sensor_EOL
{
    public partial class LogForm : Form
    {
        private CSV csv;
        MainForm mainform;
        public LogForm(MainForm mainform_)
        {
            InitializeComponent();
            csv = new CSV();
            mainform = mainform_;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            string[] datalog = new string[7];
            string[] datalog2 = new string[14];
            List<string> value = new List<string>();
            if(mainform.list.Count > 0)
            {
                value = mainform.list;
                dataGridView1.RowCount = value.Count;

                for (int i = 0; i < value.Count - 1; i++)
                {
                    datalog = value[i + 1].Split(',');
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        dataGridView1.Rows[i].Cells[j].Value = datalog[j];
                }
                for (int i = 0; i < value.Count - 1; i++)
                {
                    if (dataGridView1[6, i].Value.ToString() == "OK")
                        dataGridView1[6, i].Style.ForeColor = Color.Blue;
                    else if (dataGridView1[6, i].Value.ToString() == "NG")
                        dataGridView1[6, i].Style.ForeColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                Txt_path.Text = openFileDialog.FileName;
                
                string[] datalog = new string[7];
                string[] datalog2 = new string[14];
                List<string> value = new List<string>();

                if(csv.load(openFileDialog.FileName).Count > 0)
                {
                    value = csv.load(openFileDialog.FileName);
                    dataGridView1.RowCount = value.Count;

                    for (int i = 0; i < value.Count - 1; i++)
                    {
                        datalog = value[i + 1].Split(',');
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            dataGridView1.Rows[i].Cells[j].Value = datalog[j];
                    }
                    for (int i = 0; i < value.Count - 1; i++)
                    {
                        if (dataGridView1[6, i].Value.ToString() == "OK")
                            dataGridView1[6, i].Style.ForeColor = Color.Blue;
                        else if (dataGridView1[6, i].Value.ToString() == "NG")
                            dataGridView1[6, i].Style.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
