namespace Analog_Digit
{
    partial class SelfForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AnalogInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AnalogTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTN_HiokiReset = new System.Windows.Forms.Button();
            this.MeasureMsg = new System.Windows.Forms.TextBox();
            this.BTN_Measure = new System.Windows.Forms.Button();
            this.BTN_Range = new System.Windows.Forms.Button();
            this.UD_Range = new System.Windows.Forms.NumericUpDown();
            this.BTN_AutoOff = new System.Windows.Forms.Button();
            this.BTN_AutoOn = new System.Windows.Forms.Button();
            this.BTN_SendMsg = new System.Windows.Forms.Button();
            this.SendMsg = new System.Windows.Forms.TextBox();
            this.ReadMsg = new System.Windows.Forms.TextBox();
            this.BTN_HiokiDis = new System.Windows.Forms.Button();
            this.BTN_HiokiCon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DigitTimer = new System.Windows.Forms.Timer(this.components);
            this.HIOKI3540 = new System.IO.Ports.SerialPort(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_Segment = new System.Windows.Forms.Button();
            this.BTN_Switch = new System.Windows.Forms.Button();
            this.BTN_Stop = new System.Windows.Forms.Button();
            this.BTN_Start = new System.Windows.Forms.Button();
            this.BTN_Off = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.Switch0 = new Ledbulb.Myledbulb();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.Switch1 = new Ledbulb.Myledbulb();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.Switch2 = new Ledbulb.Myledbulb();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.Switch3 = new Ledbulb.Myledbulb();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Switch4 = new Ledbulb.Myledbulb();
            this.Switch5 = new Ledbulb.Myledbulb();
            this.Switch6 = new Ledbulb.Myledbulb();
            this.Switch7 = new Ledbulb.Myledbulb();
            this.BTN_Update = new System.Windows.Forms.Button();
            this.voltagevalue = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Range)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voltagevalue)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-5, 84);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Voltage";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(609, 374);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 500);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Controls.Add(this.AnalogInput);
            this.groupBox1.Location = new System.Drawing.Point(5, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 467);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Analog Input";
            // 
            // AnalogInput
            // 
            this.AnalogInput.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AnalogInput.Location = new System.Drawing.Point(219, 24);
            this.AnalogInput.Name = "AnalogInput";
            this.AnalogInput.Size = new System.Drawing.Size(361, 43);
            this.AnalogInput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(-1, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Analog";
            // 
            // AnalogTimer
            // 
            this.AnalogTimer.Enabled = true;
            this.AnalogTimer.Tick += new System.EventHandler(this.AnalogTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(636, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 489);
            this.panel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTN_HiokiReset);
            this.groupBox2.Controls.Add(this.MeasureMsg);
            this.groupBox2.Controls.Add(this.BTN_Measure);
            this.groupBox2.Controls.Add(this.BTN_Range);
            this.groupBox2.Controls.Add(this.UD_Range);
            this.groupBox2.Controls.Add(this.BTN_AutoOff);
            this.groupBox2.Controls.Add(this.BTN_AutoOn);
            this.groupBox2.Controls.Add(this.BTN_SendMsg);
            this.groupBox2.Controls.Add(this.SendMsg);
            this.groupBox2.Controls.Add(this.ReadMsg);
            this.groupBox2.Controls.Add(this.BTN_HiokiDis);
            this.groupBox2.Controls.Add(this.BTN_HiokiCon);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 479);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // BTN_HiokiReset
            // 
            this.BTN_HiokiReset.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_HiokiReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_HiokiReset.Location = new System.Drawing.Point(296, 320);
            this.BTN_HiokiReset.Name = "BTN_HiokiReset";
            this.BTN_HiokiReset.Size = new System.Drawing.Size(109, 45);
            this.BTN_HiokiReset.TabIndex = 11;
            this.BTN_HiokiReset.Text = "Reset";
            this.BTN_HiokiReset.UseVisualStyleBackColor = true;
            this.BTN_HiokiReset.Click += new System.EventHandler(this.BTN_HiokiReset_Click);
            // 
            // MeasureMsg
            // 
            this.MeasureMsg.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MeasureMsg.Location = new System.Drawing.Point(24, 421);
            this.MeasureMsg.Name = "MeasureMsg";
            this.MeasureMsg.Size = new System.Drawing.Size(189, 51);
            this.MeasureMsg.TabIndex = 10;
            // 
            // BTN_Measure
            // 
            this.BTN_Measure.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Measure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Measure.Location = new System.Drawing.Point(246, 426);
            this.BTN_Measure.Name = "BTN_Measure";
            this.BTN_Measure.Size = new System.Drawing.Size(157, 49);
            this.BTN_Measure.TabIndex = 9;
            this.BTN_Measure.Text = "Measure";
            this.BTN_Measure.UseVisualStyleBackColor = true;
            this.BTN_Measure.Click += new System.EventHandler(this.BTN_Measure_Click);
            // 
            // BTN_Range
            // 
            this.BTN_Range.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Range.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Range.Location = new System.Drawing.Point(246, 371);
            this.BTN_Range.Name = "BTN_Range";
            this.BTN_Range.Size = new System.Drawing.Size(157, 49);
            this.BTN_Range.TabIndex = 8;
            this.BTN_Range.Text = "Range";
            this.BTN_Range.UseVisualStyleBackColor = true;
            this.BTN_Range.Click += new System.EventHandler(this.BTN_Range_Click);
            // 
            // UD_Range
            // 
            this.UD_Range.Location = new System.Drawing.Point(24, 382);
            this.UD_Range.Name = "UD_Range";
            this.UD_Range.Size = new System.Drawing.Size(190, 25);
            this.UD_Range.TabIndex = 7;
            this.UD_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BTN_AutoOff
            // 
            this.BTN_AutoOff.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AutoOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_AutoOff.Location = new System.Drawing.Point(163, 320);
            this.BTN_AutoOff.Name = "BTN_AutoOff";
            this.BTN_AutoOff.Size = new System.Drawing.Size(119, 45);
            this.BTN_AutoOff.TabIndex = 6;
            this.BTN_AutoOff.Text = "Auto Off";
            this.BTN_AutoOff.UseVisualStyleBackColor = true;
            this.BTN_AutoOff.Click += new System.EventHandler(this.BTN_AutoOff_Click);
            // 
            // BTN_AutoOn
            // 
            this.BTN_AutoOn.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AutoOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_AutoOn.Location = new System.Drawing.Point(24, 320);
            this.BTN_AutoOn.Name = "BTN_AutoOn";
            this.BTN_AutoOn.Size = new System.Drawing.Size(124, 45);
            this.BTN_AutoOn.TabIndex = 5;
            this.BTN_AutoOn.Text = "Auto On";
            this.BTN_AutoOn.UseVisualStyleBackColor = true;
            this.BTN_AutoOn.Click += new System.EventHandler(this.BTN_AutoOn_Click);
            // 
            // BTN_SendMsg
            // 
            this.BTN_SendMsg.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_SendMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_SendMsg.Location = new System.Drawing.Point(296, 267);
            this.BTN_SendMsg.Name = "BTN_SendMsg";
            this.BTN_SendMsg.Size = new System.Drawing.Size(108, 47);
            this.BTN_SendMsg.TabIndex = 4;
            this.BTN_SendMsg.Text = "Send";
            this.BTN_SendMsg.UseVisualStyleBackColor = true;
            this.BTN_SendMsg.Click += new System.EventHandler(this.BTN_SendMsg_Click);
            // 
            // SendMsg
            // 
            this.SendMsg.Location = new System.Drawing.Point(24, 276);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(258, 25);
            this.SendMsg.TabIndex = 3;
            this.SendMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ReadMsg
            // 
            this.ReadMsg.Font = new System.Drawing.Font("돋움체", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ReadMsg.Location = new System.Drawing.Point(25, 84);
            this.ReadMsg.Multiline = true;
            this.ReadMsg.Name = "ReadMsg";
            this.ReadMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReadMsg.Size = new System.Drawing.Size(379, 168);
            this.ReadMsg.TabIndex = 2;
            // 
            // BTN_HiokiDis
            // 
            this.BTN_HiokiDis.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_HiokiDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_HiokiDis.Location = new System.Drawing.Point(225, 22);
            this.BTN_HiokiDis.Name = "BTN_HiokiDis";
            this.BTN_HiokiDis.Size = new System.Drawing.Size(180, 45);
            this.BTN_HiokiDis.TabIndex = 1;
            this.BTN_HiokiDis.Text = "Disconnect";
            this.BTN_HiokiDis.UseVisualStyleBackColor = true;
            this.BTN_HiokiDis.Click += new System.EventHandler(this.BTN_HiokiDis_Click);
            // 
            // BTN_HiokiCon
            // 
            this.BTN_HiokiCon.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_HiokiCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_HiokiCon.Location = new System.Drawing.Point(25, 22);
            this.BTN_HiokiCon.Name = "BTN_HiokiCon";
            this.BTN_HiokiCon.Size = new System.Drawing.Size(180, 45);
            this.BTN_HiokiCon.TabIndex = 0;
            this.BTN_HiokiCon.Text = "Connect";
            this.BTN_HiokiCon.UseVisualStyleBackColor = true;
            this.BTN_HiokiCon.Click += new System.EventHandler(this.BTN_HiokiCon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(642, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "HIOKI 3540";
            // 
            // DigitTimer
            // 
            this.DigitTimer.Enabled = true;
            this.DigitTimer.Tick += new System.EventHandler(this.DigitTimer_Tick);
            // 
            // HIOKI3540
            // 
            this.HIOKI3540.PortName = "COM3";
            this.HIOKI3540.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.HIOKI3540_DataReceived);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BTN_Segment);
            this.panel3.Controls.Add(this.BTN_Switch);
            this.panel3.Controls.Add(this.BTN_Stop);
            this.panel3.Controls.Add(this.BTN_Start);
            this.panel3.Controls.Add(this.BTN_Off);
            this.panel3.Controls.Add(this.button10);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Location = new System.Drawing.Point(14, 518);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(583, 377);
            this.panel3.TabIndex = 5;
            // 
            // BTN_Segment
            // 
            this.BTN_Segment.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Segment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Segment.Location = new System.Drawing.Point(178, 312);
            this.BTN_Segment.Name = "BTN_Segment";
            this.BTN_Segment.Size = new System.Drawing.Size(152, 47);
            this.BTN_Segment.TabIndex = 38;
            this.BTN_Segment.Text = "Seg Setting";
            this.BTN_Segment.UseVisualStyleBackColor = true;
            this.BTN_Segment.Click += new System.EventHandler(this.BTN_Segment_Click);
            // 
            // BTN_Switch
            // 
            this.BTN_Switch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Switch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Switch.Location = new System.Drawing.Point(5, 312);
            this.BTN_Switch.Name = "BTN_Switch";
            this.BTN_Switch.Size = new System.Drawing.Size(152, 47);
            this.BTN_Switch.TabIndex = 39;
            this.BTN_Switch.Text = "Input";
            this.BTN_Switch.UseVisualStyleBackColor = true;
            this.BTN_Switch.Click += new System.EventHandler(this.BTN_Switch_Click);
            // 
            // BTN_Stop
            // 
            this.BTN_Stop.Enabled = false;
            this.BTN_Stop.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Stop.Location = new System.Drawing.Point(178, 255);
            this.BTN_Stop.Name = "BTN_Stop";
            this.BTN_Stop.Size = new System.Drawing.Size(152, 47);
            this.BTN_Stop.TabIndex = 38;
            this.BTN_Stop.Text = "Stop";
            this.BTN_Stop.UseVisualStyleBackColor = true;
            this.BTN_Stop.Click += new System.EventHandler(this.BTN_Stop_Click);
            // 
            // BTN_Start
            // 
            this.BTN_Start.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Start.Location = new System.Drawing.Point(5, 255);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(152, 47);
            this.BTN_Start.TabIndex = 37;
            this.BTN_Start.Text = "Start";
            this.BTN_Start.UseVisualStyleBackColor = true;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_Start_Click);
            // 
            // BTN_Off
            // 
            this.BTN_Off.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Off.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Off.Location = new System.Drawing.Point(499, 248);
            this.BTN_Off.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Off.Name = "BTN_Off";
            this.BTN_Off.Size = new System.Drawing.Size(72, 62);
            this.BTN_Off.TabIndex = 34;
            this.BTN_Off.Tag = "00";
            this.BTN_Off.Text = "Off";
            this.BTN_Off.UseVisualStyleBackColor = true;
            this.BTN_Off.Click += new System.EventHandler(this.BTN_Off_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button10.Location = new System.Drawing.Point(420, 248);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 62);
            this.button10.TabIndex = 33;
            this.button10.Tag = "0";
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Digital";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(341, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 62);
            this.button1.TabIndex = 24;
            this.button1.Tag = "1";
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.Location = new System.Drawing.Point(499, 178);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(72, 62);
            this.button9.TabIndex = 32;
            this.button9.Tag = "9";
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(420, 38);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 62);
            this.button2.TabIndex = 25;
            this.button2.Tag = "2";
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button8.Location = new System.Drawing.Point(420, 178);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 62);
            this.button8.TabIndex = 31;
            this.button8.Tag = "8";
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(499, 38);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 62);
            this.button3.TabIndex = 26;
            this.button3.Tag = "3";
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.Location = new System.Drawing.Point(341, 178);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 62);
            this.button7.TabIndex = 30;
            this.button7.Tag = "7";
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(341, 108);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 62);
            this.button4.TabIndex = 27;
            this.button4.Tag = "4";
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button6.Location = new System.Drawing.Point(499, 108);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 62);
            this.button6.TabIndex = 29;
            this.button6.Tag = "6";
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(420, 108);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 62);
            this.button5.TabIndex = 28;
            this.button5.Tag = "5";
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonNum_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.checkBox11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.checkBox10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.checkBox9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.checkBox8);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.checkBox7);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.checkBox5);
            this.groupBox3.Controls.Add(this.Switch0);
            this.groupBox3.Controls.Add(this.checkBox4);
            this.groupBox3.Controls.Add(this.Switch1);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.Switch2);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.Switch3);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.Switch4);
            this.groupBox3.Controls.Add(this.Switch5);
            this.groupBox3.Controls.Add(this.Switch6);
            this.groupBox3.Controls.Add(this.Switch7);
            this.groupBox3.Location = new System.Drawing.Point(5, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 216);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(17, 191);
            this.checkBox12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(37, 19);
            this.checkBox12.TabIndex = 27;
            this.checkBox12.Tag = "3";
            this.checkBox12.Text = "3";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(283, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 25);
            this.label10.TabIndex = 45;
            this.label10.Text = "0";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(56, 191);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(37, 19);
            this.checkBox11.TabIndex = 26;
            this.checkBox11.Tag = "2";
            this.checkBox11.Text = "2";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(244, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 25);
            this.label9.TabIndex = 44;
            this.label9.Text = "1";
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(95, 191);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(37, 19);
            this.checkBox10.TabIndex = 25;
            this.checkBox10.Tag = "1";
            this.checkBox10.Text = "1";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(205, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 25);
            this.label8.TabIndex = 43;
            this.label8.Text = "2";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(132, 191);
            this.checkBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(37, 19);
            this.checkBox9.TabIndex = 24;
            this.checkBox9.Tag = "0";
            this.checkBox9.Text = "0";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(166, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 25);
            this.label7.TabIndex = 42;
            this.label7.Text = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(9, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 28);
            this.label13.TabIndex = 23;
            this.label13.Text = "Port1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(127, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 41;
            this.label6.Text = "4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(9, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 28);
            this.label14.TabIndex = 22;
            this.label14.Text = "Port0";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(15, 125);
            this.checkBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(37, 19);
            this.checkBox8.TabIndex = 21;
            this.checkBox8.Tag = "7";
            this.checkBox8.Text = "7";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(89, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 25);
            this.label4.TabIndex = 40;
            this.label4.Text = "5";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(52, 125);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(37, 19);
            this.checkBox7.TabIndex = 20;
            this.checkBox7.Tag = "6";
            this.checkBox7.Text = "6";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(50, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 25);
            this.label11.TabIndex = 39;
            this.label11.Text = "6";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(89, 125);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(37, 19);
            this.checkBox6.TabIndex = 19;
            this.checkBox6.Tag = "5";
            this.checkBox6.Text = "5";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(13, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 25);
            this.label12.TabIndex = 38;
            this.label12.Text = "7";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(126, 125);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(37, 19);
            this.checkBox5.TabIndex = 18;
            this.checkBox5.Tag = "4";
            this.checkBox5.Text = "4";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Switch0
            // 
            this.Switch0.DrawRectangle = false;
            this.Switch0.Location = new System.Drawing.Point(282, 25);
            this.Switch0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch0.Name = "Switch0";
            this.Switch0.On = true;
            this.Switch0.Size = new System.Drawing.Size(32, 24);
            this.Switch0.TabIndex = 37;
            this.Switch0.TextX = 0F;
            this.Switch0.TextY = 0F;
            this.Switch0.UserText = null;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(163, 125);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(37, 19);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.Tag = "3";
            this.checkBox4.Text = "3";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Switch1
            // 
            this.Switch1.DrawRectangle = false;
            this.Switch1.Location = new System.Drawing.Point(243, 25);
            this.Switch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch1.Name = "Switch1";
            this.Switch1.On = true;
            this.Switch1.Size = new System.Drawing.Size(32, 24);
            this.Switch1.TabIndex = 36;
            this.Switch1.TextX = 0F;
            this.Switch1.TextY = 0F;
            this.Switch1.UserText = null;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(200, 125);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(37, 19);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Tag = "2";
            this.checkBox3.Text = "2";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Switch2
            // 
            this.Switch2.DrawRectangle = false;
            this.Switch2.Location = new System.Drawing.Point(204, 25);
            this.Switch2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch2.Name = "Switch2";
            this.Switch2.On = true;
            this.Switch2.Size = new System.Drawing.Size(32, 24);
            this.Switch2.TabIndex = 35;
            this.Switch2.TextX = 0F;
            this.Switch2.TextY = 0F;
            this.Switch2.UserText = null;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(238, 125);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(37, 19);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Tag = "1";
            this.checkBox2.Text = "1";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Switch3
            // 
            this.Switch3.DrawRectangle = false;
            this.Switch3.Location = new System.Drawing.Point(165, 25);
            this.Switch3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch3.Name = "Switch3";
            this.Switch3.On = true;
            this.Switch3.Size = new System.Drawing.Size(32, 24);
            this.Switch3.TabIndex = 34;
            this.Switch3.TextX = 0F;
            this.Switch3.TextY = 0F;
            this.Switch3.UserText = null;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(277, 125);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(37, 19);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Tag = "0";
            this.checkBox1.Text = "0";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Switch4
            // 
            this.Switch4.DrawRectangle = false;
            this.Switch4.Location = new System.Drawing.Point(126, 25);
            this.Switch4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch4.Name = "Switch4";
            this.Switch4.On = true;
            this.Switch4.Size = new System.Drawing.Size(32, 24);
            this.Switch4.TabIndex = 33;
            this.Switch4.TextX = 0F;
            this.Switch4.TextY = 0F;
            this.Switch4.UserText = null;
            // 
            // Switch5
            // 
            this.Switch5.DrawRectangle = false;
            this.Switch5.Location = new System.Drawing.Point(89, 25);
            this.Switch5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch5.Name = "Switch5";
            this.Switch5.On = true;
            this.Switch5.Size = new System.Drawing.Size(32, 24);
            this.Switch5.TabIndex = 32;
            this.Switch5.TextX = 0F;
            this.Switch5.TextY = 0F;
            this.Switch5.UserText = null;
            // 
            // Switch6
            // 
            this.Switch6.DrawRectangle = false;
            this.Switch6.Location = new System.Drawing.Point(49, 25);
            this.Switch6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch6.Name = "Switch6";
            this.Switch6.On = true;
            this.Switch6.Size = new System.Drawing.Size(32, 24);
            this.Switch6.TabIndex = 31;
            this.Switch6.TextX = 0F;
            this.Switch6.TextY = 0F;
            this.Switch6.UserText = null;
            // 
            // Switch7
            // 
            this.Switch7.DrawRectangle = false;
            this.Switch7.Location = new System.Drawing.Point(12, 25);
            this.Switch7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Switch7.Name = "Switch7";
            this.Switch7.On = true;
            this.Switch7.Size = new System.Drawing.Size(32, 24);
            this.Switch7.TabIndex = 30;
            this.Switch7.TextX = 0F;
            this.Switch7.TextY = 0F;
            this.Switch7.UserText = null;
            // 
            // BTN_Update
            // 
            this.BTN_Update.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_Update.Location = new System.Drawing.Point(883, 52);
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.Size = new System.Drawing.Size(159, 52);
            this.BTN_Update.TabIndex = 11;
            this.BTN_Update.Text = "Update";
            this.BTN_Update.UseVisualStyleBackColor = true;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click_1);
            // 
            // voltagevalue
            // 
            this.voltagevalue.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.voltagevalue.Location = new System.Drawing.Point(680, 68);
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
            this.voltagevalue.Size = new System.Drawing.Size(170, 28);
            this.voltagevalue.TabIndex = 10;
            this.voltagevalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(657, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(187, 32);
            this.label24.TabIndex = 2;
            this.label24.Text = "Analog Output";
            // 
            // Error
            // 
            this.Error.Enabled = true;
            this.Error.Tick += new System.EventHandler(this.Error_Tick);
            // 
            // SelfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 900);
            this.Controls.Add(this.BTN_Update);
            this.Controls.Add(this.voltagevalue);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SelfForm";
            this.Text = "Manual Test";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Range)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voltagevalue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AnalogInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer AnalogTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTN_HiokiDis;
        private System.Windows.Forms.Button BTN_HiokiCon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ReadMsg;
        private System.Windows.Forms.Timer DigitTimer;
        private System.IO.Ports.SerialPort HIOKI3540;
        private System.Windows.Forms.TextBox MeasureMsg;
        private System.Windows.Forms.Button BTN_Measure;
        private System.Windows.Forms.Button BTN_Range;
        private System.Windows.Forms.NumericUpDown UD_Range;
        private System.Windows.Forms.Button BTN_AutoOff;
        private System.Windows.Forms.Button BTN_AutoOn;
        private System.Windows.Forms.Button BTN_SendMsg;
        private System.Windows.Forms.TextBox SendMsg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Ledbulb.Myledbulb Switch0;
        private Ledbulb.Myledbulb Switch1;
        private Ledbulb.Myledbulb Switch2;
        private Ledbulb.Myledbulb Switch3;
        private Ledbulb.Myledbulb Switch4;
        private Ledbulb.Myledbulb Switch5;
        private Ledbulb.Myledbulb Switch6;
        private Ledbulb.Myledbulb Switch7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_Off;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button BTN_Stop;
        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.Button BTN_Segment;
        private System.Windows.Forms.Button BTN_Switch;
        private System.Windows.Forms.Button BTN_HiokiReset;
        private System.Windows.Forms.Button BTN_Update;
        private System.Windows.Forms.NumericUpDown voltagevalue;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Timer Error;
    }
}