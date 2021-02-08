namespace Power_Simulator
{
    partial class ProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_Open = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_RowDecrease = new System.Windows.Forms.Button();
            this.BTN_RowIncrease = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_LimC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_Voltage = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTN_Confirm = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Save
            // 
            this.BTN_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.BTN_Save.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Save.ForeColor = System.Drawing.Color.White;
            this.BTN_Save.Location = new System.Drawing.Point(29, 15);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(160, 58);
            this.BTN_Save.TabIndex = 5;
            this.BTN_Save.Text = "저장";
            this.BTN_Save.UseVisualStyleBackColor = false;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_Open
            // 
            this.BTN_Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.BTN_Open.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Open.ForeColor = System.Drawing.Color.White;
            this.BTN_Open.Location = new System.Drawing.Point(206, 15);
            this.BTN_Open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Open.Name = "BTN_Open";
            this.BTN_Open.Size = new System.Drawing.Size(160, 58);
            this.BTN_Open.TabIndex = 6;
            this.BTN_Open.Text = "열기";
            this.BTN_Open.UseVisualStyleBackColor = false;
            this.BTN_Open.Click += new System.EventHandler(this.BTN_Open_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 11);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "전류";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1170, 361);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BTN_RowDecrease);
            this.panel1.Controls.Add(this.BTN_RowIncrease);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Txt_LimC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rb_Voltage);
            this.panel1.Location = new System.Drawing.Point(29, 474);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 301);
            this.panel1.TabIndex = 8;
            // 
            // BTN_RowDecrease
            // 
            this.BTN_RowDecrease.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_RowDecrease.Location = new System.Drawing.Point(55, 226);
            this.BTN_RowDecrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_RowDecrease.Name = "BTN_RowDecrease";
            this.BTN_RowDecrease.Size = new System.Drawing.Size(122, 53);
            this.BTN_RowDecrease.TabIndex = 17;
            this.BTN_RowDecrease.Text = "데이터 삭제";
            this.BTN_RowDecrease.UseVisualStyleBackColor = true;
            this.BTN_RowDecrease.Click += new System.EventHandler(this.BTN_RowDecrease_Click);
            // 
            // BTN_RowIncrease
            // 
            this.BTN_RowIncrease.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_RowIncrease.Location = new System.Drawing.Point(55, 146);
            this.BTN_RowIncrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_RowIncrease.Name = "BTN_RowIncrease";
            this.BTN_RowIncrease.Size = new System.Drawing.Size(122, 53);
            this.BTN_RowIncrease.TabIndex = 1;
            this.BTN_RowIncrease.Text = "데이터 추가";
            this.BTN_RowIncrease.UseVisualStyleBackColor = true;
            this.BTN_RowIncrease.Click += new System.EventHandler(this.BTN_RowIncrease_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(190, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "A";
            // 
            // Txt_LimC
            // 
            this.Txt_LimC.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Txt_LimC.Location = new System.Drawing.Point(111, 87);
            this.Txt_LimC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_LimC.Name = "Txt_LimC";
            this.Txt_LimC.Size = new System.Drawing.Size(66, 26);
            this.Txt_LimC.TabIndex = 12;
            this.Txt_LimC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(13, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Limit 전류";
            // 
            // rb_Voltage
            // 
            this.rb_Voltage.AutoSize = true;
            this.rb_Voltage.Checked = true;
            this.rb_Voltage.Location = new System.Drawing.Point(41, 51);
            this.rb_Voltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_Voltage.Name = "rb_Voltage";
            this.rb_Voltage.Size = new System.Drawing.Size(59, 16);
            this.rb_Voltage.TabIndex = 0;
            this.rb_Voltage.TabStop = true;
            this.rb_Voltage.Text = "정전압";
            this.rb_Voltage.UseVisualStyleBackColor = true;
            this.rb_Voltage.CheckedChanged += new System.EventHandler(this.rb_Voltage_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(306, 474);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 301);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(661, 295);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // BTN_Confirm
            // 
            this.BTN_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.BTN_Confirm.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Confirm.ForeColor = System.Drawing.Color.White;
            this.BTN_Confirm.Location = new System.Drawing.Point(914, 11);
            this.BTN_Confirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Confirm.Name = "BTN_Confirm";
            this.BTN_Confirm.Size = new System.Drawing.Size(145, 58);
            this.BTN_Confirm.TabIndex = 10;
            this.BTN_Confirm.Text = "확인";
            this.BTN_Confirm.UseVisualStyleBackColor = false;
            this.BTN_Confirm.Click += new System.EventHandler(this.BTN_Confirm_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.BTN_Cancel.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.White;
            this.BTN_Cancel.Location = new System.Drawing.Point(1065, 11);
            this.BTN_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(145, 58);
            this.BTN_Cancel.TabIndex = 11;
            this.BTN_Cancel.Text = "취소";
            this.BTN_Cancel.UseVisualStyleBackColor = false;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "csv 파일 (*.csv)|*.csv|엑셀 파일 (*.xlsx)|*.xlsx|엑셀 파일 (*.xls)|*.xls";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Location = new System.Drawing.Point(29, 78);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1179, 381);
            this.panel3.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "시간(ms)";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "시간(s)";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "전압(V)";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "파형유형";
            this.Column4.Name = "Column4";
            this.Column4.Width = 225;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 801);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Confirm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTN_Open);
            this.Controls.Add(this.BTN_Save);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Open;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rb_Voltage;
        private System.Windows.Forms.Button BTN_Confirm;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_LimC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_RowDecrease;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTN_RowIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}