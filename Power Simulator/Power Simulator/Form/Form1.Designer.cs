namespace Power_Simulator
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_Option = new System.Windows.Forms.Button();
            this.BTN_Self = new System.Windows.Forms.Button();
            this.BTN_Log = new System.Windows.Forms.Button();
            this.BTN_Profile = new System.Windows.Forms.Button();
            this.BTN_Test = new System.Windows.Forms.Button();
            this.DockingPanel = new System.Windows.Forms.Panel();
            this.ODA_ = new System.IO.Ports.SerialPort(this.components);
            this.Sorensen_ = new System.IO.Ports.SerialPort(this.components);
            this.Lamda_ = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(249, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(716, 68);
            this.label1.TabIndex = 1;
            this.label1.Text = "3CH DC POWER SIMULATOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(1176, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 67);
            this.button1.TabIndex = 3;
            this.button1.Text = "종료";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BTN_Option);
            this.panel1.Controls.Add(this.BTN_Self);
            this.panel1.Controls.Add(this.BTN_Log);
            this.panel1.Controls.Add(this.BTN_Profile);
            this.panel1.Controls.Add(this.BTN_Test);
            this.panel1.Location = new System.Drawing.Point(10, 88);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 53);
            this.panel1.TabIndex = 4;
            // 
            // BTN_Option
            // 
            this.BTN_Option.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Option.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Option.ForeColor = System.Drawing.Color.White;
            this.BTN_Option.Location = new System.Drawing.Point(696, 0);
            this.BTN_Option.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Option.Name = "BTN_Option";
            this.BTN_Option.Size = new System.Drawing.Size(169, 50);
            this.BTN_Option.TabIndex = 7;
            this.BTN_Option.Text = "Option";
            this.BTN_Option.UseVisualStyleBackColor = false;
            this.BTN_Option.Click += new System.EventHandler(this.BTN_Option_Click);
            // 
            // BTN_Self
            // 
            this.BTN_Self.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Self.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Self.ForeColor = System.Drawing.Color.White;
            this.BTN_Self.Location = new System.Drawing.Point(174, 0);
            this.BTN_Self.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Self.Name = "BTN_Self";
            this.BTN_Self.Size = new System.Drawing.Size(169, 50);
            this.BTN_Self.TabIndex = 6;
            this.BTN_Self.Text = "Self";
            this.BTN_Self.UseVisualStyleBackColor = false;
            this.BTN_Self.Click += new System.EventHandler(this.BTN_Self_Click);
            // 
            // BTN_Log
            // 
            this.BTN_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Log.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Log.ForeColor = System.Drawing.Color.White;
            this.BTN_Log.Location = new System.Drawing.Point(522, 0);
            this.BTN_Log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Log.Name = "BTN_Log";
            this.BTN_Log.Size = new System.Drawing.Size(169, 50);
            this.BTN_Log.TabIndex = 6;
            this.BTN_Log.Text = "Log";
            this.BTN_Log.UseVisualStyleBackColor = false;
            this.BTN_Log.Click += new System.EventHandler(this.BTN_Log_Click);
            // 
            // BTN_Profile
            // 
            this.BTN_Profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Profile.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Profile.ForeColor = System.Drawing.Color.White;
            this.BTN_Profile.Location = new System.Drawing.Point(348, 0);
            this.BTN_Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Profile.Name = "BTN_Profile";
            this.BTN_Profile.Size = new System.Drawing.Size(169, 50);
            this.BTN_Profile.TabIndex = 6;
            this.BTN_Profile.Text = "Profile";
            this.BTN_Profile.UseVisualStyleBackColor = false;
            this.BTN_Profile.Click += new System.EventHandler(this.BTN_Profile_Click);
            // 
            // BTN_Test
            // 
            this.BTN_Test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Test.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Test.ForeColor = System.Drawing.Color.White;
            this.BTN_Test.Location = new System.Drawing.Point(0, 0);
            this.BTN_Test.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(169, 50);
            this.BTN_Test.TabIndex = 5;
            this.BTN_Test.Text = "Test";
            this.BTN_Test.UseVisualStyleBackColor = false;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
            // 
            // DockingPanel
            // 
            this.DockingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DockingPanel.Location = new System.Drawing.Point(10, 155);
            this.DockingPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DockingPanel.Name = "DockingPanel";
            this.DockingPanel.Size = new System.Drawing.Size(1265, 821);
            this.DockingPanel.TabIndex = 5;
            // 
            // ODA_
            // 
            this.ODA_.PortName = "COM5";
            this.ODA_.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ODA_DataReceived);
            // 
            // Sorensen_
            // 
            this.Sorensen_.PortName = "COM6";
            this.Sorensen_.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Sorensen__DataReceived);
            // 
            // Lamda_
            // 
            this.Lamda_.PortName = "COM3";
            this.Lamda_.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Lamda__DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Power_Simulator.Properties.Resources.ts;
            this.pictureBox2.Location = new System.Drawing.Point(971, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(199, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Power_Simulator.Properties.Resources.원택로고_바탕투명_칼라;
            this.pictureBox1.Location = new System.Drawing.Point(10, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 987);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.DockingPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Mainform";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_Log;
        private System.Windows.Forms.Button BTN_Profile;
        private System.Windows.Forms.Button BTN_Test;
        private System.Windows.Forms.Panel DockingPanel;
        private System.Windows.Forms.Button BTN_Self;
        private System.Windows.Forms.Button BTN_Option;
        private System.IO.Ports.SerialPort ODA_;
        private System.IO.Ports.SerialPort Sorensen_;
        private System.IO.Ports.SerialPort Lamda_;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

