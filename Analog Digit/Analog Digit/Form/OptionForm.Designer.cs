namespace Analog_Digit
{
    partial class OptionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.NIName = new System.Windows.Forms.TextBox();
            this.filepath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.HiokiName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_SaveName = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.NIName);
            this.panel1.Controls.Add(this.filepath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(26, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 98);
            this.panel1.TabIndex = 5;
            // 
            // NIName
            // 
            this.NIName.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NIName.Location = new System.Drawing.Point(8, 33);
            this.NIName.Name = "NIName";
            this.NIName.Size = new System.Drawing.Size(243, 51);
            this.NIName.TabIndex = 3;
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
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "NI Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.HiokiName);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel3.Location = new System.Drawing.Point(326, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 98);
            this.panel3.TabIndex = 6;
            // 
            // HiokiName
            // 
            this.HiokiName.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HiokiName.Location = new System.Drawing.Point(8, 33);
            this.HiokiName.Name = "HiokiName";
            this.HiokiName.Size = new System.Drawing.Size(243, 51);
            this.HiokiName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 38);
            this.label4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "HIOKI PortName";
            // 
            // BTN_SaveName
            // 
            this.BTN_SaveName.Font = new System.Drawing.Font("새굴림", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_SaveName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTN_SaveName.Location = new System.Drawing.Point(374, 458);
            this.BTN_SaveName.Name = "BTN_SaveName";
            this.BTN_SaveName.Size = new System.Drawing.Size(164, 68);
            this.BTN_SaveName.TabIndex = 25;
            this.BTN_SaveName.Text = "저장";
            this.BTN_SaveName.UseVisualStyleBackColor = true;
            this.BTN_SaveName.Click += new System.EventHandler(this.BTN_SaveName_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 576);
            this.Controls.Add(this.BTN_SaveName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "OptionForm";
            this.Text = "Option";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NIName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox HiokiName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_SaveName;
    }
}