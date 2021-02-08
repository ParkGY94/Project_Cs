namespace Power_Simulator
{
    partial class LogForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeTimeForCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresentCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sampling = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mean_V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mean_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Open = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Txt_filepath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTime,
            this.RelativeTimeForCycle,
            this.RelativeTime,
            this.Ch,
            this.PresentCycle,
            this.TotalCycle,
            this.Sampling,
            this.Type,
            this.SetV,
            this.SetC,
            this.LimC,
            this.Mean_V,
            this.Mean_C});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(7, 85);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1263, 706);
            this.dataGridView1.TabIndex = 0;
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "DateTime";
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            this.DateTime.Width = 165;
            // 
            // RelativeTimeForCycle
            // 
            this.RelativeTimeForCycle.HeaderText = "RelativeTimeForCycle(sec)";
            this.RelativeTimeForCycle.Name = "RelativeTimeForCycle";
            this.RelativeTimeForCycle.ReadOnly = true;
            this.RelativeTimeForCycle.Width = 165;
            // 
            // RelativeTime
            // 
            this.RelativeTime.HeaderText = "RelativeTime(sec)";
            this.RelativeTime.Name = "RelativeTime";
            this.RelativeTime.ReadOnly = true;
            this.RelativeTime.Width = 110;
            // 
            // Ch
            // 
            this.Ch.HeaderText = "Ch";
            this.Ch.Name = "Ch";
            this.Ch.ReadOnly = true;
            this.Ch.Width = 50;
            // 
            // PresentCycle
            // 
            this.PresentCycle.HeaderText = "PresentCycle(회)";
            this.PresentCycle.Name = "PresentCycle";
            this.PresentCycle.ReadOnly = true;
            this.PresentCycle.Width = 110;
            // 
            // TotalCycle
            // 
            this.TotalCycle.HeaderText = "TotalCycle(회)";
            this.TotalCycle.Name = "TotalCycle";
            this.TotalCycle.ReadOnly = true;
            this.TotalCycle.Width = 115;
            // 
            // Sampling
            // 
            this.Sampling.HeaderText = "Sampling(ms)";
            this.Sampling.Name = "Sampling";
            this.Sampling.ReadOnly = true;
            this.Sampling.Width = 90;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 75;
            // 
            // SetV
            // 
            this.SetV.HeaderText = "SetV(V)";
            this.SetV.Name = "SetV";
            this.SetV.ReadOnly = true;
            this.SetV.Width = 75;
            // 
            // SetC
            // 
            this.SetC.HeaderText = "SetC(A)";
            this.SetC.Name = "SetC";
            this.SetC.ReadOnly = true;
            this.SetC.Width = 75;
            // 
            // LimC
            // 
            this.LimC.HeaderText = "LimC(A)";
            this.LimC.Name = "LimC";
            this.LimC.ReadOnly = true;
            this.LimC.Width = 75;
            // 
            // Mean_V
            // 
            this.Mean_V.HeaderText = "Meas_V(V)";
            this.Mean_V.Name = "Mean_V";
            this.Mean_V.ReadOnly = true;
            this.Mean_V.Width = 75;
            // 
            // Mean_C
            // 
            this.Mean_C.HeaderText = "Meas_C(A)";
            this.Mean_C.Name = "Mean_C";
            this.Mean_C.ReadOnly = true;
            this.Mean_C.Width = 75;
            // 
            // BTN_Open
            // 
            this.BTN_Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.BTN_Open.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Open.ForeColor = System.Drawing.Color.White;
            this.BTN_Open.Location = new System.Drawing.Point(10, 10);
            this.BTN_Open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Open.Name = "BTN_Open";
            this.BTN_Open.Size = new System.Drawing.Size(112, 59);
            this.BTN_Open.TabIndex = 1;
            this.BTN_Open.Text = "열기";
            this.BTN_Open.UseVisualStyleBackColor = false;
            this.BTN_Open.Click += new System.EventHandler(this.BTN_Open_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "csv 파일 (*.csv)|*.csv|엑셀 파일 (*.xlsx)|*.xlsx|엑셀 파일 (*.xls)|*.xls";
            // 
            // Txt_filepath
            // 
            this.Txt_filepath.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Txt_filepath.Location = new System.Drawing.Point(137, 17);
            this.Txt_filepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_filepath.Name = "Txt_filepath";
            this.Txt_filepath.Size = new System.Drawing.Size(849, 39);
            this.Txt_filepath.TabIndex = 2;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 802);
            this.Controls.Add(this.Txt_filepath);
            this.Controls.Add(this.BTN_Open);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogForm";
            this.Text = "LogForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTN_Open;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox Txt_filepath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativeTimeForCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ch;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresentCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sampling;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mean_V;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mean_C;
    }
}