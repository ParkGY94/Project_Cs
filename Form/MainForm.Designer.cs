namespace Pressure_Sensor_EOL
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dockingPannel = new System.Windows.Forms.Panel();
            this.BTN_Auto = new System.Windows.Forms.Button();
            this.BTN_Self = new System.Windows.Forms.Button();
            this.BTN_Option = new System.Windows.Forms.Button();
            this.BTN_Spec = new System.Windows.Forms.Button();
            this.BTN_Log = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(247, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1031, 66);
            this.label1.TabIndex = 3;
            this.label1.Text = "압력센서 EOL TESTER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pressure_Sensor_EOL.Properties.Resources.DaeYang_Mark;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(254, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1162, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // dockingPannel
            // 
            this.dockingPannel.BackColor = System.Drawing.Color.LightGray;
            this.dockingPannel.Location = new System.Drawing.Point(-2, 119);
            this.dockingPannel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockingPannel.Name = "dockingPannel";
            this.dockingPannel.Size = new System.Drawing.Size(1280, 1024);
            this.dockingPannel.TabIndex = 5;
            // 
            // BTN_Auto
            // 
            this.BTN_Auto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Auto.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Auto.ForeColor = System.Drawing.Color.White;
            this.BTN_Auto.Location = new System.Drawing.Point(-2, 70);
            this.BTN_Auto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Auto.Name = "BTN_Auto";
            this.BTN_Auto.Size = new System.Drawing.Size(203, 46);
            this.BTN_Auto.TabIndex = 0;
            this.BTN_Auto.Text = "테스트";
            this.BTN_Auto.UseVisualStyleBackColor = false;
            this.BTN_Auto.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_Self
            // 
            this.BTN_Self.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Self.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Self.ForeColor = System.Drawing.Color.White;
            this.BTN_Self.Location = new System.Drawing.Point(206, 70);
            this.BTN_Self.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Self.Name = "BTN_Self";
            this.BTN_Self.Size = new System.Drawing.Size(203, 45);
            this.BTN_Self.TabIndex = 6;
            this.BTN_Self.Text = "셀프";
            this.BTN_Self.UseVisualStyleBackColor = false;
            this.BTN_Self.Click += new System.EventHandler(this.BTN_Manual_Click);
            // 
            // BTN_Option
            // 
            this.BTN_Option.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Option.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Option.ForeColor = System.Drawing.Color.White;
            this.BTN_Option.Location = new System.Drawing.Point(832, 70);
            this.BTN_Option.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Option.Name = "BTN_Option";
            this.BTN_Option.Size = new System.Drawing.Size(203, 46);
            this.BTN_Option.TabIndex = 1;
            this.BTN_Option.Text = "옵션";
            this.BTN_Option.UseVisualStyleBackColor = false;
            this.BTN_Option.Click += new System.EventHandler(this.BTN_Option_Click);
            // 
            // BTN_Spec
            // 
            this.BTN_Spec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Spec.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Spec.ForeColor = System.Drawing.Color.White;
            this.BTN_Spec.Location = new System.Drawing.Point(624, 70);
            this.BTN_Spec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Spec.Name = "BTN_Spec";
            this.BTN_Spec.Size = new System.Drawing.Size(203, 46);
            this.BTN_Spec.TabIndex = 7;
            this.BTN_Spec.Text = "스펙";
            this.BTN_Spec.UseVisualStyleBackColor = false;
            this.BTN_Spec.Click += new System.EventHandler(this.BTN_Spec_Click);
            // 
            // BTN_Log
            // 
            this.BTN_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.BTN_Log.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_Log.ForeColor = System.Drawing.Color.White;
            this.BTN_Log.Location = new System.Drawing.Point(415, 71);
            this.BTN_Log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Log.Name = "BTN_Log";
            this.BTN_Log.Size = new System.Drawing.Size(203, 45);
            this.BTN_Log.TabIndex = 7;
            this.BTN_Log.Text = "로그";
            this.BTN_Log.UseVisualStyleBackColor = false;
            this.BTN_Log.Click += new System.EventHandler(this.BTN_Log_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1271, 1005);
            this.Controls.Add(this.BTN_Log);
            this.Controls.Add(this.BTN_Self);
            this.Controls.Add(this.BTN_Option);
            this.Controls.Add(this.BTN_Auto);
            this.Controls.Add(this.BTN_Spec);
            this.Controls.Add(this.dockingPannel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel dockingPannel;
        private System.Windows.Forms.Button BTN_Auto;
        private System.Windows.Forms.Button BTN_Self;
        private System.Windows.Forms.Button BTN_Option;
        private System.Windows.Forms.Button BTN_Spec;
        private System.Windows.Forms.Button BTN_Log;
    }
}