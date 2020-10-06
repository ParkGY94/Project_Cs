namespace Sampling
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dockingPannel = new System.Windows.Forms.Panel();
            this.BTN_Data = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.Text_Time = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BTN_Reset = new System.Windows.Forms.Button();
            this.Text_Off_T = new System.Windows.Forms.TextBox();
            this.Text_On_T = new System.Windows.Forms.TextBox();
            this.Text_Duty = new System.Windows.Forms.TextBox();
            this.Text_Freq = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UpDown_Samples = new System.Windows.Forms.NumericUpDown();
            this.UpDown_Freq = new System.Windows.Forms.NumericUpDown();
            this.Text_Vrms = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Open = new System.Windows.Forms.Button();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dockingPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Samples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Freq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(11, 121);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1048, 17);
            this.panel3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 101);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(894, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 71);
            this.label1.TabIndex = 3;
            this.label1.Text = "신입사원 발표 과제#1";
            // 
            // dockingPannel
            // 
            this.dockingPannel.Controls.Add(this.BTN_Data);
            this.dockingPannel.Controls.Add(this.label16);
            this.dockingPannel.Controls.Add(this.Text_Time);
            this.dockingPannel.Controls.Add(this.label15);
            this.dockingPannel.Controls.Add(this.label14);
            this.dockingPannel.Controls.Add(this.label13);
            this.dockingPannel.Controls.Add(this.label12);
            this.dockingPannel.Controls.Add(this.label11);
            this.dockingPannel.Controls.Add(this.label10);
            this.dockingPannel.Controls.Add(this.label9);
            this.dockingPannel.Controls.Add(this.BTN_Reset);
            this.dockingPannel.Controls.Add(this.Text_Off_T);
            this.dockingPannel.Controls.Add(this.Text_On_T);
            this.dockingPannel.Controls.Add(this.Text_Duty);
            this.dockingPannel.Controls.Add(this.Text_Freq);
            this.dockingPannel.Controls.Add(this.chart1);
            this.dockingPannel.Controls.Add(this.label8);
            this.dockingPannel.Controls.Add(this.label7);
            this.dockingPannel.Controls.Add(this.UpDown_Samples);
            this.dockingPannel.Controls.Add(this.UpDown_Freq);
            this.dockingPannel.Controls.Add(this.Text_Vrms);
            this.dockingPannel.Controls.Add(this.label6);
            this.dockingPannel.Controls.Add(this.label5);
            this.dockingPannel.Controls.Add(this.label4);
            this.dockingPannel.Controls.Add(this.label3);
            this.dockingPannel.Controls.Add(this.label2);
            this.dockingPannel.Controls.Add(this.BTN_Open);
            this.dockingPannel.Controls.Add(this.BTN_Start);
            this.dockingPannel.Location = new System.Drawing.Point(11, 145);
            this.dockingPannel.Name = "dockingPannel";
            this.dockingPannel.Size = new System.Drawing.Size(1048, 645);
            this.dockingPannel.TabIndex = 11;
            // 
            // BTN_Data
            // 
            this.BTN_Data.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Data.Location = new System.Drawing.Point(202, 10);
            this.BTN_Data.Name = "BTN_Data";
            this.BTN_Data.Size = new System.Drawing.Size(144, 54);
            this.BTN_Data.TabIndex = 28;
            this.BTN_Data.Text = "Data";
            this.BTN_Data.UseVisualStyleBackColor = true;
            this.BTN_Data.Click += new System.EventHandler(this.BTN_Data_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(953, 551);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 38);
            this.label16.TabIndex = 27;
            this.label16.Text = "Sec";
            // 
            // Text_Time
            // 
            this.Text_Time.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_Time.Location = new System.Drawing.Point(824, 551);
            this.Text_Time.Name = "Text_Time";
            this.Text_Time.Size = new System.Drawing.Size(115, 38);
            this.Text_Time.TabIndex = 26;
            this.Text_Time.Text = "5";
            this.Text_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(723, 549);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 38);
            this.label15.TabIndex = 25;
            this.label15.Text = "Time";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(973, 414);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 38);
            this.label14.TabIndex = 24;
            this.label14.Text = "Hz";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(973, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 38);
            this.label13.TabIndex = 23;
            this.label13.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(973, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 38);
            this.label12.TabIndex = 22;
            this.label12.Text = "Sec";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(973, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 38);
            this.label11.TabIndex = 21;
            this.label11.Text = "Sec";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(973, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 38);
            this.label10.TabIndex = 20;
            this.label10.Text = "Hz";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(973, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 38);
            this.label9.TabIndex = 19;
            this.label9.Text = "V";
            // 
            // BTN_Reset
            // 
            this.BTN_Reset.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Reset.Location = new System.Drawing.Point(371, 9);
            this.BTN_Reset.Name = "BTN_Reset";
            this.BTN_Reset.Size = new System.Drawing.Size(144, 55);
            this.BTN_Reset.TabIndex = 18;
            this.BTN_Reset.Text = "Reset";
            this.BTN_Reset.UseVisualStyleBackColor = true;
            this.BTN_Reset.Click += new System.EventHandler(this.BTN_Reset_Click);
            // 
            // Text_Off_T
            // 
            this.Text_Off_T.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_Off_T.Location = new System.Drawing.Point(815, 335);
            this.Text_Off_T.Name = "Text_Off_T";
            this.Text_Off_T.Size = new System.Drawing.Size(152, 38);
            this.Text_Off_T.TabIndex = 17;
            this.Text_Off_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Text_On_T
            // 
            this.Text_On_T.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_On_T.Location = new System.Drawing.Point(815, 283);
            this.Text_On_T.Name = "Text_On_T";
            this.Text_On_T.Size = new System.Drawing.Size(152, 38);
            this.Text_On_T.TabIndex = 16;
            this.Text_On_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Text_Duty
            // 
            this.Text_Duty.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_Duty.Location = new System.Drawing.Point(815, 231);
            this.Text_Duty.Name = "Text_Duty";
            this.Text_Duty.Size = new System.Drawing.Size(152, 38);
            this.Text_Duty.TabIndex = 15;
            this.Text_Duty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Text_Freq
            // 
            this.Text_Freq.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_Freq.Location = new System.Drawing.Point(815, 178);
            this.Text_Freq.Name = "Text_Freq";
            this.Text_Freq.Size = new System.Drawing.Size(152, 38);
            this.Text_Freq.TabIndex = 14;
            this.Text_Freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 85);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(695, 552);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(723, 481);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 38);
            this.label8.TabIndex = 12;
            this.label8.Text = "Samples";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(723, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 38);
            this.label7.TabIndex = 11;
            this.label7.Text = "Freq";
            // 
            // UpDown_Samples
            // 
            this.UpDown_Samples.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpDown_Samples.Location = new System.Drawing.Point(871, 493);
            this.UpDown_Samples.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.UpDown_Samples.Name = "UpDown_Samples";
            this.UpDown_Samples.Size = new System.Drawing.Size(138, 30);
            this.UpDown_Samples.TabIndex = 10;
            this.UpDown_Samples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDown_Samples.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // UpDown_Freq
            // 
            this.UpDown_Freq.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpDown_Freq.Location = new System.Drawing.Point(815, 422);
            this.UpDown_Freq.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.UpDown_Freq.Name = "UpDown_Freq";
            this.UpDown_Freq.Size = new System.Drawing.Size(152, 30);
            this.UpDown_Freq.TabIndex = 9;
            this.UpDown_Freq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDown_Freq.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // Text_Vrms
            // 
            this.Text_Vrms.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Text_Vrms.Location = new System.Drawing.Point(815, 125);
            this.Text_Vrms.Name = "Text_Vrms";
            this.Text_Vrms.Size = new System.Drawing.Size(152, 38);
            this.Text_Vrms.TabIndex = 8;
            this.Text_Vrms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(717, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 38);
            this.label6.TabIndex = 7;
            this.label6.Text = "On_T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(717, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 38);
            this.label5.TabIndex = 6;
            this.label5.Text = "Off_T";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(723, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Duty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(723, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Freq";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(723, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vrms";
            // 
            // BTN_Open
            // 
            this.BTN_Open.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Open.Location = new System.Drawing.Point(541, 9);
            this.BTN_Open.Name = "BTN_Open";
            this.BTN_Open.Size = new System.Drawing.Size(144, 55);
            this.BTN_Open.TabIndex = 1;
            this.BTN_Open.Text = "Open";
            this.BTN_Open.UseVisualStyleBackColor = true;
            this.BTN_Open.Click += new System.EventHandler(this.BTN_Open_Click);
            // 
            // BTN_Start
            // 
            this.BTN_Start.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Start.Location = new System.Drawing.Point(32, 9);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(144, 55);
            this.BTN_Start.TabIndex = 0;
            this.BTN_Start.Text = "Start";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1067, 794);
            this.Controls.Add(this.dockingPannel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Main";
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dockingPannel.ResumeLayout(false);
            this.dockingPannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Samples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Freq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dockingPannel;
        private System.Windows.Forms.TextBox Text_Vrms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_Open;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.TextBox Text_Off_T;
        private System.Windows.Forms.TextBox Text_On_T;
        private System.Windows.Forms.TextBox Text_Duty;
        private System.Windows.Forms.TextBox Text_Freq;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown UpDown_Samples;
        private System.Windows.Forms.NumericUpDown UpDown_Freq;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BTN_Reset;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox Text_Time;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BTN_Data;
    }
}

