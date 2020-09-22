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
            this.NIName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HiokiName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_SaveName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NIName
            // 
            this.NIName.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NIName.Location = new System.Drawing.Point(35, 51);
            this.NIName.Name = "NIName";
            this.NIName.Size = new System.Drawing.Size(243, 51);
            this.NIName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(30, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "NI Name";
            // 
            // HiokiName
            // 
            this.HiokiName.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HiokiName.Location = new System.Drawing.Point(337, 51);
            this.HiokiName.Name = "HiokiName";
            this.HiokiName.Size = new System.Drawing.Size(243, 51);
            this.HiokiName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(332, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
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
            this.Controls.Add(this.HiokiName);
            this.Controls.Add(this.NIName);
            this.Controls.Add(this.BTN_SaveName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "OptionForm";
            this.Text = "Option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NIName;
        private System.Windows.Forms.TextBox HiokiName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTN_SaveName;
    }
}