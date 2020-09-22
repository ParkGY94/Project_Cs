namespace Analog_Digit
{
    partial class AutoForm
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
            this.components = new System.ComponentModel.Container();
            this.BTN_FileOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.file_path = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.filepath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ResMax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ResMin = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.VolMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.VolMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.측정값 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.결과 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.IncCnt = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.CorCnt = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TotalCnt = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.AnalogInput = new System.Windows.Forms.TextBox();
            this.BTN_Set = new System.Windows.Forms.Button();
            this.voltagevalue = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.AnalogTImer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Hioki3540 = new System.IO.Ports.SerialPort(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.myledbulb8 = new Ledbulb.Myledbulb();
            this.myledbulb7 = new Ledbulb.Myledbulb();
            this.myledbulb6 = new Ledbulb.Myledbulb();
            this.myledbulb5 = new Ledbulb.Myledbulb();
            this.myledbulb4 = new Ledbulb.Myledbulb();
            this.myledbulb3 = new Ledbulb.Myledbulb();
            this.myledbulb2 = new Ledbulb.Myledbulb();
            this.myledbulb1 = new Ledbulb.Myledbulb();
            this.label34 = new System.Windows.Forms.Label();
            this.DigitalTImer = new System.Windows.Forms.Timer(this.components);
            this.panel12 = new System.Windows.Forms.Panel();
            this.StateMsg = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.BTN_Measue = new System.Windows.Forms.Button();
            this.MeasureTimer = new System.Windows.Forms.Timer(this.components);
            this.Error = new System.Windows.Forms.Timer(this.components);
            this.Resistance = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.BTN_AutoOn = new System.Windows.Forms.Button();
            this.BTN_AutoOff = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voltagevalue)).BeginInit();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_FileOpen
            // 
            this.BTN_FileOpen.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.BTN_FileOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_FileOpen.Location = new System.Drawing.Point(22, 27);
            this.BTN_FileOpen.Name = "BTN_FileOpen";
            this.BTN_FileOpen.Size = new System.Drawing.Size(101, 62);
            this.BTN_FileOpen.TabIndex = 7;
            this.BTN_FileOpen.Text = "Open";
            this.BTN_FileOpen.UseVisualStyleBackColor = true;
            this.BTN_FileOpen.Click += new System.EventHandler(this.BTN_FileOpen_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.path);
            this.panel1.Controls.Add(this.file_path);
            this.panel1.Controls.Add(this.filepath);
            this.panel1.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(141, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 45);
            this.panel1.TabIndex = 6;
            // 
            // file_path
            // 
            this.file_path.AutoSize = true;
            this.file_path.Location = new System.Drawing.Point(9, 1);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(0, 38);
            this.file_path.TabIndex = 4;
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.path.Location = new System.Drawing.Point(9, 1);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 38);
            this.path.TabIndex = 3;
            // 
            // filepath
            // 
            this.filepath.AutoSize = true;
            this.filepath.Location = new System.Drawing.Point(3, 1);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(0, 38);
            this.filepath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(141, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(476, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 46);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ω";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(270, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "Max";
            // 
            // ResMax
            // 
            this.ResMax.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ResMax.Location = new System.Drawing.Point(340, 273);
            this.ResMax.Name = "ResMax";
            this.ResMax.Size = new System.Drawing.Size(133, 52);
            this.ResMax.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(221, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 46);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ω";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(23, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 28);
            this.label14.TabIndex = 4;
            this.label14.Text = "Min";
            // 
            // ResMin
            // 
            this.ResMin.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ResMin.Location = new System.Drawing.Point(86, 273);
            this.ResMin.Name = "ResMin";
            this.ResMin.Size = new System.Drawing.Size(129, 52);
            this.ResMin.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(22, 231);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(193, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "Resistance Max/Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(479, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 46);
            this.label11.TabIndex = 8;
            this.label11.Text = "V";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(270, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 28);
            this.label12.TabIndex = 7;
            this.label12.Text = "Max";
            // 
            // VolMax
            // 
            this.VolMax.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VolMax.Location = new System.Drawing.Point(340, 152);
            this.VolMax.Name = "VolMax";
            this.VolMax.Size = new System.Drawing.Size(133, 52);
            this.VolMax.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(221, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 46);
            this.label10.TabIndex = 5;
            this.label10.Text = "V";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("돋움", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(23, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 28);
            this.label9.TabIndex = 4;
            this.label9.Text = "Min";
            // 
            // VolMin
            // 
            this.VolMin.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.VolMin.Location = new System.Drawing.Point(86, 149);
            this.VolMin.Name = "VolMin";
            this.VolMin.Size = new System.Drawing.Size(129, 52);
            this.VolMin.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(22, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Voltage Max/Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(22, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Data";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(22, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 291);
            this.panel2.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.측정값,
            this.결과});
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(501, 283);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // 측정값
            // 
            this.측정값.HeaderText = "측청값";
            this.측정값.Name = "측정값";
            this.측정값.ReadOnly = true;
            this.측정값.Width = 130;
            // 
            // 결과
            // 
            this.결과.HeaderText = "결과";
            this.결과.Name = "결과";
            this.결과.ReadOnly = true;
            this.결과.Width = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(621, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Accuracy Count";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(549, 137);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 77);
            this.panel5.TabIndex = 15;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.IncCnt);
            this.panel8.Controls.Add(this.label20);
            this.panel8.Location = new System.Drawing.Point(210, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(99, 71);
            this.panel8.TabIndex = 16;
            // 
            // IncCnt
            // 
            this.IncCnt.AutoSize = true;
            this.IncCnt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IncCnt.ForeColor = System.Drawing.Color.Black;
            this.IncCnt.Location = new System.Drawing.Point(30, 27);
            this.IncCnt.Name = "IncCnt";
            this.IncCnt.Size = new System.Drawing.Size(38, 45);
            this.IncCnt.TabIndex = 1;
            this.IncCnt.Text = "0";
            this.IncCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Aqua;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 27);
            this.label20.TabIndex = 0;
            this.label20.Text = "Incorrect";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.CorCnt);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Location = new System.Drawing.Point(108, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(96, 71);
            this.panel7.TabIndex = 16;
            // 
            // CorCnt
            // 
            this.CorCnt.AutoSize = true;
            this.CorCnt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CorCnt.ForeColor = System.Drawing.Color.Black;
            this.CorCnt.Location = new System.Drawing.Point(30, 27);
            this.CorCnt.Name = "CorCnt";
            this.CorCnt.Size = new System.Drawing.Size(38, 45);
            this.CorCnt.TabIndex = 1;
            this.CorCnt.Text = "0";
            this.CorCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Aqua;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.Yellow;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 27);
            this.label18.TabIndex = 0;
            this.label18.Text = "Correct";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.TotalCnt);
            this.panel6.Controls.Add(this.Total);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(99, 71);
            this.panel6.TabIndex = 0;
            // 
            // TotalCnt
            // 
            this.TotalCnt.AutoSize = true;
            this.TotalCnt.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TotalCnt.ForeColor = System.Drawing.Color.Black;
            this.TotalCnt.Location = new System.Drawing.Point(30, 27);
            this.TotalCnt.Name = "TotalCnt";
            this.TotalCnt.Size = new System.Drawing.Size(38, 45);
            this.TotalCnt.TabIndex = 1;
            this.TotalCnt.Text = "0";
            this.TotalCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.Color.Aqua;
            this.Total.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Total.ForeColor = System.Drawing.Color.Magenta;
            this.Total.Location = new System.Drawing.Point(0, 0);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(99, 27);
            this.Total.TabIndex = 0;
            this.Total.Text = "Total";
            this.Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.Blue;
            this.label26.Location = new System.Drawing.Point(657, 231);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(78, 25);
            this.label26.TabIndex = 2;
            this.label26.Text = "HIKOKI";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.Location = new System.Drawing.Point(573, 507);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 38);
            this.label22.TabIndex = 13;
            this.label22.Text = "AI";
            // 
            // AnalogInput
            // 
            this.AnalogInput.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AnalogInput.Location = new System.Drawing.Point(639, 504);
            this.AnalogInput.Name = "AnalogInput";
            this.AnalogInput.Size = new System.Drawing.Size(213, 43);
            this.AnalogInput.TabIndex = 12;
            // 
            // BTN_Set
            // 
            this.BTN_Set.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Set.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Set.Location = new System.Drawing.Point(748, 452);
            this.BTN_Set.Name = "BTN_Set";
            this.BTN_Set.Size = new System.Drawing.Size(104, 42);
            this.BTN_Set.TabIndex = 11;
            this.BTN_Set.Text = "Update";
            this.BTN_Set.UseVisualStyleBackColor = true;
            this.BTN_Set.Click += new System.EventHandler(this.BTN_Set_Click);
            // 
            // voltagevalue
            // 
            this.voltagevalue.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.voltagevalue.Location = new System.Drawing.Point(639, 459);
            this.voltagevalue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.voltagevalue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.voltagevalue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.voltagevalue.Name = "voltagevalue";
            this.voltagevalue.Size = new System.Drawing.Size(96, 28);
            this.voltagevalue.TabIndex = 10;
            this.voltagevalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(613, 415);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(205, 25);
            this.label24.TabIndex = 2;
            this.label24.Text = "Analog Input/Output";
            // 
            // AnalogTImer
            // 
            this.AnalogTImer.Enabled = true;
            this.AnalogTImer.Tick += new System.EventHandler(this.AnalogTImer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Hioki3540
            // 
            this.Hioki3540.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Hioki3540_DataReceived);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(821, 670);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 25);
            this.label8.TabIndex = 53;
            this.label8.Text = "7";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(786, 670);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 25);
            this.label17.TabIndex = 52;
            this.label17.Text = "6";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(751, 670);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 25);
            this.label19.TabIndex = 51;
            this.label19.Text = "5";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.Location = new System.Drawing.Point(719, 670);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(23, 25);
            this.label27.TabIndex = 50;
            this.label27.Text = "4";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.Location = new System.Drawing.Point(686, 670);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 25);
            this.label28.TabIndex = 49;
            this.label28.Text = "3";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.Location = new System.Drawing.Point(649, 669);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 25);
            this.label29.TabIndex = 48;
            this.label29.Text = "2";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.Location = new System.Drawing.Point(613, 670);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(23, 25);
            this.label30.TabIndex = 47;
            this.label30.Text = "1";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.Location = new System.Drawing.Point(576, 670);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 25);
            this.label31.TabIndex = 46;
            this.label31.Text = "0";
            // 
            // myledbulb8
            // 
            this.myledbulb8.DrawRectangle = false;
            this.myledbulb8.Location = new System.Drawing.Point(817, 629);
            this.myledbulb8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb8.Name = "myledbulb8";
            this.myledbulb8.On = true;
            this.myledbulb8.Size = new System.Drawing.Size(35, 28);
            this.myledbulb8.TabIndex = 45;
            this.myledbulb8.TextX = 0F;
            this.myledbulb8.TextY = 0F;
            this.myledbulb8.UserText = null;
            // 
            // myledbulb7
            // 
            this.myledbulb7.DrawRectangle = false;
            this.myledbulb7.Location = new System.Drawing.Point(783, 629);
            this.myledbulb7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb7.Name = "myledbulb7";
            this.myledbulb7.On = true;
            this.myledbulb7.Size = new System.Drawing.Size(35, 28);
            this.myledbulb7.TabIndex = 44;
            this.myledbulb7.TextX = 0F;
            this.myledbulb7.TextY = 0F;
            this.myledbulb7.UserText = null;
            // 
            // myledbulb6
            // 
            this.myledbulb6.DrawRectangle = false;
            this.myledbulb6.Location = new System.Drawing.Point(748, 629);
            this.myledbulb6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb6.Name = "myledbulb6";
            this.myledbulb6.On = true;
            this.myledbulb6.Size = new System.Drawing.Size(35, 28);
            this.myledbulb6.TabIndex = 43;
            this.myledbulb6.TextX = 0F;
            this.myledbulb6.TextY = 0F;
            this.myledbulb6.UserText = null;
            // 
            // myledbulb5
            // 
            this.myledbulb5.DrawRectangle = false;
            this.myledbulb5.Location = new System.Drawing.Point(716, 629);
            this.myledbulb5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb5.Name = "myledbulb5";
            this.myledbulb5.On = true;
            this.myledbulb5.Size = new System.Drawing.Size(35, 28);
            this.myledbulb5.TabIndex = 42;
            this.myledbulb5.TextX = 0F;
            this.myledbulb5.TextY = 0F;
            this.myledbulb5.UserText = null;
            // 
            // myledbulb4
            // 
            this.myledbulb4.DrawRectangle = false;
            this.myledbulb4.Location = new System.Drawing.Point(681, 629);
            this.myledbulb4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb4.Name = "myledbulb4";
            this.myledbulb4.On = true;
            this.myledbulb4.Size = new System.Drawing.Size(35, 28);
            this.myledbulb4.TabIndex = 41;
            this.myledbulb4.TextX = 0F;
            this.myledbulb4.TextY = 0F;
            this.myledbulb4.UserText = null;
            // 
            // myledbulb3
            // 
            this.myledbulb3.DrawRectangle = false;
            this.myledbulb3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.myledbulb3.Location = new System.Drawing.Point(645, 629);
            this.myledbulb3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb3.Name = "myledbulb3";
            this.myledbulb3.On = true;
            this.myledbulb3.Size = new System.Drawing.Size(35, 28);
            this.myledbulb3.TabIndex = 40;
            this.myledbulb3.TextX = 0F;
            this.myledbulb3.TextY = 0F;
            this.myledbulb3.UserText = null;
            // 
            // myledbulb2
            // 
            this.myledbulb2.DrawRectangle = false;
            this.myledbulb2.Location = new System.Drawing.Point(608, 629);
            this.myledbulb2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb2.Name = "myledbulb2";
            this.myledbulb2.On = true;
            this.myledbulb2.Size = new System.Drawing.Size(35, 28);
            this.myledbulb2.TabIndex = 39;
            this.myledbulb2.TextX = 0F;
            this.myledbulb2.TextY = 0F;
            this.myledbulb2.UserText = null;
            // 
            // myledbulb1
            // 
            this.myledbulb1.DrawRectangle = false;
            this.myledbulb1.Location = new System.Drawing.Point(573, 629);
            this.myledbulb1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myledbulb1.Name = "myledbulb1";
            this.myledbulb1.On = true;
            this.myledbulb1.Size = new System.Drawing.Size(35, 28);
            this.myledbulb1.TabIndex = 38;
            this.myledbulb1.TextX = 0F;
            this.myledbulb1.TextY = 0F;
            this.myledbulb1.UserText = null;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(672, 584);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 25);
            this.label34.TabIndex = 2;
            this.label34.Text = "Digital";
            // 
            // DigitalTImer
            // 
            this.DigitalTImer.Enabled = true;
            this.DigitalTImer.Tick += new System.EventHandler(this.DigitalTImer_Tick);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.Window;
            this.panel12.Controls.Add(this.StateMsg);
            this.panel12.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel12.Location = new System.Drawing.Point(22, 378);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(508, 82);
            this.panel12.TabIndex = 63;
            // 
            // StateMsg
            // 
            this.StateMsg.AutoSize = true;
            this.StateMsg.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StateMsg.Location = new System.Drawing.Point(13, 37);
            this.StateMsg.Name = "StateMsg";
            this.StateMsg.Size = new System.Drawing.Size(0, 45);
            this.StateMsg.TabIndex = 0;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label39.ForeColor = System.Drawing.Color.Blue;
            this.label39.Location = new System.Drawing.Point(22, 353);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(104, 25);
            this.label39.TabIndex = 2;
            this.label39.Text = "Statement";
            // 
            // BTN_Measue
            // 
            this.BTN_Measue.Enabled = false;
            this.BTN_Measue.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Measue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Measue.Location = new System.Drawing.Point(608, 723);
            this.BTN_Measue.Name = "BTN_Measue";
            this.BTN_Measue.Size = new System.Drawing.Size(192, 51);
            this.BTN_Measue.TabIndex = 64;
            this.BTN_Measue.Text = "Measure Start";
            this.BTN_Measue.UseVisualStyleBackColor = true;
            this.BTN_Measue.Click += new System.EventHandler(this.BTN_Measue_Click);
            // 
            // MeasureTimer
            // 
            this.MeasureTimer.Enabled = true;
            this.MeasureTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Error
            // 
            this.Error.Enabled = true;
            this.Error.Tick += new System.EventHandler(this.Error_Tick);
            // 
            // Resistance
            // 
            this.Resistance.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Resistance.Location = new System.Drawing.Point(598, 270);
            this.Resistance.Name = "Resistance";
            this.Resistance.Size = new System.Drawing.Size(186, 52);
            this.Resistance.TabIndex = 7;
            this.Resistance.TextChanged += new System.EventHandler(this.Resistance_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(790, 273);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 46);
            this.label21.TabIndex = 9;
            this.label21.Text = "Ω";
            // 
            // BTN_AutoOn
            // 
            this.BTN_AutoOn.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AutoOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_AutoOn.Location = new System.Drawing.Point(574, 336);
            this.BTN_AutoOn.Name = "BTN_AutoOn";
            this.BTN_AutoOn.Size = new System.Drawing.Size(127, 42);
            this.BTN_AutoOn.TabIndex = 12;
            this.BTN_AutoOn.Text = "AutoOn";
            this.BTN_AutoOn.UseVisualStyleBackColor = true;
            this.BTN_AutoOn.Click += new System.EventHandler(this.BTN_AutoOn_Click);
            // 
            // BTN_AutoOff
            // 
            this.BTN_AutoOff.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AutoOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_AutoOff.Location = new System.Drawing.Point(725, 336);
            this.BTN_AutoOff.Name = "BTN_AutoOff";
            this.BTN_AutoOff.Size = new System.Drawing.Size(127, 42);
            this.BTN_AutoOff.TabIndex = 13;
            this.BTN_AutoOff.Text = "AutoOff";
            this.BTN_AutoOff.UseVisualStyleBackColor = true;
            this.BTN_AutoOff.Click += new System.EventHandler(this.BTN_AutoOff_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(566, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 38);
            this.label4.TabIndex = 65;
            this.label4.Text = "AO";
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 800);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BTN_AutoOff);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.AnalogInput);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.BTN_Set);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.BTN_AutoOn);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.voltagevalue);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.myledbulb8);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.myledbulb7);
            this.Controls.Add(this.BTN_Measue);
            this.Controls.Add(this.myledbulb6);
            this.Controls.Add(this.Resistance);
            this.Controls.Add(this.myledbulb5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.myledbulb4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.myledbulb3);
            this.Controls.Add(this.ResMin);
            this.Controls.Add(this.myledbulb2);
            this.Controls.Add(this.myledbulb1);
            this.Controls.Add(this.ResMax);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.VolMax);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.VolMin);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.BTN_FileOpen);
            this.Controls.Add(this.panel1);
            this.Name = "AutoForm";
            this.Text = "AutoTest";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voltagevalue)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_FileOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ResMax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ResMin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox VolMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox VolMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label TotalCnt;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label IncCnt;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label CorCnt;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown voltagevalue;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button BTN_Set;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox AnalogInput;
        private System.Windows.Forms.Timer AnalogTImer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.Ports.SerialPort Hioki3540;
        private System.Windows.Forms.Label file_path;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private Ledbulb.Myledbulb myledbulb8;
        private Ledbulb.Myledbulb myledbulb7;
        private Ledbulb.Myledbulb myledbulb6;
        private Ledbulb.Myledbulb myledbulb5;
        private Ledbulb.Myledbulb myledbulb4;
        private Ledbulb.Myledbulb myledbulb3;
        private Ledbulb.Myledbulb myledbulb2;
        private Ledbulb.Myledbulb myledbulb1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Timer DigitalTImer;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label StateMsg;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 측정값;
        private System.Windows.Forms.DataGridViewTextBoxColumn 결과;
        private System.Windows.Forms.Button BTN_Measue;
        private System.Windows.Forms.Timer MeasureTimer;
        private System.Windows.Forms.Timer Error;
        private System.Windows.Forms.TextBox Resistance;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button BTN_AutoOn;
        private System.Windows.Forms.Button BTN_AutoOff;
        private System.Windows.Forms.Label label4;
    }
}