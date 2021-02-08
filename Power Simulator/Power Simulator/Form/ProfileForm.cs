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
    public partial class ProfileForm : Form
    {
        CSV csv;
        DataGridViewComboBoxCell cCell;
        public int RowCount;
        public ProfileForm()
        {
            InitializeComponent();
            csv = new CSV();

            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RowCount = 1;
            dataGridView1.RowCount = RowCount;
            dataGridView1.Rows[RowCount - 1].Cells[0].Value = RowCount;
            cCell = new DataGridViewComboBoxCell();
            cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cCell.Items.Add("SQUARE");
            cCell.Items.Add("RAMP");
            dataGridView1.Rows[RowCount - 1].Cells[4] = cCell;
        }

        private void BTN_RowIncrease_Click(object sender, EventArgs e)
        {
            RowCount++;
            dataGridView1.RowCount = RowCount;
            dataGridView1.Rows[RowCount - 1].Cells[0].Value = RowCount;
            cCell = new DataGridViewComboBoxCell();
            cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cCell.Items.Add("SQUARE");
            cCell.Items.Add("RAMP");
            dataGridView1.Rows[RowCount - 1].Cells[4] = cCell;
        }

        private void BTN_RowDecrease_Click(object sender, EventArgs e)
        {
            if(RowCount > 1)
            {
                RowCount--;
                dataGridView1.RowCount = RowCount;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    dataGridView1.Rows[0].Cells[i+1].Value = "";
                }
            }
        }

        private void BTN_Confirm_Click(object sender, EventArgs e)
        {
            //double a = 0;
            for(int i = 0; i < RowCount; i++)
            {
                for(int j= 0; j < 5; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "")
                    {
                        MessageBox.Show("값을 모두 입력해주세요", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    /*if(!Double.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(),out a))
                    {
                        MessageBox.Show("값을 확인해주세요", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }*/
                }
            }
            chart1.Series.Clear();
            chart1.Series.Add("전압");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].BorderWidth = 2;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.Series[0].Color = Color.Red;

            for (int i = 0; i < RowCount; i++)
            {
                switch (dataGridView1.Rows[i].Cells[4].Value.ToString())
                {
                    case "SQUARE":
                        if (i > 0)
                        {
                            /*DateTime starttime = DateTime.Now;
                            chart1.Series[0].Points.AddXY(Convert.ToDouble(dataGridView1.Rows[i-1].Cells[1].Value),Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                            while (true)
                            {
                                Application.DoEvents();
                                DateTime presenttime = DateTime.Now;
                                chart1.Series[0].Points.AddXY(Convert.ToDouble((presenttime - starttime).ToString("ss") + Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[1].Value)), Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                                
                                if (presenttime - starttime >= TimeSpan.FromSeconds(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value) - Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[1].Value)))
                                {
                                    break;
                                }
                            }*/
                            //chart1.Series[0].Points.AddXY(Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[1].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                            double time = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[2].Value);
                            double endtime = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                            while (time <= endtime)
                            {
                                chart1.Series[0].Points.AddXY(time, Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
                                time++;
                                if (time == endtime + 1)
                                {
                                    break;
                                }
                                else if (time > endtime)
                                    time = endtime;
                            }
                        }
                        else
                        {
                            /*DateTime starttime = DateTime.Now;
                            chart1.Series[0].Points.AddY(0);
                            while (true)
                            {
                                Application.DoEvents();
                                DateTime presenttime = DateTime.Now;
                                chart1.Series[0].Points.AddXY(Convert.ToDouble((presenttime - starttime).ToString("ss")), Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                                if (presenttime - starttime >= TimeSpan.FromSeconds(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value)))
                                {
                                    break;
                                }
                            }*/
                            chart1.Series[0].Points.AddY(0);
                            double time = 0;
                            double endtime = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                            while (time <= endtime)
                            {
                                chart1.Series[0].Points.AddXY(time, Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
                                time++;
                                if (time == endtime + 1)
                                {
                                    break;
                                }
                                else if (time > endtime)
                                    time = endtime;
                            }
                        }
                        break;
                    case "RAMP":
                        if (i > 0)
                        {
                            double starttime = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[2].Value);
                            double time = Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[2].Value);
                            double endtime = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                            while (time <= endtime)
                            {
                                chart1.Series[0].Points.AddXY(time, (Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[3].Value)) + (time - starttime) * ((Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) - Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[3].Value))
                                / (Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) - Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[2].Value))));
                                
                                time++;
                                if (time == endtime + 1)
                                {
                                    break;
                                }
                                else if (time > endtime)
                                    time = endtime;
                            }
                        }
                        else
                        {
                            //chart1.Series[0].Points.AddY(0);
                            double time = 0;
                            double endtime = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                            while (time <= endtime)
                            {
                                chart1.Series[0].Points.AddXY(time, time*(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)/Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value)));
                                time++;
                                if (time == endtime + 1)
                                {
                                    break;
                                }
                                else if (time > endtime)
                                    time = endtime;
                            }
                        }
                        break;
                }
            }
            //chart1.Series[0].Points.AddXY(Convert.ToDouble(dataGridView1.Rows[RowCount - 1].Cells[1].Value), 0);
        }

        private void rb_Voltage_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Voltage.Checked)
            {
                dataGridView1.Columns[2].HeaderText = "전압(V)";
                chart1.Series[0].Name = "전압";
                Txt_LimC.ReadOnly = false;
            }
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    try
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "")
                        {
                            MessageBox.Show("데이터를 모두 입력해주세요");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("데이터를 모두 입력해주세요");
                        return;
                    }
                }
            }
            
            List<string> list = new List<string>();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                if (filename.Length > 0)
                {
                    for (int i = 0; i < RowCount; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            list.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        csv.saveProfile(list, filename);
                        list.Clear();
                    }
                    list.Add("");
                    list.Add("세팅");
                    list.Add("정전압");
                    list.Add("Lim_C");
                    list.Add(Txt_LimC.Text);
                    csv.saveProfile(list, filename);
                    list.Clear();
                }
                chart1.SaveImage(filename + ".png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);    
            }
        }

        private void BTN_Open_Click(object sender, EventArgs e)
        {
            string[] datalog = new string[5];
            List<string> list = new List<string>();
            List<string> value = new List<string>();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                if (csv.load(filename).Count > 0)
                {
                    value = csv.load(filename);

                    chart1.Series[0].BorderWidth = 2;
                    chart1.Series[0].Color = Color.Red;

                    dataGridView1.Rows.Clear();
                    dataGridView1.RowCount = value.Count - 2;
                    RowCount = dataGridView1.RowCount;
                    for (int i = 0; i < value.Count - 2; i++)
                    {
                        datalog = value[i + 1].Split(',');
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            dataGridView1.Rows[i].Cells[j].Value = datalog[j];
                    }
                    dataGridView1.RowCount = value.Count - 1;
                    datalog = value[value.Count - 1].Split(',');
                    Txt_LimC.Text = datalog[4];
                    Txt_LimC.ReadOnly = false;
                }
            }
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            RowCount = 1;
            dataGridView1.RowCount = RowCount;
            for(int i = 0; i < 3; i++)
            {
                dataGridView1.Rows[0].Cells[i + 1].Value = "";
            }
            chart1.Series.Add("전압");
            Txt_LimC.Text = "";

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = ((DataGridView)sender).CurrentCell.RowIndex;
            int colIndex = ((DataGridView)sender).CurrentCell.ColumnIndex;
            double sec = 0;
            double outdata;
            
            if(colIndex == 1)
            {
                if(!Double.TryParse(((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value.ToString(), out outdata))
                {
                    MessageBox.Show("값을 올바르게 입력해주세요", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value = null;
                    return;
                }
                sec = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value);
                if (rowIndex > 0 && ((DataGridView)sender).Rows[rowIndex - 1].Cells[colIndex].Value == null)
                {
                    MessageBox.Show("이전 값을 먼저 입력해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value = null;
                    return;
                }
                else if(rowIndex > 0 && ((DataGridView)sender).Rows[rowIndex - 1].Cells[colIndex].Value != null)
                {
                    if(sec <= Convert.ToDouble(((DataGridView)sender).Rows[rowIndex - 1].Cells[colIndex].Value))
                    {
                        MessageBox.Show("이전 값보다 큰 값을 입력해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                        ((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value = null;
                        return;
                    }
                }
                ((DataGridView)sender).Rows[rowIndex].Cells[colIndex + 1].Value = sec / 1000;
            }
            else if (colIndex == 2)
            {
                if (!Double.TryParse(((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value.ToString(), out outdata))
                {
                    MessageBox.Show("값을 올바르게 입력해주세요", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value = null;
                    return;
                }
                sec = Convert.ToDouble(((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value);
                if (rowIndex > 0 && ((DataGridView)sender).Rows[rowIndex - 1].Cells[colIndex].Value == null)
                {
                    MessageBox.Show("이전 값을 먼저 입력해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                    ((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value = null;
                    return;
                }
                else if (rowIndex > 0 && ((DataGridView)sender).Rows[rowIndex - 1].Cells[colIndex].Value != null)
                {
                    if (sec <= Convert.ToDouble(((DataGridView)sender).Rows[rowIndex - 1].Cells[colIndex].Value))
                    {
                        MessageBox.Show("이전 값보다 큰 값을 입력해주세요.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                        ((DataGridView)sender).Rows[rowIndex].Cells[colIndex].Value = null;
                        return;
                    }
                }
                ((DataGridView)sender).Rows[rowIndex].Cells[colIndex - 1].Value = sec * 1000;
            }
            
        }
    }
}
