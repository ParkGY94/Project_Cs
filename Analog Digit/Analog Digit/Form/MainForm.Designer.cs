namespace Analog_Digit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTN_SettingForm = new System.Windows.Forms.Button();
            this.BTN_SelfForm = new System.Windows.Forms.Button();
            this.BTN_OptionForm = new System.Windows.Forms.Button();
            this.BTN_LogForm = new System.Windows.Forms.Button();
            this.BTN_AutoForm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dockingPannel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(949, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 67);
            this.label1.TabIndex = 3;
            this.label1.Text = "인턴 프로젝트";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 101);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTN_SettingForm);
            this.panel2.Controls.Add(this.BTN_SelfForm);
            this.panel2.Controls.Add(this.BTN_OptionForm);
            this.panel2.Controls.Add(this.BTN_LogForm);
            this.panel2.Controls.Add(this.BTN_AutoForm);
            this.panel2.Location = new System.Drawing.Point(12, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 92);
            this.panel2.TabIndex = 5;
            // 
            // BTN_SettingForm
            // 
            this.BTN_SettingForm.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_SettingForm.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_SettingForm.ForeColor = System.Drawing.Color.OrangeRed;
            this.BTN_SettingForm.Location = new System.Drawing.Point(516, 12);
            this.BTN_SettingForm.Name = "BTN_SettingForm";
            this.BTN_SettingForm.Size = new System.Drawing.Size(144, 67);
            this.BTN_SettingForm.TabIndex = 5;
            this.BTN_SettingForm.Text = "SETTING";
            this.BTN_SettingForm.UseVisualStyleBackColor = false;
            this.BTN_SettingForm.Click += new System.EventHandler(this.BTN_SettingForm_Click);
            // 
            // BTN_SelfForm
            // 
            this.BTN_SelfForm.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_SelfForm.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_SelfForm.ForeColor = System.Drawing.Color.OrangeRed;
            this.BTN_SelfForm.Location = new System.Drawing.Point(173, 12);
            this.BTN_SelfForm.Name = "BTN_SelfForm";
            this.BTN_SelfForm.Size = new System.Drawing.Size(143, 67);
            this.BTN_SelfForm.TabIndex = 4;
            this.BTN_SelfForm.Text = "SELF";
            this.BTN_SelfForm.UseVisualStyleBackColor = false;
            this.BTN_SelfForm.Click += new System.EventHandler(this.BTN_SelfForm_Click);
            // 
            // BTN_OptionForm
            // 
            this.BTN_OptionForm.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_OptionForm.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_OptionForm.ForeColor = System.Drawing.Color.OrangeRed;
            this.BTN_OptionForm.Location = new System.Drawing.Point(694, 12);
            this.BTN_OptionForm.Name = "BTN_OptionForm";
            this.BTN_OptionForm.Size = new System.Drawing.Size(135, 67);
            this.BTN_OptionForm.TabIndex = 2;
            this.BTN_OptionForm.Text = "Option";
            this.BTN_OptionForm.UseVisualStyleBackColor = false;
            this.BTN_OptionForm.Click += new System.EventHandler(this.BTN_OptionForm_Click);
            // 
            // BTN_LogForm
            // 
            this.BTN_LogForm.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_LogForm.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_LogForm.ForeColor = System.Drawing.Color.OrangeRed;
            this.BTN_LogForm.Location = new System.Drawing.Point(342, 12);
            this.BTN_LogForm.Name = "BTN_LogForm";
            this.BTN_LogForm.Size = new System.Drawing.Size(143, 67);
            this.BTN_LogForm.TabIndex = 1;
            this.BTN_LogForm.Text = "DATA";
            this.BTN_LogForm.UseVisualStyleBackColor = false;
            this.BTN_LogForm.Click += new System.EventHandler(this.BTN_LogForm_Click);
            // 
            // BTN_AutoForm
            // 
            this.BTN_AutoForm.BackColor = System.Drawing.SystemColors.Control;
            this.BTN_AutoForm.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AutoForm.ForeColor = System.Drawing.Color.OrangeRed;
            this.BTN_AutoForm.Location = new System.Drawing.Point(13, 12);
            this.BTN_AutoForm.Name = "BTN_AutoForm";
            this.BTN_AutoForm.Size = new System.Drawing.Size(137, 67);
            this.BTN_AutoForm.TabIndex = 0;
            this.BTN_AutoForm.Text = "AUTO";
            this.BTN_AutoForm.UseVisualStyleBackColor = false;
            this.BTN_AutoForm.Click += new System.EventHandler(this.BTN_AutoForm_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Location = new System.Drawing.Point(12, 229);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1075, 17);
            this.panel3.TabIndex = 6;
            // 
            // dockingPannel
            // 
            this.dockingPannel.Location = new System.Drawing.Point(12, 253);
            this.dockingPannel.Name = "dockingPannel";
            this.dockingPannel.Size = new System.Drawing.Size(1092, 928);
            this.dockingPannel.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1116, 1197);
            this.Controls.Add(this.dockingPannel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTN_AutoForm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTN_LogForm;
        private System.Windows.Forms.Button BTN_SettingForm;
        private System.Windows.Forms.Button BTN_SelfForm;
        private System.Windows.Forms.Button BTN_OptionForm;
        private System.Windows.Forms.Panel dockingPannel;
    }
}

